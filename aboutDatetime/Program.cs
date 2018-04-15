using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aboutDatetime
{
    class Program
    {
        #region 得到一周的周一和周日的日期
        /// <summary> 
        /// 计算本周的周一日期 
        /// </summary> 
        /// <returns></returns> 
        public static DateTime GetMondayDate() => GetMondayDate(DateTime.Now);

        /// <summary> 
        /// 计算本周周日的日期 
        /// </summary> 
        /// <returns></returns> 
        public static DateTime GetSundayDate() => GetSundayDate(DateTime.Now);
        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }
        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }
        #endregion


        public static string workTime()
        {
            var t = "上课时间";
            var nowtime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            var sone = Convert.ToDateTime("09:30:00");
            var sonem = Convert.ToDateTime("10:00:00");
            var stwo = Convert.ToDateTime("11:30:00");
            var stwom = Convert.ToDateTime("13:00:00");
            var xone = Convert.ToDateTime("14:30:00");
            var xonem = Convert.ToDateTime("15:00:00");
            var xtwo = Convert.ToDateTime("16:30:00");
            var xtwos = Convert.ToDateTime("17:00:00");
            var noonTimeStart = Convert.ToDateTime("11:30:00");
            var noonTimeEnd = Convert.ToDateTime("13:00:00");
            var workTimeStart = Convert.ToDateTime("08:00:00");
            var workTimeEnd = Convert.ToDateTime("18:00:00");
            if (nowtime >= workTimeStart && nowtime < workTimeEnd)
            {
                if (nowtime >= sone && nowtime < sonem || nowtime >= stwo && nowtime < stwom ||
                    nowtime >= xone && nowtime < xonem || nowtime >= xtwo && nowtime < xtwos)
                     { t = "课间休息";}
                else if (nowtime >= noonTimeStart && nowtime < noonTimeEnd)
                     { t = "午休时间";}
            }else
            {
                t = "课余时间";
            }
            return t;
        }

        static void Main()
        {
            DateTime dt = DateTime.Now;  //当前时间

            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
            DateTime endWeek = startWeek.AddDays(6);  //本周周日

            DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末
            //DateTime endMonth = startMonth.AddDays((dt.AddMonths(1) - dt).Days - 1);  //本月月末

            DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);  //本季度初
            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末

            DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初
            DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年年末
            Console.WriteLine("当前时间：" + GetMondayDate());
            Console.WriteLine("本周周一日期：" + startWeek);
            Console.WriteLine("本周周日日期：" + endWeek);
            Console.WriteLine("本月月初日期：" + startMonth);
            Console.WriteLine("本月月末日期：" + endMonth);
            Console.WriteLine("本季度初日期：" + startQuarter);
            Console.WriteLine("本季度末日期：" + endQuarter);
            Console.WriteLine("本年年初日期：" + startYear);
            Console.WriteLine("本年年末日期：" + endYear);
            Console.WriteLine("本周周一日期（第二种方法）："+GetMondayDate());
            Console.WriteLine("本周周日日期（第二种方法）：" + GetSundayDate());
            Console.WriteLine(workTime());
            Console.ReadKey();
        }
    }
}
