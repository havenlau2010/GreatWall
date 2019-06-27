using GreatWall.Domain.Models;
using Util.Domains.Trees;

namespace GreatWall.Domain.Repositories {
    /// <summary>
    /// 模块仓储
    /// </summary>
    public interface IModuleRepository : ITreeCompactRepository<Module> {
    }
}