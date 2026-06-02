using Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador;
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
    public partial class frmReportes : Form
    {
        CtrlJugador ctrlJugador;
        CtrlEquipo ctrlEquipo;
        CtrlPartida ctrlPartida;
        CtrlTorneo ctrlTorneo;

        public frmReportes(CtrlJugador ctrlJ, CtrlEquipo ctrlE, CtrlPartida ctrlP, CtrlTorneo ctrlT)
        {
            InitializeComponent();

            ctrlJugador = ctrlJ;
            ctrlEquipo = ctrlE;
            ctrlPartida = ctrlP;
            ctrlTorneo = ctrlT;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            cboReportes.Items.Add("Jugadores");
            cboReportes.Items.Add("Equipos");
            cboReportes.Items.Add("Partidas");
            cboReportes.Items.Add("Torneos");
            cboReportes.Items.Add("Top Jugadores");
        }

        

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboReportes.Text;

            dgvReportes.DataSource = null;

            switch (opcion)
            {
                case "Jugadores":

                    dgvReportes.DataSource =
                        ctrlJugador.Listar();

                    break;

                case "Equipos":

                    dgvReportes.DataSource =
                        ctrlEquipo.Listar();

                    break;

                case "Partidas":

                    dgvReportes.DataSource =
                        ctrlPartida.Listar();

                    break;

                case "Torneos":

                    dgvReportes.DataSource =
                        ctrlTorneo.Listar();

                    break;

                case "Top Jugadores":

                    dgvReportes.DataSource =
                        ctrlJugador.Listar()
                        .OrderByDescending(x =>
                            x.Estadistica.Puntos)
                        .ToList();

                    break;
            }
        }
    }
}
