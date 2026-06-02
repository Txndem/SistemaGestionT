using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Servidor
    {
        public string Nombre { get; set; }
        public string Region { get; set; }

        public Servidor()
        {

        }

        public Servidor(string nombre, string region)
        {
            Nombre = nombre;
            Region = region;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
