using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public class SalesLog
    {

        [Required]
        [Key]
        public int SalesLogID { get; set; }

        [Required]
        [Display(Name = "Quantity of item ordered")]
        public int ItemOrderQTY { get; set; }



        [Display(Name = "Item ID")]
        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }


        [Display(Name = "Sale order ID")]
        public int SaleOrderID { get; set; }
        [ForeignKey("SaleOrderID")]
        public virtual SaleOrder SaleOrder { get; set; }
    }
}