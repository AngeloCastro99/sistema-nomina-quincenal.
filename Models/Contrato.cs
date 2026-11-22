using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("contratos")]
    public class Contrato : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        [Column("cargo_id")]
        public int CargoId { get; set; }

        [Column("tipo_contrato_id")]
        public int TipoContratoId { get; set; }

        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; } = DateTime.Today;

        [Column("fecha_fin")]
        public DateTime? FechaFin { get; set; }

        [Column("salario_mensual")]
        public decimal SalarioMensual { get; set; }

        [Column("salario_quincenal", ignoreOnInsert: true, ignoreOnUpdate: true)]
        public decimal SalarioQuincenal { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = "Vigente";
    }
}