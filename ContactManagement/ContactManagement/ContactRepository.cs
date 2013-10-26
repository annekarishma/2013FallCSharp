using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;

namespace ContactManagement
{
    public class ContactRepository
    {
        //Maintains the patient collection locally
        private static List<Contact> contacts = new List<Contact>();

        /// <summary>
        /// Add a Contact 
        /// </summary>
        internal void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        /// <summary>
        /// Remove a Contact based on 
        /// </summary>
        /// <param name="Contact">Contact to remove</param>
        internal void Remove(Contact contact)
        {
            contacts.Remove(contact);
        }

        /// <summary>
        /// Search for the Contact with Contact ID
        /// </summary>
        /// <param name="id">Contact ID</param>
        /// <returns></returns>
        internal Contact Search(int id)
        {
            //Get the Contacts index in the collection
            int index = GetIndex(id);
            //If present then return the element
            if (index > -1)
                return contacts[index];
            return null;
        }

        /// <summary>
        /// Search for the Contact ID in the collection and return the Index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int GetIndex(int id)
        {
            int index = -1;
            //If Collection has Items
            if (contacts.Count > 0)
            {
                //Loop through the collection
                for (int i = 0; i < contacts.Count; i++)
                {
                    //If match
                    if (contacts[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

    }
}
