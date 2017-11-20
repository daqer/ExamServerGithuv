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
using ExamDataAccess;

namespace ExamService.Controllers
{
    public class AnswersController : ApiController
    {
        private ExamProjectTournamentEntities db = new ExamProjectTournamentEntities();

        // GET: api/Answers
        public IQueryable<tblAnswer> GettblAnswer()
        {
            return db.tblAnswer;
        }

        // GET: api/Answers/5
        [ResponseType(typeof(tblAnswer))]
        public IHttpActionResult GettblAnswer(long id)
        {
            tblAnswer tblAnswer = db.tblAnswer.Find(id);
            if (tblAnswer == null)
            {
                return NotFound();
            }

            return Ok(tblAnswer);
        }

        // PUT: api/Answers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAnswer(long id, tblAnswer tblAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAnswer.fldAnswerID)
            {
                return BadRequest();
            }

            db.Entry(tblAnswer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAnswerExists(id))
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

        // POST: api/Answers
        [ResponseType(typeof(tblAnswer))]
        public IHttpActionResult PosttblAnswer(tblAnswer tblAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblAnswer.Add(tblAnswer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblAnswer.fldAnswerID }, tblAnswer);
        }

        // DELETE: api/Answers/5
        [ResponseType(typeof(tblAnswer))]
        public IHttpActionResult DeletetblAnswer(long id)
        {
            tblAnswer tblAnswer = db.tblAnswer.Find(id);
            if (tblAnswer == null)
            {
                return NotFound();
            }

            db.tblAnswer.Remove(tblAnswer);
            db.SaveChanges();

            return Ok(tblAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAnswerExists(long id)
        {
            return db.tblAnswer.Count(e => e.fldAnswerID == id) > 0;
        }
    }
}