using Challenge1.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Console
{
    public class ProgramUI
    {
        private MenuRepo _komodoRepo = new MenuRepo();
        public void Run() 
        {
            Menu sample = new Menu();
            _komodoRepo.AddMenuItem(sample);
            UserMenu();
        }

        private void UserMenu() 
        {
            bool running = true;
            while (running == true)
            {
                //display options
                System.Console.WriteLine("Welcome to Komodo Cafe! \n" +
                    "1. See full menu \n" +
                    "2. Add new menu item \n" +
                    "3. Remove menu item \n" +
                    "4. Exit");
                //get user input
                string input = System.Console.ReadLine();
                switch (input)
                {
                    case "1": FullMenu(); break;
                    case "2": AddItem(); break;
                    case "3": DeleteItem(); break;
                    case "4": running = false; break;
                    default: System.Console.WriteLine("please enter a valid response"); break;
                }
                System.Console.Clear();
                //evaluate input
            }
        }
        private void FullMenu() //read menu
        {
            System.Console.Clear();
            List<Menu> menu = _komodoRepo.ReadMenu();
            System.Console.WriteLine("Komodo Cafe Menu:");
            foreach(Menu item in menu)
            {
                System.Console.WriteLine(item.mealNum + ". " + item.mealName + " $" + item.price);
                System.Console.WriteLine(item.description);
            }
            System.Console.WriteLine("Type the name of an item for ingredients, or F to finish.");
            string input = System.Console.ReadLine();
            if(input == "f" || input == "F")
            {
                return;
            }
            _komodoRepo.GetIngredients(input);
            System.Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }
        private void AddItem() //add menu item
        {
            System.Console.Clear();
            Menu newItem = new Menu();
            newItem.ingredients.Clear();
            string input;
            //get name
            System.Console.WriteLine("Please enter the meal name");
            newItem.mealName = System.Console.ReadLine();
            //get number
            System.Console.WriteLine("What is the meal number?");
            input = System.Console.ReadLine();
            newItem.mealNum = int.Parse(input);
            //get price
            System.Console.WriteLine("How much does the meal cost?");
            input = System.Console.ReadLine();
            newItem.price = double.Parse(input);
            //get description
            System.Console.WriteLine("Please describe the meal");
            newItem.description = System.Console.ReadLine();
            //get ingredients
            System.Console.WriteLine("Please enter ingredients. Hit enter after each ingredient, and type F to finish");
            bool done = false;
            while(done == false) 
            {
                input = System.Console.ReadLine();
                if (input == "f" || input == "F") { done = true; }
                else { newItem.ingredients.Add(input); }
            }
            _komodoRepo.AddMenuItem(newItem);
            System.Console.WriteLine("Menu item added! Press any key to continue.");
            System.Console.ReadKey();
        }
        private void DeleteItem()
        {
            System.Console.Clear();
            foreach(Menu item in _komodoRepo._fullMenu)
            {
                System.Console.WriteLine(item.mealNum + ". " + item.mealName);
            }
            System.Console.WriteLine("Please enter the name of the item you want to delete:");
            string input = System.Console.ReadLine();
            _komodoRepo.RemoveMenuItem(input);
            System.Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }
    }
}
