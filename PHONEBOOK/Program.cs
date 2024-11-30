
//Controller controller = new Controller();
//controller.AddContact();
using System;

namespace PHONEBOOK
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.Controller controller = new Controller.Controller();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====== PHONEBOOK MENU ======");
                //Console.WriteLine("1. Show All Contacts");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. Remove Contact");
                Console.WriteLine("4. Update Contact");
                Console.WriteLine("5. Exit");
                Console.WriteLine("============================");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        controller.ShowAllContacts();
                        Console.WriteLine("\nPress any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        controller.AddContact();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter the ID of the contact to remove: ");
                        string removeId = Console.ReadLine();
                        if (int.TryParse(removeId, out int idToRemove))
                        {
                            controller.RemoveContact(idToRemove); 
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format!");
                        }
                        Console.WriteLine("\nPress any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Enter the ID of the contact to update: ");
                        string updateId = Console.ReadLine();
                        if (int.TryParse(updateId, out int idToUpdate))
                        {
                            controller.UpdateContact(idToUpdate); 
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format!");
                        }
                        Console.WriteLine("\nPress any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
