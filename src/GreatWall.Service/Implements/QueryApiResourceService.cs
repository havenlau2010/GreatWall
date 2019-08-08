using GreatWall.Data.Pos;
using GreatWall.Data.Stores.Abstractions;
using GreatWall.Domain.Enums;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Dtos.Extensions;
using GreatWall.Service.Queries;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// Api资源查询服务
    /// </summary>
    public class QueryApiResourceService : QueryServiceBase<ResourcePo, ApiResourceDto, ResourceQuery>, IQueryApiResourceService {
        /// <summary>
        /// 初始化Api资源服务
        /// </summary>
        /// <param name="resourceStore">资源存储器</param>
        public QueryApiResourceService( IResourcePoStore resourceStore )
            : base( resourceStore ) {
            ResourceStore = resourceStore;
        }
        
        /// <summary>
        /// 资源存储器
        /// </summary>
        public IResourcePoStore ResourceStore { get; set; }

        /// <summary>
        /// 转成Api资源参数
        /// </summary>
        protected override ApiResourceDto ToDto( ResourcePo po ) {
            return po.ToApiResourceDto();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<ResourcePo> CreateQuery( ResourceQuery param ) {
            return new Query<ResourcePo>( param )
                .Where( t => t.Type == ResourceType.Api )
                .WhereIfNotEmpty( t => t.Uri.Contains( param.Uri ) )
                .WhereIfNotEmpty( t => t.Name.Contains( param.Name ) );
        }
    }
}