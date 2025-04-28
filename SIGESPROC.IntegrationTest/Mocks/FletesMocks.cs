using SIGESPROC.Common.Models.ModelsFlete;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class FletesMocks
    {
        public static tbFletesEncabezado CrearMockFletes()
        {

            return new tbFletesEncabezado
            {
                flen_Id = 1,
                flen_FechaHoraSalida = DateTime.Now,
                flen_FechaHoraEstablecidaDeLlegada = DateTime.Now,
                flen_FechaHoraLlegada = DateTime.Now,
                emtr_Id = 93,
                emss_Id = 91,
                emsl_Id = 89,
                boas_Id = 26,
                flen_ComprobanteLLegada = "llego",
                flen_DestinoProyecto = false,
                flen_SalidaProyecto = false,
                flen_Estado = false,
                boat_Id = 33,
                usua_Modificacion = 3,
            };
        }
        public static FleteEncabezadoViewModel EditarMockFletes()
        {

            return new FleteEncabezadoViewModel
            {
                flen_Id = 1,
                flen_FechaHoraSalida = DateTime.Now,
                flen_FechaHoraEstablecidaDeLlegada = DateTime.Now,
                flen_FechaHoraLlegada = DateTime.Now,
                emtr_Id = 93,
                emss_Id = 91,
                emsl_Id = 89,
                boas_Id = 26,
                flen_ComprobanteLLegada = "llego",
                flen_DestinoProyecto = false,
                flen_SalidaProyecto = false,
                flen_Estado = false,
                boat_Id = 33,
                usua_Modificacion = 3,
            };
        }
    }
}
