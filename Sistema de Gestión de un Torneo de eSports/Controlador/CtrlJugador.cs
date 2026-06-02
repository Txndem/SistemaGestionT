using Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador
{
    public class CtrlJugador
    {
        public BindingList<Jugador> ListaJugadores =
            new BindingList<Jugador>();

        public void Guardar(Jugador j)
        {
            ListaJugadores.Add(j);
        }

        public void Editar(Jugador jugadorEditado)
        {
            var jugador = ListaJugadores
                .FirstOrDefault(x => x.Codigo == jugadorEditado.Codigo);

            if (jugador != null)
            {
                jugador.Nombre = jugadorEditado.Nombre;
                jugador.Nick = jugadorEditado.Nick;
                jugador.Equipo = jugadorEditado.Equipo;
            }
        }

        public void Eliminar(string codigo)
        {
            var jugador = ListaJugadores
                .FirstOrDefault(x => x.Codigo == codigo);

            if (jugador != null)
            {
                ListaJugadores.Remove(jugador);
            }
        }

        public Jugador Buscar(string codigo)
        {
            return ListaJugadores
                .FirstOrDefault(x => x.Codigo == codigo);
        }

        public BindingList<Jugador> Listar()
        {
            return ListaJugadores;
        }

        public List<Jugador> Filtrar(string nombre)
        {
            return ListaJugadores
                .Where(x => x.Nombre.ToLower()
                .Contains(nombre.ToLower()))
                .ToList();
        }
    }
}