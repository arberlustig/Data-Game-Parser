using Exceptions.Extensions;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Linq;
using System.Threading.Channels;


datagameparser juststart = new datagameparser();
juststart.mainMenu();
Console.ReadKey();




public class datagameparser
{
    public bool success;
    public string userInput;
    public string userChoice;

    public void mainMenu()
    {
        do
        {
            try
            {
                Console.WriteLine("Enter the name of the file you want to read or to edit:");
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new MyCustomException("No empty input mate!");
                }

                var jsonAsString = File.ReadAllText(userInput);
                List<Game> jsonList = JsonSerializer.Deserialize<List<Game>>(jsonAsString);
                Console.WriteLine("Do you want to add some games to the list? [Y]es or [N]o)");
                userChoice = Console.ReadLine();
                if (userChoice == "N")
                {
                    jsonList.giveOutputFromList();

                }
                else if(userChoice == "Y")
                {
                    Console.WriteLine("Enter your title of the game");
                }
                success = userInput.checkIfReal();
            }
            catch (MyCustomException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                "logfile.txt".logFile(ex);
                success = false;
            }
            catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File was not found: " + ex.Message);
                Console.ResetColor();
                //File.Create("logfile.txt").Close();
                "logfile.txt".logFile(ex);
                success = false;
            }
            catch (JsonException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something is wrong with the JSON File. Maybe wrong format? " + ex.Message);
                Console.ResetColor();
                "logfile.txt".logFile(ex);
                success = false;
            }
        } while (!success);

        Console.WriteLine("Press any key to close");
    }
}



public class Game
{
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

}

