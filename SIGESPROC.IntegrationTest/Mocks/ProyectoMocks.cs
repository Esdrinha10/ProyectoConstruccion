using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class  ProyectoMocks
    {
        public static tbProyectos ProyectoModel()
        {
            return new tbProyectos
            {
                tipr_Id = 1,
                proy_Nombre = "Test Unitario",
                proy_Descripcion = "Descripcion Aqui",
                proy_FechaInicio = DateTime.Now,
                proy_FechaFin = DateTime.Now,
                proy_DireccionExacta = "Direccion Exacta Uni test",
                clie_Id = 1,
                ciud_Id = 1,
                usua_Creacion = 3,
                proy_FechaCreacion = DateTime.Now
            };
        }

        public static tbProyectos ActualizarMockProyecto()
        {
            return new tbProyectos
            {
                proy_Id = 149,
                tipr_Id = 1,
                proy_Nombre = "Proyecto edificio rios",
                proy_Descripcion = "Edificio en la Ceiba",
                proy_FechaInicio = DateTime.Now,
                proy_FechaFin = DateTime.Now,
                proy_DireccionExacta = "La ceiba, barrio barrias",
                clie_Id = 31,
                frec_Id = 7,
                espr_Id = 1,
                ciud_Id = 17,
                usua_Modificacion = 3,
                proy_FechaModificacion = DateTime.Now
            };
        }
    }
}
