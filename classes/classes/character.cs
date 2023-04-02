using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class character : ArmorandWeapon
    {
        public bool? wEquiped;

        public string name { get; set; } = "pepe";
        public int life { get; set; } = 15;
        public int BaseAtk { get; set; } = 5;
        public int BaseDef { get; set; } = 2;
        public int DurabilityWeapon { get; set; } 
        public int DurabilityArmor { get; set; }
        public bool equipweapon { get; set; } = true;
        public string Weapon { get; set; }
        public string Armor { get; set; }
        private CharacterClass _class;
        private bool isClassSet;
        public CharacterClass Class
        {
            get
            {
                return _class;
            }
            set
            {
                if (!isClassSet)
                {
                    _class = value;
                    isClassSet = true;
                }
            }
        }

        public character(string name, int life, int baseAtk, int baseDef, int atk_weapon, int def_armor, int dur_weapon, int dur_armor, bool equipweapon, bool equiparmor, int durabilityWeapon, int durabilityArmor) : base(def_armor, atk_weapon, dur_armor, dur_weapon, equiparmor, equipweapon)
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
            this.BaseAtk = baseAtk;
            this.BaseDef = baseDef;
            DurabilityWeapon = durabilityWeapon;
            DurabilityArmor = durabilityArmor;

        }
        public void Attack(character enemy)
        {
            if (DurabilityWeapon > 0)
            {
                int damage = BaseAtk;
                if (enemy.equiparmor)
                {
                    damage -= enemy.dur_armor;
                }
                if (damage > 0)
                {
                    enemy.life -= damage;
                }
                DurabilityWeapon--;
                if (DurabilityWeapon <= 0)
                {
                    equipweapon = false;
                }
            }
            CheckEquipmentDurability();
        }
        public void Defend()
        {
            DurabilityArmor--;
            dur_armor++;
            CheckEquipmentDurability();
        }
        public void CheckEquipmentDurability()
        {
            if (DurabilityWeapon <= 0)
            {
                equipweapon = false;
            }
            if (DurabilityArmor <= 0)
            {
                equiparmor = false;
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public void EquipArmor(Armor armor)
        {
            throw new NotImplementedException();
        }
    }

    public enum CharacterClass
    {
        Human,
        Beast,
        Hybrid
    }


}

