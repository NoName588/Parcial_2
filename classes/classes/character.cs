﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class character : ArmorandWeapon
    {
        public string name { get; set; } = "pepe";
        public int life { get; set; } = 15;
        public int BaseAtk { get; set; } = 5;
        public int BaseDef { get; set; } = 2;
        public CharacterClass Class { get; set; } = CharacterClass.Human;

        public character(string name, int life, int Baseatk, int Basedef, int atk_weapon, int def_armor,
                  int dur_weapon, int dur_armor, bool equipweapon, bool equiparmor)
                  : base(def_armor, atk_weapon, dur_armor, dur_weapon, equiparmor, equipweapon)
        {
            this.name = name;
            this.life = life;
            this.BaseAtk = BaseAtk;
            this.BaseDef = BaseDef;
        }
    }

    public enum CharacterClass
    {
        Human,
        Beast,
        Hybrid
    }


}

