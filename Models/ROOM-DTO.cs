using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ROOM_DTO
    {
        //קוד חדר
        public int r_code { get; set; }
        public Nullable<int> number_of_beds { get; set; }
        

        public static  ROOM_DTO CONVERTtODTO(ROOMS R)
        {
            return new ROOM_DTO()
            {
                 r_code=R.r_code,
                 number_of_beds=R.number_of_beds,
                 
            };
        }

        public ROOMS CONVERTFROMDTO()
        {
            return new ROOMS()
            {
                r_code = this.r_code,
                number_of_beds = (int)this.number_of_beds,
               
            };
        }
    }
}