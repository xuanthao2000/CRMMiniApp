using CRMMiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace CRMMiniApp.Controllers
{
    public class loginController : ApiController
    {
        private CRMMiniAppEntities db = new CRMMiniAppEntities();

        
        [System.Web.Http.Route("api/login/{Email}/{Password}")]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get(string Email, string Password)
        {
            employee employee =  db.employees.Where(s => s.Email == Email && s.Password == Password).FirstOrDefault();
            //employee emp = db.employees.Find(employee);
            if (employee == null)
                return NotFound();
            else
                return Ok(employee);
        }

        //public IQueryable<employee> Get()
        //{
        //    return db.employees;
        //}
    }
}
