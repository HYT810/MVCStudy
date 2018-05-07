using MVCDemo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCDemo3.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        
        public ActionResult Login()
        {
            return View();
        }
        //登录
        [HttpPost]
        public ActionResult DoLogin(UserInfo user)
        {            
            if (GetUserStatus(user) == UserStatus.AuthenticatedAdmin)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["IsAdmin"] = true;
                return RedirectToAction("Index", "Employee");
            }
            else if (GetUserStatus(user) == UserStatus.AuthentucatedUser)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["IsAdmin"] = false;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }
        [NonAction]
        public bool IsValidate(UserInfo user)
        {
            if (user.UserName == "admin" && user.Password=="admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [NonAction]
        public UserStatus GetUserStatus(UserInfo user)
        {
            if (user.UserName == "admin" && user.Password == "admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (user.UserName == "hyt" && user.Password == "hyt")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
        //登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}