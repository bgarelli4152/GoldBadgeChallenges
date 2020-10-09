using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repo
{
    public enum claimType
    {
        car = 1,
        home,
        theft
    }
    public class Claim
    {
        public int claimID { get; set; }
        public claimType type = new claimType();
        public string description { get; set; }
        public double amount { get; set; }
        public DateTime incidentDate = new DateTime();
        public DateTime claimDate = new DateTime();
        public bool isValid { get; set; }
        public DateTime dateClosed = new DateTime();

        public Claim()//blank constructor
        {
            claimID = 1;
            type = claimType.car;
            description = "sample description";
            amount = 999.99;
            incidentDate = DateTime.Now;
            claimDate = DateTime.Now;
            isValid = true;
        }
    }
}
