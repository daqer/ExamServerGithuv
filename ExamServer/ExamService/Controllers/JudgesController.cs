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
    public class JudgesController : ApiController
    {
        private ExamProjectTournamentEntities db = new ExamProjectTournamentEntities();

        // GET: api/Judges
        public IQueryable<tblJudge> GettblJudge()
        {
            return db.tblJudge;
        }

        // GET: api/Judges/5
        [ResponseType(typeof(tblJudge))]
        public IHttpActionResult GettblJudge(long id)
        {
            tblJudge tblJudge = db.tblJudge.Find(id);
            if (tblJudge == null)
            {
                return NotFound();
            }

            return Ok(tblJudge);
        }

        // PUT: api/Judges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblJudge(long id, tblJudge tblJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblJudge.fldJudgeID)
            {
                return BadRequest();
            }

            db.Entry(tblJudge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblJudgeExists(id))
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

        // POST: api/Judges
        [ResponseType(typeof(tblJudge))]
        public IHttpActionResult PosttblJudge(tblJudge tblJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblJudge.Add(tblJudge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblJudge.fldJudgeID }, tblJudge);
        }

        // DELETE: api/Judges/5
        [ResponseType(typeof(tblJudge))]
        public IHttpActionResult DeletetblJudge(long id)
        {
            tblJudge tblJudge = db.tblJudge.Find(id);
            if (tblJudge == null)
            {
                return NotFound();
            }

            db.tblJudge.Remove(tblJudge);
            db.SaveChanges();

            return Ok(tblJudge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblJudgeExists(long id)
        {
            return db.tblJudge.Count(e => e.fldJudgeID == id) > 0;
        }
    }
}