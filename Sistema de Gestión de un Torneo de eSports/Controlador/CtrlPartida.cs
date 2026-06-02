using Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador
{
    public class CtrlPartida
    {
        public BindingList<Partida> ListaPartidas = new BindingList<Partida>();
        public Servidor Servidor { get; set; }

        public void Guardar(Partida p)
        {
            ListaPartidas.Add(p);
        }

        public void Editar(Partida partidaEditada)
        {
            var partida = ListaPartidas
                .FirstOrDefault(x => x.Codigo == partidaEditada.Codigo);

            if (partida != null)
            {
                partida.Equipo1 = partidaEditada.Equipo1;
                partida.Equipo2 = partidaEditada.Equipo2;
                partida.Arbitro = partidaEditada.Arbitro;
                partida.Score1 = partidaEditada.Score1;
                partida.Score2 = partidaEditada.Score2;
                partida.Fecha = partidaEditada.Fecha;
            }
        }

        public void Eliminar(string codigo)
        {
            var partida = ListaPartidas
                .FirstOrDefault(x => x.Codigo == codigo);

            if (partida != null)
            {
                ListaPartidas.Remove(partida);
            }
        }

        public Partida Buscar(string codigo)
        {
            return ListaPartidas
                .FirstOrDefault(x => x.Codigo == codigo);
        }

        public BindingList<Partida> Listar()
        {
            return ListaPartidas;
        }

        public List<Partida> Filtrar(string codigo)
        {
            return ListaPartidas
                .Where(x => x.Codigo.ToLower()
                .Contains(codigo.ToLower()))
                .ToList();
        }

        // DEPENDENCIA
        public void ConectarServidor(Servidor s)
        {
            if (s == null)
            {
                MessageBox.Show("No se ha seleccionado ningún servidor");
                return;
            }

            MessageBox.Show("Servidor conectado: " + s.Nombre);
        }
    }
}