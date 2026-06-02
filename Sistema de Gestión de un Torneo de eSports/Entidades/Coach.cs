using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Coach : Persona
    {
        public string Estrategia { get; set; }

        public Coach()
        {

        }

        public Coach(string codigo, string nombre, string estrategia)
            : base(codigo, nombre)
        {
            Estrategia = estrategia;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
