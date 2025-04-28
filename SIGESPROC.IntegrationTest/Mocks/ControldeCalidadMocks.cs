using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class ControldeCalidadMocks
    {
      

        public static tbControlDeCalidadesPorActividades CrearMockControldeCalidad()
        {
            return new tbControlDeCalidadesPorActividades
            {
                coca_Descripcion = "Prueba",
                coca_Fecha = DateTime.Now,
                coca_CantidadTrabajada = 1,
                acet_Id = 892,
                usua_Creacion = 3,
                coca_FechaCreacion = DateTime.Now
            };

        }

        public static tbControlDeCalidadesPorActividades EditarMockControldeCalidad()
        {
            return new tbControlDeCalidadesPorActividades
            {
                coca_Id=1,
                coca_Descripcion = "Prueba",
                coca_Fecha = DateTime.Now,
                coca_CantidadTrabajada = 1,
                acet_Id = 892,
                usua_Modificacion = 3,
                coca_FechaModificacion = DateTime.Now,
            };

        }


    }
}
