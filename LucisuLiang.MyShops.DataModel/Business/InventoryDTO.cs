using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LuciusLiang.MyShops.DataModel.Business
{
    /// <summary>
    /// 库存模型
    /// </summary>
    public class InventoryDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 仓库位置
        /// </summary>
        public string WarehousePosition { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int InboundAmount { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int OutboundAmount { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        public int InventoryAmount { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarik { get; set; }

    }
}