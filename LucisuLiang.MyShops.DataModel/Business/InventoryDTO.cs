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
        /// 产品单价
        /// </summary>
        public double ProductPrice { get; set; }

        /// <summary>
        /// 所属仓库
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int Amount { get; set; }

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