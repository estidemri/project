using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Bl1
    {

        DBConection dbCon;
        public Bl1()
        {
            dbCon = new DBConection();
        }
        public enum Result
        {
            IncorrectDetails,
            NotFound,
            Found
        }
        public List<T> GetDbSet<T>() where T : class
        {
            return dbCon.GetDbSet<T>();
        }
        public void AddToDB<T>(T entity) where T : class
        {
            dbCon.Execute<T>(entity, DBConection.ExecuteActions.Insert);
        }
        public void DeleteToDB<T>(T entity) where T : class
        {
            dbCon.Execute<T>(entity, DBConection.ExecuteActions.Delete);
        }
        public void UpdateToDB<T>(T entity) where T : class
        {
            dbCon.Execute<T>(entity, DBConection.ExecuteActions.Update);
        }
    }
}

