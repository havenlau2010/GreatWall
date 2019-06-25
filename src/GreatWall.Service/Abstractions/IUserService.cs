using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService : IDeleteService<UserDto, UserQuery> {
    }
}