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
    public class QuestionairesController : ApiController
    {
        private db_ExamProjectTournamentEntities db = new db_ExamProjectTournamentEntities();

        // GET: api/Questionaires
        public IQueryable<tblQuestionaire> GettblQuestionaire()
        {
            return db.tblQuestionaire;
        }

        // GET: api/Questionaires/5
        [ResponseType(typeof(tblQuestionaire))]
        public IHttpActionResult GettblQuestionaire(long id)
        {
            tblQuestionaire tblQuestionaire = db.tblQuestionaire.Find(id);
            if (tblQuestionaire == null)
            {
                return NotFound();
            }

            return Ok(tblQuestionaire);
        }

        // PUT: api/Questionaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblQuestionaire(long id, tblQuestionaire tblQuestionaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblQuestionaire.fldQuestionaireID)
            {
                return BadRequest();
            }

            db.Entry(tblQuestionaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblQuestionaireExists(id))
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

        // POST: api/Questionaires
        [ResponseType(typeof(tblQuestionaire))]
        public IHttpActionResult PosttblQuestionaire(tblQuestionaire tblQuestionaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblQuestionaire.Add(tblQuestionaire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblQuestionaire.fldQuestionaireID }, tblQuestionaire);
        }

        // DELETE: api/Questionaires/5
        [ResponseType(typeof(tblQuestionaire))]
        public IHttpActionResult DeletetblQuestionaire(long id)
        {
            tblQuestionaire tblQuestionaire = db.tblQuestionaire.Find(id);
            if (tblQuestionaire == null)
            {
                return NotFound();
            }

            db.tblQuestionaire.Remove(tblQuestionaire);
            db.SaveChanges();

            return Ok(tblQuestionaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblQuestionaireExists(long id)
        {
            return db.tblQuestionaire.Count(e => e.fldQuestionaireID == id) > 0;
        }
    }
}