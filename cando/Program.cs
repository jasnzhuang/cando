using System;

namespace cando

{

    //类(class)和对象(object)是两种以计算机为载体的计算机语言的合称

    //对象是对客观事物的抽象，类是对对象的抽象。类是一种抽象的数据类型

    //它们的关系是，对象是类的实例，类是对象的模板

    //对象是通过(new className)产生的，用来调用类的方法

    //

    //这里就是定义了一个叫做Person的基类

    public class Person

    {

        //这里就是Person类的成员属性

        public string Name;

        public string Sex;

        public int Age;

        public string Job;

        //这里就是基类Person的成员函数，函数有时也称为方法

        public void PrintName()

        {

            Console.WriteLine("这位Person的姓名是：" + Name);

            Console.ReadKey();

        }

        public void PrintInfo()

        {

            Console.WriteLine("这位 " + Age + " 岁 " + Sex + " 性 " + Job + " 的姓名是 " + Name);

            Console.ReadKey();

        }

        public virtual void Roar()

        {

            Console.WriteLine(Name + "--->俺们是人类！");

            Console.ReadKey();

        }


    }

    //这就是从Person基类派生出来的Student类，也可以说是Student类继承自Person类

    public class Student : Person

    {

        //这里啥都没写？因为根据我的要求，我把所有的成员都写在基类里面了，继承类没必要去再写一遍，基类也就是爸爸有什么，派生类儿子也就有什么

    }

    //同样，这就是从Person基类派生出来的Teacher类，也可以说是Teacher类继承自Person类

    public class Teacher : Person

    {

        //这里啥都没写？因为根据我的要求，我把所有的成员都写在基类里面了，继承类没必要去再写一遍，基类也就是爸爸有什么，派生类儿子也就有什么

    }

    public class PlantPerson : Person

    {

        //我们啊，不被允许删除基类中的任何成员，但是呢，可以用名字一样的成员函数来屏蔽基类的同名成员函数

        //记住一定要用new关键字，不然系统报错

        //屏蔽数据成员，也就是属性成员呢，就是在派生类里面直接写一个同样类型同样名字的即可

        private new string Job = "213藕";

        //屏蔽函数成员，只是在派生类里面直接写一个相同函数签名(也就是参数列表和函数名称相同，而不包括返回类型)的即可

        public new void PrintName()

        {

            Console.WriteLine("这位植物人的大号是：" + Name + Job);

            Console.ReadKey();

        }

    }

    public class Caller : Person

    {

        //我们开始使用虚方法的手段，来覆盖掉基类Person中的Roar方法

        public override void Roar()

        {

            Console.WriteLine(Name + "--->@#$%^&*(！卧槽，我们不会说话了！");

            Console.ReadKey();

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            //这里呢，就是创建了一个名为mmy的对象，对象从哪里来的呢？从继承自Person类的Student类里抽象出来，所以说类是对象的模板

            Person mmy = new Student();

            mmy.Name = "刘婉玥";

            mmy.PrintName();

            mmy.Sex = "女";

            mmy.Age = 19;

            mmy.Job = "学生";

            mmy.PrintInfo();

            //同理，这里呢，就是创建了一个名为lxh的对象，对象从哪里来的呢？从继承自Person类的Teacher类里抽象出来，所以说类是对象的模板

            Person lxh = new Teacher();

            lxh.Name = "李笑航";

            lxh.Sex = "男";

            lxh.Age = 27;

            lxh.Job = "UI讲师";

            lxh.PrintInfo();

            var szh = new PlantPerson();

            szh.Name = "苏子豪";

            szh.PrintName();

            Person xszh = new PlantPerson();

            xszh.Name = "小苏子豪";

            xszh.PrintName();

            //面向对象有一个尽可能去遵守的原则：依赖倒置原则。

            //就是说程序设计要尽量依赖于抽象类(Person)，而不依赖于具体类(Student\Teacher\PlantPerson\Caller)

            //目的是让程序具有良好的可扩展性，使程序做到解耦，降低彼此的耦合度,不懂什么是“解耦”、“耦合度”，请自行百度

            var zls = new Person();

            zls.Name = "庄老师";

            zls.Roar();

            Person dgj = new Caller();

            dgj.Name = "耿思瑶";

            dgj.Roar();

        }

    }

}

//为什么要解耦呢？

//举个例子：

//getScore(student)

//{

//}

//假如一个课程类，里面有一个获取学生分数的的方法getScore()。该方法要求传入一学号。

//在这个方法中，就跟学生类student耦合了。

//因为在getScore方法中，需要student->getNum();

//假如现在学生类被类作者改变了，取消了getNum()这个方法，那么你这个方法，就需要重新写了。

//当开发人员只有很少人时，这个耦合带来的影响是比较小的，因为我们大概都知道在哪里用了，改起来也不麻烦。

//但是当项目比较大，开发人员多起来的时候，改动一个，几乎就需要改动很多类了。

//解耦比较好的方法，就是需要什么，就要求什么：

//getScore(StudentId)

//{

//}

//这样，当学生类变动的时候，就不需要担心自己的类需要改变了。