using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LuciusLiang.SSO.UnitTest
{
    public class SSOUnitTest
    {
        [Fact]
        public async void Test1()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }

            Assert.False(disco.IsError);

            var tokenClient = new TokenClient(disco.TokenEndpoint, "MyShopApi.ClientId", "MyShopApi.Secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("MyShopApi");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Assert.False(tokenResponse.IsError);

            Console.WriteLine(tokenResponse.Json);

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5010/api/business/Inventory");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Assert.True(response.IsSuccessStatusCode);

        }
    }

}
