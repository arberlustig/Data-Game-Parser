using Exceptions.Extensions;
bool success;

do
{
    Console.WriteLine("Enter the name of the file you want to read:");
    string? userInput = Console.ReadLine();
    success = userInput.checkIfReal();
    if (success)
        Console.WriteLine("Es ist da!");
} while (success == false);


