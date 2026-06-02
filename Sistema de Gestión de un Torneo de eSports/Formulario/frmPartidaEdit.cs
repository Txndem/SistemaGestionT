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
    public partial class frmPartidaEdit : Form
    {
        CtrlPartida ctrlPartida;
        CtrlEquipo ctrlEquipo;

        Partida partidaEditar;

        public frmPartidaEdit(CtrlPartida ctrlP, CtrlEquipo ctrlE, Partida p)
        {
            InitializeComponent();

            ctrlPartida = ctrlP;
            ctrlEquipo = ctrlE;

            CargarDatos();

            partidaEditar = p;

            txtCodigo.Text = p.Codigo;

            txtScore1.Text = p.Score1.ToString();
            txtScore2.Text = p.Score2.ToString();

            dtpFecha.Value = p.Fecha;

            cboEquipo1.SelectedItem = p.Equipo1;
            cboEquipo2.SelectedItem = p.Equipo2;
            cboArbitro.SelectedItem = p.Arbitro;
        }

        public frmPartidaEdit(CtrlPartida ctrlP, CtrlEquipo ctrlE)
        {
            InitializeComponent();

            ctrlPartida = ctrlP;
            ctrlEquipo = ctrlE;

            CargarDatos();
        }

        public frmPartidaEdit()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            cboEquipo1.DataSource = null;
            cboEquipo1.DataSource = ctrlEquipo.Listar();

            cboEquipo2.DataSource = null;
            cboEquipo2.DataSource = ctrlEquipo.Listar().ToList();

            List<Arbitro> arbitros = new List<Arbitro>();

            arbitros.Add(new Arbitro("A01", "Carlos", "LAN"));
            arbitros.Add(new Arbitro("A02", "Luis", "LAS"));
            arbitros.Add(new Arbitro("A03", "David", "NA"));

            cboArbitro.DataSource = arbitros;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboEquipo1.SelectedItem == null || cboEquipo2.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar ambos equipos.");
                return;
            }

            Equipo eq1 = (Equipo)cboEquipo1.SelectedItem;
            Equipo eq2 = (Equipo)cboEquipo2.SelectedItem;

            if (eq1 == eq2)
            {
                MessageBox.Show("Un equipo no puede jugar contra sí mismo.");
                return;
            }

            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código.");
                return;
            }

            if (txtScore1.Text.Trim() == "" || txtScore2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese los scores.");
                return;
            }

            if (!int.TryParse(txtScore1.Text, out int score1) ||
                !int.TryParse(txtScore2.Text, out int score2))
            {
                MessageBox.Show("Los scores deben ser números.");
                return;
            }

            if (partidaEditar == null)
            {
                Partida p = new Partida();

                p.Codigo = txtCodigo.Text;

                p.Equipo1 = eq1;
                p.Equipo2 = eq2;

                p.Arbitro = (Arbitro)cboArbitro.SelectedItem;

                p.Servidor = (Servidor)cboServidores.SelectedItem;

                p.Score1 = score1;
                p.Score2 = score2;

                p.Fecha = dtpFecha.Value;

                ctrlPartida.Guardar(p);
            }
            else
            {
                partidaEditar.Codigo = txtCodigo.Text;

                partidaEditar.Equipo1 = eq1;
                partidaEditar.Equipo2 = eq2;

                partidaEditar.Arbitro = (Arbitro)cboArbitro.SelectedItem;

                partidaEditar.Servidor = (Servidor)cboServidores.SelectedItem;

                partidaEditar.Score1 = score1;
                partidaEditar.Score2 = score2;

                partidaEditar.Fecha = dtpFecha.Value;

                ctrlPartida.Editar(partidaEditar);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartidaEdit_Load(object sender, EventArgs e)
        {
            cboEquipo1.DataSource = ctrlEquipo.Listar();

            cboEquipo2.DataSource = ctrlEquipo.Listar().ToList();

            List<Arbitro> arbitros = new List<Arbitro>();

            arbitros.Add(new Arbitro("A01", "Carlos", "LAN"));
            arbitros.Add(new Arbitro("A02", "Luis", "LAS"));
            arbitros.Add(new Arbitro("A03", "David", "NA"));

            cboArbitro.DataSource = arbitros;

            List<Servidor> servidores = new List<Servidor>();

            servidores.Add(new Servidor("Servidor NA", "NA"));
            servidores.Add(new Servidor("Servidor SA", "SA"));
            servidores.Add(new Servidor("Servidor EU", "EU"));
            servidores.Add(new Servidor("Servidor AS", "AS"));
            servidores.Add(new Servidor("Servidor OCE", "OCE"));

            cboServidores.DataSource = servidores;
        }
    }
}
