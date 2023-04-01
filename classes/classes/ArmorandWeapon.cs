using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class ArmorandWeapon
    {
        public string Name { get; set; } = "";
        public int Power { get; set; } = 0;
        public int Durability { get; set; } = 0;
        public PieceClass Class { get; set; } = PieceClass.Any;

        public ArmorandWeapon(int power, int durability, PieceClass pieceClass)
        {
            this.Power = power;
            this.Durability = durability;
            this.Class = pieceClass;
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

