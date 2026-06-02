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
    public partial class frmEquipoEdit : Form
    {
        CtrlJugador ctrlJugador;
        CtrlEquipo ctrlEquipo;
        CtrlCoach ctrlCoach;

        Equipo equipoEditar;

        public frmEquipoEdit(CtrlEquipo ctrlE, CtrlJugador ctrlJ, CtrlCoach ctrlC, Equipo eq)
        {
            InitializeComponent();

            ctrlEquipo = ctrlE;
            ctrlJugador = ctrlJ;
            ctrlCoach = ctrlC;

            equipoEditar = eq;

            txtCodigo.Text = eq.Codigo;
            txtNombre.Text = eq.Nombre;
            txtPais.Text = eq.Pais;

            foreach (Jugador j in eq.ListaJugadores)
            {
                lstJugadores.Items.Add(j);
            }
        }

        public frmEquipoEdit( CtrlEquipo ctrlEquipo, CtrlJugador ctrlJugador, CtrlCoach ctrlCoach)
        {
            InitializeComponent();

            this.ctrlEquipo = ctrlEquipo;
            this.ctrlJugador = ctrlJugador;
            this.ctrlCoach = ctrlCoach;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Equipo eq;

            if (equipoEditar == null)
            {
                eq = new Equipo();

                eq.Codigo = txtCodigo.Text;
                eq.Nombre = txtNombre.Text;
                eq.Pais = txtPais.Text;

                eq.Coach = (Coach)cboCoach.SelectedItem;

                ctrlEquipo.Guardar(eq);
            }
            else
            {
                eq = equipoEditar;

                eq.Codigo = txtCodigo.Text;
                eq.Nombre = txtNombre.Text;
                eq.Pais = txtPais.Text;

                eq.Coach = (Coach)cboCoach.SelectedItem;

                foreach (Jugador j in ctrlJugador.Listar())
                {
                    if (j.Equipo == eq)
                    {
                        j.Equipo = null;
                    }
                }

                eq.ListaJugadores.Clear();
            }

            foreach (Jugador j in lstJugadores.Items)
            {
                j.Equipo = eq;

                eq.ListaJugadores.Add(j);
            }

            ctrlEquipo.Editar(eq);

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmEquipoEdit_Load(object sender, EventArgs e)
        {
            cboCoach.DataSource = null;
            cboCoach.DataSource = ctrlCoach.Listar();

            cboJugadores.DataSource = null;
            cboJugadores.DataSource = ctrlJugador.Listar();

            if (equipoEditar != null)
            {
                cboCoach.SelectedItem = equipoEditar.Coach;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstJugadores.SelectedItem != null)
            {
                lstJugadores.Items.Remove(lstJugadores.SelectedItem);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboJugadores.SelectedItem == null)
            {
                MessageBox.Show("No hay jugadores disponibles");
                return;
            }

            Jugador j = (Jugador)cboJugadores.SelectedItem;

            if (j.Equipo != null)
            {
                if (equipoEditar == null || j.Equipo != equipoEditar)
                {
                    MessageBox.Show(
                        "El jugador ya pertenece al equipo: "
                        + j.Equipo.Nombre);

                    return;
                }
            }

            if (!lstJugadores.Items.Contains(j))
            {
                lstJugadores.Items.Add(j);
            }
        }
    }

    // Método para registrar un equipo en una lista


}
