using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public class Item
    {
        [Required]
        [Key]
        [Display(Name = "Item ID")]
        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Item name")]
        [StringLength(20)]
        public String ItemName { get; set; }

        [Required]
        [Display(Name = "Item description")]
        [StringLength(60)]
        public String ItemDesc { get; set; }

        [Required]
        [Display(Name = "Item quantity")]
        public int ItemQTY { get; set; }

        [Required]
        [Display(Name = "Item threshold")]
        public int ItemThres { get; set; }

        [Required]
        [Display(Name = "Item sale price")]
        public int ItemSalePrice { get; set; }

        [Required]
        [Display(Name = "Item purchase price")]
        public int ItemPurchasePrice { get; set; }

        [Required]
        [Display(Name = "Item photo")]
        [Url]
        public String ItemPhoto { get; set; }

        public virtual ICollection<PurchaseLog> PurchaseLogs { get; set; }
        public virtual ICollection<SalesLog> SalesLogs { get; set; }
    }
}