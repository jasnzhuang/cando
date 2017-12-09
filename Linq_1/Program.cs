using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //这里来看看如何首先从一段文本中分拆查找到字符类型的元素，然后按照要求排序，最后输出
            var textsss = "The quick brown fox jumps over the lazy dog 1 22 333 444 55555 666666";
            var result = from word in textsss.Split()
                orderby word.Length
                select word;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            var textssss = "****************************************";
            Console.WriteLine(textssss);
            Console.ReadLine();

            var words =
                from word in "The quick brown fox jumps over the lazy dog".Split()
                orderby word.ToUpper()
                select word;

            var duplicates =
                from word in words
                group word.ToUpper() by word.ToUpper() into g
                where g.Count() > 1
                select new { g.Key, Count = g.Count() };

            // The Dump extension method writes out queries:

            foreach(var word in words)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
            foreach (var word in duplicates)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();

        }
    }
}
