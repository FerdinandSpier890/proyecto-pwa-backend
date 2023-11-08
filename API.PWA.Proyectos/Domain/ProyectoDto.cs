using System.ComponentModel.DataAnnotations;

namespace API.PWA.Proyectos.Domain
{
    public class ProyectoDto
    {
        [Key]
        public Guid IdProyecto { get; set; }

        public string NombreProyecto { get; set; }

        public string DuracionProyecto { get; set; }

        public string SoftwareProyecto { get; set; }

        public Guid EmpresaProyecto { get; set; }
    }
}
