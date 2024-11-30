using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PHONEBOOK.DATAACCESS;
using PHONEBOOK.MODEL;

namespace PHONEBOOK.Controller
{
    internal class Controller
    {
        private BussinessLogicLayer bll;
        public Controller()
        {

        }
        public void AddContact()
        {
            string name;
            string number;

            
            do
            {
                Console.WriteLine("Please enter your name (cannot be empty):");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Error: Name cannot be empty!");
                }
            } while (string.IsNullOrWhiteSpace(name));

           
            do
            {
                Console.WriteLine("Please enter your phone number (cannot be empty):");
                number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number))
                {
                    Console.WriteLine("Error: Phone number cannot be empty!");
                }
            } while (string.IsNullOrWhiteSpace(number));

            
            Console.WriteLine("Please enter your surname:");
            string surname = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your website:");
            string website = Console.ReadLine() ?? "";

            
            Contacts contact = new Contacts(name, surname, email, number, website);
            bll = new BussinessLogicLayer();
            bll.CheckContact(contact);
        }


        //public void AddContact()
        //{
        //    Console.WriteLine("PLease enter your name:");
        //    string name = Console.ReadLine() ?? "";

        //    Console.WriteLine("PLease enter your surname:");
        //    string surname = Console.ReadLine() ?? "";

        //    Console.WriteLine("PLease enter your phone:");
        //    string phone = Console.ReadLine() ?? "";

        //    Console.WriteLine("PLease enter your Email:");
        //    string email = Console.ReadLine() ?? "";

        //    Console.WriteLine("PLease enter your website:");
        //    string website = Console.ReadLine() ?? "";


        //    Contacts contact = new Contacts(name, surname, email, phone, website);
        //    bll = new BussinessLogicLayer();

        //    bll.CheckContact(contact);
        //}


        public void ShowAllContacts()
 {
     using (SqlConnection connection = new SqlConnection("Data Source=localhost;Database=CONTACT;Integrated Security=sspi;"))
     {
         try
         {
             connection.Open();

             string query = "SELECT * FROM CONTACTS";
             using (SqlCommand command = new SqlCommand(query, connection))
             using (SqlDataReader reader = command.ExecuteReader())
             {
                 Console.WriteLine("\n--- Contact List ---");

                 while (reader.Read())
                 {
                     Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, " +
                                       $"Gmail: {reader["Gmail"]}, Number: {reader["Number"]}, Website: {reader["Website"]}");
                 }
                 Console.WriteLine("\n--- End of List ---");
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error: {ex.Message}");
         }
     }

     Console.WriteLine("\nPress any key to return to the menu...");
     Console.ReadKey();
 }





        public void RemoveContact(int id)
        {

            Console.WriteLine($"Contact {id} SILINDI");

        }
        public void UpdateContact(int id)
        {
            Console.WriteLine($"Updating contact with ID: {id}");

            
            Console.WriteLine("Enter the new name (leave blank if no change):");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the new surname (leave blank if no change):");
            string newSurname = Console.ReadLine();

            Console.WriteLine("Enter the new phone number (leave blank if no change):");
            string newPhone = Console.ReadLine();

            Console.WriteLine("Enter the new email (leave blank if no change):");
            string newEmail = Console.ReadLine();

            Console.WriteLine("Enter the new website (leave blank if no change):");
            string newWebsite = Console.ReadLine();

            
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Database=CONTACT;Integrated Security=sspi;"))
            {
                try
                {
                    connection.Open(); 

                   
                    string query = "UPDATE CONTACTS SET ";

                    
                    bool hasChanges = false;

                    
                    if (!string.IsNullOrEmpty(newName))
                    {
                        query += "Name = @Name, ";
                        hasChanges = true;
                    }
                    if (!string.IsNullOrEmpty(newSurname))
                    {
                        query += "Surname = @Surname, ";
                        hasChanges = true;
                    }
                    if (!string.IsNullOrEmpty(newPhone))
                    {
                        query += "Number = @Number, ";
                        hasChanges = true;
                    }
                    if (!string.IsNullOrEmpty(newEmail))
                    {
                        query += "Gmail = @Gmail, ";
                        hasChanges = true;
                    }
                    if (!string.IsNullOrEmpty(newWebsite))
                    {
                        query += "Website = @Website, ";
                        hasChanges = true;
                    }

                    
                    if (hasChanges)
                    {
                        query = query.TrimEnd(',', ' ') + " WHERE ID = @ID"; // Son virgülü ve boşluğu temizliyoruz, ardından ID ile WHERE şartı ekliyoruz.

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                           
                            if (!string.IsNullOrEmpty(newName)) command.Parameters.AddWithValue("@Name", newName);
                            if (!string.IsNullOrEmpty(newSurname)) command.Parameters.AddWithValue("@Surname", newSurname);
                            if (!string.IsNullOrEmpty(newPhone)) command.Parameters.AddWithValue("@Number", newPhone);
                            if (!string.IsNullOrEmpty(newEmail)) command.Parameters.AddWithValue("@Gmail", newEmail);
                            if (!string.IsNullOrEmpty(newWebsite)) command.Parameters.AddWithValue("@Website", newWebsite);
                            command.Parameters.AddWithValue("@ID", id); 

                            
                            int rowsAffected = command.ExecuteNonQuery();

                            
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Contact updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("No contact found with the specified ID.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No changes were made.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        //public void UpdateContact(int id)
        //{

        //    Console.WriteLine($"Updating contact with ID: {id}");


        //    Console.WriteLine("Enter the new name (leave blank if no change):");
        //    string newName = Console.ReadLine();

        //    Console.WriteLine("Enter the new surname (leave blank if no change):");
        //    string newSurname = Console.ReadLine();

        //    Console.WriteLine("Enter the new phone number (leave blank if no change):");
        //    string newPhone = Console.ReadLine();

        //    Console.WriteLine("Enter the new email (leave blank if no change):");
        //    string newEmail = Console.ReadLine();

        //    Console.WriteLine("Enter the new website (leave blank if no change):");
        //    string newWebsite = Console.ReadLine();




        //}

    }
}
