using System.Threading.Tasks;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Systems {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class ApplicationController : QueryControllerBase<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        public ApplicationController( IQueryApplicationService service ) : base( service ) {
            QueryService = service;
        }

        /// <summary>
        /// 应用程序服务
        /// </summary>
        public IQueryApplicationService QueryService { get; }

        /// <summary>
        /// 获取全部应用程序
        /// </summary>
        [HttpGet( "all" )]
        public async Task<IActionResult> GetAllAsync() {
            var result = await QueryService.GetAllAsync();
            return Success( result );
        }
    }
}