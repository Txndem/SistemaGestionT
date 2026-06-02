using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Estadistica
    {
        public int PartidasJugadas { get; set; }
        public int PartidasGanadas { get; set; }
        public int Puntos { get; set; }

        public Estadistica()
        {
            PartidasJugadas = 0;
            PartidasGanadas = 0;
            Puntos = 0;
        }

        public override string ToString()
        {
            return "PJ: " + PartidasJugadas +
                   " | PG: " + PartidasGanadas +
                   " | PTS: " + Puntos;
        }
    }
}
