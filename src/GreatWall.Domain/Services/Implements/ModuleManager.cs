using System;
using System.Threading.Tasks;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Domain.Services.Abstractions;
using Util;
using Util.Domains.Services;

namespace GreatWall.Domain.Services.Implements {
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleManager : DomainServiceBase, IModuleManager {
        /// <summary>
        /// 初始化模块服务
        /// </summary>
        /// <param name="moduleRepository">模块仓储</param>
        public ModuleManager( IModuleRepository moduleRepository ) {
            ModuleRepository = moduleRepository;
        }

        /// <summary>
        /// 模块仓储
        /// </summary>
        public IModuleRepository ModuleRepository { get; }

        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="module">模块</param>
        public async Task CreateAsync( Module module ) {
            module.CheckNull( nameof( module ) );
            module.Init();
            var parent = await ModuleRepository.FindAsync( module.ParentId );
            module.InitPath( parent );
            module.SortId = await ModuleRepository.GenerateSortIdAsync( module.ApplicationId.SafeValue(), module.ParentId );
            await ModuleRepository.AddAsync( module );
        }
    }
}
