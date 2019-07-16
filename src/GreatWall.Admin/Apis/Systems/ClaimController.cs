using GreatWall.Service.Abstractions;
using Util.Webs.Controllers;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 声明控制器
    /// </summary>
    public class ClaimController : CrudControllerBase<ClaimDto, ClaimQuery> {
        /// <summary>
        /// 初始化声明控制器
        /// </summary>
        /// <param name="service">声明服务</param>
        public ClaimController( IClaimService service ) : base( service ) {
            ClaimService = service;
        }
        
        /// <summary>
        /// 声明服务
        /// </summary>
        public IClaimService ClaimService { get; }
    }
}