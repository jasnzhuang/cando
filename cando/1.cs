using System;

namespace cando
{
    internal class Student
    {
        public string Name;
        public string Sex;
        public int Age;

        public void WhoAmI()
        {
            Console.WriteLine("学生姓名:" + Name + ". 性别:" + Sex + ". 年龄:" + Age);
        }
        public virtual void WhoAmPower()
        {
            Console.WriteLine("学生姓名:" + Name + ". 性别:" + Sex + ". 年龄:" + Age);
        }
    }
    //new覆盖的方法可以通过父类访问到，但是override重写的方法是不能的.
    //new方法是创建实例化一个对象，override是对虚方法进行重写。
    internal class ParentOfStudent : Student
    {
        //这里我们用了一个new，并且WhoAmI和父类中的方法同名，因为我们要隐藏掉父类中的方法，所以这么写
        public new void WhoAmI()
        {
            var relationShip = Sex == "男" ? "父亲" : "母亲";
            Console.WriteLine("家长姓名:" + Name + ". 性别:" + Sex + ". 年龄:" + Age + "。 与学生关系:" + relationShip);
        }

    }

    internal class PowerOfStudent : Student
    {
        //这里我们用了一个override，并且WhoAmPower和父类中的virtual方法同名，因为我们要重载父类中的原有方法，所以这么写
        public override void WhoAmPower()
        {
            var relationShip = Sex == "男" ? "男朋友" : "女朋友";
            Console.WriteLine("床伴姓名:" + Name + ". 性别:" + Sex + ". 年龄:" + Age + "。 与学生关系:" + relationShip);
        }

    }

    class Program
    {
        private static void Main(string[] args)
        {
            var aiyouwie = new Student
            {
                Name = "哎呦喂",
                Age = 19,
                Sex = "女"
            };
            aiyouwie.WhoAmI();
            var mama = new ParentOfStudent
            {
                Name = "哎妈妈",
                Age = 44,
                Sex = "女"
            };
            mama.WhoAmI();
            var doudou = new PowerOfStudent
            {
                Name = "豆豆",
                Age = 19,
                Sex = "男"
            };
            doudou.WhoAmPower();
            Console.ReadKey();
        }
    }


}
