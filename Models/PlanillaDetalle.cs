using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("planilla_detalle")]
    public class PlanillaDetalle : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("planilla_id")]
        public int PlanillaId { get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        [Column("dias_trabajados")]
        public decimal DiasTrabajados { get; set; } = 15.00m;

        [Column("salario_basico_quincenal")]
        public decimal SalarioBasicoQuincenal { get; set; }

        [Column("total_otros_ingresos")]
        public decimal TotalOtrosIngresos { get; set; }

        [Column("monto_subsidio_empresa")]
        public decimal MontoSubsidioEmpresa { get; set; }

        [Column("total_devengado")]
        public decimal TotalDevengado { get; set; }

        [Column("inss_laboral")]
        public decimal InssLaboral { get; set; }

        [Column("ir_laboral")]
        public decimal IrLaboral { get; set; }

        [Column("otras_deducciones")]
        public decimal OtrasDeducciones { get; set; }

        [Column("total_deducciones")]
        public decimal TotalDeducciones { get; set; }

        [Column("neto_a_recibir")]
        public decimal NetoARecibir { get; set; }

        [Column("inss_patronal")]
        public decimal InssPatronal { get; set; }

        [Column("inatec")]
        public decimal Inatec { get; set; }
    }
}