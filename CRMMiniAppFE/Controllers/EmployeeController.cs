using CRMMiniAppFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CRMMiniAppFE.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        
        public ActionResult Index()
        {
            IEnumerable<employeeModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<employeeModel>>().Result;

            return View(empList.Where(s => s.Role != "Admin"));
        }
        public ActionResult Create()
        {
            return View(new employeeModel());
        }

        [HttpPost]
        public ActionResult Create(employeeModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("employees", emp).Result;
            TempData["SuccessMessage"] = "Thêm nhân viên thành công";

            return RedirectToAction("Index");
        }
        
        public ActionResult EditEmp(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("employees/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<employeeModel>().Result);
        }
        [HttpPost]
        public ActionResult EditEmp(employeeModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("employees/" + emp.MaNV, emp).Result;
            TempData["SuccessMessage"] = "Sửa nhân viên thành công";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Xóa nhân viên thành công";
            return RedirectToAction("Index");
        }

    }
}