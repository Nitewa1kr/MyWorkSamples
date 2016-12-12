using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewUsersVERBs.DAL;
using NewUsersVERBs.Models;

namespace NewUsersVERBs.Controllers
{
    public class NewUsersController : ApiController
    {
        private NewUsersDBContext db = new NewUsersDBContext();

        // GET: api/NewUsers
        public IQueryable<NewUsers> GetUsers()
        {
            return db.Users;
        }

        // GET: api/NewUsers/5
        [ResponseType(typeof(NewUsers))]
        public async Task<IHttpActionResult> GetNewUsers(int id)
        {
            NewUsers newUsers = await db.Users.FindAsync(id);
            if (newUsers == null)
            {
                return NotFound();
            }

            return Ok(newUsers);
        }

        // PUT: api/NewUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNewUsers(int id, NewUsers newUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newUsers.UserID)
            {
                return BadRequest();
            }

            db.Entry(newUsers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewUsersExists(id))
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

        // POST: api/NewUsers
        [ResponseType(typeof(NewUsers))]
        public async Task<IHttpActionResult> PostNewUsers(NewUsers newUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(newUsers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newUsers.UserID }, newUsers);
        }

        // DELETE: api/NewUsers/5
        [ResponseType(typeof(NewUsers))]
        public async Task<IHttpActionResult> DeleteNewUsers(int id)
        {
            NewUsers newUsers = await db.Users.FindAsync(id);
            if (newUsers == null)
            {
                return NotFound();
            }

            db.Users.Remove(newUsers);
            await db.SaveChangesAsync();

            return Ok(newUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewUsersExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}