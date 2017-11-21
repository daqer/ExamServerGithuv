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
    public class ProjectsController : ApiController
    {
        private db_ExamProjectTournamentEntities db = new db_ExamProjectTournamentEntities();

        // GET: api/Projects
        public IQueryable<tblProject> GettblProject()
        {
            return db.tblProject;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(tblProject))]
        public IHttpActionResult GettblProject(int id)
        {
            tblProject tblProject = db.tblProject.Find(id);
            if (tblProject == null)
            {
                return NotFound();
            }

            return Ok(tblProject);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblProject(int id, tblProject tblProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblProject.fldProjectID)
            {
                return BadRequest();
            }

            db.Entry(tblProject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(tblProject))]
        public IHttpActionResult PosttblProject(tblProject tblProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblProject.Add(tblProject);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblProjectExists(tblProject.fldProjectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblProject.fldProjectID }, tblProject);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(tblProject))]
        public IHttpActionResult DeletetblProject(int id)
        {
            tblProject tblProject = db.tblProject.Find(id);
            if (tblProject == null)
            {
                return NotFound();
            }

            db.tblProject.Remove(tblProject);
            db.SaveChanges();

            return Ok(tblProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblProjectExists(int id)
        {
            return db.tblProject.Count(e => e.fldProjectID == id) > 0;
        }
    }
}