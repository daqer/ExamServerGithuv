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
    public class TournamentsController : ApiController
    {
        private db_ExamProjectTournamentEntities db = new db_ExamProjectTournamentEntities();

        // GET: api/Tournaments
        public IQueryable<tblTournament> GettblTournament()
        {
            return db.tblTournament;
        }

        // GET: api/Tournaments/5
        [ResponseType(typeof(tblTournament))]
        public IHttpActionResult GettblTournament(int id)
        {
            tblTournament tblTournament = db.tblTournament.Find(id);
            if (tblTournament == null)
            {
                return NotFound();
            }

            return Ok(tblTournament);
        }

        // PUT: api/Tournaments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblTournament(int id, tblTournament tblTournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTournament.fldTournamentID)
            {
                return BadRequest();
            }

            db.Entry(tblTournament).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTournamentExists(id))
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

        // POST: api/Tournaments
        [ResponseType(typeof(tblTournament))]
        public IHttpActionResult PosttblTournament(tblTournament tblTournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblTournament.Add(tblTournament);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblTournamentExists(tblTournament.fldTournamentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblTournament.fldTournamentID }, tblTournament);
        }

        // DELETE: api/Tournaments/5
        [ResponseType(typeof(tblTournament))]
        public IHttpActionResult DeletetblTournament(int id)
        {
            tblTournament tblTournament = db.tblTournament.Find(id);
            if (tblTournament == null)
            {
                return NotFound();
            }

            db.tblTournament.Remove(tblTournament);
            db.SaveChanges();

            return Ok(tblTournament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblTournamentExists(int id)
        {
            return db.tblTournament.Count(e => e.fldTournamentID == id) > 0;
        }
    }
}