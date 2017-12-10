using System;
using System.Collections;

namespace arrayExample
{
    public class CreateArray
    {
        /// <summary> 
        /// 一维数组的定义 
        /// </summary> 
        //使用数组中的元素是通过索引值来实现的。
        //数组中遍历元素，即对数组中所有的元素都按次序访问并仅访问一次。
        //一维数组编历时应该尽量使用foreach语句，因为foreach会自动检查数组的索引，使其不会出现越界值。
        public static void TestArr1()
        {
            var myIntArr = new int[100];
            //定义一个长度为100的int数组 
            foreach (var t in myIntArr)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("现在看到这个长度为100的int数组不赋初值的时候，里面每个元素的默认值了吧？都是0");
            Console.ReadKey();

            var mystringArr = new string[100];
            //定义一个长度为100的string数组 
            foreach (var t in mystringArr)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("现在看到这个长度为100的string数组不赋初值的时候，里面每个元素的默认值了吧？都是不显示的。。。什么呢？null");
            Console.ReadKey();

            var myObjectArr = new object[100];
            //定义一个长度为100的int数组 
            foreach (var t in myObjectArr)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("现在看到这个长度为100的object数组不赋初值的时候，里面每个元素的默认值了吧？都是不显示的。。。什么呢？null");
            Console.ReadKey();

            int[] myIntArr2 = { 1, 2, 3 };
            //定义一个int数组，长度为3
            foreach (var t in myIntArr2)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("这个没什么好说");
            Console.ReadKey();

            string[] mystringArr2 = { "崟才", "眯眯眼" };
            //定义一个string数组，长度为2
            foreach (var t in mystringArr2)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("这个也是没什么好说的吧？");
            Console.ReadKey();
        }

        /// <summary> 
        /// 多维数组的定义 
        /// </summary> 
        public static void TestArr2()
        {
            var myIntArr = new int[10, 100];
            //定义一个10*100的二维int数组 
            var mystringArr = new string[2, 2, 3];
            //定义一个2*2*3的三维string数组   

            int[,] myIntArr2 = { { 1, 2, 3 }, { -1, -2, -3 } };
            //定义一个2*3的二维int数组，并初始化 
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write("{0}\t", myIntArr2[row, col]);
                }
                Console.Write("\n");
            }
            Console.ReadKey();

