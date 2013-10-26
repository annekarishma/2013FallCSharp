using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement;
using ContactManagement.Models;

namespace ContactManagement
{
   public  class ContactManager
    {
       readonly ContactRepository contactRepository;
        
        /// <summary>
        /// Initialises all the private variables
        /// </summary>
       public ContactManager()
        {
            contactRepository = new ContactRepository();
        }
        
        /// <summary>
        /// Add Patient
        /// </summary>
        /// <param name="patient">Patient to add</param>
        /// <returns></returns>
        public bool Add(Contact contact)
        {
            //Search if the patient exists and if not add the patient.
            if (contactRepository.Search(contact.Id) == null)
            {
                contactRepository.Add(contact);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove Patient
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            //Search if the patient exists and if exists remove the patient.
            Contact contact = contactRepository.Search(id);
            if (contact != null)
            {
                contactRepository.Remove(contact);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Search for a patient
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns></returns>
        public Contact Search(int id)
        {
            return contactRepository.Search(id);
        }

    }
}
