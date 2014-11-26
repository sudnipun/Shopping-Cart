using ShoppingCart.DataAccess;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

        public ActionResult Index()
        {
            ViewBag.products =Repository.GetProductList();
            return View();
        }

        public ActionResult Purchase(string name, string desc, string price) 
        {
            ViewBag.Name = name;
            ViewBag.Desc = desc;
            ViewBag.Price = price;
            return View();
        }

        
        public ActionResult Orders(UserModel model) 
        {
            
            if (Repository.GetUser(model.Email) == 0)
            {
                Repository.InsertUser(model.FirstName, model.LastName, model.Email);
            }
            ViewBag.orders = Repository.GetallOrders();
            return View("Orders");
        }
    }
}
