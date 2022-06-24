using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public class student
    {
            DBConection dBCon;
            List<Models.STEDENTS> liststudent;
            List<Models.STEDENT_DTO> liststudentDTO;

            public student()
            {
                dBCon = new DBConection();
                liststudent = dBCon.GetDbSet<STEDENTS>();
                ConvertToDTO();
            }

            public int Insert(STEDENT_DTO S)
            {
                try
                {
                    if (liststudentDTO.Find(a => a.id == S.id) == null)
                    {
                        dBCon.Execute<STEDENTS>(S.CONVERTFROMDTO(), DBConection.ExecuteActions.Insert);
                        liststudent = dBCon.GetDbSet<STEDENTS>();
                        ConvertToDTO();
                        return liststudent.Max(a => a.classCode  );
                    }
                    return -1;
                }
                catch
                {
                    return 0;
                }
            }

            public int Update(STEDENT_DTO S)
            {
                try
                {
                if (liststudentDTO.Find(a => a.id == S.id) != null)
                    {
                        dBCon.Execute<STEDENTS>(S.CONVERTFROMDTO(), DBConection.ExecuteActions.Update);
                        liststudent = dBCon.GetDbSet<STEDENTS>();
                        ConvertToDTO();
                        return 1;
                    }
                    return -1;
                }
                catch(Exception e)
                {
                    return 0;
                }
            }

            public int Delete(STEDENT_DTO S)
            {
                try
                {
                if (liststudentDTO.Find(a => a.id == S.id) != null)
                    {
                        dBCon.Execute<STEDENTS>(S.CONVERTFROMDTO(), DBConection.ExecuteActions.Delete);
                        liststudent = dBCon.GetDbSet<STEDENTS>();
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

            public List<STEDENT_DTO> DisplayAllStudent()
            {
                ConvertToDTO();
                return liststudentDTO;
            }
            public void ConvertToDTO()
            {
                liststudentDTO = new List<STEDENT_DTO>();
                foreach (var s in liststudent)
                {
                    liststudentDTO.Add(STEDENT_DTO.CONVERTtOdto(s));
                }
            }

        }
    }

