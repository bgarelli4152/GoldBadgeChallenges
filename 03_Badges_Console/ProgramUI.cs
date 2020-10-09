using _03_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    public class ProgramUI
    {
        BadgeRepo _komodoSecurity = new BadgeRepo();
        public void Run()
        {
            
            Badge sample = new Badge();
            _komodoSecurity.AddBadge(sample.ID,sample.doors);
            Menu();
        }
        private void Menu()
        {
            bool running = true;
            while (running == true)
            {
                //display options
                System.Console.WriteLine("Welcome to Komodo Cafe! \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges\n" +
                    "4. Exit");
                //get user input
                string input = System.Console.ReadLine();
                switch (input)
                {
                    case "1":  AddBadge(); break;
                    case "2":  Update(); break;
                    case "3":  List(); break;
                    case "4": running = false; break;
                    default: System.Console.WriteLine("please enter a valid response"); break;
                }
                System.Console.Clear();
                //evaluate input
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("Please enter new badge number.");
            int badgeNum = int.Parse(Console.ReadLine());
            bool isDone = false;
            List<string> doorList = new List<string>();
            while(isDone==false)
            {
                Console.WriteLine("Enter a door to add access.");
                string door = Console.ReadLine();
                if (door != "") { doorList.Add(door); }
                else { Console.WriteLine("Please enter a valid door"); }
                
                bool isValid = false;
                while (isValid == false)
                {
                    Console.WriteLine("Would you like to add another door? Y/N");
                    string input = Console.ReadLine();
                    if (input == "y" || input == "Y")
                    {
                        isValid = true;
                    }
                    else if (input == "n" || input == "N")
                    {
                        isValid = true;
                        isDone = true;
                    }
                    else { Console.WriteLine("Please enter a valid input"); }
                }
                
            }
            _komodoSecurity.AddBadge(badgeNum, doorList);

        }
        private void Update()
        {
            //id of badge to update
            Console.Clear();
            Console.WriteLine("Please enter ID of badge to update.");
            int ID = int.Parse(Console.ReadLine());
            _komodoSecurity.GetBadge(ID);
           
            //ask whether to remove or add doors
            Console.WriteLine("Would you like to add or remove access? A/R");
            //if add, request door string and pass to update baderepo function
            bool isValid = false;
            while(isValid==false)
            {
                string input = Console.ReadLine();
                if(input=="a"||input=="A")
                {
                    Console.WriteLine("Please enter the door to provide access:");
                    _komodoSecurity.AddAccess(ID, Console.ReadLine());
                    isValid = true;
                }
                //remove goes here
                else if(input=="r"||input=="R")
                {
                    Console.WriteLine("Please enter the door to revoke access:");
                    _komodoSecurity.RemoveAccess(ID, Console.ReadLine());
                    isValid = true;
                }
                else { Console.WriteLine("Please enter a valid input"); }
            }

            Console.WriteLine("Badge has been successfully updated");
            _komodoSecurity.GetBadge(ID);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void List()
        {
            Console.Clear();
            _komodoSecurity.ListBadges();  //list all badges with their door access permissions in a formatted list
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
