using System.Threading.Tasks;
using GreatWall.Domain.Models;
using Util.Domains.Services;

namespace GreatWall.Domain.Services.Abstractions {
    /// <summary>
    /// 模块服务
    /// </summary>
    public interface IModuleManager : IDomainService {
        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="module">模块</param>
        Task CreateAsync( Module module );
    }
}
