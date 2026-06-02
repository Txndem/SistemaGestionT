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
    public partial class frmPartidas : Form
    {
        CtrlPartida ctrlPartida;

        CtrlEquipo ctrlEquipo;

        public frmPartidas(CtrlPartida ctrlP, CtrlEquipo ctrlE)
        {
            InitializeComponent();

            ctrlPartida = ctrlP;
            ctrlEquipo = ctrlE;
        }



        public void Listar()
        {
            dgvPartidas.DataSource = null;

            dgvPartidas.DataSource = ctrlPartida.Listar();

            dgvPartidas.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPartidaEdit frm = new frmPartidaEdit(ctrlPartida,ctrlEquipo);

            frm.ShowDialog();

            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPartidas.CurrentRow != null)
            {
                Partida p = (Partida)dgvPartidas.CurrentRow.DataBoundItem;

                frmPartidaEdit frm =
                    new frmPartidaEdit(ctrlPartida, ctrlEquipo, p);

                frm.ShowDialog();

                Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPartidas.CurrentRow != null)
            {
                Partida p = (Partida)dgvPartidas.CurrentRow.DataBoundItem;

                ctrlPartida.Eliminar(p.Codigo);

                Listar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPartidas.DataSource = null;

            dgvPartidas.DataSource = ctrlPartida.Filtrar(txtBuscar.Text);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartidas_Load(object sender, EventArgs e)
        {
            dgvPartidas.AllowUserToAddRows = false;

            dgvPartidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPartidas.MultiSelect = false;

            dgvPartidas.ReadOnly = true;

            dgvPartidas.RowHeadersVisible = false;

            Listar();
        }
    }
}
