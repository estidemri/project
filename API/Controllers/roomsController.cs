using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;

namespace API.Controllers
{
    public class roomsController : ApiController
    {

        [RoutePrefix("api/room")]
        public class CompanyController : ApiController
        {
            BL.room ro = new BL.room();
            [AcceptVerbs("GET", "POST")]
            [Route("addroom")]
            [HttpPost]
            public int addroom(ROOM_DTO r)
            {
                try
                {
                    ro.Insert(r);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            [Route("updateroom")]
            [HttpPost]
            public int updateroom(ROOM_DTO r)
            {
                try
                {
                    ro.Update(r);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            [Route("deleateroom")]
            [HttpPost]
            public int deleateroom(ROOM_DTO r)
            {
                try
                {
                    ro.Delete(r);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }

        }
    }
}
