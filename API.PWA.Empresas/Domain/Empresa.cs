using System.ComponentModel.DataAnnotations;

namespace API.PWA.Empresas.Domain
{
    public class Empresa
    {
        [Key]
        public Guid IdEmpresa { get; set; }

        public string NombreEmpresa { get; set; }

        public string DireccionEmpresa { get; set; }

        public string ImagenEmpresa { get; set; }

        public string DescripcionEmpresa { get; set; }
    }
}
