using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Arbitro : Persona
    {
        public string Region { get; set; }

        public Arbitro()
        {

        }

        public Arbitro(string codigo, string nombre, string region)
            : base(codigo, nombre)
        {
            Region = region;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
