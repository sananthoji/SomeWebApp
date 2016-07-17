using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessModels
{
    public class MyHotDealsModel
    {
        public MyHotDealsModel()
        {
            ListHotDeals = new List<SelectListItem>();
            ListOfProducts = new List<SelectListItem>();
            ListOfStores = new List<SelectListItem>();

        }
        public List<SelectListItem> ListHotDeals{ get; set; }
        public List<SelectListItem> ListOfProducts { get; set; }
        public List<SelectListItem> ListOfStores { get; set; }
        [Required]
        [Display(Name="Hot Deals")]
        public string HotDealCode { get; set; }
        [Display(Name = "Hot Deal Description")]
        public string HotDealDescription { get; set; }

        public int UserId { get; set; }
    }
}
