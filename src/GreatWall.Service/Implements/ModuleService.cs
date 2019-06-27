using GreatWall.Data;
using GreatWall.Data.Pos;
using GreatWall.Data.Stores.Abstractions;
using GreatWall.Domain.Repositories;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications.Trees;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 模块服务
    /// </summary>
    public class ModuleService : TreeServiceBase<ResourcePo, ModuleDto, ResourceQuery>, IModuleService {
        /// <summary>
        /// 初始化模块服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="moduleRepository">模块仓储</param>
        public ModuleService( IGreatWallUnitOfWork unitOfWork, IResourcePoStore resourceStore, IModuleRepository moduleRepository )
            : base( unitOfWork, resourceStore ) {
     
        }
        
        /// <summary>
        /// 资源仓储
        /// </summary>
        public IModuleRepository ResourceRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ResourcePo> CreateQuery( ResourceQuery param ) {
            return new Query<ResourcePo>( param );
        }
    }
}