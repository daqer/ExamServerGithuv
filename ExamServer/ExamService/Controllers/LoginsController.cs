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
    public class LoginsController : ApiController
    {
        private db_ExamProjectTournamentEntities db = new db_ExamProjectTournamentEntities();

        // GET: api/Logins
        public IQueryable<tblLogin> GettblLogin()
        {
            return db.tblLogin;
        }

        // GET: api/Logins/5
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult GettblLogin(long id)
        {
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            return Ok(tblLogin);
        }

        // PUT: api/Logins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblLogin(long id, tblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLogin.fldLoginID)
            {
                return BadRequest();
            }

            db.Entry(tblLogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblLoginExists(id))
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

        // POST: api/Logins
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult PosttblLogin(tblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblLogin.Add(tblLogin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblLogin.fldLoginID }, tblLogin);
        }

        // DELETE: api/Logins/5
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult DeletetblLogin(long id)
        {
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            db.tblLogin.Remove(tblLogin);
            db.SaveChanges();

            return Ok(tblLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblLoginExists(long id)
        {
            return db.tblLogin.Count(e => e.fldLoginID == id) > 0;
        }
    }
}