using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using di2._1_mudGame;

//这个项目虽然叫DI，但是其实不是，只是说作为介绍DI之前关于接口（interface）以及策略（Strategy）使用的一个例子罢了
namespace di2._1_mudGame
{
    internal interface IAttackStrategy
    {
        void AttackTarget(Monster monster);
    }
    internal sealed class WoodSword : IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            monster.Notify(20);
        }
    }
    internal sealed class IronSword : IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            monster.Notify(50);
        }
    }
    internal sealed class MagicSword : IAttackStrategy
    {
        private Random _random = new Random();

        public void AttackTarget(Monster monster)
        {
            var loss = (_random.NextDouble() < 0.5) ? 100 : 200;
            if (200 == loss)
            {
                Console.WriteLine("出现暴击！！！");
            }
            monster.Notify(loss);
        }
    }
    /// <summary>  
    /// 怪物  
    /// </summary>  
    internal sealed class Monster
    {
        /// <summary>  
        /// 怪物的名字  
        /// </summary>  
        public String Name { get; set; }

        /// <summary>  
        /// 怪物的生命值  
        /// </summary>  
        private Int32 Hp { get; set; }

        /// <summary>  
        /// 怪物的攻击力  
        /// </summary>  
        private Int32 Attack { get; set; }

        /// <param name="name">设置怪物的名字name</param> 
        /// /// <param name="hp">设置怪物的初始HP</param> 
        public Monster(String name, Int32 hp)
        {
            Name = name;
            Hp = hp;
        }

        /// <summary>  
        /// 怪物被攻击时，被调用的方法，用来处理被攻击后的状态更改  
        /// </summary>  
        /// <param name="loss">此次攻击损失的HP</param>  
        public void Notify(Int32 loss)
        {
            if (Hp <= 0)
            {
                Console.WriteLine("此怪物已死");
                return;
            }

            Hp -= loss;
            if (Hp <= 0)
            {
                Console.WriteLine("怪物" + Name + "被打死");
            }
            else
            {
                Console.WriteLine("怪物" + Name + "损失" + loss + "HP");
            }
        }

    }
    /// <summary>  
    /// 角色  
    /// </summary>  
    internal sealed class Role
    {
        /// <summary>  
        /// 表示角色初始生命值  
        /// </summary> 
        private int _hp;

        /// <summary>  
        /// 表示角色名称  
        /// </summary> 
        private string _name;

        /// <summary>  
        /// 表示角色目前所持武器  
        /// </summary>  
        public IAttackStrategy Weapon { get; set; }

        /// <param name="monster">被攻击的怪物</param>  
        public void Attack(Monster monster)
        {
            Weapon.AttackTarget(monster);
        }

        /// <summary>  
        /// 攻击怪物  
        /// </summary>  
        /// <param name="hp">角色的初始HP</param>  
        public Role(string name, Int32 hp)
        {
            _name = name;
            _hp = hp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("面对春虫虫的围攻");
            Console.ReadLine();
            Console.WriteLine("你的人生早已七零八落");
            Console.ReadLine();
            Console.WriteLine("更别提你的什么狗屁理想和未来");
            Console.ReadLine();
            Console.WriteLine("那么，首先请输入你的名字：");
            var name=Console.ReadLine();
            Console.WriteLine("好吧，原来你就是令正派学生闻风丧胆，让别人家孩子望而退却，只能活在老师眼角的 "+name+" 啊！");
            Console.WriteLine("随便敲一下键盘的回车键，让我们开始吧。。。");
            Console.ReadLine();
            //生成怪物  
            var monster1 = new Monster("小怪A", 50);
            var monster2 = new Monster("小怪B", 50);
            var monster3 = new Monster("关主", 200);
            var monster4 = new Monster("最终Boss", 1000);

            //生成角色  
            var role = new Role(name,100);

            //木剑攻击  
            role.Weapon = new WoodSword();
            role.Attack(monster1);

            //铁剑攻击  
            role.Weapon = new IronSword();
            role.Attack(monster2);
            role.Attack(monster3);

            //魔剑攻击  
            role.Weapon = new MagicSword();
            role.Attack(monster3);
            role.Attack(monster4);
            role.Attack(monster4);
            role.Attack(monster4);
            role.Attack(monster4);
            role.Attack(monster4);
            Console.ReadLine();
        }
    }
}
