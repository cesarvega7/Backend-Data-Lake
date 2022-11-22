using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLake.Entities
{
    [Table("Dim_Proyectos", Schema = "ods")]
    public class Proyectos
    {
        [Key]
        [Column("intProyectos")]
        public int IdProyecto { get; set; }
        [Required]
        [Column("intEmpresa")]
        public int IdEmpresa { get; set; }
        [Required]
        [Column("intProyectoCategoria")]
        public int IdProyectoCategoria { get; set; }
        [Required]
        [Column("intEtapas")]
        public int IdEtapa { get; set; }
        [Required]
        [Column("intProyectoGeneral")]
        public int IdProyectoGeneral { get; set; }
        [Required]
        [Column("vchNombreProyecto")]
        public string? NombreProyecto { get; set; }
        [Required]
        [Column("vchFechaInicio")]
        public string? FechaInicio { get; set; }
        [Required]
        [Column("vchFechaFin")]
        public string? FechaFin { get; set; }
        [Required]
        [Column("dmlMetrosCuadrados")]
        public decimal MetrosCuadrados { get; set; }
        [Column("vchFechaModificada")]
        public string? FechaModificacion { get; set; }
        [Required]
        [Column("dcmPorcentajeUtilidadC")]
        public decimal PorcentajeUtilidad { get; set; }
        [Column("vchCoordenadas")]
        public string? Coordenadas { get; set; }
        [Required]
        [Column("dtmFechaCarga")]
        public DateTime FechaCarga { get; set; }
    }
}
