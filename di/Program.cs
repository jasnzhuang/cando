using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//这个项目虽然叫DI，但是其实不是，只是说作为介绍DI之前关于接口（interface）以及策略（Strategy）使用的一个例子罢了
namespace di
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
            Int32 loss = (_random.NextDouble() < 0.5) ? 100 : 200;
            if (200 == loss)
            {
                Console.WriteLine("出现暴击！！！");
            }
            monster.Notify(loss);
        }
    }

    internal sealed class Mianfen : IAttackStrategy
    {
        private Random _random = new Random();

        public void AttackTarget(Monster monster)
        {
            Int32 loss = (_random.NextDouble() < 0.5) ? 300 : 600;
            if (600 == loss)
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
        private Int32 HP { get; set; }
        /// <param name="name">设置怪物的名字name</param> 
        /// /// <param name="hp">设置怪物的初始HP</param> 
        public Monster(String name, Int32 hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        /// <summary>  
        /// 怪物被攻击时，被调用的方法，用来处理被攻击后的状态更改  
        /// </summary>  
        /// <param name="loss">此次攻击损失的HP</param>  
        public void Notify(Int32 loss)
        {
            if (this.HP <= 0)
            {
                Console.WriteLine("此怪物已死");
                return;
            }

            this.HP -= loss;
            if (this.HP <= 0)
            {
                Console.WriteLine("怪物" + this.Name + "被打死");
            }
            else
            {
                Console.WriteLine("怪物" + this.Name + "损失" + loss + "HP");
            }
        }
    }

    /// <summary>  
    /// 角色  
    /// </summary>  
    internal sealed class Role
    {
        /// <summary>  
        /// 表示角色目前所持武器  
        /// </summary>  
        public IAttackStrategy Weapon { get; set; }

        /// <summary>  
        /// 攻击怪物  
        /// </summary>  
        /// <param name="monster">被攻击的怪物</param>  
        public void Attack(Monster monster)
        {
            this.Weapon.AttackTarget(monster);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //生成怪物  
            Monster monster1 = new Monster("小怪A", 50);
            Monster monster2 = new Monster("小怪B", 50);
            Monster monster3 = new Monster("关主", 200);
            Monster monster4 = new Monster("最终Boss", 1000);

            //生成角色  
            Role role = new Role();

            //木剑攻击  
            role.Weapon = new WoodSword();
            role.Attack(monster1);

            //铁剑攻击  
            role.Weapon = new IronSword();
            role.Attack(monster2);
            role.Attack(monster3);

            //魔剑攻击  
            role.Weapon = new Mianfen();
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
