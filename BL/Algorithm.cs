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
    class Algorithm
    {
        public void DoWork(int maxNumOfBedsInRoom)
        {
            
            Bl1 bl = new Bl1();
            List<STEDENT_DTO> students = bl.GetDbSet<STEDENT_DTO>();
            STEDENT_DTO s = new STEDENT_DTO();
            //משתנים שיכילו את כמות הבנות שאמורות להיות בחדר מכל אילוץ
            int class1 = 0, class2 = 0, class3 = 0, class4 = 0, profession1 = 0, profession2 = 0, profession3 = 0, origin1 = 0, origin2 = 0, origin3 = 0, mentally1 = 0, mentally2 = 0, mentally3 = 0;
            int tziun = 0;
            FirstAlgorithm f = new FirstAlgorithm();
            Room[] rooms = f.RoomsAlgorithm(maxNumOfBedsInRoom, students);
            int[,] mat1 = new int[students.Count + 1, rooms.Length + 1];
            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                mat1[i, 0] = students[i].st_code;
            }
            //  for(int i = 0; i<mat1.GetLength(1); i++)
            //{
            //          mat1[0,i]=rooms[i].st_code;
            //       }
            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                class1 = rooms[i].Arr[0].L[0];

                class2 = rooms[i].Arr[0].L[1];

                class3 = rooms[i].Arr[0].L[2];

                class4 = rooms[i].Arr[0].L[3];

                profession1 = rooms[i].Arr[1].L[0];

                profession2 = rooms[i].Arr[1].L[1];

                profession3 = rooms[i].Arr[1].L[2];

                origin1 = rooms[i].Arr[2].L[0];


             origin1 = rooms[i].Arr[2].L[1];

                origin1 = rooms[i].Arr[2].L[2];

                mentally1 = rooms[i].Arr[3].L[0];

                mentally1 = rooms[i].Arr[3].L[1];

                mentally1 = rooms[i].Arr[3].L[2];
                tziun = 0;
                for (int j = 0; j < mat1.GetLength(1); j++)
                {
                    s = students.Where(st => st.st_code == mat1[i, 0]).First();
                    if (s.classCode == 1 && class1 > 0)
                    {
                        class1--;
                    }
                    else
                    {
                        if (s.classCode == 2 && class2 > 0) { class2--; }
                        else
                        {
                            if (s.classCode == 3 && class3 > 0) { class3--; }
                            else
                            {
                                if (s.classCode == 4 && class4 > 0) { class4--; }
                                else
                                {
                                    tziun += 5;

                                }

                            }

                        }

                    }



                    if (s.profession == 1 && profession1 > 0)
                    {
                        profession1--;
                    }
                    else
                    {
                        if (s.profession == 2 && profession2 > 0) { profession2--; }
                        else
                        {
                            if (s.profession == 3 && profession3 > 0) { profession3--; }
                            else
                            {

                                tziun += 5;

                            }

                        }

                    }
                    if (s.origin == 1 && origin1 > 0)
                    {
                        origin1--;
                    }
                    else
                    {
                        if (s.origin == 2 && origin2 > 0) { origin2--; }
                        else
                        {
                            if (s.origin == 3 && origin3 > 0) { origin3--; }
                            else
                            {

                                tziun += 5;

                            }

                        }

                    }
                    if (s.mentally == 1 && mentally1 > 0)
                    {
                        mentally1--;
                    }
                    else
                    {
                        if (s.mentally == 2 && mentally2 > 0) { mentally2--; }
                        else
                        {
                            if (s.mentally == 3 && mentally3 > 0) { mentally3--; }
                            else
                            {

                                tziun += 5;
                            }

                        }

                    }

                    mat1[i, j] = tziun;
                }
            }
        }
    }





