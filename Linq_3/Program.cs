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
        public Contact(string company, string lastName, string firstName, string address, string city, string stateProvince)
        {
            this.Company = company;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Address = address;
            this.City = city;
            this.StateProvince = stateProvince;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Contact[] contacts ={
                new Contact("骗子公司", "眯眯眼", "刘", "678", "哈尔滨", "黑龙江"),
                new Contact("传销公司", "大伟", "王", "678", "沈阳", "辽宁"),
                new Contact("转账公司", "璇", "刘", "678", "长春", "吉林"),
                new Contact("会计公司", "冬雪", "邢", "678", "四平", "吉林"),
                new Contact("财务公司", "四元", "于", "678", "吉林市", "吉林"),
                new Contact("保险公司", "大骨架", "耿", "678", "滦县", "河北"),
                new Contact("人口公司", "崟才", "江", "678", "嘉兴", "浙江"),
                };

            var result = from contact in contacts
                         group contact by contact.StateProvince;
            foreach (var grp in result)
            {
                Console.WriteLine(grp.Key);
                foreach (var details in grp)
                {
                    Console.WriteLine("{0}---{1}---{2}{3}",details.City,details.Company, details.FirstName, details.LastName
                        );
                }
            }
            Console.ReadKey();
        }
    }
}
