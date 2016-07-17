using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccessLayer.Contracts;
using BusinessModels;
namespace DataAccessLayer.Processors
{
    public class DataAccessLayers : IDataAccessLayer
    {
        //private SomeOnlineApplicationDBEntities db;//= new SomeOnlineApplicationDBEntities();
        public DataAccessLayers()
        {
           // db = new SomeOnlineApplicationDBEntities();
        }

        public void PlaceOrder(DashBoardModel dashBoardModel)
        {
            using (SomeOnlineApplicationDBEntities db = new SomeOnlineApplicationDBEntities())
            {
                var entity = db.Carts.Create();
                entity.NameId = dashBoardModel.ProductId;
                entity.Item = dashBoardModel.Items;
                entity.StoreId = dashBoardModel.StoreId;
                entity.Price = dashBoardModel.Price;
                db.Carts.Add(entity);
                db.SaveChanges();
                var cartId = entity.Id;
                var entityCart = db.UserCartRelations.Create();
                entityCart.CardId = cartId;
                entityCart.UserId = dashBoardModel.UserId;
                entityCart.Status = "O";
                entityCart.StoreId = dashBoardModel.StoreId;
                entityCart.CreateDate = entityCart.UpdatedDate = DateTime.Now;
                entityCart.CreatedBy =
                    entityCart.UpdatedBy =
                        db.ApplicationUsers.Where(x => x.Id == dashBoardModel.UserId).FirstOrDefault().Name;
                db.UserCartRelations.Add(entityCart);
                db.SaveChanges();
            }
        }

        public void PlaceDeal(MyHotDealsModel myHotDealsModel)
        {
            using (SomeOnlineApplicationDBEntities db = new SomeOnlineApplicationDBEntities())
            {
                var list =
                    db.StoreProductAssociations.Where(x => x.HotDealCode == myHotDealsModel.HotDealCode)
                        .AsEnumerable()
                        .ToList();
                foreach (var record in list)
                {
                    var entity = db.Carts.Create();
                    entity.NameId = record.ProductId;
                    entity.Item = 1;
                    entity.StoreId = record.StoreId;
                    entity.Price = record.Product.Price;
                    db.Carts.Add(entity);
                    db.SaveChanges();
                    var cartId = entity.Id;
                    var entityCart = db.UserCartRelations.Create();
                    entityCart.CardId = cartId;
                    entityCart.UserId = myHotDealsModel.UserId;
                    entityCart.Status = "O";
                    entityCart.StoreId = record.StoreId;
                    entityCart.CreateDate = entityCart.UpdatedDate = DateTime.Now;
                    entityCart.CreatedBy =
                        entityCart.UpdatedBy =
                            db.ApplicationUsers.Where(x => x.Id == myHotDealsModel.UserId).FirstOrDefault().Name;
                    db.UserCartRelations.Add(entityCart);
                    db.SaveChanges();
                }
            }
        }

        public DashBoardModel GetMyDashBoard(int? userId)
        {
            DashBoardModel dashBoardModel = new DashBoardModel();
            using (SomeOnlineApplicationDBEntities db = new SomeOnlineApplicationDBEntities())
            {
                
                dashBoardModel.ListOfOrders =
                    db.UserCartRelations.Where(x => x.UserId == userId).AsEnumerable().Select(x => new DashBoardModel
                    {
                        CartId = Convert.ToInt32(x.CardId),
                        UserId = Convert.ToInt32(userId),
                        OrderStatus = GetStatus(x.Status),
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreateDate,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDateTime = x.UpdatedDate,
                        StoreName = x.Store.Name,
                        ProductName = x.Cart.Product.Name
                    }).ToList();
            }
            return dashBoardModel;
        }

        public string GetStatus(string status)
        {
            switch (status)
            {
                case "P":
                    status = "Processing";
                    break;
                case "C":
                    status = "Complete";
                    break;
                case "O":
                    status = "Order Placed";
                    break;
            }
            return status;
        }


        public void GetNewOrder(DashBoardModel dashBoardModel)
        {
            using (SomeOnlineApplicationDBEntities db = new SomeOnlineApplicationDBEntities())
            {
                dashBoardModel.ListOfProductId= db.Products.AsEnumerable()
                    .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()})
                    .ToList();
                dashBoardModel.ListOfStoreId = db.Stores.AsEnumerable()
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                    .ToList();
                
            }
        }

        public void GetHotDeals(MyHotDealsModel myHotDealsModel)
        {
            using (SomeOnlineApplicationDBEntities db = new SomeOnlineApplicationDBEntities())
            {
                myHotDealsModel.ListHotDeals = db.StoreProductAssociations.AsEnumerable()
                    .Select(x => new SelectListItem { Text = x.Description, Value = x.HotDealCode.ToString() }).Distinct()
                    .ToList();
                myHotDealsModel.ListOfProducts = db.Products.AsEnumerable()
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                    .ToList();
                myHotDealsModel.ListOfStores = db.Stores.AsEnumerable()
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                    .ToList();

            }
        }
    }
}
