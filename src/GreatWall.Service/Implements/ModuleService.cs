using System;
using System.Threading.Tasks;
using GreatWall.Data;
using GreatWall.Domain.Repositories;
using GreatWall.Domain.Services.Abstractions;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos.Extensions;
using GreatWall.Service.Dtos.Requests;
using Util;
using Util.Applications;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : ServiceBase, IModuleService {
        /// <summary>
        /// 初始化模块服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="moduleRepository">模块仓储</param>
        /// <param name="moduleManager">模块服务</param>
        public ModuleService( IGreatWallUnitOfWork unitOfWork, IModuleRepository moduleRepository,IModuleManager moduleManager ) {
            UnitOfWork = unitOfWork;
            ModuleRepository = moduleRepository;
            ModuleManager = moduleManager;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IModuleManager ModuleManager { get; set; }

        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建模块参数</param>
        public async Task<Guid> CreateAsync( CreateModuleRequest request ) {
            request.CheckNull( nameof( request ) );
            var module = request.ToModule();
            await ModuleManager.CreateAsync( module );
            await UnitOfWork.CommitAsync();
            return module.Id;
        }
    }
}