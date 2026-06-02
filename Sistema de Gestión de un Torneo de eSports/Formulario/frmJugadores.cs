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
    public partial class frmJugadores : Form
    {
        CtrlJugador ctrlJugador;
        CtrlEquipo ctrlEquipo;


        public frmJugadores(CtrlJugador ctrlJ, CtrlEquipo ctrlE)
        {
            InitializeComponent();

            ctrlJugador = ctrlJ;
            ctrlEquipo = ctrlE;
        }

        public void Listar()
        {
            dgvJugadores.DataSource = null;

            dgvJugadores.DataSource = ctrlJugador.Listar();

            if (dgvJugadores.Columns["Equipo"] != null)
            {
                dgvJugadores.Columns["Equipo"].Visible = false;
            }

            dgvJugadores.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmJugadorEdit frm = new frmJugadorEdit(ctrlJugador, ctrlEquipo);

            frm.ShowDialog();

            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvJugadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un jugador");
                return;
            }

            Jugador j =
                (Jugador)dgvJugadores.SelectedRows[0].DataBoundItem;

            frmJugadorEdit frm =
                new frmJugadorEdit(ctrlJugador, ctrlEquipo, j);

            frm.ShowDialog();

            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvJugadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un jugador");
                return;
            }

            Jugador j =
                (Jugador)dgvJugadores.SelectedRows[0].DataBoundItem;

            ctrlJugador.Eliminar(j.Codigo);

            Listar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvJugadores.DataSource = null;
            dgvJugadores.DataSource =
                ctrlJugador.Filtrar(txtBuscar.Text);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmJugadores_Load(object sender, EventArgs e)
        {
            dgvJugadores.AutoGenerateColumns = true;

            dgvJugadores.AllowUserToAddRows = false;

            dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvJugadores.MultiSelect = false;

            dgvJugadores.ReadOnly = true;

            dgvJugadores.RowHeadersVisible = false;

            Listar();
        }
    }
}
