using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRMMiniApp.Models;

namespace CRMMiniApp.Controllers
{
    public class customersController : ApiController
    {
        private CRMMiniAppEntities db = new CRMMiniAppEntities();

        // GET: api/customers
        public IQueryable<customer> Getcustomers()
        {
            return db.customers;
        }

        // GET: api/customers/5
        [ResponseType(typeof(customer))]
        public IHttpActionResult Getcustomer(int id)
        {
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcustomer(int id, customer customer)
        {
            customer cus = db.customers.Find(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.MaKH)
            {
                return BadRequest();
            }

            cus.HoTenKH = customer.HoTenKH;
            cus.DienThoai = customer.DienThoai;
            cus.Email = customer.Email;
            cus.DiaChi = customer.DiaChi;
            cus.MaLoai = customer.MaLoai;
            cus.info1 = customer.info1;
            cus.info2 = customer.info2;
            cus.info3 = customer.info3;
            cus.info4 = customer.info4;
            cus.info5 = customer.info5;

            try
            {   
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/customers
        [ResponseType(typeof(customer))]
        public IHttpActionResult Postcustomer(customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.MaKH }, customer);
        }

        // DELETE: api/customers/5
        [ResponseType(typeof(customer))]
        public IHttpActionResult Deletecustomer(int id)
        {
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customerExists(int id)
        {
            return db.customers.Count(e => e.MaKH == id) > 0;
        }
    }
}