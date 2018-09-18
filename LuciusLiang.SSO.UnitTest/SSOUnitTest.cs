using AspectCore.Extensions.Reflection;
using IdentityModel.Client;
using LuciusLiang.MyShops.DataModel.Business;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
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

            var response = await client.GetAsync("http://localhost:5010/api/inventory/InventoryDetails");
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
        public async void RedisTimeout()
        {
            ConfigurationOptions options = ConfigurationOptions.Parse("192.168.0.105:6379,password=123qwe");

            try
            {
                using (var connection = await ConnectionMultiplexer.ConnectAsync(options))
                {
                    var db = connection.GetDatabase(0);
                    var swAll = Stopwatch.StartNew();

                    for (int i = 0; i < 10000; i++)
                    {
                        var value = await db.StringGetAsync("aaa" + i);
                    }

                    swAll.Stop();

                    Trace.WriteLine($"��ѭ����ʱ{swAll.ElapsedMilliseconds}���룬�߳�{ Environment.CurrentManagedThreadId }");

                    swAll.Restart();

                    Parallel.For(0, 10000,async t => 
                    {
                        var value = await db.StringGetAsync("aaa" + t);
                    });

                    swAll.Stop();

                    Trace.WriteLine($"������ʱ{swAll.ElapsedMilliseconds}���룬�߳�{ Environment.CurrentManagedThreadId }");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Trace.WriteLine("�����");
        }

        [Fact]
        public void Reflector()
        {
            var lstInventory = new List<InventoryDTO>();

            for (int index = 0; index < 100000; index++)
            {
                var inventory = new InventoryDTO()
                {
                    Id = index,
                    ProductName = "��Ʒ" + index,
                    Unit = "��λ" + index,
                    WarehousePosition = "�ֿ�λ��" + index,
                    InboundAmount = index * 11,
                    OutboundAmount = index * 22,
                    InventoryAmount = index * 100,
                    LastUpdateTime = DateTime.Now,
                    Remarik = "��ע" + index
                };

                lstInventory.Add(inventory);
            }

            var stopWatch = Stopwatch.StartNew();

            foreach (var itemInventory in lstInventory)
            {
                var redisKey = GenerateCacheKey(itemInventory);
            }

            stopWatch.Stop();

            Trace.WriteLine($"ִ��ʱ�䣺{ stopWatch.ElapsedMilliseconds } ����");

            stopWatch.Restart();

            foreach (var itemInventory in lstInventory)
            {
                var redisKey = ReflectorGenerateCacheKey(itemInventory);
            }

            stopWatch.Stop();

            Trace.WriteLine($"ִ��ʱ��ԭ����{ stopWatch.ElapsedMilliseconds } ����");
        }

        public string GenerateCacheKey<T>(T source) where T : new()
        {
            var typeReflector = typeof(InventoryDTO).GetReflector();
            var classRedisKey = typeReflector.GetCustomAttribute<CacheKeyAttribute>();

            var propertys = (from t in typeof(InventoryDTO).GetProperties()
                             where Attribute.IsDefined(t, typeof(CacheKeyAttribute))
                             select t).ToList();

            string propertyKey = string.Empty;
            foreach (var item in propertys)
            {
                var propertyReflector = item.GetReflector();

                var propertyValue = propertyReflector.GetValue(source);
                var keyName = item.GetCustomAttribute<CacheKeyAttribute>().KeyName;

                propertyKey += $"{keyName}:{propertyValue}";
            }

            var redisKey = $"{classRedisKey.KeyName}_{propertyKey}";

            return redisKey;
        }

        public string ReflectorGenerateCacheKey<T>(T source) where T : new()
        {
            var typeReflector = typeof(InventoryDTO);
            var classRedisKey = (typeReflector.GetCustomAttributes(typeof(CacheKeyAttribute), false).FirstOrDefault() as CacheKeyAttribute);

            var propertys = (from t in typeof(InventoryDTO).GetProperties()
                             where Attribute.IsDefined(t, typeof(CacheKeyAttribute))
                             select t).ToList();

            string propertyKey = string.Empty;
            foreach (var itemProperty in propertys)
            {
                var propertyValue = itemProperty.GetValue(source);
                var keyName = (typeReflector.GetCustomAttributes(typeof(CacheKeyAttribute), false).FirstOrDefault() as CacheKeyAttribute).KeyName;

                propertyKey += $"{keyName}:{propertyValue}";
            }

            var redisKey = $"{classRedisKey.KeyName}_{propertyKey}";

            return redisKey;
        }
         
    }
}
