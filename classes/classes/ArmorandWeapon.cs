using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class ArmorandWeapon
    {
        public int def_armor;
        public int atk_weapon;
        public int dur_armor;
        public int dur_weapon;
        public bool equiparmor;
        public bool equipweapon;
        public int v1;
        public int v2;
        public PieceClass armor;
        public PieceClass weapon;
        public bool v3;
        public bool v4;

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
                               CharacterClass characterClass, bool equipweapon, bool equiparmor)
        {
            if ((equipweapon && pieceClassWeapon == PieceClass.Any) || (equiparmor && pieceClassArmor == PieceClass.Any))
            {
                this.Power = equipweapon ? powerWeapon : powerArmor;
                this.Durability = equipweapon ? durabilityWeapon : durabilityArmor;
                this.Class = equipweapon ? pieceClassWeapon : pieceClassArmor;
            }
            else if (equipweapon && pieceClassWeapon == PieceClass.Weapon && characterClass == CharacterClass.Beast)
            {
                this.Power = powerWeapon;
                this.Durability = durabilityWeapon;
                this.Class = pieceClassWeapon;
            }
            else if (equiparmor && pieceClassArmor == PieceClass.Armor && characterClass == CharacterClass.Human)
            {
                this.Power = powerArmor;
                this.Durability = durabilityArmor;
                this.Class = pieceClassArmor;
            }
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

        public ArmorandWeapon(int power, int durability, PieceClass pieceClass, int v1, int v2, PieceClass armor, bool v3, bool v4) : this(power, durability, pieceClass)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.armor = armor;
            this.v3 = v3;
            this.v4 = v4;
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

