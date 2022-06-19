using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
      public  class STEDENT_DTO
    {
        public int st_code { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int profession { get; set; }
        public int origin { get; set; }
        public int mentally { get; set; }
        public int PersonalFilecCode { get; set; }
        public int classCode { get; set; }
        public static STEDENT_DTO CONVERTtOdto(STEDENT S)
        {
            return new STEDENT_DTO()
            {
                 st_code = S.st_code,
                id = S.id,
                firstName = S.firstName,
                lastName = S.lastName,
                profession = S.profession,
                origin = S.origin,
                mentally = S.mentally,
                PersonalFilecCode = S.PersonalFilecCode,
                classCode = S.classCode,
            };
        }
        public STEDENT CONVERTFROMDTO()
        {
            return new STEDENT()
            {
                st_code = this.st_code,
                id = this.id,
                firstName = this.firstName,
                lastName = this.lastName,
                profession = this.profession,
                origin = this.origin,
                mentally = this.mentally,
                PersonalFilecCode = this.PersonalFilecCode,
                classCode = this.classCode,

            };
        }
    }
}
