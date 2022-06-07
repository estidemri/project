using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SchedulingDTO
    {
        public int sc_code { get; set; }
        public string SchedulingName { get; set; }
        public Nullable<System.DateTime> PlacementDate { get; set; }
        public Nullable<bool> L_Lay_down { get; set; }
        public Nullable<bool> MixedAges { get; set; }
        public Nullable<bool> FullRooms { get; set; }

        public SchedulingDTO CONVERTtODTO(Scheduling S)
        {
            return new SchedulingDTO()
            {
                 sc_code=S.sc_code,
                 SchedulingName=S.SchedulingName,
                 PlacementDate=S.PlacementDate,
                 L_Lay_down=S.L_Lay_down,
                 MixedAges=S.MixedAges,
                 FullRooms=S.FullRooms,
            };
        }
        public Scheduling CONVERTFROMDTO(SchedulingDTO S)
        {
            return new Scheduling()
            {
                sc_code = S.sc_code,
                SchedulingName = S.SchedulingName,
                PlacementDate = S.PlacementDate,
                L_Lay_down = S.L_Lay_down,
                MixedAges = S.MixedAges,
                FullRooms = S.FullRooms,
            };
        }

    }
}
