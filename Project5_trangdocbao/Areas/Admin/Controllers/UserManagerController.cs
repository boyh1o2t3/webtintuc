using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class UserManagerController : Controller
    {
        //
        // GET: /Admin/UserManager/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AccountInfo()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult LogoutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
