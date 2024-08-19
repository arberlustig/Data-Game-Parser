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
        do
        {


            Console.WriteLine("Enter the name of the file you want to read:");
            string userInput = Console.ReadLine();

            try
            {
                var jsonAsString = File.ReadAllText(userInput);
                List<Game> jsonList = JsonSerializer.Deserialize<List<Game>>(jsonAsString);

                foreach(Game spiel in jsonList)
                {
                    Console.WriteLine($"Loaded games are... Title: {spiel.Title} || Release Year: {spiel.ReleaseYear} || Rating: {spiel.Rating}");
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File was not found", ex.Message);

            }
            catch (JsonException ex)
            {
                Console.WriteLine("Something is wrong with the JSON File. Maybe wrong format?", ex.Message);
                throw;
            }



            success = userInput.checkIfReal();
            //if (success)
            //    Console.WriteLine("Es ist da!");



        } while (success == false);

        Console.ReadKey();
    }





}


public class Game
{
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

}