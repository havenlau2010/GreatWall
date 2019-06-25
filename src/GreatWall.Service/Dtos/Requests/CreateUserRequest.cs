using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;

namespace GreatWall.Service.Dtos.Requests {
    /// <summary>
    /// 创建用户请求参数
    /// </summary>
    public class CreateUserRequest : RequestBase {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "用户名" )]
        public string UserName { get; set; }
        /// <summary>
        /// 安全邮箱
        /// </summary>
        [StringLength( 256 )]
        [EmailAddress]
        [Display( Name = "邮箱" )]
        public string Email { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        [StringLength( 64, ErrorMessage = "安全手机输入过长，不能超过64位" )]
        [Phone]
        [Display( Name = "手机" )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required( ErrorMessage = "密码不能为空" )]
        [StringLength( 256 )]
        [DataType( DataType.Password )]
        [Display( Name = "密码" )]
        public string Password { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Remark { get; set; }
    }
}
