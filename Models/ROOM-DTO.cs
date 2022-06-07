using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ROOM_DTO
    {
        public int r_code { get; set; }
        public Nullable<int> number_of_beds { get; set; }
        public Nullable<int> floor_code { get; set; }

        public ROOM_DTO CONVERTtODTO(ROOMS R)
        {
            return new ROOM_DTO()
            {
                 r_code=R.r_code,
                 number_of_beds=R.number_of_beds,
                 
            };
        }

        public ROOMS CONVERTFROMDTO(ROOM_DTO R)
        {
            return new ROOMS()
            {
                r_code = R.r_code,
                number_of_beds = R.number_of_beds,
               
            };
        }
    }
}