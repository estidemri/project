using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
      public class STEDENT_DTO
    {
        public int st_code { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> classCode { get; set; }
        public Nullable<bool> statous { get; set; }
        public Nullable<int> PersonalFilecCode { get; set; }
        public STEDENT_DTO CONVERTtOdto(STEDENTS S)
        {
            return new STEDENT_DTO()
            {
                st_code = S.st_code,
                id = S.id,
                firstName = S.firstName,
                lastName = S.lastName,
                classCode = S.class,
                statous = S.statous,
                PersonalFilecCode = S.PersonalFilecCode,

            };
        }
        public STEDENTS CONVERTFROMDTO(STEDENT_DTO S)
        {
            return new STEDENTS()
            {
                st_code = S.st_code,
                id = S.id,
                firstName = S.firstName,
                lastName = S.lastName,
                classCode = S.classCode,
                statous = S.statous,
                PersonalFilecCode = S.PersonalFilecCode,

            };
        }
    }
}
