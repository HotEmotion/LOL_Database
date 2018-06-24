using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_and_register.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index(int Id)
        {
            return View();
        }
        public string getData(string Id)
        {
            string myJson;
            int intId = Convert.ToInt32(Id);
            Model_Data.Data oData = new Model_Data.Data();
            DataSet ds;
            ds = oData.getDetail(intId);
            myJson = System.Convert.ToString(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]));
            return myJson.ToString();
        }
    }
}