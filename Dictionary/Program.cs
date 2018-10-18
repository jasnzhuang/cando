using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        /// <summary>
        /// Dictionary<string, string>是一个泛型
        /// 
        /// 他本身有集合的功能有时候可以把它看成数组
        /// 
        /// 他的结构是这样的：Dictionary<[key], [value]>
        /// 
        /// 他的特点是存入对象是需要与[key]值一一对应的存入该泛型
        /// 
        /// 通过某一个一定的[key]去找到对应的值
        /// 
        /// 举个例子：
        /// 
        /// //实例化对象
        /// 
        /// Dictionary<int, string> dic = new Dictionary<int, string>();
        /// 
        /// //对象打点添加
        /// 
        /// dic.Add(1, "one");
        /// 
        /// dic.Add(2, "two");
        /// 
        /// dic.Add(3, "one");
        /// 
        /// //提取元素的方法
        /// 
        /// string a = dic[1];
        /// 
        /// string b = dic[2];
        /// 
        /// string c = dic[3];
        /// 
        /// //1、2、3是键，分别对应“one”“two”“one”
        /// 
        /// //上面代码中分别把值赋给了a,b,c
        /// 
        /// //注意,键相当于找到对应值的唯一标识，所以不能重复
        /// 
        /// //但是值可以重复
        /// 
        /// 如果你还看不懂我最后给你举一个通俗的例子
        /// 
        /// 有一缸米，你想在在每一粒上都刻上标记，不重复，相当于“键”当你找的时候一一对应不会找错，这就是这个泛型的键的-作用，而米可以一样，我的意思你明白了吧？
        /// 
        /// Dictionary的基本用法。假如
        /// 
        /// 需求：现在要导入一批数据，这些数据中有一个称为公司的字段是我们数据库里已经存在了的，目前我们需要把每个公司名字转为ID后才存入数据库。
        /// 
        /// 分析：每导一笔记录的时候，就把要把公司的名字转为公司的ID，这个不应该每次都查询一下数据库的，因为这太耗数据库的性能了。
        /// 
        /// 解决方案：在业务层里先把所有的公司名称及相应的公司ID一次性读取出来，然后存放到一个Key和Value的键值对里，然后实现只要把一个公司的名字传进去，
        /// 就可以得到此公司相应的公司ID，就像查字典一样。对，我们可以使用字典Dictionary操作这些数据。
        /// 
        /// 示例：SetKeyValue()方法相应于从数据库里读取到了公司信息。
        /// 
        /// 定义Key为string类型，Value为int类型的一个Dictionary
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> SetKeyValue()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("公司1", 1);
            dic.Add("公司2", 2);
            dic.Add("公司3", 3);
            dic.Add("公司4", 4);
            //以上5行可以简化为
            //Dictionary<string, int> dic = new Dictionary<string, int> {{"公司1", 1}, {"公司2", 2}, {"公司3", 3}, {"公司4", 4}};
            return dic;
        }


        /// <summary>
        /// 得到根据指定的Key行到Value
        /// </summary>
        protected void GetKeyValue()
        {
            Dictionary<string, int> myDictionary = SetKeyValue();
            //测试得到公司2的值
            int directorValue = myDictionary["公司2"];
            Console.Write("公司2的value是：" + directorValue);
        }


        static void Main(string[] args)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "HaHa");
            dic.Add(5, "HoHo");
            dic.Add(3, "HeHe");
            dic.Add(2, "HiHi");
            dic.Add(4, "HuHu");
            var result = from pair in dic orderby pair.Key select pair;
            foreach (KeyValuePair<int, string> pair in result)
            {
                Console.WriteLine("Key:{0}, Value:{1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}