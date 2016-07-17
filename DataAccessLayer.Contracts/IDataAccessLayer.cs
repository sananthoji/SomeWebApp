using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;
namespace DataAccessLayer.Contracts
{
    public interface IDataAccessLayer
    {
        void PlaceOrder(DashBoardModel dashBoardModel);

        void PlaceDeal(MyHotDealsModel myHotDealsModel);

        DashBoardModel GetMyDashBoard(int? userId);

        void GetNewOrder(DashBoardModel dashBoardModel);

        void GetHotDeals(MyHotDealsModel myHotDealsModel);
    }
}
