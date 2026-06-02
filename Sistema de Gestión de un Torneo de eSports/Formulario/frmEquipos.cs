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
    public partial class frmEquipos : Form
    {
        CtrlEquipo ctrlEquipo;
        CtrlJugador ctrlJugador;
        CtrlCoach ctrlCoach;

        public frmEquipos(CtrlEquipo ctrlE, CtrlJugador ctrlJ, CtrlCoach ctrlC)
        {
            InitializeComponent();

            ctrlEquipo = ctrlE;
            ctrlJugador = ctrlJ;
            ctrlCoach = ctrlC;
        }

        public void Listar()
        {
            dgvEquipos.DataSource = null;

            dgvEquipos.DataSource = ctrlEquipo.Listar();

            if (dgvEquipos.Columns["ListaJugadores"] != null)
            {
                dgvEquipos.Columns["ListaJugadores"].Visible = false;
            }

            dgvEquipos.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmEquipoEdit frm = new frmEquipoEdit(ctrlEquipo, ctrlJugador, ctrlCoach);

            frm.ShowDialog();

            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.CurrentRow != null)
            {
                Equipo eq =
                    (Equipo)dgvEquipos.CurrentRow.DataBoundItem;

                frmEquipoEdit frm = new frmEquipoEdit(ctrlEquipo, ctrlJugador, ctrlCoach, eq);

                frm.ShowDialog();

                Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.CurrentRow != null)
            {
                Equipo eq =
                    (Equipo)dgvEquipos.CurrentRow.DataBoundItem;

                ctrlEquipo.Eliminar(eq.Codigo);

                Listar();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEquipos.DataSource = null;

            dgvEquipos.DataSource =
                ctrlEquipo.Filtrar(txtBuscar.Text);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEquipos_Load(object sender, EventArgs e)
        {
            dgvEquipos.AllowUserToAddRows = false;

            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvEquipos.MultiSelect = false;

            dgvEquipos.ReadOnly = true;

            dgvEquipos.RowHeadersVisible = false;

            Listar();
        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEquipos_SelectionChanged(object sender, EventArgs e)
        {
            lstIntegrantes.Items.Clear();

            if (dgvEquipos.CurrentRow != null)
            {
                Equipo eq =
                    (Equipo)dgvEquipos.CurrentRow.DataBoundItem;

                if (eq != null)
                {
                    foreach (Jugador j in eq.ListaJugadores)
                    {
                        lstIntegrantes.Items.Add(j);
                    }
                }
            }
        }
    }
}
