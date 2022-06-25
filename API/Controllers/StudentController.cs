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
        [Route("addStudent")]
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
        [Route("updateStudent")]
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

        [Route("doAlgorithm")]
        [HttpGet]
        public Dictionary<int, List<string>> doAlgorithm(int maxNumOfBeds)
        {
            try
            {
               var alg = new Algorithm();
                var res = alg.DoAlgorithem(maxNumOfBeds);
                return res;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        // GET: api/Student
        public IEnumerable<STEDENT_DTO> Get()
    {
        return st.DisplayAllStudent();
    }

  
    }
}
