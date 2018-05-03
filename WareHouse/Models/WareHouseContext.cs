using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public class WareHouseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WareHouseContext() : base("name=WareHouseContext")
        {
        }

        public System.Data.Entity.DbSet<WareHouse.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<WareHouse.Models.PurchaseOrder> PurchaseOrders { get; set; }

        public System.Data.Entity.DbSet<WareHouse.Models.SaleOrder> SaleOrders { get; set; }

        public System.Data.Entity.DbSet<WareHouse.Models.SalesLog> SalesLogs { get; set; }

        public System.Data.Entity.DbSet<WareHouse.Models.PurchaseLog> PurchaseLogs { get; set; }
    }
}
