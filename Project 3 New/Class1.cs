using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_New
{
    class Worker : Students
    {
        public const string StudentType = "Student Worker";
        public double MonethlyRent;
        public double HoursWorked;

        public Worker()
        {

        }
        public Worker(string FName, string LName, int RoomNum, int IDNum,double HoursWorked) : base(FName, LName, RoomNum, IDNum)
        {
            this.FName = FName;
            this.LName = LName;
            this.RoomNum = RoomNum;
            this.IDNum = IDNum;
            this.HoursWorked = HoursWorked;
            MonethlyRent = 1250 - (HoursWorked * 14 / 2);

        }
    }
}
