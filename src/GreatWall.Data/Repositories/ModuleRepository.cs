using GreatWall.Data.Pos;
using GreatWall.Data.Pos.Extensions;
using GreatWall.Data.Stores.Abstractions;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Repositories {
    /// <summary>
    /// 模块仓储
    /// </summary>
    public class ModuleRepository : TreeCompactRepositoryBase<Module, ResourcePo>, IModuleRepository {
        /// <summary>
        /// 资源存储器
        /// </summary>
        private readonly IResourcePoStore _store;

        /// <summary>
        /// 初始化模块仓储
        /// </summary>
        /// <param name="store">资源存储器</param>
        public ModuleRepository( IResourcePoStore store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected override Module ToEntity( ResourcePo po ) {
            return po.ToModule();
        }

        /// <summary>
        /// 转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourcePo ToPo( Module entity ) {
            return entity.ToPo();
        }
    }
}