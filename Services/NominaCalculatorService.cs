using SistemaNominaQuincenal.Models;

namespace SistemaNominaQuincenal.Services
{
    public class NominaCalculatorService
    {
        // Porcentajes de Ley en Nicaragua
        private const decimal TasaInssLaboral = 0.07m;      // 7%
        private const decimal TasaInssPatronal = 0.225m;   // 22.5% (Empresas grandes/medianas)
        private const decimal TasaInatec = 0.02m;          // 2%

        /// <summary>
        /// Calcula todos los deducciones y aportes para un detalle de planilla quincenal.
        /// </summary>
        public void CalcularDetallePlanilla(PlanillaDetalle detalle, bool aplicaInss = true, bool aplicaIr = true)
        {
            // 1. Total Devengado Quincenal (Salario básico + otros ingresos / subsidios)
            detalle.TotalDevengado = detalle.SalarioBasicoQuincenal + detalle.TotalOtrosIngresos + detalle.MontoSubsidioEmpresa;

            // 2. INSS Laboral (Se calcula sobre el devengado de la quincena si aplica)
            if (aplicaInss)
            {
                detalle.InssLaboral = Math.Round(detalle.TotalDevengado * TasaInssLaboral, 2);
            }
            else
            {
                detalle.InssLaboral = 0.00m;
            }

            // 3. IR Laboral (El IR en Nicaragua se calcula sobre base mensual. 
            // Multiplicamos la base quincenal por 2 para estimar el equivalente mensual, calculamos la escala y dividimos entre 2).
            if (aplicaIr)
            {
                decimal salarioMensualEstimado = detalle.TotalDevengado * 2m;
                decimal irMensual = CalcularIrMensual(salarioMensualEstimado, detalle.InssLaboral * 2m);
                detalle.IrLaboral = Math.Round(irMensual / 2m, 2);
            }
            else
            {
                detalle.IrLaboral = 0.00m;
            }

            // 4. Totales de Deducciones y Neto a Recibir
            detalle.TotalDeducciones = detalle.InssLaboral + detalle.IrLaboral + detalle.OtrasDeducciones;
            detalle.NetoARecibir = Math.Round(detalle.TotalDevengado - detalle.TotalDeducciones, 2);

            // 5. Aportes Patronales (Para reportes fiscales INSS/INATEC)
            if (aplicaInss)
            {
                detalle.InssPatronal = Math.Round(detalle.TotalDevengado * TasaInssPatronal, 2);
                detalle.Inatec = Math.Round(detalle.TotalDevengado * TasaInatec, 2);
            }
            else
            {
                detalle.InssPatronal = 0.00m;
                detalle.Inatec = 0.00m;
            }
        }

        /// <summary>
        /// Tabla Progresiva del IR (DGI Nicaragua) anualizada / convertida a mensual.
        /// </summary>
        private decimal CalcularIrMensual(decimal salarioMensual, decimal inssMensual)
        {
            // Base imponible anual (excluyendo el INSS anual)
            decimal baseAnualImponible = (salarioMensual - inssMensual) * 12m;
            decimal impuestoAnual = 0m;

            // Escalas de IR en Nicaragua
            if (baseAnualImponible <= 100000m)
            {
                impuestoAnual = 0m;
            }
            else if (baseAnualImponible <= 200000m)
            {
                impuestoAnual = (baseAnualImponible - 100000m) * 0.15m;
            }
            else if (baseAnualImponible <= 350000m)
            {
                impuestoAnual = 15000m + ((baseAnualImponible - 200000m) * 0.20m);
            }
            else if (baseAnualImponible <= 500000m)
            {
                impuestoAnual = 45000m + ((baseAnualImponible - 350000m) * 0.25m);
            }
            else
            {
                impuestoAnual = 82500m + ((baseAnualImponible - 500000m) * 0.30m);
            }

            // Retornar IR mensual
            return Math.Max(0m, impuestoAnual / 12m);
        }
    }
}