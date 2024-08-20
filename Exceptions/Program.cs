using Exceptions.Extensions;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Linq;
using System.Threading.Channels;
using System.Runtime.CompilerServices;


datagameparser juststart = new datagameparser();
juststart.mainMenu();
Console.ReadKey();




public class datagameparser
{
    public bool success;
    public string userInput;
    public string userChoice;
    public string? _Title { get; set; }
    public int _ReleaseYear { get; set; }
    public double _Rating { get; set; }

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
                Console.WriteLine("Do you want to add some games to the list? [Y]es or [N]o");
                userChoice = Console.ReadLine();
                if (userChoice == "N")
                {
                    jsonList.giveOutputFromList();

                }
                else if(userChoice == "Y")
                {
                    do {


                        Console.WriteLine("Enter your title of the game");
                        _Title = Console.ReadLine();
                        Console.WriteLine("In which year was it released?");
                        _ReleaseYear = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("What rating does it have?");
                        _Rating = Convert.ToDouble(Console.ReadLine());


                        Game gameObject = new Game(_Title, _ReleaseYear, _Rating);
                        jsonList.Add(gameObject);
                        jsonAsString = JsonSerializer.Serialize(jsonList);
                        File.WriteAllText(userInput, jsonAsString);

                        Console.WriteLine("Do you want to continue adding some games? [Y]es or [N]o ");
                        userChoice = Console.ReadLine();


                        if (userChoice == "Yes")
                            success = false;
                        else 
                            success = true;
                    } while (success == false);

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


    public Game(string? title, int releaseYear, double rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }

    


}

