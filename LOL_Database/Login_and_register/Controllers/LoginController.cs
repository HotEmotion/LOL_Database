using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_and_register.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        string userID;
        public ActionResult Index()
        {
            return View();
        }
        public string Login()
        {
            string pass;
            userID = Request["UserName"].ToString();
            pass = Request["UserPwd"].ToString();
            Session["userid"] = userID;
            Model_Data.User oUser = new Model_Data.User();
            return oUser.Login(userID, pass);
        }

    }
}