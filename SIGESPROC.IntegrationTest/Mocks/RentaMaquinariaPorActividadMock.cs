using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class RentaMaquinariaPorActividadMock
    {
        public static tbRentaMaquinariasPorActividades InsertarRentaMaquinariaPorActividadMock()
        {
            return new tbRentaMaquinariasPorActividades
            {
                rmac_Id = 310,
                rmac_FechaContratacion = DateTime.Now,
                rmac_Rentapor = 0,
                rmac_CantidadRenta = 100,
                rmac_PrecioRenta = 300,
                rmac_CantidadMaquinas = 1,
                mapr_Id = 79,
                acet_Id = 986,
                usua_Creacion = 52,
                rmac_ActividadLlenado = null,
                rmac_FechaCreacion = DateTime.Now,
                usua_Modificacion = 52,
                rmac_CantidadMaquinaFormula = "",
                rmac_PrecioRentaFormula = "",
                rmac_CantidadRentaFormula = "",
                rmac_FechaModificacion = DateTime.Now,
                rmac_Estado = true,
                usuaCreacion = "string",
                usuaModificacion = "string",
                rmac_HorasRenta = 0
            };
        }

        public static tbRentaMaquinariasPorActividades ActualizarRentaMaquinariaPorActividadMock()
        {
            return new tbRentaMaquinariasPorActividades
            {
                rmac_Id = 310,
                rmac_FechaContratacion = DateTime.Now,
                rmac_Rentapor = 0,
                rmac_CantidadRenta = 100,
                rmac_PrecioRenta = 300,
                rmac_CantidadMaquinas = 1,
                mapr_Id = 79,
                acet_Id = 986,
                usua_Creacion = 52,
                rmac_ActividadLlenado = null,
                rmac_FechaCreacion = DateTime.Now,
                usua_Modificacion = 52,
                rmac_CantidadMaquinaFormula = "",
                rmac_PrecioRentaFormula = "",
                rmac_CantidadRentaFormula = "",
                rmac_FechaModificacion = DateTime.Now,
                rmac_Estado = true,
                usuaCreacion = "string",
                usuaModificacion = "string",
                rmac_HorasRenta = 0
            };
        }
    }
}
