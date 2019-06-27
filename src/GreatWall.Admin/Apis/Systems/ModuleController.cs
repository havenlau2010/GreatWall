using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 模块控制器
    /// </summary>
    public class ModuleController : QueryControllerBase<ModuleDto, ResourceQuery> {
        /// <summary>
        /// 初始化模块控制器
        /// </summary>
        /// <param name="service">模块服务</param>
        public ModuleController( IModuleService service ) : base( service ) {
            ModuleService = service;
        }

        /// <summary>
        /// 模块服务
        /// </summary>
        public IModuleService ModuleService { get; }
    }
}