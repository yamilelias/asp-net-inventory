using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public class PurchaseLog
    {
        [Required]
        [Key]
        public int PurchaseLogID { get; set; }


        [Required]
        [Display(Name = "Quantity of item ordered")]
        public int ItemOrderQTY { get; set; }


        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        [Display (Name ="ItemID")]
        public virtual Item Item { get; set; }


        public int PurchaseOrderID { get; set; }
        [ForeignKey("PurchaseOrderID")]
        [Display(Name ="PurchaseOrderID")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}