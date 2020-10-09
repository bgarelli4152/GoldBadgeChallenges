using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class Badge
    {
        public int ID { get; set; }
        public List<string> doors = new List<string>();
        public Badge()
        {
            ID = 1234;
            doors.Add("Public Access");
            doors.Add("Cafe Access");
        }
    }
}
