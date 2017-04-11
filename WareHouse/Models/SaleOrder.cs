using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouse.Models
{
    public enum Status
    {
        Sold, Returned
    }
    public class SaleOrder
    {
        [Required]
        [Display(Name = "Sale order ID")]
        public int SaleOrderID { get; set; }

        [Required]
        [Display(Name = "Sale order status")]
        public Status? SaleOrderStatus { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sale order date")]
        public DateTime SaleOrderDate { get; set; }

        public virtual ICollection<SalesLog> SalesLogs { get; set; }
    }
}