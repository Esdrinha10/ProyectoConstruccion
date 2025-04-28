using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ProveedorMock
    {
        public static tbProveedores CrearMoskProveedor()
        {
            return new tbProveedores
            {
                prov_Descripcion = "Prueba",
                prov_Correo = "Prueba",
                prov_InsumoOMaquinariaOEquipoSeguridad = 1,
                prov_Telefono = "97201491",
                prov_SegundoTelefono = "33623663",
                ciud_Id = 3,
                usua_Creacion = 3,
                prov_FechaCreacion = DateTime.Now
            };

        }

        public static tbProveedores EditarMoskProveedor()
        {
            return new tbProveedores
            {
                prov_Id = 71,
                prov_Descripcion = "Prueba",
                prov_Correo = "Prueba",
                prov_InsumoOMaquinariaOEquipoSeguridad = 1,
                prov_Telefono = "97201491",
                prov_SegundoTelefono = "33623663",
                ciud_Id = 3,
                usua_Creacion = 3,
                prov_FechaCreacion = DateTime.Now
            };

        }
    }
}
