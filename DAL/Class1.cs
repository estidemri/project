//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Models;
//namespace MusicCopositionDAL
//{
//    public class DBConection
//    {
//        public DBConection() { }
//        public List<T> GetDbSet<T>() where T : class
//        {
//            using (estiEntities musicCompEntity = new estiEntities())
//            {
//                return musicCompEntity.GetDbSet<T>().ToList();
//            }
//        }
//        public enum ExecuteActions
//        {
//            Insert,
//            Update,
//            Delete
//        }
//        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
//        {
//            using (estiEntities esty = new estiEntities())
//            {
//                var model = esty.Set<T>();
//                switch (exAction)
//                {
//                    case ExecuteActions.Insert:
//                        model.Add(entity);
//                        break;
//                    case ExecuteActions.Update:
//                        model.Attach(entity);
//                        esty.Entry(entity).State = System.Data.Entity.EntityState.Modified;
//                        break;
//                    case ExecuteActions.Delete:
//                        model.Attach(entity);
//                        musicCompEntity.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
//                        break;
//                    default:
//                        break;
//                }
//                esty.SaveChanges();

//            }
//        }
//    }



////זימון הפונקציות הגנריות עבור הצגה והוספה:

//public class ClientsBL
//{
//    DBConection dbCon;
//    public List<Clients> listOfClients;
//    public ClientsBL()
//    {
//        dbCon = new DBConection();
//        listOfClients = dbCon.GetDbSet<Clients>().ToList();
//    }
//    public List<Clients> GetAllClients()
//    {
//        return listOfClients;
//    }
//    //הוספת לקוח
//    public int InsertClient(Clients clients)
//    {
//        if (listOfClients.Find(c => c.idC == clients.idC) == null)
//            try
//            {
//                dbCon.Execute<Clients>(new Clients() { codeCli = listOfClients.Max(c => c.codeCli) + 1, idC = clients.idC, fullNameC = clients.fullNameC.ToString(), pel1 = clients.pel1, pel2 = clients.pel2, email = clients.email, points = clients.points, status = clients.status, Appearances = clients.Appearances }, DBConection.ExecuteActions.Insert);
//                listOfClients = dbCon.GetDbSet<Clients>().ToList();
//                return listOfClients.First(c => c.idC == clients.idC).codeCli;
//            }
//            catch (Exception ex)
//            {
//                return 0;
//            }

//        return listOfClients.First(c => c.idC == clients.idC).codeCli;

//    }

//    //זימון הפונקציות מהBL לController בapi:
//    [RoutePrefix("api/client")] 
//    public class ClientController : ApiController
//    {
//        MusicCompositionBL.classes.ClientsBL clientsBL;
//        MusicCompositionBL.classes.PlayersBL playersBL;

//        [AcceptVerbs("GET", "POST")]
//        [Route("signup")]
//        [HttpPost]
//        public int SignUp(Clients clients)
//        {
//            clientsBL = new MusicCompositionBL.classes.ClientsBL();
//            return clientsBL.InsertClient(clients);
//        }




//        public DbSet<T> GetDbSet<T>() where T : class
//        {
//            return this.Set<T>();
//        }

//    }
//}

//}