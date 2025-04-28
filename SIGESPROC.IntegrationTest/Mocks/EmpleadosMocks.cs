using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class EmpleadosMocks
    {
        public static tbEmpleados CrearMockEmpleados()
        {
            return new tbEmpleados
            {
                empl_DNI = "1909200909821",
                empl_Nombre = "Prueba",
                empl_Apellido = "Prueba",
                empl_CorreoElectronico = "Prueba",
                empl_Telefono = "89587844",
                empl_Sexo = "f",
                empl_FechaNacimiento = DateTime.Now,
                empl_Salario = 5125,
                deduccionesJSON = "5855",
                ciud_Id = 1,
                civi_Id = 1,
                carg_Id = 1,
                banc_Id = 1,
                frec_Id = 1,
                empl_NoBancario = "a",
                usua_Creacion = 3,
                empl_FechaCreacion = DateTime.Now,
            };
        }

        public static tbEmpleados EditarMockEmpleados()
        {
            return new tbEmpleados
            {
                empl_Id = 1,
                empl_DNI = "1909200909821",
                empl_Nombre = "Prueba",
                empl_Apellido = "Prueba",
                empl_CorreoElectronico = "Prueba",
                empl_Telefono = "89587844",
                empl_Sexo = "f",
                empl_FechaNacimiento = DateTime.Now,
                empl_Salario = 5125,
                ciud_Id = 1,
                civi_Id = 1,
                carg_Id = 1,
                banc_Id = 1,
                frec_Id = 1,
                empl_NoBancario = "a",
                usua_Modificacion = 3,
                empl_FechaModificacion = DateTime.Now,
            };
        }
    }
}
