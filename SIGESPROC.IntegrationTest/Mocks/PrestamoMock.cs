using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{

    class PrestamoMock
    {
        public static tbPrestamos CrearMockPrestamos()
        {
            return new tbPrestamos
            {
                pres_Id = 1,
                pres_Monto = 50000,
                pres_TasaInteres = 5,
                pres_Abonado = 10000,
                pres_Descripcion = "Préstamo inicial",
                pres_FechaPrimerPago = DateTime.Now.AddMonths(1),
                pres_Pagos = 10,
                pres_PagosRestantes = 5,
                empl_Id = 1,
                empleado = "Juan Pérez",
                frec_Id = 10,
                frec_Descripcion = "Mensual",
                pres_UltimaFechaPago = DateTime.Now.ToString(),
                usua_Creacion = 1,
                pres_FechaCreacion = DateTime.Now,
                usua_Modificacion = 1,
                pres_FechaModificacion = DateTime.Now,
                pres_Estado = true
            };
        }

        public static tbPrestamos ActualizarMockPrestamos()
        {
            return new tbPrestamos
            {
                pres_Id = 1,
                pres_Monto = 60000,
                pres_TasaInteres = 4,
                pres_Abonado = 15000,
                pres_Descripcion = "Préstamo actualizado",
                pres_FechaPrimerPago = DateTime.Now.AddMonths(1),
                pres_Pagos = 12,
                pres_PagosRestantes = 4,
                empl_Id = 1,
                empleado = "Juan Pérez",
                frec_Id = 10,
                frec_Descripcion = "Mensual",
                pres_UltimaFechaPago = DateTime.Now.ToString(),
                usua_Creacion = 1,
                pres_FechaCreacion = DateTime.Now,
                usua_Modificacion = 2,
                pres_FechaModificacion = DateTime.Now,
                pres_Estado = true
            };
        }

    }
}
