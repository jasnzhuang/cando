using System;


namespace studentGraduted
{
    public class Student
    {
        public string Name;
        public int Age;
        public string Sex;
        public string Major;
        public float FirstYearScore;
        public float SecondYearScore;
        public float ThirdYearScore;
        public float FourthYearScore;
        public float AverageScore;
        public int FightWithOther=0;
        public int QuarrelWithTeacher = 0;

        public bool FightWithOthers()
        {
            return FightWithOther > 0;
        }

        public bool QuarrelWithTeachers()
        {
            return QuarrelWithTeacher > 0;
        }

        public bool IsScoreEnough()
        {
            AverageScore = (FirstYearScore + SecondYearScore + ThirdYearScore + FourthYearScore) / 4;
            return AverageScore >= 60 && FirstYearScore >= 60 && SecondYearScore >= 60 && ThirdYearScore >= 60 &&
                   FourthYearScore >= 60;
        }

        public void IsGraduated()
        {
            if ((!FightWithOthers() && !QuarrelWithTeachers()) && IsScoreEnough())
            {
                Console.WriteLine("恭喜！ " + Name + " 你毕业了！");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("哈哈！ " + Name + " 你完犊子了！");
                if (!IsScoreEnough())
                {
                    Console.WriteLine("你的平均成绩只有：" + AverageScore + ".");
                }
                if (FightWithOthers())
                {
                    Console.WriteLine("你与他人发生过：" + FightWithOther + " 起打架事件.");
                    
                }
                if (QuarrelWithTeachers())
                {
                    Console.WriteLine("你与老师发生过：" + QuarrelWithTeacher + " 起争执事件.");
                }

                Console.ReadKey();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var ou = new Student
            {
                Name="SJH",
                Age=15,
                Sex="女",
                FirstYearScore=60,
                SecondYearScore=60,
                ThirdYearScore=60,
                FourthYearScore=60

            };
            ou.IsGraduated();

            var yoyo = new Student
            {
                Name = "dmm",
                Age = 19,
                Sex = "女",
                FirstYearScore = 59,
                SecondYearScore = 60,
                ThirdYearScore = 60,
                FourthYearScore = 60

            };
            yoyo.IsGraduated();

            var hoho = new Student
            {
                Name = "doggy",
                Age = 19,
                Sex = "男",
                FirstYearScore = 90,
                SecondYearScore = 90,
                ThirdYearScore = 90,
                FourthYearScore = 90,
                FightWithOther=1,
                QuarrelWithTeacher=3
            };
            hoho.IsGraduated();

        }
    }
}
