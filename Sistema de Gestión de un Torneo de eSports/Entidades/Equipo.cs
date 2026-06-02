using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Equipo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public Coach Coach { get; set; }

        // AGREGACIÓN
        public List<Jugador> ListaJugadores { get; set; }

        public Equipo()
        {
            ListaJugadores = new List<Jugador>();
        }

        public Equipo(string codigo, string nombre, string pais)
        {
            Codigo = codigo;
            Nombre = nombre;
            Pais = pais;

            ListaJugadores = new List<Jugador>();
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
