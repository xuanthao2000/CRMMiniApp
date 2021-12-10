using CRMMiniAppFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CRMMiniAppFE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("login/" + Email + "/"+ Password).Result;
            
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Đăng nhập thành công";
                var stringJSon = Convert.ToString(response.Content.ReadAsStringAsync().Result);

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                employeeModel emp = javaScriptSerializer.Deserialize<employeeModel>(stringJSon);
                Session["TrangThai"] = true;
                Session["MaNV"] = emp.MaNV;
                Session["TenNV"] = emp.HoTenNV;
                Session["DiaChi"] = emp.DiaChi;
                Session["DienThoai"] = emp.DienThoai;
                Session["Role"] = emp.Role;
                
                
                return RedirectToAction("Index", "Home");
            }
            else
            { 
                TempData["ErrorMessage"] = "Đăng nhập thất bại";
                return RedirectToAction("Index", "Login");
            }    
                

        }

        public ActionResult SignUp()
        {

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}