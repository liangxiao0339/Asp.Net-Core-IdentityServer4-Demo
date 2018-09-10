using System;
using System.Collections.Generic;
using System.Text;

namespace LuciusLiang.MyShops.DataModel.Account
{
    /// <summary>
    /// 账户登陆模型
    /// </summary>
    public class AuthorizationLoginDTO
    {
        /// <summary>
        /// IdentityServer4 ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 客户端密钥
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// 授权类型
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
