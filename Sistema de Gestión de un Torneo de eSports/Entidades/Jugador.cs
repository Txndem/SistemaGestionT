using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Jugador : Persona
    {
        public string Nick { get; set; }
        public Equipo Equipo { get; set; }

        // COMPOSICIÓN
        public Estadistica Estadistica { get; set; }

        public Jugador()
        {
            Estadistica = new Estadistica();
        }

        public Jugador(string codigo, string nombre, string nick)
            : base(codigo, nombre)
        {
            Nick = nick;
            Estadistica = new Estadistica();
        }

        public override string ToString()
        {
            return Nick;
        }
    }
}
