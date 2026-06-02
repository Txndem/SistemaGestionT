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
    public partial class frmTorneoEdit : Form
    {

        CtrlTorneo ctrlTorneo;
        CtrlEquipo ctrlEquipo;
        CtrlPartida ctrlPartida;

        Torneo torneoEditar;

        public frmTorneoEdit(CtrlTorneo ctrlT, CtrlEquipo ctrlE, CtrlPartida ctrlP, Torneo t)
        {
            InitializeComponent();

            ctrlTorneo = ctrlT;
            ctrlEquipo = ctrlE;
            ctrlPartida = ctrlP;

            CargarDatos();

            torneoEditar = t;

            txtCodigo.Text = t.Codigo;
            txtNombre.Text = t.Nombre;
            txtJuego.Text = t.Juego;

            txtPremio.Text = t.Premio.Nombre;

            cboEquipos.SelectedItem =
                t.ListaEquipos.FirstOrDefault();

            cboPartidas.SelectedItem =
                t.ListaPartidas.FirstOrDefault();
        }

        public frmTorneoEdit(CtrlTorneo ctrlT, CtrlEquipo ctrlE, CtrlPartida ctrlP)
        {
            InitializeComponent();

            ctrlTorneo = ctrlT;
            ctrlEquipo = ctrlE;
            ctrlPartida = ctrlP;

            CargarDatos();
        }

        public frmTorneoEdit()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            cboEquipos.DataSource = null;
            cboEquipos.DataSource = ctrlEquipo.Listar();

            cboPartidas.DataSource = null;
            cboPartidas.DataSource = ctrlPartida.Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (torneoEditar == null)
            {
                Torneo t = new Torneo();

                t.Codigo = txtCodigo.Text;
                t.Nombre = txtNombre.Text;
                t.Juego = txtJuego.Text;

                foreach (Equipo eq in lstEquipos.Items)
                {
                    t.ListaEquipos.Add(eq);
                }

                foreach (Partida p in lstPartidas.Items)
                {
                    t.ListaPartidas.Add(p);
                }

                ctrlTorneo.Guardar(t);
            }
            else
            {
                torneoEditar.Codigo = txtCodigo.Text;
                torneoEditar.Nombre = txtNombre.Text;
                torneoEditar.Juego = txtJuego.Text;

                torneoEditar.ListaEquipos.Clear();
                torneoEditar.ListaPartidas.Clear();

                foreach (Equipo eq in lstEquipos.Items)
                {
                    torneoEditar.ListaEquipos.Add(eq);
                }

                foreach (Partida p in lstPartidas.Items)
                {
                    torneoEditar.ListaPartidas.Add(p);
                }

                ctrlTorneo.Editar(torneoEditar);
            }

            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (cboEquipos.SelectedItem == null)
            {
                return;
            }

            Equipo eq = (Equipo)cboEquipos.SelectedItem;

            if (!lstEquipos.Items.Contains(eq))
            {
                lstEquipos.Items.Add(eq);
            }
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (lstEquipos.SelectedItem != null)
            {
                lstEquipos.Items.Remove(lstEquipos.SelectedItem);
            }
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            if (cboPartidas.SelectedItem == null)
            {
                return;
            }

            Partida p = (Partida)cboPartidas.SelectedItem;

            if (!lstPartidas.Items.Contains(p))
            {
                lstPartidas.Items.Add(p);
            }
        }

        private void btnQuitar2_Click(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedItem != null)
            {
                lstPartidas.Items.Remove(lstPartidas.SelectedItem);
            }
        }

        private void frmTorneoEdit_Load(object sender, EventArgs e)
        {
            cboEquipos.DataSource = null;
            cboEquipos.DataSource = ctrlEquipo.Listar();

            cboPartidas.DataSource = null;
            cboPartidas.DataSource = ctrlPartida.Listar();

            if (torneoEditar != null)
            {
                foreach (Equipo eq in torneoEditar.ListaEquipos)
                {
                    lstEquipos.Items.Add(eq);
                }

                foreach (Partida p in torneoEditar.ListaPartidas)
                {
                    lstPartidas.Items.Add(p);
                }
            }
        }
    }
}
