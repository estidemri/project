using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;


namespace API.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        BL.student st = new student();
        [AcceptVerbs("GET", "POST")]
        [Route("addstudent")]
        [HttpPost]
        public int addstudent(STEDENT_DTO s)
        {
            try
            {
                st.Insert(s);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        [Route("updatestudent")]
        [HttpPost]
        public int updatestudent(STEDENT_DTO s)
        {
            try
            {
                st.Update(s);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        [Route("deleatestudent")]
        [HttpPost]
        public int deleatestudent(STEDENT_DTO s)
        {
            try
            {
                st.Delete(s);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

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
