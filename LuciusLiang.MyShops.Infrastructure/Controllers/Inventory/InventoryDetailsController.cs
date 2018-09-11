using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuciusLiang.MyShops.DataModel.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LuciusLiang.MyShops.Infrastructure.Controllers.Inventory
{
    [Authorize]
    [Route("api/inventory/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class InventoryDetailsController : ControllerBase
    {
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <returns>库存模型集合</returns>
        [HttpGet]
        public IEnumerable<InventoryDTO> Get()
        {
            var lstInventoryDTO = new List<InventoryDTO>();

            for (int index = 1; index < 17; index++)
            {
                lstInventoryDTO.Add(new InventoryDTO()
                {
                    Id = index,
                    ProductName = "产品" + index,
                    Unit = "单位" + index,
                    WarehousePosition = "仓库位置" + index,
                    InboundAmount = index * 11,
                    OutboundAmount = index * 22,
                    InventoryAmount = index * 100,
                    LastUpdateTime = DateTime.Now,
                    Remarik = "备注" + index
                });
            }

            return lstInventoryDTO;
        }

    }
}
