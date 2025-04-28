using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class RetrasoMock
    {
        public static tbRetrasos InsertarRetrasoMock()
        {
            return new tbRetrasos
            {
                retr_Descripcion = "Descripción Del Retraso",
                retr_Monto = 5000,
                retr_Fecha = DateTime.Now,
                Proy_Id = 4,
                usua_Creacion = 3,
                retr_FechaCreacion = DateTime.Now
            };
        }

        public static tbRetrasos ActualizarRetrasoMock()
        {
            return new tbRetrasos
            {
                retr_Id = 3,
                retr_Descripcion = "Descripción Del Retraso Actualizada",
                retr_Monto = 15000,
                retr_Fecha = DateTime.Now,
                Proy_Id = 4,
                usua_Creacion = 3,
                retr_FechaCreacion = DateTime.Now
            };
        }
    }
}
