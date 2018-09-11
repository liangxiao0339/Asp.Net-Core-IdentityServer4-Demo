using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using LuciusLiang.MyShops.DataModel.Account;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LuciusLiang.SSO.Account.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        /// <summary>
        /// 登陆用户并获取授权 access_token
        /// </summary>
        /// <param name="loginDTO">登陆模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Newtonsoft.Json.Linq.JObject>> Post([FromBody]AuthorizationLoginDTO loginDTO)
        {
            // TODO: 需要验证账户密码的正确性

            var discovery = await DiscoveryClient.GetAsync("http://localhost:5000");

            if (discovery.IsError)
            {
                throw new HttpRequestException($"请求授权服务器错误：{discovery.Error}");
            }

            // TODO: 需要从配置重读取密钥以及 ApiResource 名称，如果密钥不同的话
            var tokenClient = new TokenClient(discovery.TokenEndpoint, loginDTO.ClientId, "MyShopApi.Secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("MyShopApi");

            if (tokenResponse.IsError)
            {
                throw tokenResponse.Exception;
            }

            Console.WriteLine(tokenResponse.Json);

            return tokenResponse.Json;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<Newtonsoft.Json.Linq.JObject>> Login([FromBody]AuthorizationLoginDTO loginDTO)
        {
            // TODO: 需要验证账户密码的正确性

            var discovery = await DiscoveryClient.GetAsync("http://localhost:5000");

            if (discovery.IsError)
            {
                throw new HttpRequestException($"请求授权服务器错误：{discovery.Error}");
            }

            // TODO: 需要从配置重读取密钥以及 ApiResource 名称，如果密钥不同的话
            var tokenClient = new TokenClient(discovery.TokenEndpoint, loginDTO.ClientId, "MyShopApi.Secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("MyShopApi");

            if (tokenResponse.IsError)
            {
                throw tokenResponse.Exception;
            }

            Console.WriteLine(tokenResponse.Json);

            return tokenResponse.Json;
        }
    }
}
