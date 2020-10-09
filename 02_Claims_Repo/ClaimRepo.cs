using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repo
{
    public class ClaimRepo
    {
        //field of all claims
        public List<Claim> _allClaims = new List<Claim>();
        public List<Claim> _closedClaims = new List<Claim>();

        //create
        public void AddClaim(Claim toAdd)
        {
            _allClaims.Add(toAdd);
        }
        //read - sort by claim date
        public void ListClaims()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-10}{4,5:d}", "ClaimID", "Type", "Description", "Amount", "DateOfClaim");
            foreach (Claim i in _allClaims)
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-10}{4,5:d}", i.claimID, i.type, i.description, i.amount, i.claimDate);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        //closed claims list
        public void ListClosed()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-10}{4,5:d}", "ClaimID", "Type", "Description", "Amount", "DateClosed");
            foreach (Claim i in _closedClaims)
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-10}{4,5:d}", i.claimID, i.type, i.description, i.amount, i.dateClosed);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        //Handle Claim
        public void HandleClaim()
        {
            if (_allClaims.Count == 0) //checks for empty repo
            { 
                Console.WriteLine("You have no claims! Press any key to continue"); 
                Console.ReadKey(); 
                return; 
            }
            DateTime oldest = _allClaims[0].claimDate;
            Claim oldestClaim = _allClaims[0];
            foreach(Claim i in _allClaims) //finds oldest claim
            {
                if(i.claimDate <= oldest)
                {
                    oldestClaim = i;
                }
            }
            Console.WriteLine("Claim ID: " + oldestClaim.claimID + "\n " +
                "Type: " + oldestClaim.type + "\n +" +
                "Description: " + oldestClaim.description + "\n" +
                "Amount: " + oldestClaim.amount + "\n" +
                "DateOfAccident: " + oldestClaim.incidentDate + "\n" +
                "DateOfClaim: " + oldestClaim.claimDate + "\n" +
                "IsValid: " + oldestClaim.isValid);
            Console.WriteLine("Would you like to handle this claim? Y/N");
            string input = Console.ReadLine();
            if(input == "y" || input == "Y")
            {
                _allClaims.Remove(oldestClaim); //removes oldest claim from allClaims
                _closedClaims.Add(oldestClaim); //adds oldest claim to closedClaims
                Console.WriteLine("claim succesfully handeled! Press any key to continue");
                oldestClaim.dateClosed = DateTime.Now;
                Console.ReadKey();
                return;
            }
            else { return; }
           
        }

        //delete
        public void DeleteClaim(int id)
        {
            foreach(Claim i in _allClaims)
            {
                if(i.claimID == id)
                {
                    _allClaims.Remove(i);
                    Console.WriteLine("Record removed succesfully.");
                    break;
                }
                else { Console.WriteLine("No matching records found."); break; }
            }
            return;
        }
    }
}
