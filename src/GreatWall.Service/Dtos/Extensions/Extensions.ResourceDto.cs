using GreatWall.Data.Pos;
using GreatWall.Data.Pos.Models;
using GreatWall.Domain.Models;
using GreatWall.Service.Dtos.Requests;
using Util.Helpers;
using Util.Maps;

namespace GreatWall.Service.Dtos.Extensions {
    /// <summary>
    /// 资源参数扩展
    /// </summary>
    public static class ResourceDtoExtension {
        /// <summary>
        /// 转成模块参数
        /// </summary>
        public static ModuleDto ToModuleDto( this ResourcePo po ) {
            if ( po == null )
                return null;
            var result = po.MapTo<ModuleDto>();
            result.Url = po.Uri;
            var extend = Json.ToObject<ModuleExtend>( po.Extend );
            result.Icon = extend?.Icon;
            result.Expanded = extend?.Expanded;
            if( po.Parent != null )
                result.ParentName = po.Parent.Name;
            if( po.Application != null )
                result.ApplicationName = po.Application.Name;
            return result;
        }

        /// <summary>
        /// 转成模块
        /// </summary> 
        public static Module ToModule( this CreateModuleRequest request ) {
            return request?.MapTo<Module>();
        }
    }
}