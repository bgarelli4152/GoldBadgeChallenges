using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repo
{
    public class Menu
    {
        public int mealNum { get; set; }
        public string mealName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public List<string> ingredients = new List<string>();

        public Menu() 
        {
            mealNum = 1;
            mealName = "sample";
            description = "sample description";
            price = 9.99;
            ingredients.Add("sample ingredient");
        } //blank constructor
        public Menu(int num, string name, string descrip, int cost, List<string> ing) //full constructor
        {
            mealNum = num;
            mealName = name;
            description = descrip;
            price = cost;
            ingredients = ing;
        }
            
    }
}
