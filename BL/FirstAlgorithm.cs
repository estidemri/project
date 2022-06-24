using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
   public class FirstAlgorithm
    {
        //שלא תהיה סתירה בין האילוצים
        public class Room
        {
            private int beds;

            public int Beds
            {
                get { return beds; }
                set { beds = value; }
            }

            private ArrIlutzim[] arr = new ArrIlutzim[5];
            public ArrIlutzim[]Arr
            {
                get { return arr; }
                set { arr = value; }
            }
            //איפוס מערך האילוצים של חדר
            public void RestartArrIlutzim()
            {
                //כיתה
                arr[0].L = new int[4] { 0, 0, 0, 0 };
                //מגמה
                arr[1].L = new int[3] { 0, 0, 0 };
                //מנטליות
                arr[2].L = new int[3] { 0, 0, 0 };
                //מוצא
                arr[3].L = new int[3] { 0, 0, 0 };
                //קוי אופי
                arr[4].L = new int[4] { 0, 0, 0, 0 };
            }
        }
       public class ArrIlutzim
        {
            private int[] l;
            public int[] L
            {
                get { return l; }
                set { l = value; }
            }
        }
        //האלגריתם לאיפיון החדר 
        public Room[] RoomsAlgorithm(int maxNumOfBedsInRoom)
        {
            Bl1 bl = new Bl1();
            List<STEDENT_DTO> listOfStudents = bl.GetDbSet<STEDENT_DTO>();
            int numOfStudents = listOfStudents.Count;
            //מס החדרים, לפי מס הבנות לחלק למס המיטות המקסימלי בכל חדר, ואם יש שארית, יתווסף עוד חדר שאפשר לשבץ בו
            int numOfRooms = (numOfStudents % maxNumOfBedsInRoom == 0) ? numOfStudents / maxNumOfBedsInRoom : numOfStudents / maxNumOfBedsInRoom + 1;
            //מערך של החדרים לשיבוץ בגודל של מס' החדרים שבהם נשבץ  
            Room[] rooms = new Room[numOfRooms];
            //מס' מיטות בכל חדר
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i].Beds = maxNumOfBedsInRoom;
                //זימון פונקציה שמאפסת את מערך האילוצים
                rooms[i].RestartArrIlutzim();
            }


            //אילוץ שכבת גיל
            //מס' בנות שאמורות להיות בכל חדר מכל שכבת גיל
            //מספר הבנות מכל כיתה
            int num1 = listOfStudents.Where(s => s.classCode == 1).Count();
            int num2 = listOfStudents.Where(s => s.classCode == 2).Count();
            int num3 = listOfStudents.Where(s => s.classCode == 3).Count();
            int num4 = listOfStudents.Where(s => s.classCode == 4).Count();

            // כמה בנות מכל כיתה אמורות להכנס לכל חדר
            if (num1 > 0)
            {
                for (int i = 0; i < numOfRooms; i++)
                {
                    int beds = rooms[i].Beds;
                    if (num1 > 0 && beds > 0)
                    {
                        if (num1 < beds)
                        {
                            rooms[i].Arr[0].L[0] += num1;
                            num1 = 0;
                        }
                        else
                        {
                            rooms[i].Arr[0].L[0] += beds;
                            num1 -= beds;
                        }
                        rooms[i].Beds -= rooms[i].Arr[0].L[0];
                    }
                    else continue;
                }
            }
            if (num2 > 0)
            {
                for (int i = 0; i < numOfRooms; i++)
                {
                    int beds = rooms[i].Beds;
                    if (num2 > 0 && beds > 0)
                    {
                        if (num2 < beds)
                        {
                            rooms[i].Arr[0].L[1] += num2;
                            num2 = 0;
                        }
                        else
                        {
                            rooms[i].Arr[0].L[1] += beds;
                            num2 -= beds;
                        }
                        rooms[i].Beds -= rooms[i].Arr[0].L[1];
                    }
                    else continue;
                }
            }
            if (num3 > 0)
            {
                for (int i = 0; i < numOfRooms; i++)
                {
                    int beds = rooms[i].Beds;
                    if (num3 > 0 && beds > 0)
                    {
                        if (num3 < beds && beds > 0)
                        {
                            rooms[i].Arr[0].L[2] += num3;
                            num3 = 0;
                        }
                        else
                        {
                            rooms[i].Arr[0].L[2] += beds;
                            num3 -= beds;
                        }
                        rooms[i].Beds -= rooms[i].Arr[0].L[2];
                    }
                    else continue;
                }
            }
            if (num4 > 0)
            {
                for (int i = 0; i < numOfRooms; i++)
                {
                    int beds = rooms[i].Beds;
                    if (num2 > 0 && beds > 0)
                    {
                        if (num4 < beds)
                        {
                            rooms[i].Arr[0].L[3] += num4;
                            num2 = 0;
                        }
                        else
                        {
                            rooms[i].Arr[0].L[3] += beds;
                            num4 -= beds;
                        }
                        rooms[i].Beds -= rooms[i].Arr[0].L[3];
                    }
                    else continue;
                }
            }
            // כמה בנות מכל מגמה אמורות להכנס לכל חדר
            //מגמת הנדסת תוכנה
            int profession1 = listOfStudents.Where(s => s.profession == 1).Count();
            //מגמת חשבונאות
            int profession2 = listOfStudents.Where(s => s.profession== 2).Count();
            //מגמת משאבי אנוש
            int profession3 = listOfStudents.Where(s => s.profession == 3).Count();

            //כמות הבנות הממוצעת מהנדסת תוכנה שצריכה להיות בכל חדר
            int profession1InRoom = profession1 / numOfRooms;
            //כמות הבנות הממוצעת מחשבנאות שצריכה להיות בכל חדר
            int profession2InRoom = profession2 / numOfRooms;
            //כמות הבנות הממוצעת משאבי אנוש שצריכה להיות בכל חדר
            int profession3InRoom = profession3 / numOfRooms;

            //כמות הבנות שנשארה מהנדסת תוכנה לאחר החלוקה הממוצעת
            int modProfession1 = profession1 % numOfRooms;
            //כמות הבנות שנשארה מהנדסת תוכנה לאחר החלוקה הממוצעת
            int modProfession2 = profession2 % numOfRooms;
            //כמות הבנות שנשארה מהנדסת תוכנה לאחר החלוקה הממוצעת
            int modProfession3 = profession3 % numOfRooms;


            // כמה בנות מכל מנטליות אמורות להכנס לכל חדר
            //חוזרות בתשובה
            int mentally1 = listOfStudents.Where(s => s.mentally == 1).Count();
            //מתחזקות
            int mentally2 = listOfStudents.Where(s => s.mentally == 2).Count();
            //חרדיות מבית
            int mentally3 = listOfStudents.Where(s => s.mentally == 3).Count();

            //כמות הבנות הממוצעת חוזרות בתשובה שצריכה להיות בכל חדר
            int mentally1InRoom = mentally1 / numOfRooms;
            //כמות הבנות הממוצעת מתחזקות שצריכה להיות בכל חדר
            int mentally2InRoom = mentally2 / numOfRooms;
            //כמות הבנות הממוצעת מבית חרדי שצריכה להיות בכל חדר
            int mentally3InRoom = mentally3 / numOfRooms;

            //כמות הבנות שנשארה חוזרות בתשובה לאחר החלוקה הממוצעת
            int modmentally1 = mentally1 % numOfRooms;
            //כמות הבנות שנשארה מתחזקות לאחר החלוקה הממוצעת
            int modmentally2 = mentally2 % numOfRooms;
            //כמות הבנות שנשארה מבית חרדי  לאחר החלוקה הממוצעת
            int modmentally3 = mentally3 % numOfRooms;



            // כמה בנות מכל מוצא אמורות להכנס לכל חדר
            //מישראל
            int origin1 = listOfStudents.Where(s => s.origin == 1).Count();
            //מאמריקה
            int origin2 = listOfStudents.Where(s => s.origin == 2).Count();
            //מארופה
            int origin3 = listOfStudents.Where(s => s.origin == 3).Count();

            //כמות הבנות הממוצעת מישראל שצריכה להיות בכל חדר
            int origin1InRoom = origin1 / numOfRooms;
            //כמות הבנות הממוצעת מאמריקה שצריכה להיות בכל חדר
            int origin2InRoom = origin2 / numOfRooms;
            //כמות הבנות הממוצעת מארופה שצריכה להיות בכל חדר
            int origin3InRoom = origin3 / numOfRooms;

            //כמות הבנות שנשארה מישראל לאחר החלוקה הממוצעת
            int modorigin1 = origin1 % numOfRooms;
            //כמות הבנות שנשארה מאמריקה לאחר החלוקה הממוצעת
            int modorigin2 = origin2 % numOfRooms;
            //כמות הבנות שנשארה מארופה לאחר החלוקה הממוצעת
            int modorigin3 = origin3 % numOfRooms;
            for (int i = 0; i < numOfRooms; i++)
            {
                //מגמה
                if (modProfession1 == 0)
                    rooms[i].Arr[1].L[0] = profession1InRoom;
                else
                {
                    rooms[i].Arr[1].L[0] = profession1InRoom + 1;
                    modProfession1--;
                }
                if (modProfession2 == 0)
                    rooms[i].Arr[1].L[1] = profession2InRoom;
                else
                {
                    rooms[i].Arr[1].L[1] = profession2InRoom + 1;
                    modProfession2--;
                }
                if (modProfession3 == 0)
                    rooms[i].Arr[1].L[2] = profession3InRoom;
                else
                {
                    rooms[i].Arr[1].L[2] = profession3InRoom + 1;
                    modProfession3--;
                }

                //מנטליות
                if (modmentally1 == 0)
                    rooms[i].Arr[1].L[0] = mentally1InRoom;
                else
                {
                    rooms[i].Arr[1].L[0] = mentally1InRoom + 1;
                    modmentally1--;
                }
                if (modmentally2 == 0)
                    rooms[i].Arr[1].L[1] = mentally2InRoom;
                else
                {
                    rooms[i].Arr[1].L[1] = mentally2InRoom + 1;
                    modmentally2--;
                }
                if (modmentally3 == 0)
                    rooms[i].Arr[1].L[2] = mentally3InRoom;
                else
                {
                    rooms[i].Arr[1].L[2] = mentally3InRoom + 1;
                    modmentally3--;
                }
                //מוצא
                if (modorigin1 == 0)
                    rooms[i].Arr[1].L[0] = origin1InRoom;
                else
                {
                    rooms[i].Arr[1].L[0] = origin1InRoom + 1;
                    modorigin1--;
                }
                if (modorigin2 == 0)
                    rooms[i].Arr[1].L[1] = origin2InRoom;
                else
                {
                    rooms[i].Arr[1].L[1] = origin2InRoom + 1;
                    modorigin2--;
                }
                if (modorigin3 == 0)
                    rooms[i].Arr[1].L[2] = origin3InRoom;
                else
                {
                    rooms[i].Arr[1].L[2] = origin3InRoom + 1;
                    modorigin3--;
                }
            }
            return rooms;
        }
    }
}
