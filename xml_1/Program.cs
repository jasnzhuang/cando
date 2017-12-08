using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xml_1
{

    public class Rootobject
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public Sk sk { get; set; }
        public Today today { get; set; }
    }

    public class Sk
    {
        public string temp { get; set; }
        public string wind_direction { get; set; }
        public string wind_strength { get; set; }
        public string humidity { get; set; }
        public string time { get; set; }
    }

    public class Today
    {
        public string city { get; set; }
        public string date_y { get; set; }
        public string week { get; set; }
        public string temperature { get; set; }
        public string weather { get; set; }
        public Weather_Id weather_id { get; set; }
    }

    public class Weather_Id
    {
        public string fa { get; set; }
        public string fb { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var document1 = new XElement("books",
                new XElement("book",
                    new XElement("title", "Sams teach yourself c# 5.0 in 24 hours"),
                    new XElement("isbn-10", "0-672-33684-7"),
                    new XElement("author", "Dorman"),
                    new XElement("price", new XAttribute("Currency", "US"), 34.99M),
                    new XElement("Publisher",
                        new XElement("name", "Sams publishing"),
                        new XElement("State", "IN")
                    )
                ));

            var document2 = new XElement("books",
                new XElement("book",
                    new XElement("title", "Sams teach yourself c# 5.0 in 24 hours"),
                    new XElement("isbn-10", "0-672-33684-7"),
                    new XElement("author", "Dorman"),
                    new XElement("price", new XAttribute("Currency", "US"), 34.99M),
                    new XElement("Publisher",
                        new XElement("name", "Sams publishing"),
                        new XElement("State", "IN")
                                )
                            ),
                new XElement("book",
                    new XElement("title", "春虫虫们的日常生活"),
                    new XElement("isbn-10", "0-672-33684-7"),
                    new XElement("author", "Dorman"),
                    new XElement("price", new XAttribute("Currency", "US"), 34.99M),
                    new XElement("Publisher",
                        new XElement("name", "Sams publishing"),
                        new XElement("State", "IN")
                    )
                ),
                new XElement("book",
                    new XElement("title", "你们又废废了"),
                    new XElement("isbn-10", "0-672-33684-7"),
                    new XElement("author", "Dorman"),
                    new XElement("price", new XAttribute("Currency", "US"), 34.99M),
                    new XElement("Publisher",
                        new XElement("name", "Sams publishing"),
                        new XElement("State", "IN")
                    )
                ),
            new XElement("book",
                    new XElement("title", "Sams teach yourself SQL in 24 hours"),
                    new XElement("isbn-10", "0-672-12345-7"),
                    new XElement("author", "Winman"),
                    new XElement("price", new XAttribute("Currency", "US"), 25.34M),
                    new XElement("Publisher",
                        new XElement("name", "Sams publishing"),
                        new XElement("State", "IN")
                    )
                )
                        );

            var first = document2.Elements("book");
            var second = document2.Elements("book").Elements("author");
            var third = document2.Element("book");
            var fourth = document2.Element("author");
            var fifth = document2.Element("book").Element("author");
            var sixth = document2.Elements("author");


            foreach (var o in document2.Elements().
                Where(e => (string)e.Element("author") == "Dorman"))
            {
                Console.WriteLine((string)o.Element("title"));

            }
            Console.ReadKey();
            //foreach (var o in document2.Elements("book").Elements("title"))
            //{
            //    Console.WriteLine((string) o);
            //}

            //Console.ReadKey();
            Console.WriteLine(document2);


            Console.ReadKey();

        }
    }
}
