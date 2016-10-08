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
using EntityState = System.Data.Entity.EntityState;

namespace CharitaPoll.Controllers
{
   
    public class UsersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {           
            return db.Users;
        }

        [HttpPost]
        [Route("api/Users/Login")]
        public IHttpActionResult Login([FromBody] User user)
        {
            if (user.Username.Equals(string.Empty) || user.Password.Equals(string.Empty))
            {
                return BadRequest();
            }
            var dbuser = db.Users.Where(e => e.Username == user.Username && e.Password == user.Password).FirstOrDefaultAsync();
            if (dbuser == null)
            {
                return NotFound();
            }
            return Ok(dbuser);
        }

        [HttpGet]
        [Route("api/Users/{UserId}/Answers")]
        public IEnumerable<Answer> getAnswersByUser(int UserId)
        {
            return db.Answers.Where(o => o.UserId == UserId);
        }



        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}