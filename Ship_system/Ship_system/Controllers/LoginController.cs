using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ship_system.Models;

namespace Ship_system.Controllers
{
    public class LoginController : Controller
    {
        ship_systemEntities shipModel = new ship_systemEntities();

        [Route("")]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public JsonResult Login(RequestObject obj)
        {
            ReturnModel result;

            customer customer = shipModel.customers.SingleOrDefault(s => s.username == obj.username && s.password == obj.password);

            if (customer == null)
            {
                result = new ReturnModel() { status = false };
            }
            else
            {
                result = new ReturnModel() { status = true };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Regiter(RequestObject obj)
        {
            ReturnModel result = new ReturnModel() ;

            try
            {
                bool isExist = shipModel.customers.
                    SingleOrDefault(s => s.username == obj.username) != null ? true : false;
                if (isExist)
                {
                    result.status = false;
                    result.error_message = "Tài khoản đã tồn tại";
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                customer newCustomer = new customer();
                newCustomer = shipModel.customers.SingleOrDefault(s => s.username == obj.username);

                newCustomer.id = Guid.NewGuid();
                newCustomer.username = obj.username;
                newCustomer.password = obj.password;
                newCustomer.email = obj.email;

                shipModel.customers.Add(newCustomer);
                shipModel.SaveChanges();
                result.status = true;
            }
            catch (Exception ex)
            {
                result.status = false;
                result.error_message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}