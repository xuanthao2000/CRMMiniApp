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
    public class classifiesController : ApiController
    {
        private CRMMiniAppEntities db = new CRMMiniAppEntities();

        // GET: api/classifies
        public IQueryable<classify> Getclassifies()
        {
            return db.classifies;
        }


        // GET: api/classifies/5
        [ResponseType(typeof(classify))]
        public IHttpActionResult Getclassify(int id)
        {
            classify classify = db.classifies.Find(id);
            if (classify == null)
            {
                return NotFound();
            }

            return Ok(classify);
        }

        // PUT: api/classifies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclassify(int id, classify classify)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classify.MaLoai)
            {
                return BadRequest();
            }

            db.Entry(classify).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!classifyExists(id))
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

        // POST: api/classifies
        [ResponseType(typeof(classify))]
        public IHttpActionResult Postclassify(classify classify)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.classifies.Add(classify);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classify.MaLoai }, classify);
        }

        // DELETE: api/classifies/5
        [ResponseType(typeof(classify))]
        public IHttpActionResult Deleteclassify(int id)
        {
            classify classify = db.classifies.Find(id);
            if (classify == null)
            {
                return NotFound();
            }

            db.classifies.Remove(classify);
            db.SaveChanges();

            return Ok(classify);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool classifyExists(int id)
        {
            return db.classifies.Count(e => e.MaLoai == id) > 0;
        }
    }
}