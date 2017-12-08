using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    //以下题目要求基于.Net Framework 4.5版本的一个通用控制台程序，
    //注意，是一个程序
    //1、	创建一个包含name和age以及sex的类，并使用构造方式创建
    //任意三个实例对象
    //2、	在上面的类中撰写一个能够输出name的方法，并且根据sex的不同，
    //在name输出后紧接着输出“先生”或“小姐”
    //3、	再根据上面的基类撰写一个派生类，并且根据该派生类，用构造的形式
    //创建3个实例对象，然后使用虚方法的形式，将上面第2小题的输出
    //改为根据sex判断输出“国王”或“王后”
    //4、编写一个将上面编写的全部实例对象输出的方法

namespace _171108
{
    public class Student
    {
        public string Name;
        public int Age;
        public string Sex;

        public Student(string Name, int Age, string Sex)
        {
            this.Name = Name;
            this.Age = Age;
            this.Sex = Sex;
        }

        public virtual void PrintInfo()
        {
            Sex = Sex == "m" ? "先生" : "小姐";
            Console.WriteLine("{0},{1}", Name, Sex);
        }

        public void PrintAll()
        {
            Console.WriteLine("{0}--{1}--{2}",Name, Age, Sex);
        }
    }

    public class Parent : Student
    {
        public Parent(string Name, int Age, string Sex) : base(Name, Age, Sex)
        {
        }
        public virtual void PrintInfo()
        {
            Sex = Sex == "m" ? "国王" : "王后";
            Console.WriteLine("{0},{1}", Name, Sex);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mmy = new Student("mmy", 19, "f");
            var jyc = new Student("jyc", 19, "m");
            var ou = new Student("ou", 16, "m");
            mmy.PrintInfo();
            jyc.PrintInfo();
            ou.PrintInfo();
            var mmy1 = new Parent("mmy1", 19, "f");
            var jyc1 = new Parent("jyc1", 19, "m");
            var ou1 = new Parent("ou1", 16, "m");
            mmy1.PrintInfo();
            jyc1.PrintInfo();
            ou1.PrintInfo();
            mmy.PrintAll();
            jyc.PrintAll();
            ou.PrintAll();
            mmy1.PrintAll();
            jyc1.PrintAll();
            ou1.PrintAll();
            Console.ReadKey();
        }
    }
}
