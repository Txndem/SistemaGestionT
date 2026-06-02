using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Persona
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Persona()
        {

        }

        public Persona(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
