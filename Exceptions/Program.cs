using Exceptions.Extensions;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Linq;
using System.Threading.Channels;


datagameparser juststart = new datagameparser();
juststart.mainMenu();
Console.ReadKey();


public class MyCustomException : Exception
{
    public MyCustomException() { }

    public MyCustomException(string message) : base(message) { }

    public MyCustomException(string message, Exception inner) : base(message, inner) { }
}


public class datagameparser
{

    public bool success;
    public string userInput;

    public void mainMenu()
    {
        do
        {


            Console.WriteLine("Enter the name of the file you want to read:");


            userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                var exception1 = new MyCustomException("No empty input mate!");
                exception1.Message.ToString();
                "logfile.txt".logFile(exception1);

                throw exception1;

            }




            if (!string.IsNullOrWhiteSpace(userInput))
            {


                try
                {
                    var jsonAsString = File.ReadAllText(userInput);
                    List<Game> jsonList = JsonSerializer.Deserialize<List<Game>>(jsonAsString);
                    jsonList.giveOutputFromList();

                }
                catch (FileNotFoundException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File was not found", ex.Message);
                    Console.ResetColor();
                    //File.Create("logfile.txt").Close();
                    "logfile.txt".logFile(ex);


                }
                catch (JsonException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something is wrong with the JSON File. Maybe wrong format?", ex.Message);
                    Console.ResetColor();
                    "logfile.txt".logFile(ex);
                }

            }


            success = userInput.checkIfReal();
            //if (success)
            //    Console.WriteLine("Es ist da!");



        } while (success == false);

        Console.WriteLine("Press any key to close");

    }





}


public class Game
{
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

}

