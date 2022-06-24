using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BL
{
    public class room
    {
        DBConection dBCon;
        List<Models.ROOMS> listroom;
        List<Models.ROOM_DTO> listroomDTO;

        public room()
        {
            dBCon = new DBConection();
            listroom = dBCon.GetDbSet<ROOMS>();
            ConvertToDTO();
        }

        public int Insert(ROOM_DTO R)
        {

            dBCon.Execute<ROOMS>(R.CONVERTFROMDTO(),
                DBConection.ExecuteActions.Insert);
            listroom = dBCon.GetDbSet<ROOMS>();
            ConvertToDTO();
            return listroom.Max(a => a.r_code);

        }

        public int Update(ROOM_DTO R)
        {
            try
            {
                if (listroomDTO.Find(a => a.r_code == R.r_code) != null)
                {
                    dBCon.Execute<ROOMS>(R.CONVERTFROMDTO(), DBConection.ExecuteActions.Update);
                    listroom = dBCon.GetDbSet<ROOMS>();
                    ConvertToDTO();
                    return 1;
                }
                return -1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(ROOM_DTO R)
        {
            try
            {
                if (listroomDTO.Find(a => a.r_code == R.r_code) != null)
                {
                    dBCon.Execute<ROOMS>(R.CONVERTFROMDTO(), DBConection.ExecuteActions.Delete);
                    listroom = dBCon.GetDbSet<ROOMS>();
                    ConvertToDTO();
                    return 1;
                }
                return -1;
            }
            catch
            {
                return 0;
            }
        }

        public List<ROOM_DTO> DisplayAllROOMS()
        {
            ConvertToDTO();
            return listroomDTO;
        }
        public void ConvertToDTO()
        {
            listroomDTO = new List<ROOM_DTO>();
            foreach (var r in listroom)
            {
                listroomDTO.Add(ROOM_DTO.CONVERTtODTO(r));
            }
        }

    }
}

