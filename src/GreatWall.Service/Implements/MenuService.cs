using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatWall.Data;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Domain.Services.Abstractions;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Responses;
using Util;
using Util.Applications;
using Util.Maps;
using Util.Security;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class MenuService : ServiceBase, IMenuService {
        /// <summary>
        /// 初始化菜单服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userManager">用户服务</param>
        /// <param name="roleRepository">角色仓储</param>
        /// <param name="moduleRepository">模块仓储</param>
        public MenuService( IGreatWallUnitOfWork unitOfWork, IUserManager userManager,
            IRoleRepository roleRepository,IModuleRepository moduleRepository ) {
            UnitOfWork = unitOfWork;
            UserManager = userManager;
            RoleRepository = roleRepository;
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 用户服务
        /// </summary>
        public IUserManager UserManager { get; set; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }
        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }

        /// <summary>
        /// 获取菜单
        /// </summary>
        public async Task<List<MenuResponse>> GetMenusAsync() {
            var userId = Session.UserId;
            if ( userId.IsEmpty() )
                return new List<MenuResponse>();
            var roleIds = await RoleRepository.GetRoleIdsAsync( userId.ToGuid() );
            var modules = await ModuleRepository.GetModulesAsync( Session.GetApplicationId(), roleIds );
            await AddMissingParents( modules );
            return modules.Select( t => t.MapTo<MenuResponse>() ).ToList();
        }

        /// <summary>
        /// 添加缺失的父节点列表
        /// </summary>
        private async Task AddMissingParents( List<Module> modules ) {
            var parentIds = modules.GetMissingParentIds<Module, Guid, Guid?>();
            var parents = await ModuleRepository.FindByIdsAsync( parentIds.Select( t => t.ToGuid() ) );
            modules.AddRange( parents.Where( t => t.Enabled ) );
        }
    }
}
