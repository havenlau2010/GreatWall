using GreatWall.Data;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Service.Abstractions;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace GreatWall.Service.Implements {
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : DeleteServiceBase<User, UserDto, UserQuery>, IUserService {
        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userRepository">用户仓储</param>
        public UserService( IGreatWallUnitOfWork unitOfWork, IUserRepository userRepository )
            : base( unitOfWork, userRepository ) {
            UserRepository = userRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IGreatWallUnitOfWork GreatWallUnitOfWork { get; set; }
        /// <summary>
        /// 用户仓储
        /// </summary>
        public IUserRepository UserRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<User> CreateQuery( UserQuery param ) {
            return new Query<User>( param );
        }
    }
}