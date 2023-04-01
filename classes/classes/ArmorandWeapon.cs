using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class ArmorandWeapon
    {
        private int def_armor;
        private int atk_weapon;
        private int dur_armor;
        private int dur_weapon;
        private bool equiparmor;
        private bool equipweapon;

        public string Name { get; set; } = "";
        public int Power { get; set; } = 0;
        public int Durability { get; set; } = 0;
        public PieceClass Class { get; set; } = PieceClass.Any;

        public ArmorandWeapon(int power, int durability, PieceClass pieceClass)
        {
            this.Power = power;
            this.Durability = durability < 1 ? 1 : durability;
            this.Class = pieceClass;
        }

        public ArmorandWeapon(int powerWeapon, int durabilityWeapon, PieceClass pieceClassWeapon,
                              int powerArmor, int durabilityArmor, PieceClass pieceClassArmor,
                              bool equipweapon, bool equiparmor)
        {
            this.Power = equipweapon ? powerWeapon : powerArmor;
            this.Durability = equipweapon ? (durabilityWeapon < 1 ? 1 : durabilityWeapon) : (durabilityArmor < 1 ? 1 : durabilityArmor);
            this.Class = equipweapon ? pieceClassWeapon : pieceClassArmor;
        }

        public ArmorandWeapon(int def_armor, int atk_weapon, int dur_armor, int dur_weapon, bool equiparmor, bool equipweapon)
        {
            this.def_armor = def_armor;
            this.atk_weapon = atk_weapon;
            this.dur_armor = dur_armor < 1 ? 1 : dur_armor;
            this.dur_weapon = dur_weapon < 1 ? 1 : dur_weapon;
            this.equiparmor = equiparmor;
            this.equipweapon = equipweapon;
        }

        public void Attack()
        {
            if (this.Class == PieceClass.Weapon)
            {
                this.Durability -= 1;
            }
        }

        public void Defend(int damage)
        {
            if (this.Class == PieceClass.Armor)
            {
                int damageReduced = Math.Max(damage / 2, 1);
                this.Durability -= damageReduced;
            }
        }
    }

    public enum PieceClass
    {
        Weapon,
        Armor,
        Any
    }

}

