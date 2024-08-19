using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Extensions
{

    public class MyCustomException : Exception
    {
        public MyCustomException() { }

        public MyCustomException(string message) : base(message) { }

        public MyCustomException(string message, Exception inner) : base(message, inner) { }
    }



    public static class Extension
    {

        public static bool checkIfReal(this string Input)
        {
            if (File.Exists(Input))
                return true;

            return false;
        }

        public static void giveOutputFromList(this List<Game> liste)
        {
            try
            {
                if (liste.Count == 0)
                    throw new MyCustomException("Empty List my guy!");

                foreach (Game spiel in liste)
                {
                    Console.WriteLine($"Loaded games are... Title: {spiel.Title} || Release Year: {spiel.ReleaseYear} || Rating: {spiel.Rating}");
                }
            }
            catch (MyCustomException exception1)

            {
                Console.WriteLine(exception1.Message);
            }

        }  

            public static void logFile(this string filepath, Exception ex)
            {
                if (!(File.Exists(filepath)))
                {
                    string textdatei = $"{DateTime.Now} || {ex.Message.ToString()}";
                    File.WriteAllText(filepath, textdatei);
                }
                else
                {
                    string textdatei = $"{DateTime.Now} || {ex.Message.ToString()}  \n";
                    File.AppendAllText(filepath, textdatei);
                }
            }




        }
    }
