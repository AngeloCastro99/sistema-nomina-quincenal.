using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("planillas")]
    public class Planilla : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("empresa_id")]
        public int EmpresaId { get; set; }

        [Column("codigo_planilla")]
        public string CodigoPlanilla { get; set; } = string.Empty;

        [Column("periodo_inicio")]
        public DateTime PeriodoInicio { get; set; } = DateTime.Today;

        [Column("periodo_fin")]
        public DateTime PeriodoFin { get; set; } = DateTime.Today.AddDays(14);

        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; } = DateTime.Today.AddDays(15);

        [Column("tipo_quincena")]
        public string TipoQuincena { get; set; } = "Primera Quincena";

        [Column("total_ingresos")]
        public decimal TotalIngresos { get; set; }

        [Column("total_deducciones")]
        public decimal TotalDeducciones { get; set; }

        [Column("total_neto")]
        public decimal TotalNeto { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = "Borrador";

        [Column("creado_por")]
        public string? CreadoPor { get; set; }
    }
}