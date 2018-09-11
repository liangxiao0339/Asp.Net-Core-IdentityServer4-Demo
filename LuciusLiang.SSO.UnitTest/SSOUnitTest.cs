using IdentityModel.Client;
using LuciusLiang.MyShops.DataModel.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LuciusLiang.SSO.UnitTest
{
    public class SSOUnitTest
    {
        [Fact]
        public async void InfrastructureApiAuthorization()
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

        [Fact]
        public void TestReflection()
        {
            Stopwatch stop = new Stopwatch();
            stop.Start();

            for (int i = 0; i < 100000; i++)
            {
                var queryProperty = typeof(SidebarMenuDTO).GetProperties();
            }

            stop.Stop();

            Console.WriteLine(stop.ElapsedMilliseconds);
        }
    }

}
