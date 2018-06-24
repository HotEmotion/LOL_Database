using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_and_register.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public string Register()
        {
            string userID, pass,email;
            userID = Request["UserName"].ToString();
            pass = Request["UserPwd"].ToString();
            email = Request["UserEmail"].ToString();
            Model_Data.User oUser = new Model_Data.User();
            return oUser.Register(userID, pass,email);

        }
    }
}