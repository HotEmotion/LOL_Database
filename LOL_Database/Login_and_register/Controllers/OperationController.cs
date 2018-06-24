using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_and_register.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }
        public string Add(string name, string nickName,string iContent, string type, string price, string image)
        {
            Model_Data.Data oData = new Model_Data.Data();
            switch (type)
            {
                case "战士": oData.TypeId ="5";break;
                case "刺客": oData.TypeId = "7"; break;
                case "法师": oData.TypeId = "6"; break;
                case "坦克": oData.TypeId = "8"; break;
                case "辅助": oData.TypeId = "10"; break;
                case "射手": oData.TypeId = "9"; break;
            }
            oData.Name = name;
            oData.NickName = nickName;
            oData.IContent = iContent;
            oData.Type = type;
            oData.Price = price;
            oData.Image = image;
            if (oData.AddNew() == "1")
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
        public string Update(string name, string nickName, string iContent, string type, string price, string image,string id)
        {
            Model_Data.Data oData = new Model_Data.Data();
            switch (type)
            {
                case "战士": oData.TypeId = "5"; break;
                case "刺客": oData.TypeId = "7"; break;
                case "法师": oData.TypeId = "6"; break;
                case "坦克": oData.TypeId = "8"; break;
                case "辅助": oData.TypeId = "10"; break;
                case "射手": oData.TypeId = "9"; break;
            }
            oData.Name = name;
            oData.NickName = nickName;
            oData.IContent = iContent;
            oData.Type = type;
            oData.Price = price;
            oData.Image = image;
            oData.Id = Convert.ToInt32(id);
            if (oData.Update() == "1")
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
        public string Delete(string id)
        {
            Model_Data.Data oData = new Model_Data.Data();
            oData.Id = Convert.ToInt32(id);
            if (oData.Delete() == "1")
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
    }
}