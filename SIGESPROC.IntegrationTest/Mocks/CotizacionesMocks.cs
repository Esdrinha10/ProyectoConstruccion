using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public  class CotizacionesMocks
    {
        public static List<CotizacionViewModel> CrearMockCotizacion()
        {
            return new List<CotizacionViewModel>
    {
        new CotizacionViewModel
        {
            coti_Id = 547,
            prov_Id = 63,
            coti_Fecha = DateTime.Now,
            empl_Id = 2,
            coti_Incluido = true,
            coti_CompraDirecta = true,
            usua_Creacion = 7,
            coti_FechaCreacion = DateTime.Now,
            code_Cantidad = 1,
            code_Renta = 0,
            code_PrecioCompra = 0,
            cime_Id = 0,
            cime_InsumoOMaquinariaOEquipoSeguridad = 0,
            usua_Modificacion = 0,
            coti_FechaModificacion = DateTime.Now,
            coti_Estado = true,
            check = true
        }
    };
        }


        public static CotizacionDetalleViewModel EditarMockCotizacionesDetalle()
        {
            return new CotizacionDetalleViewModel
            {
                code_Id = 440,
                coti_Id = 150,
                cime_Id = 2,
                code_Cantidad = 1,
                code_PrecioCompra = 2000,
                usua_Modificacion = 3,
                code_FechaModificacion = DateTime.Now
            };
        }
    }
}
