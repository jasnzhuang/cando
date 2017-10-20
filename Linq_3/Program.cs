using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_3
{
    class Contact
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
    }
    

    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<Contact> contacts
            {
                new 
            }
            var result = from contact in contacts
                select contact.FirstName;
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
    }
}
