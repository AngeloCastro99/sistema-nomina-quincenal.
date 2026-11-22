using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("tipos_contrato")]
    public class TipoContrato : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("aplica_inss")]
        public bool AplicaInss { get; set; } = true;

        [Column("aplica_ir")]
        public bool AplicaIr { get; set; } = true;

        [Column("aplica_prestaciones")]
        public bool AplicaPrestaciones { get; set; } = true;
    }
}