using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Contact
    {
        public Contact(string name, string number)
        {
            if (name.Length > 3)
            {
                Name = name;
            }
            else
            {
                Console.WriteLine("Name doesnt have at least 3 characters");
                return;
            }
            if (number.Length == 9 && number.All(char.IsDigit))
            {
                Number = number;
            }
            else
            {
                Console.WriteLine("Number doesnt have 9 characters or they are not only digits");
                return;
            }
        }

        public Contact()
        {

        }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
