using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PERSONAL_FILE_DTO
    {
        public int p_code { get; set; }
        public string CharacterTest { get; set; }

        public PERSONAL_FILE_DTO CONVERTtODTO(PERSONAL_FILE P)
        {
            return new PERSONAL_FILE_DTO()
            {
                  p_code=P.p_code,
                  CharacterTest=P.CharacterTest,

            };
        }
        public PERSONAL_FILE CONVERTFROMDTO(PERSONAL_FILE_DTO P)
            {
                return new PERSONAL_FILE()
                {
                    p_code = P.p_code,
                    CharacterTest = P.CharacterTest,

                };

            }

 
       
    }

}
