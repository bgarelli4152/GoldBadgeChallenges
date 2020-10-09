using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repo
{
    public class MenuRepo
    {
        //field; list of all stored menu items
        public List<Menu> _fullMenu = new List<Menu>();

        //blank constructor
        public MenuRepo()
        {
            
        }
       
        
        //Create
        public void AddMenuItem(Menu meal)
        {
            _fullMenu.Add(meal);
           
        }
        
        //Read
        public List<Menu> ReadMenu()
        {
            return _fullMenu;
        }

        //Update not necessary at this point
        public bool UpdateMenu(Menu update)
        {
            foreach(Menu item in _fullMenu)
            {
                if(item.mealName == update.mealName && update != null) //updates matching record if update is not blank
                {
                    item.mealNum = update.mealNum;
                    item.price = update.price;
                    item.ingredients = update.ingredients;
                    return true; //returns true if matching record is found and updated
                }
            }
            return false; //returns false if no matching record is found
        }
        //Delete
        public bool RemoveMenuItem(string name)
        {
            foreach(Menu item in _fullMenu) //loops through each item in the full menu
            {
                if(item.mealName == name) //deletes all items of the input name from full menu and returns true
                {
                    _fullMenu.Remove(item);
                    Console.WriteLine("item deleted!");
                    return true;
                }
                
            }
            Console.WriteLine("No item found with that name.");
            return false; //returns false if no item exists
        }
        public bool GetIngredients(string name)
        {
            foreach (Menu item in _fullMenu) //loops through each item in the full menu
            {
                if (item.mealName == name) //deletes all items of the input name from full menu and returns true
                {
                    foreach (string ingredient in item.ingredients)
                    {
                        Console.WriteLine(ingredient);
                    }
                    return true;
                }

            }
            Console.WriteLine("No item found with that name.");
            return false; //returns false if no item exists
        }

    }
}
