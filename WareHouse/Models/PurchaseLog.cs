using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public class PurchaseLog
    {
        [Required]
        [Display(Name = "Purchase order ID")]
        public int PurchaseOrderID { get; set; }

        [Required]
        [Display(Name = "Item ID")]
        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Quantity of item ordered")]
        public uint ItemOrderQTY { get; set; }

        public virtual Item Item { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}