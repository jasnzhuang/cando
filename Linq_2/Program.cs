using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_2
{
    class Student
    {
        /// <summary>
        ///学生姓名的字段和属性
        /// </summary>
        private string _Name;
        public string Name => this._Name;
        private string _Xingbie;
        /// <summary>
        /// 学生性别的字段和属性
        /// </summary>
        public string Xingbie => this._Xingbie;

        /// <summary>
        /// 学生年龄的字段和属性
        /// </summary>
        private uint _Age;
        public uint Age => this._Age;

        /// <summary>
        /// 学生成绩的字段和属性
        /// </summary>
        private List<LessonScore> _Scores;
        public List<LessonScore> Scores => this._Scores;

        /// <summary>
        /// 构造函数，传入学生姓名，性别，年龄，成绩
        /// </summary>
        public Student(string name, string xb, uint age, List<LessonScore> scrs)
        {
            this._Name = name;
            this._Xingbie = xb;
            this._Age = age;
            this._Scores = scrs;
        }
        public Student(string name, string xb, uint age)
        {
            this._Name = name;
            this._Xingbie = xb;
            this._Age = age;
            this._Scores = null;
        }
        public override string ToString()
        {
            string str;
            str = string.Format("{0}--{1}--{2}", this._Name, this._Age, this._Xingbie);
            return str;
        }

    }

    class LessonScore
    {
        /// <summary>
        /// 课程成绩的字段和属性
        /// </summary>
        private float _Score;
        public float Score => this._Score;

        /// <summary>
        /// 课程名称的字段和属性
        /// </summary>
        private string _Lessson;
        public string Lesson => this._Lessson;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LessonScore(string les, float scr)
        {
            this._Lessson = les;
            this._Score = scr;
        }

        public override string ToString()
        {
            string str;
            str = string.Format("{0}----{1}分", this._Lessson, this._Score);
            return str;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] arr =
            {
                new Student("张氏那","男",20),
                new Student("李四","男",23),
                new Student("李霞","女",23),
                new Student("王妈妈","女",25),
                new Student("郭明","男",22),
                new Student("欧阳夏","女",24),
                new Student("王丹","女",20),
                new Student("张宝","男",25),
            };
            Console.WriteLine("query");
            var query =
                from val in arr
                select val;
            foreach (Student item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();



            Console.WriteLine("query2");
            var query2 =
                from val in arr
                select val.Name;
            foreach (string item in query2)
            {
                Console.Write("{0},   ", item);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("query3");
            var query3 =
                from val in arr
                select val.Name.Length;
            foreach (int item in query3)
            {
                Console.Write("{0},   ", item);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("query4");
            var query4 =
                from val in arr
                select new { val.Name, val.Age, NameLen = val.Name.Length };
            foreach (var item2 in query4)
            {
                Console.WriteLine(item2);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();



            Console.WriteLine("query5");
            int[] ary = { 9, 54, 32, 1, 67, 43, 0, 9, 7, 4, 9, 2, 23, 66, 61 };
            var query5 =
                from val in ary
                orderby val
                select val;
            foreach (var item in query5)
            {
                Console.Write("{0}   ", item);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();



            Console.WriteLine("query6");
            var query6 =
                from val in ary
                orderby val descending
                select val;
            foreach (var item in query6)
            {
                Console.Write("{0}   ", item);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("query7");
            var query7 =
                from val in arr
                orderby val.Name.Length ascending, val.Age descending
                select val;
            foreach (var item in query7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();



            Console.WriteLine("query8");
            var query8 =
                from val in arr
                group val by val.Xingbie;
            foreach (var grp in query8)
            {
                Console.WriteLine(grp.Key);
                foreach (var st in grp)
                {
                    Console.WriteLine("\t{0}", st);
                }
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();




            Console.WriteLine("query9");
            var query9 =
                from val in arr
                group val by val.Age into stgrp
                orderby stgrp.Key descending
                select stgrp;
            foreach (var st in query9)
            {
                Console.WriteLine("{0}岁的学生：", st.Key);
                foreach (var stu in st)
                {
                    Console.WriteLine("\t{0}", stu);
                }
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();

            /*
             *from子句的复合查询 
             */
            Student[] stAry = {
                                  new Student("张氏那","男",20,
                                      new List<LessonScore>{
                                          new LessonScore("语文",80.5f),
                                          new LessonScore("数学",90f),
                                          new LessonScore("英语",89f)
                                      }),
                                  new Student("李四","男",23,
                                      new List<LessonScore>{
                                          new LessonScore("语文",86.5f),
                                          new LessonScore("数学",97f),
                                          new LessonScore("英语",95f)
                                      }),
                                  new Student("李霞","女",23,
                                      new List<LessonScore>{
                                          new LessonScore("语文",76f),
                                          new LessonScore("数学",85f),
                                          new LessonScore("英语",79f)
                                      }),
                                  new Student("王妈妈","女",25,
                                      new List<LessonScore>{
                                          new LessonScore("语文",85f),
                                          new LessonScore("数学",87f),
                                          new LessonScore("英语",79f)
                                      }),
                                  new Student("郭明","男",22,
                                      new List<LessonScore>{
                                          new LessonScore("语文",69f),
                                          new LessonScore("数学",72f),
                                          new LessonScore("英语",83f)
                                      }),
                                  new Student("欧阳夏","女",24,
                                      new List<LessonScore>{
                                          new LessonScore("语文",85f),
                                          new LessonScore("数学",85f),
                                          new LessonScore("英语",79f)
                                      }),
                                  new Student("王丹","女",20,
                                      new List<LessonScore>{
                                          new LessonScore("语文",73f),
                                          new LessonScore("数学",77f),
                                          new LessonScore("英语",80f)
                                      }),
                                  new Student("张宝","男",25,
                                      new List<LessonScore>{
                                          new LessonScore("语文",88f),
                                          new LessonScore("数学",89f),
                                          new LessonScore("英语",94f)
                                      }),
                              };

            Console.WriteLine("query10");
            var query10 =
                from st in stAry
                from scr in st.Scores
                where scr.Score > 80
                group new { st.Name, scr } by st.Name;
            foreach (var grp in query10)
            {
                Console.WriteLine(grp.Key);
                foreach (var item in grp)
                {
                    Console.WriteLine("\t{0}", item);
                }
            }

            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();



            Console.WriteLine("query11");
            int[] intarry1 = { 5, 10, 15, 20, 25, 50, 30, 33, 100 };
            int[] intarry2 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var query11 =
                from val1 in intarry1
                from val2 in intarry2
                where val2 % val1 == 0
                group val2 by val1;
            foreach (var grp in query11)
            {
                Console.Write("{0}:  ", grp.Key);
                foreach (var val in grp)
                {
                    Console.Write("{0}  ", val);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("query12");
            Console.WriteLine("*********************join*****************************************");
            Console.WriteLine();
            Console.WriteLine("**********内部联接**************************");
            int[] intarray1 = { 5, 15, 25, 30, 33, 40 };
            int[] intarray2 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var query12 =
                from val1 in intarray1
                join val2 in intarray2 on val1 % 5 equals val2 % 15
                select new { VAL1 = val1, VAL2 = val2 };
            foreach (var val in query12)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("**********分组联接**************************");

            var query13 =
                from val1 in intarray1
                join val2 in intarray2 on val1 % 5 equals val2 % 15 into grpName
                select new { VAL1 = val1, VAL2 = grpName };
            foreach (var val in query13)
            {
                Console.Write("{0}:  ", val.VAL1);
                foreach (var obj in val.VAL2)
                {
                    Console.Write("{0}  ", obj);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("**********左外部联接**************************");
            var query14 =
                from val1 in intarray1
                join val2 in intarray2 on val1 % 5 equals val2 % 15 into grpName
                from grp in grpName.DefaultIfEmpty()
                select new { VAL1 = val1, VAL2 = grp };
            foreach (var val in query14)
            {
                Console.WriteLine(val);
            }
        }
    }
}