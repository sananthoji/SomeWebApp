using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessModels
{
    public class DashBoardModel
    {
        public DashBoardModel()
        {
            ListOfOrders = new List<DashBoardModel>();
            ListOfProductId = new List<SelectListItem>();
            ListOfStoreId = new List<SelectListItem>();
            StatusList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Processing",Value = "P"},
                new SelectListItem(){Text = "Complete",Value = "C"},
                new SelectListItem(){Text = "Order Placed",Value = "O"}
            };

        }
        //[Required]
        [Display(Name = "Order#")]
        public int CartId { set; get; }

        public int UserId { get; set; }
        [Display(Name = "Store Name")]
        [Required]
        public int StoreId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Order Status")]
        public String OrderStatus { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Create On")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Updated On")]
        public DateTime? UpdatedDateTime { set; get; }
        [Display(Name = "Order Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Order Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "My Order List")]
        public List<DashBoardModel> ListOfOrders { set; get; }
        [Display(Name = "Product List")]
        public List<SelectListItem> ListOfProductId { get; set; }
        [Display(Name = "Store List")]
        public List<SelectListItem> ListOfStoreId { get; set; }
        [Display(Name = "Store List")]
        public List<SelectListItem> StatusList { get; set; }
        [Required]
        [Display(Name = "Item Count")]
        public int Items { get; set; }
        [Required]
        [Display(Name = "Credit Card Number")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Total Price")]
        public decimal Price { get; set; }

    }
}
