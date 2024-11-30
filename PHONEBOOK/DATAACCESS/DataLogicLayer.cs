using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PHONEBOOK.MODEL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PHONEBOOK.DATAACCESS
{
    internal class DataLogicLayer

    {
       
        private string connectionstring = "Data Source=localhost;Database=CONTACT;Integrated Security=sspi;";

       
        public void AddContact(Contacts contact)
        {
            string query = "INSERT INTO CONTACTS(Name, Surname, Gmail, Number, Website) VALUES ( @Name, @Surname, @Gmail, @Number, @Website)";
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Database=CONTACT;Integrated Security=sspi;"))

                try
            {
                connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", contact.Name);
                        command.Parameters.AddWithValue("@Surname", contact.Surname);
                        command.Parameters.AddWithValue("@Gmail", contact.Gmail);
                        command.Parameters.AddWithValue("@Number", contact.number);
                        command.Parameters.AddWithValue("@Website", contact.Website);
                        command.ExecuteNonQuery();



                    }
            }
            catch (Exception ex)
            {

                    Console.WriteLine(ex.Message);
                }
        }
    }
}
