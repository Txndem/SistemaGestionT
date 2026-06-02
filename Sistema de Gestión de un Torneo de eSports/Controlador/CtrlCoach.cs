using Sistema_de_Gestión_de_un_Torneo_de_eSports.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_de_Gestión_de_un_Torneo_de_eSports.Controlador
{
    public class CtrlCoach
    {
        public List<Coach> ListaCoaches;

        public CtrlCoach()
        {
            ListaCoaches = new List<Coach>();
        }

        public void Guardar(Coach c)
        {
            ListaCoaches.Add(c);
        }

        public void Editar(Coach coachEditado)
        {
            var coach = ListaCoaches
                .FirstOrDefault(x => x.Codigo == coachEditado.Codigo);

            if (coach != null)
            {
                coach.Nombre = coachEditado.Nombre;
            }
        }

        public void Eliminar(string codigo)
        {
            var coach = ListaCoaches
                .FirstOrDefault(x => x.Codigo == codigo);

            if (coach != null)
            {
                ListaCoaches.Remove(coach);
            }
        }

        public List<Coach> Listar()
        {
            return ListaCoaches;
        }
    }
}