using System;
using System.Threading.Tasks;
using GreatWall.Domain.Models;
using GreatWall.Domain.Repositories;
using GreatWall.Domain.Services.Implements;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Util.Security.Claims;

namespace GreatWall.Authentications {
    /// <summary>
    /// 获取用户信息服务
    /// </summary>
    public class ProfileService : ProfileService<User> {
        private readonly IUserClaimsPrincipalFactory<User> _claimsFactory;
        private readonly IdentityUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileService{TUser}"/> class.
        /// </summary>
        public ProfileService( IUserClaimsPrincipalFactory<User> claimsFactory, IdentityUserManager userManager,
            IApplicationRepository applicationRepository, IRoleRepository roleRepository ) : base( userManager, claimsFactory ) {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            ApplicationRepository = applicationRepository;
            RoleRepository = roleRepository;
        }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }

        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }

        /// <summary>
        /// This method is called whenever claims about the user are requested (e.g. during token creation or via the userinfo endpoint)
        /// </summary>
        /// <param name="context">The context.</param>
        public override async Task GetProfileDataAsync( ProfileDataRequestContext context ) {
            var sub = context.Subject?.GetSubjectId();
            if( sub == null ) throw new Exception( "No sub claim present" );

            var user = await _userManager.FindByIdAsync( sub );
            if( user == null ) 
                return;
            //await AddApplicationClaims( user, context.Client.ClientId );
            //await AddRoleClaims( user );
            var principal = await _claimsFactory.CreateAsync( user );
            if( principal == null ) throw new Exception( "ClaimsFactory failed to create a principal" );
            //context.AddRequestedClaims( principal.Claims );
            context.IssuedClaims.AddRange( principal.Claims );
            //context.IssuedClaims.AddRange( user.GetClaims() );
        }

        /// <summary>
        /// 添加应用程序声明
        /// </summary>
        private async Task AddApplicationClaims( User user, string applicationCode ) {
            //var application = await ApplicationRepository.GetByCodeAsync( applicationCode );
            //if( application == null )
            //    return;
            //user.AddClaim( ClaimTypes.ApplicationId, application.Id.SafeString() );
            //user.AddClaim( ClaimTypes.ApplicationCode, applicationCode );
            //user.AddClaim( ClaimTypes.ApplicationName, application.Name );
        }

        /// <summary>
        /// 添加角色声明
        /// </summary>
        private async Task AddRoleClaims( User user ) {
            //var roles = await RoleRepository.GetRolesAsync( user.Id );
            //user.AddClaim( ClaimTypes.RoleIds, roles.Select( t => t.Id ).ToList().Join() );
            //user.AddClaim( ClaimTypes.RoleName, roles.Select( t => t.Name ).ToList().Join() );
        }
    }
}
