using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications.Trees;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : ITreeService<RoleDto, RoleQuery> {
    }
}