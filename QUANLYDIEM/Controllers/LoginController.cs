using BLL;
using BLL.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using Newtonsoft.Json;
using QUANLYDIEM.Models;
using System.Web.Security;

namespace QUANLYDIEM.Controllers
{

    public class LoginController : Controller
    {
        // GET: KhoiHoc

        public ActionResult Login()
        {
            return View();
        }
        IUsersBLL k = new UsersBLL();

       [HttpPost]
        public JsonResult Login(string us,string pw)
        {
            Users u = k.CheckAccount(us, pw);
            if(u==null)//Tài khoản sai
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }    
            else
            {
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(u, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public ActionResult Logout()
        {
           
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");

           
        }
    }
}