using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;

namespace DataAccessLayer.Contracts
{
    public interface IAuthorise
    {
        bool IsAuthorisedUser(UserModel userModel);
        
    }
}
