using Exceptions.Extensions;
using System.Text.Json;


datagameparser juststart = new datagameparser();
juststart.mainMenu();
Console.ReadKey();

public class datagameparser
{

    public bool success;

    public void mainMenu()
    {
        //do
        //{


            Console.WriteLine("Enter the name of the file you want to read:");
            string? userInput = Console.ReadLine();
            try
            {
            var jsonString = JsonSerializer.Deserialize<List<string>>(userInput);

            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File wurde nicht gefunden", ex.Message);

            }


            //success = userInput.checkIfReal();
            //if (success)
            //    Console.WriteLine("Es ist da!");



        //} while (success == false);

        Console.ReadKey();
    }





}


public class Game
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

}