            string[,] mystringArr2 = { { "困", "懒" }, { "《好学》", "《上进》" } };
            //定义一个2*2的二维string数组，并初始化 
        }

        /// <summary> 
        /// 交错数组的定义 
        /// </summary> 
        public static void TestArr3()
        {
            var myJaggedArray = new int[3][];
            myJaggedArray[0] = new int[5];
            myJaggedArray[1] = new int[4];
            myJaggedArray[2] = new int[2];

            int[][] myJaggedArray2 = {
                new[] {1,3,5,7,9},
                new[] {0,2,4,6},
                new[] {11,22}
             };
        }
    }

    public class TraverseArray
    {
        /// <summary> 
        /// 使用GetLowerBound|GetUpperBound遍历数组 
        /// </summary> 
        public static void Test1()
        {
            //定义二维数组 
            string[,] myStrArr2 = { { "困", "懒" }, { "《好学》", "《上进》" }, { "眯眯眼", "崟才" } };
            //循环输出 
            for (var i = myStrArr2.GetLowerBound(0); i <= myStrArr2.GetUpperBound(0); i++)
            {
                Console.WriteLine("item{0}", i);
                for (var j = myStrArr2.GetLowerBound(1); j <= myStrArr2.GetUpperBound(1); j++)
                {
                    Console.WriteLine(" item{0}{1}:{2}", i, j, myStrArr2.GetValue(i, j));
                }
            }
        }

        /// <summary> 
        /// 使用foreach遍历数组 
        /// </summary> 
        public static void Test2()
        {
            //定义二维数组 
            string[,] myStrArr2 = { { "懒", "困" }, { "《上进》", "《好学》" }, { "崟才", "眯眯眼" } };
            //循环输出 
            foreach (var item in myStrArr2)
            {
                {
                    Console.WriteLine("{0}", item);
                }
            }
        }
    }

    public class SortArray
    {
        /// <summary> 
        /// 利用Sort方法进行数组排序 
        /// </summary> 
        public static void Test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (var t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //对数组排序 
            Array.Sort(myArr);

            //并输出排序后的数组：1->2->3->4->5-> 
            Console.WriteLine("排序以后数组:");
            foreach (var t in myArr)
                Console.Write("{0}->", t);
        }

        /// <summary> 
        /// 多个数组的关键字排序 
        /// </summary> 
        public static void Test2()
        {
            //定义数组 
            int[] arrSid = { 5, 4, 3, 2, 1 };
            string[] arrSname = { "张三", "李四", "王五", "赵六", "陶七" };

            //输出原始数组：原始数组:张三(5)->李四(4)->王五(3)->赵六(2)->陶七(1)-> 
            Console.WriteLine("原始数组:");
            for (var i = 0; i < arrSid.Length; i++)
                Console.Write("{0}({1})->", arrSname[i], arrSid[i]);
            Console.WriteLine();

            //根据学号关键字排序 
            Array.Sort(arrSid, arrSname);

            //并输出排序后的数组：陶七(1)->赵六(2)->王五(3)->李四(4)->张三(5)  
            Console.WriteLine("排序以后数组:");
            for (var i = 0; i < arrSid.Length; i++)
                Console.Write("{0}({1})->", arrSname[i], arrSid[i]);
        }
    }

    public class SearchArray
    {
        /// <summary> 
        /// 利用BinarySearch方法搜索元素 
        /// </summary> 
        public static void Test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //对数组排序 
            Array.Sort(myArr);

            //搜索 
            var target = 3;
            var result = Array.BinarySearch(myArr, target); //2  
            Console.WriteLine("{0}的下标为{1}", target, result); //2  
        }

        /// <summary> 
        /// 判断是否包含某个值 
        /// </summary> 
        public static void Test2()
        {
            //定义数组 
            string[] arrSname = { "张三", "李四", "王五", "赵六", "陶七" };

            //判断是否含有某值 
            var target = "王五";
            var result = ((IList)arrSname).Contains(target);
            //着重注意这里iList的出现和用法
            Console.WriteLine("包含{0}?{1}", target, result); //true  
        }
    }

    public class ReverseArray
    {
        /// <summary> 
        /// 利用Reverse方法反转数组 
        /// </summary> 
        public static void Test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (var t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //对数组反转 
            Array.Reverse(myArr);

            //并输出反转后的数组：1->2->3->4->5-> 
            Console.WriteLine("反转以后数组:");
            foreach (var t in myArr)
                Console.Write("{0}->", t);
        }
    }

    public class CopyArray
    {
        /// <summary> 
        /// 利用Copy静态方法复制数组 
        /// </summary> 
        public static void Test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (var t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //复制数组 
            var newArr = new int[3];
            Array.Copy(myArr, newArr, 3);

            //并输出反复制的数组：5->4->3-> 
            Console.WriteLine("复制数组:");
            for (var i = 0; i < newArr.Length; i++)
                Console.Write("{0}->", newArr[i]);
        }

        /// <summary> 
        /// 利用CopyTo实例方法复制数组 
        /// </summary> 
        public static void Test2()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (var t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //复制数组 
            var newArr = new int[7];
            myArr.CopyTo(newArr, 2);

            //并输出反复制的数组：0->0->5->4->3->2->1-> 
            Console.WriteLine("复制数组:");
            for (var i = 0; i < newArr.Length; i++)
                Console.Write("{0}->", newArr[i]);
        }
    }

    public class DynamicCreateArray
    {
        /// <summary> 
        /// 利用CreateInstance动态创建数组 
        /// </summary> 
        public void Test1()
        {
            //定义长度数组 
            int[] lengthsArr = { 3, 4 };
            int[] lowerBoundsArr = { 1, 11 };

            var arr = Array.CreateInstance(Type.GetType("System.Int32") ?? throw new InvalidOperationException(), lengthsArr, lowerBoundsArr);

            var r = new Random(); //声明一个随机数对象 
                                  //循环赋值、输出 
            for (var i = arr.GetLowerBound(0) - 1; i < arr.GetUpperBound(0) - 1; i++)
            {
                for (var j = arr.GetLowerBound(1) - 1; j < arr.GetUpperBound(1) - 1; j++)
                {
                    arr.SetValue(r.Next() % 100, i, j);//用1～100的随即数赋值 
                    Console.WriteLine("arr[{0},{1}]={3}", i, j, arr.GetValue(i, j));
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreateArray.TestArr1();
            CreateArray.TestArr2();

        }
    }
}