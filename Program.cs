using System;

namespace Game
{
    class Program
    {
        public class Character
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Damage { get; set; }

            public Character(string name, int health, int damage)
            {
                Name = name;
                Health = health;
                Damage = damage;
            }
        }

        public class Warrior : Character
        {
            public int Armor { get; set; }

            public Warrior(string name, int health, int damage, int armor) : base(name, health, damage)
            {
                Armor = armor;
            }

            public void AttackWithSword(Character target)
            {
                int damage = new Random().Next(10, 30);
                Console.WriteLine($"{Name} gains {Armor} armor.");
                Health += Armor;

                target.Health -= damage;
                Console.WriteLine($"{Name} attacks {target.Name} with sword, {damage} damage.");
                if (target.Health <= target.Health * 0.1)
                {
                    Console.WriteLine($"Critical Hit!");
                    target.Health = 0;
                }
            }
        }

        public class Mage : Character
        {
            public int Mana { get; set; }
            private int freezeCount = 3;

            public Mage(string name, int health, int damage, int mana) : base(name, health, damage)
            {
                Mana = mana;
            }

            public void CastSpell(Character target)
            {
                if (Mana >= 5)
                {
                    int damage = new Random().Next(20, 40);
                    target.Health -= damage;
                    if(Health>0){
                        Console.WriteLine($"{Name} casts a spell on {target.Name}, {damage} damage.");
                    Mana -= 8; 
                    
                    if (freezeCount != 0 && damage < 30)
                    {
                        Console.WriteLine("Freeze!");
                        freezeCount--;
                        damage *= 2;
                        target.Health -= damage;
                        Console.WriteLine($"{Name} attacks {target.Name} with freeze magic, {damage} damage.");
                    }
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} doesn't have enough mana to cast a spell.");
                }
            }
        }

           public class Battle
    {
        public void StartBattle(Character c1, Character c2)
        {
            Console.WriteLine($"{c1.Name} (Warrior) vs {c2.Name} (Mage)");

            while (c1.Health > 0 && c2.Health > 0){
            if (c1 is Warrior warrior)
            {
            warrior.AttackWithSword(c2);
            }
            if (c2 is Mage mage)
            {
             mage.CastSpell(c1);
    }
}
            if (c1.Health <= 0)
            {
                Console.WriteLine($"{c1.Name} is defeated.");
            }
            else if (c2.Health <= 0)
            {
                Console.WriteLine($"{c2.Name} is defeated.");
            }
        }
    }

    static void Main(string[] args)
    {
        Warrior c1 = new Warrior("Garen", 150, 0, 25);
        Mage c2 = new Mage("Jaina", 130, 0, 100);
        Battle battle = new Battle();
        battle.StartBattle(c1, c2);
    }
}
}
