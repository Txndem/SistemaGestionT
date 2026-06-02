using Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador;
using Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Formulario
{
    public partial class frmJugadorEdit : Form
    {
        CtrlJugador ctrlJugador;
        CtrlEquipo ctrlEquipo;

        Jugador jugadorEditar;

        public frmJugadorEdit(CtrlJugador ctrl, CtrlEquipo ctrlE)
        {
            InitializeComponent();

            ctrlJugador = ctrl;
            ctrlEquipo = ctrlE;
        }

        public frmJugadorEdit(CtrlJugador ctrl, CtrlEquipo ctrlE, Jugador j)
        {
            InitializeComponent();

            ctrlJugador = ctrl;
            ctrlEquipo = ctrlE;

            jugadorEditar = j;

            txtCodigo.Text = j.Codigo;
            txtNombre.Text = j.Nombre;
            txtNick.Text = j.Nick;

            if (j.Estadistica != null)
            {
                txtPJ.Text =
                    j.Estadistica.PartidasJugadas.ToString();

                txtPG.Text =
                    j.Estadistica.PartidasGanadas.ToString();

                txtPuntos.Text =
                    j.Estadistica.Puntos.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código.");
                return;
            }

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre.");
                return;
            }

            if (txtNick.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nick.");
                return;
            }

            if (cboEquipos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un equipo.");
                return;
            }

            if (txtPJ.Text.Trim() == "" ||
                txtPG.Text.Trim() == "" ||
                txtPuntos.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar todas las estadísticas.");
                return;
            }

            int pj, pg, puntos;

            if (!int.TryParse(txtPJ.Text, out pj) ||
                !int.TryParse(txtPG.Text, out pg) ||
                !int.TryParse(txtPuntos.Text, out puntos))
            {
                MessageBox.Show("Las estadísticas deben ser números.");
                return;
            }

            if (pj <= 0 && pg <= 0 && puntos <= 0)
            {
                MessageBox.Show("El jugador necesita al menos un puntaje inicial.");
                return;
            }

            if (pg > pj)
            {
                MessageBox.Show("Las partidas ganadas no pueden ser mayores que las jugadas.");
                return;
            }

            Equipo nuevoEquipo = (Equipo)cboEquipos.SelectedItem;

            if (jugadorEditar == null)
            {
                Jugador j = new Jugador();

                j.Codigo = txtCodigo.Text;
                j.Nombre = txtNombre.Text;
                j.Nick = txtNick.Text;

                j.Estadistica = new Estadistica();

                j.Estadistica.PartidasJugadas = pj;
                j.Estadistica.PartidasGanadas = pg;
                j.Estadistica.Puntos = puntos;

                j.Equipo = nuevoEquipo;

                if (nuevoEquipo != null)
                {
                    if (!nuevoEquipo.ListaJugadores.Contains(j))
                    {
                        nuevoEquipo.ListaJugadores.Add(j);
                    }
                }

                ctrlJugador.Guardar(j);
            }
            else
            {
                Equipo equipoAnterior = jugadorEditar.Equipo;

                if (equipoAnterior != null)
                {
                    equipoAnterior.ListaJugadores.Remove(jugadorEditar);
                }

                jugadorEditar.Nombre = txtNombre.Text;
                jugadorEditar.Nick = txtNick.Text;

                jugadorEditar.Equipo = nuevoEquipo;

                if (nuevoEquipo != null)
                {
                    if (!nuevoEquipo.ListaJugadores.Contains(jugadorEditar))
                    {
                        nuevoEquipo.ListaJugadores.Add(jugadorEditar);
                    }
                }

                if (jugadorEditar.Estadistica == null)
                {
                    jugadorEditar.Estadistica = new Estadistica();
                }

                jugadorEditar.Estadistica.PartidasJugadas = pj;
                jugadorEditar.Estadistica.PartidasGanadas = pg;
                jugadorEditar.Estadistica.Puntos = puntos;

                ctrlJugador.Editar(jugadorEditar);
            }

            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJugadorEdit_Load(object sender, EventArgs e)
        {
            cboEquipos.DataSource = null;
            cboEquipos.DataSource = ctrlEquipo.Listar();

            cboEquipos.DisplayMember = "Nombre";
            cboEquipos.ValueMember = "Codigo";

            if (jugadorEditar != null)
            {
                cboEquipos.SelectedItem = jugadorEditar.Equipo;
            }
        }
    }
}
