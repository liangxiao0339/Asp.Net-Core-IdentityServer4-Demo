using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuciusLiang.MyShops.DataModel.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuciusLiang.MyShops.Infrastructure.Controllers.Inventory
{
    [Authorize]
    [Route("api/business/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class InventoryController : Controller
    {
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <returns>库存模型集合</returns>
        [HttpGet]
        public IEnumerable<InventoryDTO> Get()
        {
            return new InventoryDTO[]
            {
                new InventoryDTO()
                {
                    Id = 1001,
                    Amount = 100,
                    LastUpdateTime = DateTime.Now,
                    ProductName = "产品1",
                    ProductPrice  = 111,
                    Remarik = "产品1备注",
                    WarehouseName = "仓库1"
                },
                new InventoryDTO()
                {
                    Id = 2002,
                    Amount = 200,
                    LastUpdateTime = DateTime.Now,
                    ProductName = "产品2",
                    ProductPrice  = 222,
                    Remarik = "产品2备注",
                    WarehouseName = "仓库2"
                },
                new InventoryDTO()
                {
                    Id = 3003,
                    Amount = 300,
                    LastUpdateTime = DateTime.Now,
                    ProductName = "产品3",
                    ProductPrice  = 333,
                    Remarik = "产品3备注",
                    WarehouseName = "仓库3"
                },
                new InventoryDTO()
                {
                    Id = 4004,
                    Amount = 400,
                    LastUpdateTime = DateTime.Now,
                    ProductName = "产品4",
                    ProductPrice  = 444,
                    Remarik = "产品4备注",
                    WarehouseName = "仓库4"
                },
                new InventoryDTO()
                {
                    Id = 5005,
                    Amount = 500,
                    LastUpdateTime = DateTime.Now,
                    ProductName = "产品5",
                    ProductPrice  = 555,
                    Remarik = "产品5备注",
                    WarehouseName = "仓库5"
                },
                new InventoryDTO()
                {
                    Id = 6006,
                    Amount = 600,
                    LastUpdateTime = DateTime.Now,
                    ProductName = "产品6",
                    ProductPrice  = 666,
                    Remarik = "产品6备注",
                    WarehouseName = "仓库6"
                }

            };
        }

    }
}
