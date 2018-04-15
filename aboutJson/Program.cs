using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace aboutJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string personJson =
                "{ 'FirstName': '小坦克1','LastName':'Tank xiao1', 'Age':'30', 'Books':[{'BookName':'c#1', 'Price':'29.9'},{'BookName':'Mac编程1', 'Price':'39.9'}]}";

            string allMoveJson =
                @"[
                    { 'FirstName': '小坦克2','LastName':'Tank xiao2', 'Age':'30', 'Books':[{'BookName':'c#2', 'Price':'29.9'},{'BookName':'Mac编程2', 'Price':'39.9'}]},
                    {'FirstName': '小坦克3','LastName':'Tank xiao3', 'Age':'40', 'Books':[{'BookName':'c#3', 'Price':'29.9'},{'BookName':'Mac编程3', 'Price':'39.9'}]}]";

            // 反序列化 单个对象
            Person oneMovie = JsonConvert.DeserializeObject<Person>(personJson);

            // 反序列化 对象集合
            List<Person> allMovie = JsonConvert.DeserializeObject<List<Person>>(allMoveJson);

            Console.WriteLine(oneMovie.FirstName);
            Console.WriteLine(allMovie[1].FirstName);

            // 序列化
            string afterJson = JsonConvert.SerializeObject(allMovie);
        }
    }


    public class Person
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int Age { get; set; }

        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string BookName { get; set; }

        public string Price { get; set; }
    }
}