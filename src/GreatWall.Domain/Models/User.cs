using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using GreatWall.Encryptors;
using Util;
using Util.Exceptions;
using Util.Security.Encryptors;
using Util.Validations;

namespace GreatWall.Domain.Models {
    /// <summary>
    /// 用户
    /// </summary>
    public partial class User {
        /// <summary>
        /// 加密器
        /// </summary>
        [NotMapped]
        public IEncryptor Encryptor { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            InitUserName();
        }

        /// <summary>
        /// 初始化用户名
        /// </summary>
        private void InitUserName() {
            if( UserName.IsEmpty() == false )
                return;
            if ( PhoneNumber.IsEmpty() == false ) {
                UserName = PhoneNumber;
                return;
            }
            if( Email.IsEmpty() == false )
                UserName = Email;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public override ValidationResultCollection Validate() {
            if( UserName.IsEmpty() )
                throw new Warning( GreatWallResource.UserNameIsEmpty );
            return base.Validate();
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        public void SetPassword( string password, bool? storeOriginalPassword ) {
            if( storeOriginalPassword.SafeValue() ) {
                Password = GetEncryptor().Encrypt( password );
                return;
            }
            Password = null;
        }

        /// <summary>
        /// 获取加密器
        /// </summary>
        protected virtual IEncryptor GetEncryptor() {
            return Encryptor ?? new PasswordEncryptor();
        }

        /// <summary>
        /// 设置安全码
        /// </summary>
        /// <param name="password">安全码</param>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        public void SetSafePassword( string password, bool? storeOriginalPassword ) {
            if( storeOriginalPassword.SafeValue() ) {
                SafePassword = GetEncryptor().Encrypt( password );
                return;
            }
            SafePassword = null;
        }

        /// <summary>
        /// 获取密码
        /// </summary>
        public string GetPassword() {
            return GetEncryptor().Decrypt( Password );
        }

        /// <summary>
        /// 获取安全码
        /// </summary>
        public string GetSafePassword() {
            return GetEncryptor().Decrypt( SafePassword );
        }

        /// <summary>
        /// 获取声明列表
        /// </summary>
        public virtual List<Claim> GetClaims() {
            return _claims;
        }

        /// <summary>
        /// 添加声明
        /// </summary>
        /// <param name="claim">声明</param>
        public void AddClaim( Claim claim ) {
            if( claim == null )
                return;
            if( claim.Value.IsEmpty() )
                return;
            if( _claims.Exists( t => t.Type.SafeString().ToLower() == claim.Type.SafeString().ToLower() ) )
                return;
            _claims.Add( claim );
        }

        /// <summary>
        /// 添加声明
        /// </summary>
        /// <param name="type">声明类型</param>
        /// <param name="value">值</param>
        public void AddClaim( string type, string value ) {
            if( type.IsEmpty() || value.IsEmpty() )
                return;
            AddClaim( new Claim( type, value ) );
        }

        /// <summary>
        /// 添加用户声明
        /// </summary>
        public virtual void AddUserClaims() {
            AddClaim( Util.Security.Claims.ClaimTypes.Mobile, PhoneNumber );
            AddClaim( Util.Security.Claims.ClaimTypes.Email, Email );
        }
    }
}