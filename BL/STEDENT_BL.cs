using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
     public  class STEDENT_BL
    {
        public STEDENT_BL()
        {


        }
        public void Scheduling()
        {
            int[,] matCost = new int[10, 10];
          int[] result = HungarianAlgorithm.FindAssignments(matCost);
        }
    }
}
