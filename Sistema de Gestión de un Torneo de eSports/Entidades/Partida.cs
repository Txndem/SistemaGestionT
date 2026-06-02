using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Partida
    {
        public string Codigo { get; set; }

        public Equipo Equipo1 { get; set; }
        public Equipo Equipo2 { get; set; }

        public Arbitro Arbitro { get; set; }

        public Servidor Servidor { get; set; }

        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public DateTime Fecha { get; set; }

        public Partida() { }

        public Partida(string codigo,
                       Equipo equipo1,
                       Equipo equipo2,
                       Arbitro arbitro,
                       Servidor servidor,
                       int score1,
                       int score2,
                       DateTime fecha)
        {
            Codigo = codigo;
            Equipo1 = equipo1;
            Equipo2 = equipo2;
            Arbitro = arbitro;
            Servidor = servidor;
            Score1 = score1;
            Score2 = score2;
            Fecha = fecha;
        }

        public override string ToString()
        {
            return $"Código: {Codigo} | " +
                   $"Equipo 1: {Equipo1?.Nombre} | " +
                   $"Equipo 2: {Equipo2?.Nombre} | " +
                   $"Árbitro: {Arbitro?.Nombre} | " +
                   $"Servidor: {Servidor?.Nombre} | " +
                   $"Marcador: {Score1} - {Score2} | " +
                   $"Fecha: {Fecha:dd/MM/yyyy}";
        }
    }
}
