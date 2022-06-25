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
        public Dictionary<int, List<string>> DoAlgorithem(int maxNumOfBedsInRoom)
        {
            //do the algorithem and save in the DB!!!!
            var studentsDic = SendToHungarianAlgorithm(maxNumOfBedsInRoom);

            var finalDic = new Dictionary<int, List<string>>();
            foreach (var s in studentsDic)
            {

                var student = students.Find(ss => ss.st_code == s.Key);
                if (!finalDic.ContainsKey(s.Value))
                {
                    finalDic.Add(s.Value, new List<string>());
                }
                finalDic[s.Value].Add(student.firstName + " " + student.lastName);

            }
            return finalDic;

        }
        public int[,] MakeMat(int maxNumOfBedsInRoom, List<STEDENTS> students)
        {

            Bl1 bl = new Bl1();
            //List<STEDENTS> students = bl.GetDbSet<STEDENTS>();
            STEDENTS s = new STEDENTS();
            int tziun = 0;
            FirstAlgorithm f = new FirstAlgorithm();
            Room[] rooms = f.RoomsAlgorithm(maxNumOfBedsInRoom);

            //מטריצה שתכיל את כמות הבנות שאמורות להיות בחדר מכל אילוץ
            int[,] ilutzimMat = new int[rooms.Length, 13];
            for (int i = 0; i < ilutzimMat.GetLength(0); i++)
            {
                for (int j = 0; j < ilutzimMat.GetLength(1); j++)
                {
                    ilutzimMat[i, j] = rooms[i].Arr[0].L[0];
                    ilutzimMat[i, j] = rooms[i].Arr[0].L[1];
                    ilutzimMat[i, j] = rooms[i].Arr[0].L[2];
                    ilutzimMat[i, j] = rooms[i].Arr[0].L[3];

                    ilutzimMat[i, j] = rooms[i].Arr[1].L[0];
                    ilutzimMat[i, j] = rooms[i].Arr[1].L[1];
                    ilutzimMat[i, j] = rooms[i].Arr[1].L[2];

                    ilutzimMat[i, j] = rooms[i].Arr[2].L[0];
                    ilutzimMat[i, j] = rooms[i].Arr[2].L[1];
                    ilutzimMat[i, j] = rooms[i].Arr[2].L[2];

                    ilutzimMat[i, j] = rooms[i].Arr[3].L[0];
                    ilutzimMat[i, j] = rooms[i].Arr[3].L[1];
                    ilutzimMat[i, j] = rooms[i].Arr[3].L[2];
                }
            }
            //int[,] mat1 = new int[students.Count, rooms.Length ];
            int[,] mat1 = new int[students.Count, students.Count];


            //for (int i = 0; i < mat1.GetLength(0); i++)
            //{
            //    mat1[i, 0] = students[i].st_code;
            //}

            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                tziun = 0;
                for (int j = 0; j < rooms.Length; j++)
                {
                    s = students[i];
                    if (s.classCode == 1 && ilutzimMat[j, 0] > 0)
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

            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                for (int j = rooms.Length; j < mat1.GetLength(1); j++)
                {
                    mat1[i, j] = mat1[i, j - rooms.Length];
                }
            }
            return mat1;
        }
        // פונקציה היוצרת 4 סוגי שיבוצים רנדומליים, בכל פעם לפי סדר שונה, ואת המטריצות שנוצרות שולחת לאלגוריתם ההונגרי

        private List<STEDENTS> students;

        public Dictionary<int, int> SendToHungarianAlgorithm(int maxBedsInRoom)
        {
            Bl1 bl = new Bl1();
            //יצירת 4 רשימות שבכל אחת ייכנסו התלמידות לפי הסדר שמופיעות במטריצה של כל אחד מהשיבוצים
            students = bl.GetDbSet<STEDENTS>();
            List<STEDENTS> students1 = new List<STEDENTS>(students);
            List<STEDENTS> students2 = new List<STEDENTS>(students);
            List<STEDENTS> students3 = new List<STEDENTS>(students);
            List<STEDENTS> students4 = new List<STEDENTS>(students);
            List<STEDENTS> students5 = new List<STEDENTS>(students);
            int numOfRooms = bl.GetDbSet<ROOMS>().Count;

            int[,] helpMat = new int[students.Count, students.Count];
            int[,] mat1 = MakeMat(maxBedsInRoom, students);
            students1.Reverse();
            int[,] mat2 = MakeMat(maxBedsInRoom, students1);
            int stdCount = students1.Count;
            students5.RemoveRange(0, stdCount / 2);
            students3.RemoveRange(stdCount / 2, stdCount - stdCount / 2);
            students3.InsertRange(0, students5);
            int[,] mat3 = MakeMat(maxBedsInRoom, students3);
            students4.Clear();
            students3.ForEach(s => students4.Add(s));
            students4.Reverse();
            int[,] mat4 = MakeMat(maxBedsInRoom, students4);

            Dictionary<int, int> minDict = new Dictionary<int, int>();
            int minMark = 0, mark = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < mat1.GetLength(0); i++)
            {
                for (int j = 0; j < mat1.GetLength(1); j++)
                {
                    helpMat[i, j] = mat1[i, j];
                }
            }
            int[] arr1 = HungarianAlgorithm.FindAssignments(mat1);
            for (int i = 0; i < arr1.Length; i++)
            {
                dict.Add(students[i].st_code, arr1[i] - ((arr1[i] / numOfRooms) * numOfRooms));
                mark += helpMat[i, dict[students[i].st_code]];
            }


            minMark = mark;
            minDict.Clear();
            foreach (var item in dict)
            {
                minDict.Add(item.Key, item.Value);
            }

            dict.Clear();
            mark = 0;
            for (int i = 0; i < mat2.GetLength(0); i++)
            {
                for (int j = 0; j < mat2.GetLength(1); j++)
                {
                    helpMat[i, j] = mat2[i, j];
                }
            }
            int[] arr2 = HungarianAlgorithm.FindAssignments(mat2);
            for (int i = 0; i < arr2.Length; i++)
            {
                dict.Add(students1[i].st_code, arr2[i] - ((arr2[i] / numOfRooms) * numOfRooms));
                mark += helpMat[i, dict[students1[i].st_code]];
            }
            if (mark < minMark)
            {
                minMark = mark;
                minDict.Clear();
                foreach (var item in dict)
                {
                    minDict.Add(item.Key, item.Value);
                }
            }
            dict.Clear();
            mark = 0;

            for (int i = 0; i < mat3.GetLength(0); i++)
            {
                for (int j = 0; j < mat3.GetLength(1); j++)
                {
                    helpMat[i, j] = mat3[i, j];
                }
            }
            int[] arr3 = HungarianAlgorithm.FindAssignments(mat3);
            for (int i = 0; i < arr3.Length; i++)
            {
                dict.Add(students3[i].st_code, arr3[i] - ((arr3[i] / numOfRooms) * numOfRooms));
                mark += helpMat[i, dict[students3[i].st_code]];
            }
            if (mark < minMark)
            {
                minMark = mark;
                minDict.Clear();
                foreach (var item in dict)
                {
                    minDict.Add(item.Key, item.Value);
                }
            }
            dict.Clear();
            mark = 0;

            for (int i = 0; i < helpMat.GetLength(0); i++)
            {
                for (int j = 0; j < helpMat.GetLength(1); j++)
                {
                    helpMat[i, j] = mat4[i, j];
                }
            }
            int[] arr4 = HungarianAlgorithm.FindAssignments(mat4);
            for (int i = 0; i < arr4.Length; i++)
            {
                dict.Add(students4[i].st_code, arr4[i] - ((arr4[i] / numOfRooms) * numOfRooms));
                mark += helpMat[i, dict[students4[i].st_code]];
            }
            if (mark < minMark)
            {
                minMark = mark;
                minDict.Clear();
                foreach (var item in dict)
                {
                    minDict.Add(item.Key, item.Value);
                }
            }
            return minDict;
        }
    }
}





