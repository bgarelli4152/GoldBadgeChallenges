using _02_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    public class ProgramUI
    {
        ClaimRepo _komodoInsurance = new ClaimRepo();
        
        public void Run()
        {
            Claim sample = new Claim();
            _komodoInsurance.AddClaim(sample);
            Menu();
        }

        public void Menu()
        {
            bool running = true;
            while (running == true)
            {
                //display options
                System.Console.WriteLine("Welcome to Komodo Insurance! \n" +
                    "1. See all claims \n" +
                    "2. Handle next claim \n" +
                    "3. Create a claim \n" +
                    "4. Delete a claim \n" +
                    "5. See closed claims \n" +
                    "6. Exit");
                //get user input
                string input = System.Console.ReadLine();
                switch (input)
                {
                    case "1": ListClaims(); break;
                    case "2": Handle(); break;
                    case "3": CreateClaim(); break;
                    case "4": Delete(); break;
                    case "5": Closed(); break;
                    case "6": running = false; break;
                    default: System.Console.WriteLine("please enter a valid response"); break;
                }
                System.Console.Clear();
                //evaluate input
            }
            //1. see all claims (ID-type-desc-amt-date
            //2. take care of next claim
            //3. enter a new claim
        }
        private void ListClaims()
        {
            Console.Clear();
            _komodoInsurance.ListClaims();
        }
        private void Closed()
        {
            Console.Clear();
            _komodoInsurance.ListClosed();
        }
        private void CreateClaim()
        {
            Console.Clear();
            Claim toAdd = new Claim();
            bool isDone = false;
            while (isDone == false) //pick claim type
            {
                Console.WriteLine("What type of claim are you adding?");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "car": toAdd.type = claimType.car; isDone = true; break;
                    case "home": toAdd.type = claimType.home; isDone = true; break;
                    case "theft": toAdd.type = claimType.theft; isDone = true; break;
                    default: Console.WriteLine("Please enter a valid response"); break;
                }
              
            }

            Console.WriteLine("Please describe the claim:");
            toAdd.description = Console.ReadLine();
            Console.WriteLine("When did the incident happen? mm/dd/yyyy");
            string date = Console.ReadLine();
            toAdd.incidentDate = DateTime.Parse(date);
            toAdd.claimDate = DateTime.Now;
            Console.WriteLine("How much are you claiming?");
            toAdd.amount = double.Parse(Console.ReadLine());
            Console.WriteLine("What is your claim ID?");
            toAdd.claimID = int.Parse(Console.ReadLine());
            _komodoInsurance.AddClaim(toAdd);

        }
        private void Delete()
        {
            ListClaims();
            Console.WriteLine("please enter the id of the claim you would like to delete");
            int input = int.Parse(Console.ReadLine());
            _komodoInsurance.DeleteClaim(input);
        }
        private void Handle()
        {
            Console.Clear();
            _komodoInsurance.HandleClaim();
        }
    }
}
