using SIGESPROC.Common.Models.ModelsPlanilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class PlanillasMocks
    {
        public static ListarEmpleadosPlanillaViewModel ListarPlanilla()
        {
            return new ListarEmpleadosPlanillaViewModel
            {
                fecha = "2024-12-21",
                frecid = 5,
                jefeplani = false,
                plan_Id = 0,
                saberCrear = false,
                usuaCrea = 27
            };
        }

        public class PlanillaRequest
        {
            public List<PlanillaViewModel> planillaViewModel { get; set; }
            public List<PagoPlanillaEmpleadosViewModel> planillaEmpleado { get; set; }
        }

        public static PlanillaRequest CreatePlanilla()
        {
            return new PlanillaRequest
            {
                planillaViewModel = new List<PlanillaViewModel>
        {
            new PlanillaViewModel
            {
                frec_Id = 5,
                plan_FechaPago = "2024-12-21T06:00:00.000Z",
                plan_FechaPeriodoFin = "2024-12-21T06:00:00.000Z",
                plan_Id = 0,
                plan_NumNomina = 0,
                plan_Observaciones = "",
                plan_PlanillaJefes = false,
                usuaCreacion = "",
                usuaModificacion = "",
                usua_Creacion = 27,
                usua_Modificacion = 0
            }
        },
                planillaEmpleado = new List<PagoPlanillaEmpleadosViewModel>
        {
            new PagoPlanillaEmpleadosViewModel
            {
                carg_Id = 22,
                cargo = "Conductor",
                codigo = 1,
                deducciones = new List<DeduccionViewModel>(), // Aseguramos que sea una lista vacía
                empl_Apellido = "Teruel",
                empl_CorreoElectronico = "raulteru@gmail.com",
                empl_DNI = "0498408940894",
                empl_Estado = true,
                empl_Id = 78,
                empl_Salario = 80000,
                plan_Id = 0,
                prestamos = new List<PrestamoViewModel>(), // Aseguramos que sea una lista vacía
                salarioDiario = 0,
                salarioExtra = 0,
                sueldoTotal = 0,
                totalDeducido = 38188,
                totalDevenagado = 0,
                totalPrestamos = 100,
                usua_Creacion = 3
            }
        }
            };
        }

    }
}
