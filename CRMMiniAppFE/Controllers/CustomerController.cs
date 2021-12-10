using CRMMiniAppFE.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CRMMiniAppFE.Controllers
{
    public class CustomerController : Controller
    {
        IEnumerable<customerModel> cusList;
        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("customers").Result;
        
        // GET: Customer
       private CRMContext db = new CRMContext();
        public ActionResult Index(int? page,int id=0)
        {
            //PagedList
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            
            DropDownListClassify(id);

            //Get list customer from API
            cusList = response.Content.ReadAsAsync<IEnumerable<customerModel>>().Result;
            DateTime fromDate;
            DateTime toDate;
            if (Session["fromDate"] == null && Session["toDate"] == null)
            {
                if (id == 0)
                    return View(cusList.ToPagedList(pageNumber, pageSize));
                else
                    return View(cusList.Where(s => s.MaLoai == id).ToPagedList(pageNumber, pageSize));
            }
            else
            {                 
                fromDate = (DateTime)Session["fromDate"];
                toDate = (DateTime)Session["toDate"];
                Session["fromDate"] = null;
                Session["toDate"] = null;
                return View(cusList.Where(s => s.NgayTao.CompareTo(fromDate) == 1 && s.NgayTao.CompareTo(toDate) == -1).ToPagedList(pageNumber, pageSize));
            }

        }

        public void DropDownListClassify(int? id)
        {
            //Get list classify from API
            IEnumerable<classifyModel> clsList;
            HttpResponseMessage res = GlobalVariables.WebApiClient.GetAsync("classifies").Result;
            clsList = res.Content.ReadAsAsync<IEnumerable<classifyModel>>().Result;

            //Dropdownlist item
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Tất cả loại", Value = "0", Selected = false };
            items.Add(item1);
            foreach (var item in clsList)
            {
                SelectListItem item2 = new SelectListItem() { Text = item.TenLoai, Value = Convert.ToString(item.MaLoai), Selected = false };
                items.Add(item2);
            }
            items.Find(d => d.Value == id.ToString()).Selected = true;
            ViewBag.LoaiKH = items;
        }
        public void DDLCreateEdit()
        {
            //Get list classify from API
            IEnumerable<classifyModel> clsList;
            HttpResponseMessage res = GlobalVariables.WebApiClient.GetAsync("classifies").Result;
            clsList = res.Content.ReadAsAsync<IEnumerable<classifyModel>>().Result;

            //Dropdownlist item
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in clsList)
            {
                SelectListItem item2 = new SelectListItem() { Text = Convert.ToString(item.MaLoai), Value = Convert.ToString(item.MaLoai), Selected = false };
                items.Add(item2);
            }
            ViewBag.MaLoai = items;
        }
        public ActionResult searchDate(customerModel cust)
        {
            Session["fromDate"] = (DateTime)cust.fromDate;
            Session["toDate"] = (DateTime)cust.toDate;
            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            DDLCreateEdit();
            return View(new customerModel());
        }

        [HttpPost]
        public ActionResult Create(customerModel cus)
        {
            cus.NgayTao = DateTime.Now;
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("customers", cus).Result;
            TempData["SuccessMessage"] = "Thêm nhân viên thành công";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            DDLCreateEdit();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("customers/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<customerModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(customerModel cus)
        {
            
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("customers/" + cus.MaKH, cus).Result;
            TempData["SuccessMessage"] = "Sửa khách hàng thành công";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("customers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Xóa khách hàng thành công";
            return RedirectToAction("Index");
        }
    }
}