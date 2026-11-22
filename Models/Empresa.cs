using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("empresa")]
    public class Empresa : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("razon_social")]
        public string RazonSocial { get; set; } = string.Empty;

        [Column("ruc")]
        public string Ruc { get; set; } = string.Empty;

        [Column("numero_patronal_inss")]
        public string? NumeroPatronalInss { get; set; }

        [Column("direccion")]
        public string? Direccion { get; set; }

        [Column("telefono")]
        public string? Telefono { get; set; }

        [Column("logo_url")]
        public string? LogoUrl { get; set; }
    }
}