using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using CharitaPoll.EF;
using CharitaPoll.Models;

namespace CharitaPoll.Controllers
{
   
    public class CharitiesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Charities
        public IQueryable<Charity> GetCharities()
        {
            return db.Charities;
        }

        [HttpGet]
        [Route("api/Charities/{CharityId}/Polls")]
        public IQueryable<Poll> GetPollsByCharity(int CharityId)
        {
            return db.Polls.Where(o => o.CharityId == CharityId);        
        }
        // GET: api/Charities/5
        [ResponseType(typeof(Charity))]
        public IHttpActionResult GetCharity(int id)
        {
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return NotFound();
            }

            return Ok(charity);
        }

        // PUT: api/Charities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharity(int id, Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charity.CharityId)
            {
                return BadRequest();
            }

            db.Entry(charity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharityExists(id))
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

        // POST: api/Charities
        [ResponseType(typeof(Charity))]
        public IHttpActionResult PostCharity(Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Charities.Add(charity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = charity.CharityId }, charity);
        }

        // DELETE: api/Charities/5
        [ResponseType(typeof(Charity))]
        public IHttpActionResult DeleteCharity(int id)
        {
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return NotFound();
            }

            db.Charities.Remove(charity);
            db.SaveChanges();

            return Ok(charity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharityExists(int id)
        {
            return db.Charities.Count(e => e.CharityId == id) > 0;
        }
    }
}