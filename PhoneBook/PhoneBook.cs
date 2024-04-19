using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    class PhoneBook
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void DeleteContactByNumber(string number)
        {
            var contactToDelete = Contacts.FirstOrDefault(c => c.Number == number);
            if (contactToDelete != null)
            {
                Contacts.Remove(contactToDelete);
                Console.WriteLine($"Contact with number {number} has been deleted");
            }
            else
            {
                Console.WriteLine("Did not find the given number");
            }
        }

        public void SaveToFile(string fileName)
        {
            if (Contacts.Any())
            {

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var contact in Contacts)
                    {
                        writer.WriteLine($"{contact.Name}\t{contact.Number}");
                    }
                }

                Console.WriteLine("Contacts have been saved to file");
            }
            else
            {
                Console.WriteLine("Your contact list is empty");
            }

        }

        public void LoadFromFile(string fileName)
        { 
            if (File.Exists(fileName))
            {
                string[] loadedContacts = File.ReadAllLines(fileName);
                foreach(var contact in loadedContacts)
                {
                    string[] parts = contact.Split('\t');
                    if (parts.Length == 2)
                    {
                        Contacts.Add(new Contact { Name = parts[0], Number = parts[1] });
                    }
                }

                Console.WriteLine("Contacts have been loaded from the file");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

        }

        private void DisplayContactDetails(Contact contact)
        {
            if (contact != null)
            {
                Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
            }
            else
            {
                Console.WriteLine($"Contact not found");
            }
        }

        private void DisplayContactsDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayContact(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);

            if(contact != null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayAllContacts()
        {
            if (Contacts.Count > 0)
            {
                DisplayContactsDetails(Contacts);
            }
            else
            {
                Console.WriteLine("There are no any contacts in the contact list");
            }

        }

        public void DisplayMatchingContacts(string searchPhrase)
        {
            if (Contacts.Count > 0)
            {
                var matchingContacts = Contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();
                DisplayContactsDetails(matchingContacts);
            }
            else
            {
                Console.WriteLine("There are no any contacts in the contact list");
            }

        }
    }
}
