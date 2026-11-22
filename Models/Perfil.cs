using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("perfiles")]
    public class Perfil : BaseModel
    {
        [PrimaryKey("id", true)] // true porque el UUID viene de auth.users
        public string Id { get; set; } = string.Empty;

        [Column("nombre_completo")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Column("rol")]
        public string Rol { get; set; } = "Consulta";

        [Column("activo")]
        public bool Activo { get; set; } = true;

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; }
    }
}