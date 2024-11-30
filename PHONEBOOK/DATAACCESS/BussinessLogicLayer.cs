using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHONEBOOK.MODEL;

namespace PHONEBOOK.DATAACCESS
{
    internal class BussinessLogicLayer
    {
        private DataLogicLayer datal;
        public BussinessLogicLayer()
        {
            this.datal = new DataLogicLayer();    
        }




        public void CheckContact(Contacts contact) {
            if (contact.Name != null && contact.Surname != null && contact.number != null)
            {
                datal.AddContact(contact);
            }
            else
            {
                throw new ArgumentException();
            }
        } 

    }

}
