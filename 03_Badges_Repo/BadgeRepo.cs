using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class BadgeRepo
    {
        //dicitonary key = badge ID value = list of door names
        Dictionary<int, List<string>> _allBadges = new Dictionary<int, List<string>>();

        //create
        public void AddBadge(int num, List<string> doors)
        {
            _allBadges.Add(num,doors);
        }
        //read
        public void ListBadges()
        {
            Console.WriteLine("{0,-10}{1,30}", "Badge ID", "Door Access");
            foreach (KeyValuePair<int,List<string>> kvp in _allBadges)
            {
                
                string doors = null;
                foreach(string i in kvp.Value)
                {
                    doors += i + ","; 
                }
                Console.WriteLine("{0,-10}{1,30}",kvp.Key,doors);
            }
            return;
        }
        //method that gets a badge info
        public void GetBadge(int num)
        {
            
            foreach(KeyValuePair<int,List<string>> kvp in _allBadges)
            {
                if (kvp.Key == num)
                {
                    Console.WriteLine("Badge ID: " + kvp.Key);
                    string doorList = "";
                    foreach (string s in kvp.Value)
                    {
                        doorList += s + ",";
                    }
                    Console.WriteLine("Door Access: " + doorList);
                    return;
                }
                
            }
            Console.WriteLine("No results");

        }
        //method that adds door access
        public void AddAccess(int ID, string door)
        {
            foreach(KeyValuePair<int,List<string>> kvp in _allBadges)
            {
                if(kvp.Key == ID)
                {
                    kvp.Value.Add(door);
                    Console.WriteLine("access has been granted.");
                }
            }
        }
        //method that removes door access
        public void RemoveAccess(int ID, string door)
        {
            foreach (KeyValuePair<int, List<string>> kvp in _allBadges)
            {
                if (kvp.Key == ID)
                {
                    kvp.Value.Remove(door);
                    Console.WriteLine("access has been denied.");
                }
            }
        }
    }
}
