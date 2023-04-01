using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class character : ArmorandWeapon
    {
        public string name { get; set; } = "pepe";
        public int life { get; set; } = 15;
        public int BaseAtk { get; set; } = 5;
        public int BaseDef { get; set; } = 2;
        public int DurabilityWeapon { get; set; } 
        public int DurabilityArmor { get; set; } 



        public CharacterClass Class { get; set; } = CharacterClass.Human;

        public character(string name, int life, int Baseatk, int Basedef, int atk_weapon, int def_armor,
                  int dur_weapon, int dur_armor, bool equipweapon, bool equiparmor, int durabilityWeapon, int durabilityArmor)
                  : base(def_armor, atk_weapon, dur_armor, dur_weapon, equiparmor, equipweapon)
        {
            this.name = name;
            if (life >= 1)
            {
                this.life = life;
            }
            else
            {
                this.life = 1;
            }
            this.BaseAtk = BaseAtk;
            this.BaseDef = BaseDef;
            DurabilityWeapon = durabilityWeapon;
            DurabilityArmor = durabilityArmor;

        }
        public void Attack(character enemy)
        {
            if (DurabilityWeapon > 0)
            {
                int damage = BaseAtk - enemy.dur_armor;
                if (damage > 0)
                {
                    enemy.life -= damage;
                }
                DurabilityWeapon--; 
            }
        }
        public void Defend()
        {
            dur_armor++;
            DurabilityArmor--; 
        }
        public void Attack()
        {
            dur_weapon++;
            DurabilityWeapon--; 
        }


    }

    public enum CharacterClass
    {
        Human,
        Beast,
        Hybrid
    }


}

