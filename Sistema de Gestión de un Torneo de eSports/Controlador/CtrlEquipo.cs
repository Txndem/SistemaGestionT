using Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador
{
    public class CtrlEquipo
    {
        public BindingList<Equipo> ListaEquipos =
            new BindingList<Equipo>();

        public void Guardar(Equipo e)
        {
            ListaEquipos.Add(e);
        }

        public void Editar(Equipo equipoEditado)
        {
            var equipo = ListaEquipos
                .FirstOrDefault(x => x.Codigo == equipoEditado.Codigo);

            if (equipo != null)
            {
                equipo.Nombre = equipoEditado.Nombre;
                equipo.Pais = equipoEditado.Pais;
                equipo.ListaJugadores = equipoEditado.ListaJugadores;
            }
        }

        public void Eliminar(string codigo)
        {
            var equipo = ListaEquipos
                .FirstOrDefault(x => x.Codigo == codigo);

            if (equipo != null)
            {
                ListaEquipos.Remove(equipo);
            }
        }

        public Equipo Buscar(string codigo)
        {
            return ListaEquipos
                .FirstOrDefault(x => x.Codigo == codigo);
        }

        public BindingList<Equipo> Listar()
        {
            return ListaEquipos;
        }

        public List<Equipo> Filtrar(string nombre)
        {
            return ListaEquipos
                .Where(x => x.Nombre.ToLower()
                .Contains(nombre.ToLower()))
                .ToList();
        }

        public bool Registrar(Equipo e, out string error)
        {
            error = null;

            if (e == null)
            {
                error = "El equipo es nulo.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(e.Codigo))
            {
                error = "El código del equipo es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(e.Nombre))
            {
                error = "El nombre del equipo es obligatorio.";
                return false;
            }

            // Evitar duplicados por código
            if (ListaEquipos.Any(x => x.Codigo.Equals(e.Codigo, StringComparison.OrdinalIgnoreCase)))
            {
                error = $"Ya existe un equipo con el código '{e.Codigo}'.";
                return false;
            }

            ListaEquipos.Add(e);
            return true;
        }
    }
}