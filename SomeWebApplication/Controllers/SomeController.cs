using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModels;

namespace SomeWebApplication.Controllers
{
    public class SomeController : BaseController
    {
        // GET: Some
        public ActionResult DashBoard()
        {
            ViewBag.Key = "My DashBoard";
            var iDataAccessLayer = DependencyResolver.Current.GetService<IDataAccessLayer>();
            //var loginProcessor =   DependencyResolver.Current.GetService<IAuthorise>();
            //var iDataAccessLayer = new DataAccessLayer.Processors.DataAccessLayers();
            int? userId = GetUserId();
            DashBoardModel dashBoardModel = iDataAccessLayer.GetMyDashBoard(userId);
            return View(dashBoardModel);
        }
        public ActionResult NewOrder()
        {
            DashBoardModel dashBoardModel = new DashBoardModel();
            UserModel user = Session["User"] as UserModel;
            dashBoardModel.UserId = user.UserId;
            dashBoardModel.UserName = user.Name;

            var iDataAccessLayer = DependencyResolver.Current.GetService<IDataAccessLayer>();
            iDataAccessLayer.GetNewOrder(dashBoardModel);
            return View(dashBoardModel);
        }
        [HttpPost]
        public ActionResult PlaceOrder(DashBoardModel dashBoardModel)
        {
            TryUpdateModel(dashBoardModel);
            ModelState.Remove("orderstatus");
            if (ModelState.IsValid)
            {
                var iDataAccessLayer = DependencyResolver.Current.GetService<IDataAccessLayer>();
                UserModel user = Session["User"] as UserModel;
                dashBoardModel.UserId = user.UserId;
                dashBoardModel.ProductId = Convert.ToInt32(dashBoardModel.ProductName);
                dashBoardModel.StoreId = Convert.ToInt32(dashBoardModel.StoreName);

                iDataAccessLayer.PlaceOrder(dashBoardModel);
                return RedirectToAction("DashBoard");
            }
            ModelState.AddModelError("Error","Please complete all fields");
            return View("NewOrder", dashBoardModel);
        }

        [HttpGet]
        public ActionResult HotDeals()
        {
            MyHotDealsModel myHotDealsModel = new MyHotDealsModel();
            UserModel user = Session["User"] as UserModel;
            myHotDealsModel.UserId = user.UserId;
            var iDataAccessLayer = DependencyResolver.Current.GetService<IDataAccessLayer>();
            iDataAccessLayer.GetHotDeals(myHotDealsModel);
            return View();
        }
        [HttpPost]
        public ActionResult PlaceDeal(MyHotDealsModel myHotDealsModel)
        {
            TryUpdateModel(myHotDealsModel);
            if (ModelState.IsValid)
            {
                var iDataAccessLayer = DependencyResolver.Current.GetService<IDataAccessLayer>();
                UserModel user = Session["User"] as UserModel;
                myHotDealsModel.UserId = user.UserId;
                iDataAccessLayer.PlaceDeal(myHotDealsModel);
                return RedirectToAction("DashBoard");
            }
            ModelState.AddModelError("Error", "Please complete all fields");
            return View("HotDeals", myHotDealsModel);
        }

    }
}