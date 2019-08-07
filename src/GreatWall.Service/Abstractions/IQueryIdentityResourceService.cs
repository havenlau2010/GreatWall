using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 身份资源查询服务
    /// </summary>
    public interface IQueryIdentityResourceService : IQueryService<IdentityResourceDto, ResourceQuery> {
    }
}