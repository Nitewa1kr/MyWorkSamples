using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NewStudentsJQ.Models;
using NewStudentsJQ.DAL;

namespace NewStudentsJQ.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentsDBContext db = new StudentsDBContext();

        public IEnumerable<NewStudents> GetAllStudents()
        {
            return db.Students;
        }
    }
}
