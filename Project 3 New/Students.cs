using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_New
{
    class Students
    {
        public string FName { get; set; }
        public string LName { get;  set;}
        public int RoomNum { get; set; }
        public int IDNum { get; set; }

        public Students()
        {

        }
        public Students(string FName,string LName,int RoomNum,int IDNum)
        {
            this.FName = FName;
            this.LName = LName;
            this.RoomNum = RoomNum;
            this.IDNum = IDNum;
        }
    }
}
