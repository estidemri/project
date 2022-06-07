using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FLOOR_DTO
    {
        public int f_code { get; set; }
        public string FloorName { get; set; }

        public FLOOR_DTO CONVERTtODTO(FLOOR1 F)
        {
            return new FLOOR_DTO()
            {
                f_code = F.f_code,
                FloorName = F.FloorName,
            };
        }

        public FLOOR1 CONVERTFROMDTO(FLOOR_DTO F)
        {
            return new FLOOR1()
            {
                f_code = F.f_code,
                FloorName = F.FloorName,
            };
        }
    }
}
