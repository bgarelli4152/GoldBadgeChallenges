using System;
using _02_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Test
{
    [TestClass]
    public class UnitTest1
    {
        ClaimRepo test = new ClaimRepo();
        Claim newClaim = new Claim();
        
        [TestMethod]
        public void CreateClaim()
        {
            newClaim.type = claimType.car;
            newClaim.description = "fender bender";
            newClaim.incidentDate = DateTime.Now;
            newClaim.claimDate = DateTime.Now;
            newClaim.amount = 9000.50;
            newClaim.claimID = 1;
            test.AddClaim(newClaim);
        }

        [TestMethod]
        public void Handle()
        {
            newClaim.type = claimType.car;
            newClaim.description = "fender bender";
            newClaim.incidentDate = DateTime.Now;
            newClaim.claimDate = DateTime.Now;
            newClaim.amount = 9000.50;
            newClaim.claimID = 1;
            test.HandleClaim();
        }


    }
}
