using System.Threading.Tasks;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Domain.Services.Abstractions;
using GreatWall.Extensions;
using Microsoft.AspNetCore.Identity;
using Util;
using Util.Domains.Services;
using Util.Exceptions;

namespace GreatWall.Domain.Services.Implements {
    /// <summary>
    /// 角色服务
    /// </summary>
    public abstract class RoleManager : DomainServiceBase, IRoleManager {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="roleManager">Identity角色服务</param>
        /// <param name="repository">角色仓储</param>
        protected RoleManager( RoleManager<Role> roleManager, IRoleRepository repository ) {
            Manager = roleManager;
            Repository = repository;
        }

        /// <summary>
        /// Identity角色服务
        /// </summary>
        private RoleManager<Role> Manager { get; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        private IRoleRepository Repository { get; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        public virtual async Task CreateAsync( Role role ) {
            await ValidateCreate( role );
            role.Init();
            var parent = await Repository.FindAsync( role.ParentId );
            role.InitPath( parent );
            role.SortId = await Repository.GenerateSortIdAsync( role.ParentId );
            var result = await Manager.CreateAsync( role );
            result.ThrowIfError();
        }

        /// <summary>
        /// 创建角色验证
        /// </summary>
        /// <param name="role">角色</param>
        protected virtual async Task ValidateCreate( Role role ) {
            role.CheckNull( nameof( role ) );
            if( await Repository.ExistsAsync( t => t.Code == role.Code ) )
                ThrowDuplicateCodeException( role.Code );
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        protected void ThrowDuplicateCodeException( string code ) {
            throw new Warning( string.Format( GreatWallResource.DuplicateRoleCode, code ) );
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        public async Task UpdateAsync( Role role ) {
            role.CheckNull( nameof( role ) );
            await ValidateUpdate( role );
            role.InitPinYin();
            await Repository.UpdatePathAsync( role );
            var result = await Manager.UpdateAsync( role );
            result.ThrowIfError();
        }

        /// <summary>
        /// 修改角色验证
        /// </summary>
        /// <param name="role">角色</param>
        protected virtual Task ValidateUpdate( Role role ) {
            return Task.CompletedTask;
        }
    }
}
