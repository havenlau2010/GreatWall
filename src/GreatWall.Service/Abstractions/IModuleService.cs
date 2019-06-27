using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications.Trees;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 模块服务
    /// </summary>
    public interface IModuleService : ITreeService<ModuleDto, ResourceQuery> {
    }
}