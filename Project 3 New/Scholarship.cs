using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_New
{
    class Scholarship : Students
    {
        public const string StudentType = "Scholarship Recipient";
        public const int MonthlyRent = 100;

        public Scholarship(string FName, string LName, int RoomNum, int IDNum) : base(FName, LName, RoomNum, IDNum)
        {
            this.FName = FName;
            this.LName = LName;
            this.RoomNum = RoomNum;
            this.IDNum = IDNum;
        }
    }
    
}
