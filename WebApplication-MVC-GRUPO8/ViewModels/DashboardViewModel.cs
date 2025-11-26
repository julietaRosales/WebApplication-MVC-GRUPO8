using System.ComponentModel.DataAnnotations;
using WebApplication_MVC_GRUPO8.Models;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class DashboardViewModel
    {
        public int Activas { get; set; }
        public int EnProceso { get; set; }
        public int Finalizadas { get; set; }
        public int Descartadas { get; set; }
        public List<Incidencia> Recientes { get; set; }
    }

}