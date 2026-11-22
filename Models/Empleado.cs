using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SistemaNominaQuincenal.Models
{
    [Table("empleados")]
    public class Empleado : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("codigo_empleado")]
        public string CodigoEmpleado { get; set; } = string.Empty;

        [Column("nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Column("apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Column("cedula")]
        public string Cedula { get; set; } = string.Empty;

        [Column("numero_inss")]
        public string? NumeroInss { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-25);

        [Column("genero")]
        public string Genero { get; set; } = "M";

        [Column("telefono")]
        public string? Telefono { get; set; }

        [Column("correo")]
        public string? Correo { get; set; }

        [Column("direccion")]
        public string? Direccion { get; set; }

        [Column("cuenta_bancaria")]
        public string? CuentaBancaria { get; set; }

        [Column("banco")]
        public string? Banco { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = "Activo";

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; }
    }
}