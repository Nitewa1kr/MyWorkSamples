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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using UserODB.Models;

namespace UserODB.Controllers
{
    public class UserODatasController : ODataController
    {
        private UserODataContext db = new UserODataContext();

        // GET: odata/UserODatas
        [EnableQuery]
        public IQueryable<UserOData> GetUserODatas()
        {
            return db.UsersData;
        }

        // GET: odata/UserODatas(5)
        [EnableQuery]
        public SingleResult<UserOData> GetUserOData([FromODataUri] int key)
        {
            return SingleResult.Create(db.UsersData.Where(userOData => userOData.ID == key));
        }

        // PUT: odata/UserODatas(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<UserOData> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserOData userOData = await db.UsersData.FindAsync(key);
            if (userOData == null)
            {
                return NotFound();
            }

            patch.Put(userOData);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserODataExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userOData);
        }

        // POST: odata/UserODatas
        public async Task<IHttpActionResult> Post(UserOData userOData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersData.Add(userOData);
            await db.SaveChangesAsync();

            return Created(userOData);
        }

        // PATCH: odata/UserODatas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<UserOData> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserOData userOData = await db.UsersData.FindAsync(key);
            if (userOData == null)
            {
                return NotFound();
            }

            patch.Patch(userOData);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserODataExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userOData);
        }

        // DELETE: odata/UserODatas(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            UserOData userOData = await db.UsersData.FindAsync(key);
            if (userOData == null)
            {
                return NotFound();
            }

            db.UsersData.Remove(userOData);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserODataExists(int key)
        {
            return db.UsersData.Count(e => e.ID == key) > 0;
        }
    }
}
