using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _171108_2
{
    interface IInfo
    {
        string GetName();
        string GetAge();
    }
    class CA : IInfo
    {
        public string Name;
        public int Age;
        public string GetName() { return Name; }
        public string GetAge() { return Age.ToString(); }
    }

    class CB : IInfo
    {
        public string First;
        public string Last;
        public double PersonsAge;
        public string GetName() { return First + Last; }
        public string GetAge() { return PersonsAge.ToString(); }
    }

    class Program
    {
        static void PrintInfo(IInfo item)
        {
            Console.WriteLine("Name: {0}, Age {1}", item.GetName(), item.GetAge());
        }

        static void Main(string[] args)
        {

            var mmy = new CA();
            mmy.Name = "mmy";
            mmy.Age = 19;

            var jyc = new CB();
            jyc.First = "YC";
            jyc.Last = "J";
            jyc.PersonsAge = 19;

            PrintInfo(mmy);
            PrintInfo(jyc);

            Console.ReadKey();
        }
    }
}
