using CRMMiniAppFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CRMMiniAppFE.Controllers
{
    public class ClassifyController : Controller
    {
        // GET: Classify
        public ActionResult Index()
        {
            IEnumerable<classifyModel> clsList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("classifies").Result;
            clsList = response.Content.ReadAsAsync<IEnumerable<classifyModel>>().Result;

            return View(clsList);
        }
        public ActionResult Create()
        {
            //ViewBag.MaLoai = new SelectList(db.classify, "MaLoai", "TenLoai");
            return View(new classifyModel());
        }
        [HttpPost]
        public ActionResult Create(classifyModel cls)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("classifies/", cls).Result;
            
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            TempData["SuccessMessage"] = "Sửa loại khách hàng thành công";
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("classifies/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<classifyModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(classifyModel cls)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("classifies/" + cls.MaLoai, cls).Result;
            TempData["SuccessMessage"] = "Sửa loại khách hàng thành công";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("classifies/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode == true)
                TempData["SuccessMessage"] = "Xóa loại khách hàng thành công";
            else
                TempData["ErrorMessage"] = "Xóa loại khách hàng thất bại. Còn tồn tại khách hàng loại này";
            return RedirectToAction("Index");
        }
    }
}