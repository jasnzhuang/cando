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
            //从contacts所指定的数据源中，选择每一个contact元素
            var result = from contact in contacts
                         //按照contact元素中的StateProvince属性来分组
                         group contact by contact.StateProvince;
            //注意分组后的结果其实是一个IGrouping<Tkey,TElement>对象组成的IEnumerable，可以看做是一个由列表（如:grp）组成的列表(如:result)
            //所以想要索引内层的列表(details)的属性内容（details.*），你就必须先循环外层列表(grp)，然后再循环每个外层列表元素(grp.[*])所代表的内层列表(details)
            //然后再指定内层列表(details)中的具体属性值(details.*)
            foreach (var grp in result)
            {
                //这个key就是你分组属性分组过后的的每个具体的值，也就是省份的值，当然，是去除重复之后的值
                Console.WriteLine(grp.Key);
                foreach (var details in grp)
                {
                    //这里的{0}什么什么的由花括号代表的意义，不用我再讲了吧？
                    Console.WriteLine("{0}---{1}---{2}{3}",details.City,details.Company, details.FirstName, details.LastName
                        );
                }
            }
            Console.ReadKey();
        }
    }
}
