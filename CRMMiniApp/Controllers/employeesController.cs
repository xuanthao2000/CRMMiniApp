using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CRMMiniApp.Models;

namespace CRMMiniApp.Controllers
{
    public class employeesController : ApiController
    {
        private CRMMiniAppEntities db = new CRMMiniAppEntities();

        // GET: api/employees
        public object Getemployees()
        {
            //return db.employees;

            var ds = db.employees.Select(s => new {
                s.MaNV,
                s.HoTenNV,
                s.DiaChi,
                s.DienThoai,
                s.Role
            }).ToList();
            return ds;
        }

        // GET: api/employees/5
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Getemployee(int id)
        {
            employee employee = await db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemployee(int id, employee employee)
        {
            employee emp = db.employees.Find(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.MaNV)
            {
                return BadRequest();
            }

            emp.HoTenNV = employee.HoTenNV;
            emp.DiaChi = employee.DiaChi;
            emp.DienThoai = employee.DienThoai;
            emp.Role = employee.Role;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        // POST: api/employees
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Postemployee(employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.employees.Add(employee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.MaNV }, employee);
        }

        // DELETE: api/employees/5
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Deleteemployee(int id)
        {
            employee employee = await db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employees.Count(e => e.MaNV == id) > 0;
        }
    }
}