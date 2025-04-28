using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class ProcesoVentaMocks
    {
        public static ProcesosVentasViewModel CrearMockProcesoVenta()
        {
            return new ProcesosVentasViewModel
            {
                btrp_Id = 2,
                btrp_Identificador = true,
                btrp_PrecioVenta_Inicio = 42000,
                btrp_PrecioVenta_Final = 45000,
                btrp_FechaPuestaVenta = DateTime.Now,
                btrp_FechaVendida = DateTime.Now,
                agen_Id = 1,
                btrp_Terreno_O_BienRaizId = true,
                btrp_BienoterrenoId = 5,
                usua_Creacion = 3,
                usua_Modificacion = 3,
                btrp_FechaCreacion = DateTime.Now,
                btrp_FechaModificacion = DateTime.Now,
                btrp_Estado = true,
                mant_Id = 4

            };
        }

        public static ProcesosVentasViewModel EditarMockProcesoVenta()
        {
            return new ProcesosVentasViewModel
            {
                btrp_Id = 2,
                btrp_Identificador = true,
                btrp_PrecioVenta_Inicio = 42000,
                btrp_PrecioVenta_Final = 45000,
                btrp_FechaPuestaVenta = DateTime.Now,
                btrp_FechaVendida = DateTime.Now,
                agen_Id = 1,
                btrp_Terreno_O_BienRaizId = true,
                btrp_BienoterrenoId = 5,
                usua_Creacion = 3,
                usua_Modificacion = 3,
                btrp_FechaCreacion = DateTime.Now,
                btrp_FechaModificacion = DateTime.Now,
                btrp_Estado = true,
                mant_Id = 4

            };
        }
    }
}
