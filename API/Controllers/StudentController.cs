using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public IEnumerable<STEDENT_DTO> Get()
        {
            return new List<STEDENT_DTO>();
        }
        // add swagger
        

        // POST: api/Student
        public void Post([FromBody]STEDENT_DTO value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]STEDENT_DTO value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
