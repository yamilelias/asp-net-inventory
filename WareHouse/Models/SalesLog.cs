using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public class SalesLog
    {
        [Required]
        [Display(Name = "Sale order ID")]
        public int SaleOrderID { get; set; }

        [Required]
        [Display(Name = "Item ID")]
        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Quantity of item ordered")]
        public uint ItemOrderQTY { get; set; }

        public virtual Item Item { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
    }
}