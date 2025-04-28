using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class GestionAdicionalMocks
    {
        public static tbGestionesAdicionales CrearMockGestionesAdicionales()
        {
            return new tbGestionesAdicionales
            {
                adic_Descripcion = "Prueba",
                adic_Fecha = DateTime.Now,
                adic_PresupuestoAdicional = 30,
                acet_Id = 892,
                usua_Creacion = 3,
                adic_FechaCreacion = DateTime.Now,
                adic_Estado = true
            };

        }

        public static tbGestionesAdicionales EditarMockGestionesAdicionales()
        {
            return new tbGestionesAdicionales
            {
                adic_Id = 30,
                adic_Descripcion = "Prueba",
                adic_Fecha = DateTime.Now,
                adic_PresupuestoAdicional = 30,
                acet_Id = 892,
                usua_Modificacion = 3,
                adic_FechaModificacion = DateTime.Now,
         
            };

        }

    }
}
