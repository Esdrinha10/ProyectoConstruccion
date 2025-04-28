using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ReferenciaCeldaMock
    {
        public static tbReferenciasCeldas InsertarReferenciaCeldaMock()
        {
            return new tbReferenciasCeldas
            {
                rece_Id=0,
                rece_Referencia= "rmac_CantidadMaquinas1",
                rece_Tipo= "rmac_CantidadRenta1",
                acet_Id=639,
                usua_Creacion=56,
                rece_FechaCreacion=DateTime.Now,
                usua_Modificacion=56,
                rece_FechaModificacion=DateTime.Now,
                usuaCreacion="string",
                usuaModificacion="string"
            };
        }
    }
}
