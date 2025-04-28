using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class PresupuestoDetalleMock
    {
        public static tbPresupuestosDetalle InsertarPresupuestoDetalleMock()
        {
            return new tbPresupuestosDetalle
            {
                pdet_Id=0,
                pdet_Cantidad=1,
                pdet_PrecioManoObra=120,
                pdet_PrecioMateriales=0,
                pdet_PrecioMaquinaria=0,
                pdet_MaquinariaFormula="",
                pdet_MaterialFormula="",
                pdet_ManoObraFormula="",
                pdet_CantidadFormula="",
                unme_Id=58,
                pren_Id=146,
                acet_Id=2316,
                pdet_Incluido=false,
                pdet_Ganancia=0,
                acti_Id=0,
                usua_Creacion=56,
                pdet_FechaCreacion=DateTime.Now,
                usua_Modificacion=56,
                pdet_FechaModificacion=DateTime.Now
            };
        }

        public static tbPresupuestosDetalle ActualizarPresupuestoDetalleMock()
        {
            return new tbPresupuestosDetalle
            {
                pdet_Id = 1139,
                pdet_Cantidad = 1,
                pdet_PrecioManoObra = 120,
                pdet_PrecioMateriales = 0,
                pdet_PrecioMaquinaria = 0,
                pdet_MaquinariaFormula = "",
                pdet_MaterialFormula = "",
                pdet_ManoObraFormula = "",
                pdet_CantidadFormula = "",
                unme_Id = 58,
                pren_Id = 146,
                acet_Id = 2316,
                pdet_Incluido = false,
                pdet_Ganancia = 0,
                acti_Id = 0,
                usua_Creacion = 56,
                pdet_FechaCreacion = DateTime.Now,
                usua_Modificacion = 56,
                pdet_FechaModificacion = DateTime.Now
            };
        }
    }
}
