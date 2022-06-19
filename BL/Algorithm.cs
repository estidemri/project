using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BL;
using static BL.FirstAlgorithm;

namespace BL
{
    public class Algorithm
    {
        public int[,] MakeMat(int maxNumOfBedsInRoom, List<STEDENT_DTO> students)
        {

            Bl1 bl = new Bl1();
            //List<STEDENT_DTO> students = bl.GetDbSet<STEDENT_DTO>();
            STEDENT_DTO s = new STEDENT_DTO();
            int tziun = 0;
            FirstAlgorithm f = new FirstAlgorithm();
            Room[] rooms = f.RoomsAlgorithm(maxNumOfBedsInRoom);

            //מטריצה שתכיל את כמות הבנות שאמורות להיות בחדר מכל אילוץ
            int[,] ilutzimMat = new int[rooms.Length, 13];
            for (int i = 0; i < ilutzimMat.GetLength(0); i++)
            {
                for (int j = 0; j < ilutzimMat.GetLength(1); j++)
                {
                     ilutzimMat[i,j] = rooms[i].Arr[0].L[0];
                     ilutzimMat[i,j] = rooms[i].Arr[0].L[1];
                     ilutzimMat[i,j] = rooms[i].Arr[0].L[2];
                     ilutzimMat[i,j] = rooms[i].Arr[0].L[3];
                    
                     ilutzimMat[i,j] = rooms[i].Arr[1].L[0];
                     ilutzimMat[i,j] = rooms[i].Arr[1].L[1];
                     ilutzimMat[i,j] = rooms[i].Arr[1].L[2];

                     ilutzimMat[i,j] = rooms[i].Arr[2].L[0];
                     ilutzimMat[i,j] = rooms[i].Arr[2].L[1];
                     ilutzimMat[i,j] = rooms[i].Arr[2].L[2];
             
                     ilutzimMat[i,j] = rooms[i].Arr[3].L[0];
                     ilutzimMat[i,j] = rooms[i].Arr[3].L[1];
                     ilutzimMat[i,j] = rooms[i].Arr[3].L[2];
                }
            }
            int[,] mat1 = new int[students.Count + 1, rooms.Length + 1];
            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                mat1[i, 0] = students[i].st_code;
            }
            //לשנות שיהיה בלי כותרת
            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                tziun = 0;
                for (int j = 0; j < mat1.GetLength(1); j++)
                {
                    s = students.Where(st => st.st_code == mat1[i, 0]).First();
                    if (s.classCode == 1 && ilutzimMat[j,0] > 0)
                    {
                        ilutzimMat[j, 0]--;
                    }
                    else
                    {
                        if (s.classCode == 2 && ilutzimMat[j, 1] > 0) { ilutzimMat[j, 1]--; }
                        else
                        {
                            if (s.classCode == 3 && ilutzimMat[j, 2] > 0) { ilutzimMat[j, 2]--; }
                            else
                            {
                                if (s.classCode == 4 && ilutzimMat[j, 3] > 0) { ilutzimMat[j, 3]--; }
                                else
                                {
                                    tziun += 5;

                                }

                            }

                        }

                    }


 
                    if (s.profession == 1 && ilutzimMat[j, 4] > 0)
                    {
                        ilutzimMat[j, 4]--;
                    }
                    else
                    {
                        if (s.profession == 2 && ilutzimMat[j, 5] > 0) { ilutzimMat[j, 5]--; }
                        else
                        {
                            if (s.profession == 3 && ilutzimMat[j, 6] > 0) { ilutzimMat[j, 6]--; }
                            else
                            {

                                tziun += 5;

                            }

                        }

                    }
                    if (s.origin == 1 && ilutzimMat[j, 7] > 0)
                    {
                        ilutzimMat[j, 7]--;
                    }
                    else
                    {
                        if (s.origin == 2 && ilutzimMat[j, 8] > 0) { ilutzimMat[j, 8]--; }
                        else
                        {
                            if (s.origin == 3 && ilutzimMat[j, 9] > 0) { ilutzimMat[j, 9]--; }
                            else
                            {

                                tziun += 4;

                            }

                        }

                    }
                    if (s.mentally == 1 && ilutzimMat[j, 10] > 0)
                    {
                        ilutzimMat[j, 10]--;
                    }
                    else
                    {
                        if (s.mentally == 2 && ilutzimMat[j, 11] > 0) { ilutzimMat[j, 11]--; }
                        else
                        {
                            if (s.mentally == 3 && ilutzimMat[j, 12] > 0) { ilutzimMat[j, 12]--; }
                            else
                            {

                                tziun += 4;
                            }

                        }

                    }

                    mat1[i, j] = tziun;
                }
            }
            return mat1;
        }
        // פונקציה היוצרת 4 סוגי שיבוצים רנדומליים, בכל פעם לפי סדר שונה, ואת המטריצות שנוצרות שולחת לאלגוריתם ההונגרי

        public void SendToHungarianAlgorithm(int maxBedsInRoom)
        {
            Bl1 bl = new Bl1();
            List<STEDENT_DTO> students = bl.GetDbSet<STEDENT_DTO>();
            List<STEDENT_DTO> students1 = bl.GetDbSet<STEDENT_DTO>();
            List<STEDENT_DTO> students2 = bl.GetDbSet<STEDENT_DTO>();
            int[,] mat1 =MakeMat(maxBedsInRoom,students);
            students1.Reverse();
            int[,] mat2 = MakeMat(maxBedsInRoom, students1);
            int stdCount = students1.Count;
            students2.RemoveRange(stdCount / 2, stdCount - stdCount / 2);
            students1.RemoveRange(stdCount / 2, stdCount - stdCount / 2);
            students1.InsertRange(0, students2);
            int[,] mat3 = MakeMat(maxBedsInRoom,students1);
            students1.Reverse();
            int[,] mat4 = MakeMat(maxBedsInRoom,students1);

            //איך בודקים מהו השיבוץ הטוב ביותר מבין השיבוצים ???????
            int[] arr1 = HungarianAlgorithm.FindAssignments(mat1);
            int[] arr2 = HungarianAlgorithm.FindAssignments(mat2);
            int[] arr3 = HungarianAlgorithm.FindAssignments(mat3);
            int[] arr4 = HungarianAlgorithm.FindAssignments(mat4);
        }
    }
}





