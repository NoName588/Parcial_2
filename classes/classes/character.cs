using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class character
    {
        public string name { get; private set; }
        public int Hp { get; private set; }
        public Arma ArmaEquipada { get; private set; }
        public Armadura ArmaduraEquipada { get; private set; }
        public int AtkBase { get; private set; }
        public int DefBase { get; private set; }
        public TipoPersonaje Clase { get; private set; }

        public Personaje(string nombre, int hp, int atkBase, int defBase, TipoPersonaje clase)
        {
            if (hp < 1) throw new ArgumentOutOfRangeException("Hp no puede ser negativo o cero.");
            Nombre = nombre;
            Hp = hp;
            AtkBase = atkBase;
            DefBase = defBase;
            Clase = clase;
        }

        public bool EquiparArma(Arma arma)
        {
            if (arma == null || arma.Durabilidad < 1 || (arma.Clase != Clase && arma.Clase != TipoPersonaje.Any)) return false;
            ArmaEquipada?.Desequipar();
            arma.Equipar(this);
            ArmaEquipada = arma;
            return true;
        }

        public bool EquiparArmadura(Armadura armadura)
        {
            if (armadura == null || armadura.Durabilidad < 1 || (armadura.Clase != Clase && armadura.Clase != TipoPersonaje.Any)) return false;
            ArmaduraEquipada?.Desequipar();
            armadura.Equipar(this);
            ArmaduraEquipada = armadura;
            return true;
        }

        public void RecibirAtaque(Personaje atacante)
        {
            int danio;
            if (ArmaduraEquipada != null)
            {
                danio = (int)Math.Floor((double)atacante.AtkBase / 2);
                danio = ArmaduraEquipada.ReducirDurabilidad(danio);
                if (danio >= Hp)
                {
                    Hp = 0;
                }
                else
                {
                    Hp -= danio;
                }
            }
            else
            {
                danio = atacante.AtkBase;
                if (danio >= Hp)
                {
                    Hp = 0;
                }
                else
                {
                    Hp -= danio;
                }
            }
        }
    }

    // Enum TipoPersonaje
    public enum TipoPersonaje
    {
        Human,
        Beast,
        Hybrid,
        Any
    }
}
}
