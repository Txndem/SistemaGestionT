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
    public partial class frmTorneo : Form
    {
        CtrlTorneo ctrlTorneo;

        CtrlEquipo ctrlEquipo;
        CtrlPartida ctrlPartida;

        public frmTorneo(CtrlTorneo ctrlT, CtrlEquipo ctrlE, CtrlPartida ctrlP)
        {
            InitializeComponent();

            ctrlTorneo = ctrlT;
            ctrlEquipo = ctrlE;
            ctrlPartida = ctrlP;
        }


        public void Listar()
        {
            dgvTorneos.DataSource = null;
            dgvTorneos.DataSource = ctrlTorneo.Listar();

            if (dgvTorneos.Columns["ListaEquipos"] != null)
                dgvTorneos.Columns["ListaEquipos"].Visible = false;

            if (dgvTorneos.Columns["ListaPartidas"] != null)
                dgvTorneos.Columns["ListaPartidas"].Visible = false;

            if (dgvTorneos.Columns["Premio"] != null)
                dgvTorneos.Columns["Premio"].Visible = false;

            if (!dgvTorneos.Columns.Contains("PremioTexto"))
            {
                dgvTorneos.Columns.Add("PremioTexto", "Premio");
            }

            foreach (DataGridViewRow row in dgvTorneos.Rows)
            {
                if (row.DataBoundItem is Torneo t && t.Premio != null)
                {
                    row.Cells["PremioTexto"].Value =
                        $"{t.Premio.Nombre} - ${t.Premio.Valor}";
                }
            }

            dgvTorneos.ClearSelection();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmTorneoEdit frm = new frmTorneoEdit(ctrlTorneo, ctrlEquipo, ctrlPartida);

            frm.ShowDialog();

            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTorneos.CurrentRow != null)
            {
                Torneo t =
                    (Torneo)dgvTorneos.CurrentRow.DataBoundItem;

                frmTorneoEdit frm =
                    new frmTorneoEdit(ctrlTorneo,
                                      ctrlEquipo,
                                      ctrlPartida,
                                      t);

                frm.ShowDialog();

                Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTorneos.CurrentRow != null)
            {
                Torneo t =
                    (Torneo)dgvTorneos.CurrentRow.DataBoundItem;

                ctrlTorneo.Eliminar(t.Codigo);

                Listar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvTorneos.DataSource = null;

            dgvTorneos.DataSource =
                ctrlTorneo.Filtrar(txtBuscar.Text);
        }

        private void frmTorneo_Load(object sender, EventArgs e)
        {
            dgvTorneos.AllowUserToAddRows = false;

            dgvTorneos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvTorneos.MultiSelect = false;

            dgvTorneos.ReadOnly = true;

            dgvTorneos.RowHeadersVisible = false;

            Listar();
        }
    }
}
