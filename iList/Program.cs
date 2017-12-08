using System;
using System.Collections;

namespace iList
{
    public class CreateArray
    {
        /// <summary> 
        /// 一维数组的定义 
        /// </summary> 
        public void testArr1()
        {
            int[] myIntArr = new int[100];
            //定义一个长度为100的int数组 
            string[] mystringArr = new string[100];
            //定义一个长度为100的string数组 
            object[] myObjectArr = new object[100];
            //定义一个长度为100的int数组 

            int[] myIntArr2 = { 1, 2, 3 };
            //定义一个int数组，长度为3  
            string[] mystringArr2 = { "油", "盐" };
            //定义一个string数组，长度为2  
        }

        /// <summary> 
        /// 多维数组的定义 
        /// </summary> 
        public void testArr2()
        {
            int[,] myIntArr = new int[10, 100];
            //定义一个10*100的二维int数组 
            string[,,] mystringArr = new string[2, 2, 3];
            //定义一个2*2*3的三维string数组   

            int[,] myIntArr2 = { { 1, 2, 3 }, { -1, -2, -3 } };
            //定义一个2*3的二维int数组，并初始化 
            string[,] mystringArr2 = { { "油", "盐" }, { "《围城》", "《晨露》" } };
            //定义一个2*2的二维string数组，并初始化 
        }

        /// <summary> 
        /// 交错数组的定义 
        /// </summary> 
        public void testArr3()
        {
            int[][] myJaggedArray = new int[3][];
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
        public void test1()
        {
            //定义二维数组 
            string[,] myStrArr2 = { { "油", "盐" }, { "《围城》", "《晨露》" }, { "毛毛熊", "Snoopy" } };
            //循环输出 
            for (int i = myStrArr2.GetLowerBound(0); i <= myStrArr2.GetUpperBound(0); i++)
            {
                Console.WriteLine("item{0}", i);
                for (int j = myStrArr2.GetLowerBound(1); j <= myStrArr2.GetUpperBound(1); j++)
                {
                    Console.WriteLine(" item{0}{1}:{2}", i, j, myStrArr2.GetValue(i, j));
                }
            }
        }

        /// <summary> 
        /// 使用foreach遍历数组 
        /// </summary> 
        public void test2()
        {
            //定义二维数组 
            string[,] myStrArr2 = { { "油", "盐" }, { "《围城》", "《晨露》" }, { "毛毛熊", "Snoopy" } };
            //循环输出 
            foreach (string item in myStrArr2)
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
        public void test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (int t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //对数组排序 
            Array.Sort(myArr);

            //并输出排序后的数组：1->2->3->4->5-> 
            Console.WriteLine("排序以后数组:");
            foreach (int t in myArr)
                Console.Write("{0}->", t);
        }

        /// <summary> 
        /// 多个数组的关键字排序 
        /// </summary> 
        public void test2()
        {
            //定义数组 
            int[] arrSid = { 5, 4, 3, 2, 1 };
            string[] arrSname = { "张三", "李四", "王五", "麻子", "淘气" };

            //输出原始数组：原始数组:张三(5)->李四(4)->王五(3)->麻子(2)->淘气(1)-> 
            Console.WriteLine("原始数组:");
            for (int i = 0; i < arrSid.Length; i++)
                Console.Write("{0}({1})->", arrSname[i], arrSid[i]);
            Console.WriteLine();

            //根据学号关键字排序 
            Array.Sort(arrSid, arrSname);

            //并输出排序后的数组：淘气(1)->麻子(2)->王五(3)->李四(4)->张三(5)  
            Console.WriteLine("排序以后数组:");
            for (int i = 0; i < arrSid.Length; i++)
                Console.Write("{0}({1})->", arrSname[i], arrSid[i]);
        }
    }

    public class SearchArray
    {
        /// <summary> 
        /// 利用BinarySearch方法搜索元素 
        /// </summary> 
        public void test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //对数组排序 
            Array.Sort(myArr);

            //搜索 
            int target = 3;
            int result = Array.BinarySearch(myArr, target); //2  
            Console.WriteLine("{0}的下标为{1}", target, result); //2  
        }

        /// <summary> 
        /// 判断是否包含某个值 
        /// </summary> 
        public void test2()
        {
            //定义数组 
            string[] arrSname = { "张三", "李四", "王五", "麻子", "淘气" };

            //判断是否含有某值 
            string target = "王五";
            bool result = ((IList)arrSname).Contains(target);
            Console.WriteLine("包含{0}?{1}", target, result); //true  
        }
    }

    public class ReverseArray
    {
        /// <summary> 
        /// 利用Reverse方法反转数组 
        /// </summary> 
        public void test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (int t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //对数组反转 
            Array.Reverse(myArr);

            //并输出反转后的数组：1->2->3->4->5-> 
            Console.WriteLine("反转以后数组:");
            foreach (int t in myArr)
                Console.Write("{0}->", t);
        }
    }

    public class CopyArray
    {
        /// <summary> 
        /// 利用Copy静态方法复制数组 
        /// </summary> 
        public void test1()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (int t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //复制数组 
            int[] newArr = new int[3];
            Array.Copy(myArr, newArr, 3);

            //并输出反复制的数组：5->4->3-> 
            Console.WriteLine("复制数组:");
            for (int i = 0; i < newArr.Length; i++)
                Console.Write("{0}->", newArr[i]);
        }

        /// <summary> 
        /// 利用CopyTo实例方法复制数组 
        /// </summary> 
        public void test2()
        {
            //定义数组 
            int[] myArr = { 5, 4, 3, 2, 1 };

            //输出原始数组：原始数组:5->4->3->2->1-> 
            Console.WriteLine("原始数组:");
            foreach (int t in myArr)
                Console.Write("{0}->", t);
            Console.WriteLine();

            //复制数组 
            int[] newArr = new int[7];
            myArr.CopyTo(newArr, 2);

            //并输出反复制的数组：0->0->5->4->3->2->1-> 
            Console.WriteLine("复制数组:");
            for (int i = 0; i < newArr.Length; i++)
                Console.Write("{0}->", newArr[i]);
        }
    }

    public class DynamicCreateArray
    {
        /// <summary> 
        /// 利用CreateInstance动态创建数组 
        /// </summary> 
        public void test1()
        {
            //定义长度数组 
            int[] lengthsArr = { 3, 4 };
            int[] lowerBoundsArr = { 1, 11 };

            Array arr = Array.CreateInstance(Type.GetType("System.Int32"), lengthsArr, lowerBoundsArr);

            Random r = new Random(); //声明一个随机数对象 
                                     //循环赋值、输出 
            for (int i = arr.GetLowerBound(0) - 1; i < arr.GetUpperBound(0) - 1; i++)
            {
                for (int j = arr.GetLowerBound(1) - 1; j < arr.GetUpperBound(1) - 1; j++)
                {
                    arr.SetValue(r.Next() % 100, i, j);//用1～100的随即数赋值 
                    Console.WriteLine("arr[{0},{1}]={3}", i, j, arr.GetValue(i, j));
                }
            }
        }
    }
}