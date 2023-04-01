using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class ArmorandWeapon
    {
        protected int def_armor = 10;
        protected int atk_weapon = 20;

        protected int dur_armor = 5;
        protected int dur_weapon = 10;

        protected bool equiparmor = true;
        protected bool equipweapon = true;

        public ArmorandWeapon (int def_armor, int atk_weapon, int dur_armor, int dur_weapon, bool equipadoarmor, bool equipadoweapon)
        {

            this.def_armor = def_armor;
            this.atk_weapon = atk_weapon;
            this.dur_armor = dur_armor;
            this.dur_weapon = dur_weapon;
            this.equiparmor = equiparmor;
            this.equipweapon = equipweapon;
        }
    }
}

