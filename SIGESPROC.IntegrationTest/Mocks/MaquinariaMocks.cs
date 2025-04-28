using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class MaquinariaMocks
    {
        public static tbMaquinarias CrearMoskMaquinaria()
        {
            return new tbMaquinarias
            {
                maqu_Descripcion = "Prueba",
                maqu_UltimoPrecioUnitario = 100,
                nive_Id = 5,
                usua_Creacion = 3,
                maqu_FechaCreacion = DateTime.Now
            };

        }

        public static tbMaquinarias EditarMoskMaquinaria()
        {
            return new tbMaquinarias
            {
                maqu_Id = 71,
                maqu_Descripcion = "Prueba",
                maqu_UltimoPrecioUnitario = 100,
                nive_Id = 5,
                usua_Modificacion = 3,
                maqu_FechaModificacion = DateTime.Now
            };

        }
    }
}
