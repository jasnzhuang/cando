using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







namespace @params
{
    class Program
    {
        //值参数：在使用参数时，是把一个值传递给函数使用的一个变量。对函数中此变量的任何修改都不会影响函数调用中指定的参数。（由于函数只有一个返回值，不能用作参数的多个变量值）。
        static void AMethod(int i)//值参数
        {
            i = i + 1;
        }

        //引用参数：即函数处理的变量与函数调用中使用的变量相同，而不仅仅是值相同的变量。因此，对这个变量的任何改变都会影响用作参数的变量值。需用ref关键字指定参数。用作ref参数的变量有两个限制，由于函数可能会改变引用参数的值，所有必须在函数调用中使用“非常量”变量。其次，必须使用初始化过的变量。
        static void BMethod(ref int i)//引用参数
        {
            i = i + 1;
        }

        //输出参数：out关键字，指定所给定的参数是一个输出参数。Out关键字的使用方式与ref关键字相同，实际上，他的执行方式与引用参数完全一样，因为在函数执行完毕后，该参数的值将返回给函数调用中使用的变量。
        static void CMethod(out int i, out string j)//输出参数
        {

            i = 6;//输出参数函数必须在函数内部进行初始化赋值
            j = "return";
        }

        //引用参数和输出参数的一些重要区别：
        //1\把未赋值的变量用作ref参数是非法的，但可以把未赋值的变量用作out参数。
        //2\另外，在函数使用out参数时，必须把它看成是尚未赋值。即调用代码可以把已赋值的变量用作out参数，但存储在该变量中的值会在函数执行时丢失。

        //参数数组:params（可以将相同类型，数量可变的多个参数传给一个方法）
        //引入：一般，参数的数量都是由目标方法声明所确定。然而，有时我们希望参数的数量是可变的。或许最好的方法是为方法传一个数组。然而，这会使调用代码变得稍微复杂一些，因为需要事先构造一个数组，再将这个数组作为参数来传递。 为了简化代码，c#提供了一个特殊的关键字，它允许在调用一个方法是提供数量可变的参数，而不是由方法事先固定好参数的数量。
        public static void DMethod(params string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine("没有参数");
                    break;
                case 1:
                    Console.WriteLine("1个参数");
                    break;
                default:
                    Console.WriteLine("多个参数");
                    break;


            }
        }


        //可选参数：
        //从c#4.0开始，增添了对可选参数的支持。声明方法是将常量赋给参数，以后调用方法是就不必每一个参数都指定，若不指定该参数则该参数为方法声明时指定的初始值。
        public static void EMethod(int x, int y = 2)
        {
            Console.WriteLine(x + y);
        }

        //与上无关
        //方法解析（即当同一个方法调用可以适用多个方法，将调用哪个方法）
        //当同时使用参数数组，可选参数，命名参数，方法重载等功能时，可能造成同一个方法调用可以适用多个方法。
        //（1）假如由于一个方法有一个可选参数，造成两个方法都适用（方法重载时可能出现），编译器最终选择的将使无可选参数的方法。
        //（2）假如有两个适用的方法，每个都需要（对参数）执行一次隐式转换，就选择与更具体的类型匹配的方法。例如，如果调用者传递的是一个int，那么接受double的方法将优先于接受object的方法。这是由于double比object更具体。
        //（3）如果有多个适用的方法，但无法从中挑选一个最具唯一性的，编译器就会报错，指明调用存在歧义。
        //与下无关


        static void Main(string[] args)
        {
            var i = 1; var j = "C#";//输出参数赋值

            AMethod(i);//调用值传递函数
            Console.WriteLine("(1)、 i=1;经过AMethod方法（加1），值传递之后  i=" + i);
            Console.WriteLine();

            BMethod(ref i);//调用引用传递函数
            Console.WriteLine("(2)、 i=1;经过BMethod方法（加1），ref传递之后 i=" + i);
            Console.WriteLine();

            CMethod(out i, out j);//调用输出传递函数
            Console.Write("(3)、 i=1;经过CMethod方法，out传递之后 ");
            Console.WriteLine("i=" + i + " j=" + j); Console.WriteLine();

            var a = "aaa";
            var b = "bbb";
            string[] c = { "cc", "dd" };
            DMethod();
            DMethod(a);
            DMethod(b);
            DMethod(c);
            DMethod(a, b);
            //上述例子中方法func可接受数量可变的参数，不管这些参数是以逗号分隔的，还是作为一个数组来传递的。为了获得这样的效果，func方法需要：（1）在方法声明的最后一个参数之前，添加一个parmas关键字。（2）将最后一个参数声明为一个数组。
            //注意事项：
            //@1、参数数组不一定是方法声明中的唯一参数。单数必须是最后一个参数。由于只有最后一个参数才可能是参数数组，所以方法最多只能有一个参数数组。
            //@2、调用者可以为参数数组指定0个参数，这会造成包含0个数据项的一个数组。也可以显示地使用一个数组，而不是以逗号分隔的参数列表，最终生成的CIL代码是一样的。
            //@3、参数数组是类型安全的------类型必须匹配与数组指定的类型。
            //@4、假如目标方法的实现要求一个最起码的参数数量，请在方法声明中显示指定必须提供的参数。这样一来，假如要求的参数遗失了，就会导致编译器报错，而不需要依赖于运行时错误处理。例如：使用int max(int first, params int[] operands)而不是int max(params int[] operands),确保至少有一个值传给方法max。

            EMethod(3, 2);
            EMethod(3);
            //上述EMethod(3, 2) EMethod(3)的输出结果是相同的。
            //注意：
            //@1、可选参数一定放在所有必须的参数（没有默认值的参数）后面。可选参数的数量可以是多个。
            //@2、默认值必须是一个常量，或者说必须是编译时能确定的一个值。
            Console.ReadKey();
        }
    }
}
