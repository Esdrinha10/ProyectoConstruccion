using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SIGESPROC.IntegrationTest.Mocks
{
    public class FrecuenciaMocks
    {
        public static tbFrecuencias CrearMockFrecuencias()
        {
            return new tbFrecuencias
            {
                  frec_Id= 10,
                  frec_Descripcion= "PruebaC",
                  usua_Creacion= 3,
                  frec_FechaCreacion= DateTime.Now,
                  usua_Modificacion= 3,
                  frec_FechaModificacion= DateTime.Now,
                  frec_Estado= true
            };
        }

        public static tbFrecuencias ActualizarMockFrecuencias()
        {
            return new tbFrecuencias
            {   
                frec_Id = 10,
                frec_Descripcion = "PruebaE",
                usua_Creacion = 3,
                frec_FechaCreacion = DateTime.Now,
                usua_Modificacion = 3,
                frec_FechaModificacion = DateTime.Now,
                frec_Estado = true
            };
        }
    }
}
