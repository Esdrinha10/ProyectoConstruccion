using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class GestiondeRiesgoMocks
    {


        public static tbGestionRiesgos CrearMockGestionRiesgos()
        {
            return new tbGestionRiesgos
            {
                geri_Descripcion = "Prueba",
                geri_Impacto = "Prueba",
                geri_Probabilidad = 30,
                geri_Mitigacion = "prueba",
                proy_Id = 892,
                usua_Creacion = 3,
                geri_FechaCreacion = DateTime.Now,
            };

        }

        public static tbGestionRiesgos EditarMockGestionRiesgos()
        {
            return new tbGestionRiesgos
            {
                geri_Id = 27,
                geri_Descripcion = "Prueba",
                geri_Impacto = "Prueba",
                geri_Probabilidad = 30,
                geri_Mitigacion = "prueba",
                proy_Id = 892,
                usua_Modificacion = 3,
                geri_FechaModificacion = DateTime.Now,
            };

        }
    }
}
