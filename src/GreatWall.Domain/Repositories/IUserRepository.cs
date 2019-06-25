using GreatWall.Domain.Models;
using Util.Domains.Repositories;

namespace GreatWall.Domain.Repositories {
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : IRepository<User> {
    }
}