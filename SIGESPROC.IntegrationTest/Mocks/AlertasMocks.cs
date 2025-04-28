using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class AlertasMocks
    {
        public static tbAlertas CrearMockAlerta()
        {
            return new tbAlertas
            {
                aler_Fecha = DateTime.Now,
                aler_Descripcion = "Se ha extendido un préstamo al colaborador Juan Rey con DNI 0501200403104.",
                aler_Ruta = "/planilla/prestamo",
                usua_Creacion = 104,
                aler_FechaCreacion = DateTime.Now
            };
        }

        public static tbAlertas EditarMockAlerta()
        {
            return new tbAlertas
            {
                aler_Fecha = DateTime.Now,
                aler_Descripcion = "Se ha extendido un préstamo al colaborador Juan Rey con DNI 0501200403104.",
                aler_Ruta = "/planilla/prestamo",
                usua_Modificacion = 104,
                aler_FechaModificacion = DateTime.Now
            };
        }
    }
}
