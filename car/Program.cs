using System;


namespace car
{
    public class Car
    {
        public string Name;
        public string Brand;
        public string Type;
        public int Wheels=4;

        public bool IsKeyInsert()
        {
            if (Name=="QQ")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool IsKey()
        {
            if (IsKeyInsert())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckKey()
        {
            if (IsKey())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Start()
        {
            if (CheckKey())
            {
                Console.WriteLine("你的 "+Brand+" 牌 "+Type+" "+Name+" 即将载着你奔向未来~");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("你的 "+Brand+" 牌 "+Type+" "+Name+" 认为你是一个不带钥匙或者拿错钥匙的213！");
                Console.ReadKey();

            }
        }


    }

    class Program

    {

        static void Main(string[] args)
        {
            var CVVIC = new Car();
            CVVIC.Name = "CVVIC";
            CVVIC.Brand = "Honda";
            CVVIC.Type = "A Class Car";
            CVVIC.Start();

            var qq = new Car
            {
                Name="QQ",
                Brand = "Chery",
                Type = "A Calss Car"
            };
            qq.Start();
        }
    }
}
