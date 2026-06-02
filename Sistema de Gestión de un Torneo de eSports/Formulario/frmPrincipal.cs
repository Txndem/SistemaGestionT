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
    public partial class frmPrincipal : Form
    {
        CtrlJugador ctrlJugador = new CtrlJugador();
        CtrlEquipo ctrlEquipo = new CtrlEquipo();
        CtrlPartida ctrlPartida = new CtrlPartida();
        CtrlTorneo ctrlTorneo = new CtrlTorneo();
        CtrlCoach ctrlCoach = new CtrlCoach();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmJugadores frm = new frmJugadores(ctrlJugador, ctrlEquipo);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEquipos frm = new frmEquipos(ctrlEquipo, ctrlJugador, ctrlCoach);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPartidas frm = new frmPartidas(ctrlPartida, ctrlEquipo);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTorneo frm = new frmTorneo(ctrlTorneo, ctrlEquipo, ctrlPartida);

            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes(ctrlJugador, ctrlEquipo, ctrlPartida, ctrlTorneo);
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            // EQUIPOS

            Equipo nacional = new Equipo()
            {
                Codigo = "EQ001",
                Nombre = "El Nacional eSports",
                Pais = "Ecuador"
            };

            Equipo abysmus = new Equipo()
            {
                Codigo = "EQ002",
                Nombre = "Abysmus",
                Pais = "Ecuador"
            };

            Equipo m5 = new Equipo()
            {
                Codigo = "EQ003",
                Nombre = "M5 eSports",
                Pais = "Ecuador"
            };

            ctrlEquipo.Guardar(nacional);
            ctrlEquipo.Guardar(abysmus);
            ctrlEquipo.Guardar(m5);

            // COACHES

            Coach c1 = new Coach()
            {
                Codigo = "C001",
                Nombre = "Coach Shadow"
            };

            Coach c2 = new Coach()
            {
                Codigo = "C002",
                Nombre = "Coach Blaze"
            };

            Coach c3 = new Coach()
            {
                Codigo = "C003",
                Nombre = "Coach Nova"
            };

            ctrlCoach.Guardar(c1);
            ctrlCoach.Guardar(c2);
            ctrlCoach.Guardar(c3);

            nacional.Coach = c1;
            abysmus.Coach = c2;
            m5.Coach = c3;

            // JUGADORES

            Jugador j1 = new Jugador()
            {
                Codigo = "J001",
                Nombre = "Carlos Tandazo",
                Nick = "txndem_rl",
                Equipo = nacional,
                Estadistica = new Estadistica()
                {
                    PartidasJugadas = 120,
                    PartidasGanadas = 79,
                    Puntos = 1580
                }
            };

            Jugador j2 = new Jugador()
            {
                Codigo = "J002",
                Nombre = "Emilio Sanchez",
                Nick = "sanxs_s",
                Equipo = nacional,
                Estadistica = new Estadistica()
                {
                    PartidasJugadas = 110,
                    PartidasGanadas = 70,
                    Puntos = 1420
                }
            };

            Jugador j3 = new Jugador()
            {
                Codigo = "J003",
                Nombre = "Alex",
                Nick = "ados",
                Equipo = nacional,
                Estadistica = new Estadistica()
                {
                    PartidasJugadas = 98,
                    PartidasGanadas = 58,
                    Puntos = 1200
                }
            };

            Jugador j4 = new Jugador()
            {
                Codigo = "J004",
                Nombre = "Jandry",
                Nick = "jz_predator22",
                Equipo = nacional,
                Estadistica = new Estadistica()
                {
                    PartidasJugadas = 135,
                    PartidasGanadas = 88,
                    Puntos = 1760
                }
            };

            ctrlJugador.Guardar(j1);
            ctrlJugador.Guardar(j2);
            ctrlJugador.Guardar(j3);
            ctrlJugador.Guardar(j4);

            nacional.ListaJugadores.Add(j1);
            nacional.ListaJugadores.Add(j2);
            nacional.ListaJugadores.Add(j3);
            nacional.ListaJugadores.Add(j4);

            // ARBITROS

            Arbitro a1 = new Arbitro()
            {
                Codigo = "A001",
                Nombre = "Luis Torres"
            };

            Arbitro a2 = new Arbitro()
            {
                Codigo = "A002",
                Nombre = "Kevin Mora"
            };

            // PARTIDAS

            Partida p1 = new Partida()
            {
                Codigo = "P001",
                Equipo1 = nacional,
                Equipo2 = abysmus,
                Arbitro = a1,
                Score1 = 3,
                Score2 = 1,
                Fecha = DateTime.Now
            };

            Partida p2 = new Partida()
            {
                Codigo = "P002",
                Equipo1 = nacional,
                Equipo2 = m5,
                Arbitro = a2,
                Score1 = 2,
                Score2 = 3,
                Fecha = DateTime.Now
            };

            ctrlPartida.Guardar(p1);
            ctrlPartida.Guardar(p2);

            // TORNEO

            Torneo t1 = new Torneo()
            {
                Codigo = "T001",
                Nombre = "Rocket League Masters EC",
                Juego = "Rocket League",

                Premio = new Premio()
                {
                    Nombre = "Premio Principal",
                    Valor = 500
                }
            };

            t1.ListaEquipos.Add(nacional);
            t1.ListaEquipos.Add(abysmus);
            t1.ListaEquipos.Add(m5);

            t1.ListaPartidas.Add(p1);
            t1.ListaPartidas.Add(p2);

            ctrlTorneo.Guardar(t1);
        }
    }
}
