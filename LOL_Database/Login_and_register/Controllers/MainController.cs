using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model_Data;

namespace Login_and_register.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public string getTreeView()
        {
            Model_Data.TreeView oTreeView = new Model_Data.TreeView();
            return oTreeView.getTreeView();
        }
        public string getAllHeroDatas()
        {
            string myJson;
            Model_Data.Data oData = new Model_Data.Data();
            DataSet ds;

            ds = oData.getAllHero();
            myJson = System.Convert.ToString(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]));
 
            return myJson.ToString();
        }
        public string getHeroDataByType(string type)
        {
            string myJson;
            Model_Data.Data oData = new Model_Data.Data();
            DataSet ds;

            ds = oData.getHeroDataBytype(type);
            myJson = System.Convert.ToString(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]));
            return myJson.ToString();
        }

    }
}