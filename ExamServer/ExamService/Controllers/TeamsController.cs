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

namespace ExamService.Controllers
{
    public class TeamsController : ApiController
    {
        private db_ExamProjectTournamentEntities db = new db_ExamProjectTournamentEntities();

        // GET: api/Teams
        public IQueryable<tblTeam> GettblTeam()
        {
            return db.tblTeam;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(tblTeam))]
        public IHttpActionResult GettblTeam(long id)
        {
            tblTeam tblTeam = db.tblTeam.Find(id);
            if (tblTeam == null)
            {
                return NotFound();
            }

            return Ok(tblTeam);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblTeam(long id, tblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTeam.fldTeamID)
            {
                return BadRequest();
            }

            db.Entry(tblTeam).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(tblTeam))]
        public IHttpActionResult PosttblTeam(tblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblTeam.Add(tblTeam);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblTeam.fldTeamID }, tblTeam);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(tblTeam))]
        public IHttpActionResult DeletetblTeam(long id)
        {
            tblTeam tblTeam = db.tblTeam.Find(id);
            if (tblTeam == null)
            {
                return NotFound();
            }

            db.tblTeam.Remove(tblTeam);
            db.SaveChanges();

            return Ok(tblTeam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblTeamExists(long id)
        {
            return db.tblTeam.Count(e => e.fldTeamID == id) > 0;
        }
    }
}