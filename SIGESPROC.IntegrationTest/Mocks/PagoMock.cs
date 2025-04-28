using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class PagoMock
    {
        public static tbPagos InsertarPagoMock()
        {
            return new tbPagos
            {
                pago_Monto = 500,
                pago_Fecha = DateTime.Now,
                clie_Id = 18,
                proy_Id = 176,
                usua_Creacion = 3,
                pago_FechaCreacion = DateTime.Now
            };
        }

        public static tbPagos ActualizarPagoMock()
        {
            return new tbPagos
            {
                pago_Id = 13,
                pago_Monto = 500,
                pago_Fecha = DateTime.Now,
                clie_Id = 18,
                proy_Id = 176,
                usua_Creacion = 3,
                pago_FechaCreacion = DateTime.Now
            };
        }
    }
}
