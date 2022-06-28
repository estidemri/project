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
                var dic = alg.SendToHungarianAlgorithm(maxNumOfBeds);
                var res = alg.DoAlgorithem(maxNumOfBeds, dic);
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [Route("getPlacements")]
        [HttpGet]
        public Dictionary<int, List<string>> GetDic()
        {
            return st.DisplayAllStudent().GroupBy(s => s.classCode)
                .ToDictionary(g => g.Key
                , g => g.Select(s => s.firstName + " " + s.lastName).ToList());
        }

        // GET: api/Student
        public IEnumerable<STEDENT_DTO> Get()
        {
            return st.DisplayAllStudent();
        }


    }
}
