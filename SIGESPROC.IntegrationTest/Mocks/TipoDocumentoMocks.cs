using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class TipoDocumentoMocks
    {
        public static TipoDocumentoViewModel CrearMockTipoDocumento()
        {
            return new TipoDocumentoViewModel
            {
                tido_Descripcion = "legal",
                usua_Creacion = 1,
                tido_FechaCreacion = DateTime.Now
            };
        }

        public static TipoDocumentoViewModel EditarMockTipoDocumento()
        {
            return new TipoDocumentoViewModel
            {
                tido_Id = 2,
                tido_Descripcion = "legal",
                usua_Mofificacion = 1,
                tido_FechaModificacion = DateTime.Now
            };
        }


    }
}
