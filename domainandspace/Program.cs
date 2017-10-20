using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domainandspace1;

namespace domainandspace
{
    class Contact
    {
        public int Age;

        public void F()
        {
            Age = 18;
        }

        public void G()
        {
            int Age;
            Age = 21;
            Console.WriteLine(Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Contact c = new Contact();
            Console.WriteLine(c.Age);
            c.F();
            Console.WriteLine(c.Age);
            c.G();
            Console.WriteLine(c.Age);
            Contatc cc = new Contatc();
            cc.cid = 11;
            Console.WriteLine(cc.cid);
            Console.ReadKey();

        }
    }
}
