using System;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook app");

            Console.WriteLine("1 Add contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 Display all contacts");
            Console.WriteLine("4 Search contacts");
            Console.WriteLine("5 Delete contacts");
            Console.WriteLine("6 Save contacts to .txt file");
            Console.WriteLine("7 Load contacts from .txt file");
            Console.WriteLine("x Exit");

            var userInput = Console.ReadLine();

            var phoneBook = new PhoneBook();


            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Insert number");
                        Console.WriteLine("Number must have 9 characters");
                        var number = Console.ReadLine();
                        Console.WriteLine("Insert name");
                        Console.WriteLine("Name must have at least 3 characters");
                        var name = Console.ReadLine();

                        var newContact = new Contact(name, number);

                        phoneBook.AddContact(newContact);
                        break;
                    case "2":

                        Console.WriteLine("Insert number");
                        var numberToSearch = Console.ReadLine();

                        phoneBook.DisplayContact(numberToSearch);
                        break;
                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;
                    case "4":
                        Console.WriteLine("Insert search phrase");
                        var searchPhrase = Console.ReadLine();

                        phoneBook.DisplayMatchingContacts(searchPhrase);
                        break;
                    case "5":
                        Console.WriteLine("Insert number which will be deleted");
                        Console.WriteLine("Number must have 9 characters");
                        var numberToDelete = Console.ReadLine();

                        phoneBook.DeleteContactByNumber(numberToDelete);
                        break;
                    case "6":
                        Console.WriteLine("Insert the name for the .txt file in which contacts will be saved (format: fileName.txt)");
                        var fileNameToSave = Console.ReadLine();
                        phoneBook.SaveToFile($"{fileNameToSave}.txt");
                        break;
                    case "7":
                        Console.WriteLine("Insert the name of the .txt file from which you want to load contacts (format: fileName.txt)");
                        var fileNameToLoad = Console.ReadLine();
                        phoneBook.LoadFromFile($"{fileNameToLoad}.txt");
                        break;
                    case "x":
                        Console.WriteLine("Exiting application");
                        return;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
                Console.WriteLine("Select operation");
                userInput = Console.ReadLine();
            }

        }
    }
}