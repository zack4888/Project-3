using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_New
{
    class Athlete : Students
    {
        public const string StudentType = "Student Athlete";
        public const int MonthlyRent = 1200;

        public Athlete(string FName, string LName, int RoomNum, int IDNum) : base(FName, LName, RoomNum, IDNum)
        {
            this.FName = FName;
            this.LName = LName;
            this.RoomNum = RoomNum;
            this.IDNum = IDNum;
        }
    }
}
