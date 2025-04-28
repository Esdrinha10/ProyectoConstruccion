using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class PresupuestoPorTasaCambioMock
    {
        public static tbPresupuestosPorTasasCambio InsertarPresupuestoPorTasaCambioMock()
        {
            return new tbPresupuestosPorTasasCambio
            {
                pren_Id = 151,
                taca_Id = 115,
                usua_Creacion = 52,
                pptc_FechaCreacion = DateTime.Now
            };
        }

        public static tbPresupuestosPorTasasCambio ActualizarPresupuestoPorTasaCambioMock()
        {
            return new tbPresupuestosPorTasasCambio
            {
                pptc_Id = 176,
                pren_Id = 151,
                taca_Id = 115,
                usua_Modificacion = 52,
            };
        }
    }
}
