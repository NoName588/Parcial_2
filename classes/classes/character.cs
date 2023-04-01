﻿using System;
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
        public PieceClass Class { get; set; }

        public CharacterClass Class { get; set; } = CharacterClass.Human;

        public character(string name, int life, int Baseatk, int Basedef, int atk_weapon, int def_armor,
                  int dur_weapon, int dur_armor, bool equipweapon, PieceClass pieceClass, bool equiparmor)
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
            this.Class = pieceClass;

        }

    }

    public bool CanEquip(ArmorandWeapon armorOrWeapon)
    {
        if (armorOrWeapon.Class == PieceClass.Any)
        {
            return true;
        }

        return armorOrWeapon.Class == this.Class;
    }
    public enum CharacterClass
    {
        Human,
        Beast,
        Hybrid
    }


}

