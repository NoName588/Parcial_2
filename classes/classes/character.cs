using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class character : ArmorandWeapon
    {
        string name = "pepe";
        int life = 15;
        int atk = 5;
        int def = 2;
        public character(string name, int life, int atk, int def,
                     int def_armor, int atk_arma, int dur_armor,
                     int dur_arma, bool equiparmor, bool equipweapon)
                     : base(def_armor, atk_arma, dur_armor, dur_arma, equiparmor, equipweapon)
        {
            this.name = name;
            this.life = life;
            this.atk = atk;
            this.def = def;
        }
    } 
       
}

