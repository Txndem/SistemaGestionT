using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades
{
    public class Premio
    {
        public string Nombre { get; set; }
        public double Valor { get; set; }

        public Premio()
        {

        }

        public Premio(string nombre, double valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public override string ToString()
        {
            return Nombre + " - $" + Valor;
        }
    }
}
