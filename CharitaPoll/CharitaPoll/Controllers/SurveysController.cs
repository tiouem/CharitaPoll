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
using CharitaPoll.EF;
using CharitaPoll.Models;
using EntityState = System.Data.Entity.EntityState;

namespace CharitaPoll.Controllers
{
    public class SurveysController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Surveys
        public IQueryable<Survey> GetSurveys()
        {
            return db.Surveys;
        }
        [HttpGet]
        [Route("api/Surveys/{SurveyId}/Polls")]
        public IEnumerable<Poll> GetPollsBysurvey(int SurveyId)
        {
            return db.Polls.Where(o => o.SurveyId == SurveyId);
        }
        // GET: api/Surveys/5
        [ResponseType(typeof(Survey))]
        public IHttpActionResult GetSurvey(int id)
        {
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        // PUT: api/Surveys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSurvey(int id, Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.SurveyId)
            {
                return BadRequest();
            }

            db.Entry(survey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(id))
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

        // POST: api/Surveys
        [ResponseType(typeof(Survey))]
        public IHttpActionResult PostSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Surveys.Add(survey);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = survey.SurveyId }, survey);
        }

        // DELETE: api/Surveys/5
        [ResponseType(typeof(Survey))]
        public IHttpActionResult DeleteSurvey(int id)
        {
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return NotFound();
            }

            db.Surveys.Remove(survey);
            db.SaveChanges();

            return Ok(survey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyExists(int id)
        {
            return db.Surveys.Count(e => e.SurveyId == id) > 0;
        }
    }
}