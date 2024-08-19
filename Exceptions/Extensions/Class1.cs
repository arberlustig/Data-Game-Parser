using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Extensions
{
    public static class Extension
    {

        public static bool checkIfReal(this string Input)
        {
            if(File.Exists(Input)) 
                    return true; 

            return false;
        }

        public static void giveOutputFromList(this List<Game> liste)
        {
            foreach (Game spiel in liste)
            {
                Console.WriteLine($"Loaded games are... Title: {spiel.Title} || Release Year: {spiel.ReleaseYear} || Rating: {spiel.Rating}");
            }
        }




    }
}
