using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Torneo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Juego { get; set; }

        public Premio Premio { get; set; }

        // AGREGACIÓN
        public List<Equipo> ListaEquipos { get; set; }

        // ASOCIACIÓN
        public List<Partida> ListaPartidas { get; set; }

        public Torneo()
        {
            Premio = new Premio();

            ListaEquipos = new List<Equipo>();
            ListaPartidas = new List<Partida>();
        }

        public Torneo(string codigo, string nombre, string juego)
        {
            Codigo = codigo;
            Nombre = nombre;
            Juego = juego;

            ListaEquipos = new List<Equipo>();
            ListaPartidas = new List<Partida>();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
