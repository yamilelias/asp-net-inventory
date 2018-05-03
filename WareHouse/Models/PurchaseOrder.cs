using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    
        public enum PurchaseStatus
        {
            Ordered, Delivered, Cancelled
        }
        public class PurchaseOrder
        {
            [Required]
            [Key]
            [Display(Name = "Purchase order ID")]
            public int PurchaseOrderID { get; set; }

            [Required]
            [Display(Name = "Purchase order description")]
            [StringLength(60)]
            public String PurchaseOrderDesc { get; set; }

            [Required]
            [Display(Name = "Purchase order status")]
            public PurchaseStatus? PurchaseOrderStatus { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Purchase order date")]
            public DateTime PurchaseOrderDate { get; set; }

            public virtual ICollection<PurchaseLog> PurchaseLogs { get; set; }
        }
    }
