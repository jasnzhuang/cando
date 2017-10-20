using System;

namespace attr
{
    public class Grade
    {
        public string Name;
        public string Sex;
        public int Age;
        public void Happened()
        {
            Console.WriteLine(Age <= 17 ? "被人玩的阶段。" : "玩别人的阶段。");
        }
    }

    public class Student
    {
        public string Name;
        public int Age;
    }

    public class Boy : Student
    {
        
    }

    public class Girl : Student
    {

    }

    public class Test{
        public static void Swap(ref int x, ref int y)
        {
           int temp = x;
            x = y;
            y = temp;
        }

        public static void Divide(int x,int y,out int result,out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }
        
    }
    class Program
    {
        static void Main()
        {
            var mmy = new Grade
            {
                Name = "眯眯眼",
                Sex = "女",
                Age = 19
            };
            mmy.Happened();
            Console.ReadKey();

            string Find(string canshuName, int canshuAge)
            {
                if (canshuName!="眯眯眼")
                {
                    return canshuAge>17 ? "找得到" : "找不到";
                }
                else
                {
                    return "找不到";
                }
                
            }

            var xyj = new Girl
            {
                Name = "眯眯眼",
                Age = 19
            };
            Console.WriteLine(xyj.Name+"一定"+Find(xyj.Name,xyj.Age));

            var maer = new Boy
            {
                Name = "马儿",
                Age = 19
            };
            Console.WriteLine(maer.Name + "一定" + Find(maer.Name, maer.Age));

            var rencai = new Boy
            {
                Name = "人才",
                Age = 19
            };
            Console.WriteLine(rencai.Name + "一定" + Find(rencai.Name, rencai.Age));

            var dagujia = new Girl
            {
                Name = "大骨架",
                Age = 21
            };
            Console.WriteLine(dagujia.Name + "一定" + Find(dagujia.Name, dagujia.Age));

            Console.ReadKey();

            int i = 9, j = 3;
            Test.Swap(ref i,ref j);
            Console.WriteLine("{0} {1}", i, j);
            Console.ReadKey();
            int res, rem;
            Test.Divide(10, 3, out res, out rem);
            Console.WriteLine("{0} {1}", res,rem);
            Console.ReadKey();
        }
    }
}
