using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class DocumentosMocks
    {
        public static tbDocumentos CrearMockDocumentos()
        {
            return new tbDocumentos
            {
                docu_Tipo = "Prueba",
                docu_Descripcion = "Prueba",
                docu_Ruta = "Prueba",
                docu_Fecha = DateTime.Now,
                empl_Id = 30,
                proy_Id = 892,
                usua_Creacion = 3,
                docu_FechaCreacion = DateTime.Now
            };

        }

        public static tbDocumentos EditarMockDocumentos()
        {
            return new tbDocumentos
            {

                docu_Id = 3,
                docu_Tipo = "Prueba",
                docu_Descripcion = "Prueba",
                docu_Ruta = "Prueba",
                docu_Fecha = DateTime.Now,
                empl_Id = 30,
                proy_Id = 892,
                usua_Modificacion = 3,
                docu_FechaModificacion = DateTime.Now
            };

        }

    }
}
