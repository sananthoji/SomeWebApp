using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Contracts;
using BusinessModels;
namespace DataAccessLayer.Processors
{
    class Authorise : IAuthorise
    {
        public bool IsAuthorisedUser(UserModel userModel)
        {
            userModel.Name = "Tome Hardy";
            userModel.UserId = 1;
            userModel.Role = "U";
            userModel.IsAuthorisedUser = true;
            using (SomeOnlineApplicationDBEntities db = new SomeOnlineApplicationDBEntities())
            {
                if (db.ApplicationUsers.Any(x => x.Email == userModel.Email && x.Password == userModel.Password))
                {
                    var entity =
                        db.ApplicationUsers.First(x => x.Email == userModel.Email && x.Password == userModel.Password)
                            ;
                    userModel.Name = entity.Name;
                    userModel.UserId = entity.Id;
                    userModel.Role = entity.Role;//"U";
                    userModel.IsAuthorisedUser = true;
                }
            }
            
            return true;
        }
    }
}
