using CRMMiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CRMMiniApp.Controllers
{
    public class ValuesController : ApiController
    {
        CRMMiniAppEntities db = new CRMMiniAppEntities();
        // GET api/values
        public IQueryable<employee> Get()
        {
            return db.employees;
        }
        private List<customer> GetAllCus()
        {
            var customers = new List<customer>
            {
            new customer{
                MaKH = 3,
                HoTenKH = "a"
            } };

            return customers;
        }    

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
