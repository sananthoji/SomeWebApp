using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BusinessModels;
using DataAccessLayer.Contracts;
using Microsoft.AspNet.Identity;
using SomeWebApplication.Utilities;

namespace SomeWebApplication.Controllers
{
    public class BaseController : Controller
    {
        protected enum UserDetails
        {
            User,
            Name,
            UserId,
            Role,
            IsAuthorised
        }

        protected int? GetUserId()
        {
            if (Session != null && Session[UserDetails.User.ToString()] != null)
            {
                var user = Session[UserDetails.User.ToString()] as UserModel;
                return user.UserId;
            }
            return 0;
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (Session!=null && Session[UserDetails.User.ToString()] != null)
            {
                UserModel user = Session[UserDetails.User.ToString()] as UserModel;
                List<ClaimsIdentity> claims = new List<ClaimsIdentity>();
                var idenity = new ClaimsIdentity();
                idenity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                idenity.AddClaim(new Claim(ClaimTypes.Sid, user.UserId.ToString()));
                idenity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                claims.Add(idenity);
                var principle = new ClaimsPrincipal(idenity);
                System.Web.HttpContext.Current.User = principle;
                ClaimsPrincipal.Current.AddIdentities(claims);
                
            }
            base.Initialize(requestContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logging.LogInfo(filterContext.Controller.ToString(),true);
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Logging.LogInfo(filterContext.Controller.ToString(), true);
            base.OnActionExecuted(filterContext);
        }

    }
}