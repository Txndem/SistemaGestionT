using Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador
{
    public class CtrlTorneo
    {
        public BindingList<Torneo> ListaTorneos =
            new BindingList<Torneo>();

        public void Guardar(Torneo t)
        {
            ListaTorneos.Add(t);
        }

        public void Editar(Torneo torneoEditado)
        {
            var torneo = ListaTorneos
                .FirstOrDefault(x => x.Codigo == torneoEditado.Codigo);

            if (torneo != null)
            {
                torneo.Nombre = torneoEditado.Nombre;
                torneo.Juego = torneoEditado.Juego;
                torneo.Premio = torneoEditado.Premio;
                torneo.ListaEquipos = torneoEditado.ListaEquipos;
                torneo.ListaPartidas = torneoEditado.ListaPartidas;
            }
        }

        public void Eliminar(string codigo)
        {
            var torneo = ListaTorneos
                .FirstOrDefault(x => x.Codigo == codigo);

            if (torneo != null)
            {
                ListaTorneos.Remove(torneo);
            }
        }

        public Torneo Buscar(string codigo)
        {
            return ListaTorneos
                .FirstOrDefault(x => x.Codigo == codigo);
        }

        public BindingList<Torneo> Listar()
        {
            return ListaTorneos;
        }

        public List<Torneo> Filtrar(string nombre)
        {
            return ListaTorneos
                .Where(x => x.Nombre.ToLower()
                .Contains(nombre.ToLower()))
                .ToList();
        }


    }
}