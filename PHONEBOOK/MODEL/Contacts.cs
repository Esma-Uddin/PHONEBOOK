using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHONEBOOK.MODEL
{
    internal class Contacts
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gmail { get; set; }
        public string number { get; set; }
        public string Website { get; set; }

        public Contacts(string name, string surname, string gmail, string number, string website)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gmail = gmail;
            this.number = number;
            this.Website = website;
        }

    }
}
