using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class DocumentoBienRaizMocks
    {


        public static DocumentoBienRaizViewModel CrearMockDocumentoBienRaiz()
        {
            return new DocumentoBienRaizViewModel
            {
                dobt_DescipcionDocumento = "legal",
                tido_Id = 1,
                dobt_Imagen = "url",
                usua_Creacion = 2,
                dobt_FechaCreacion = DateTime.Now,
                dobt_Terreno_O_BienRaizId = 2,
                dobt_Terreno_O_BienRaizbit = true
            };
        }



        public static DocumentoBienRaizViewModel EditarMockDocumentoBienRaiz()
        {
            return new DocumentoBienRaizViewModel
            {
                dobt_Id = 3,
                dobt_DescipcionDocumento = "legal",
                tido_Id = 1,
                dobt_Imagen = "url",
                usua_Modificacion = 2,
                dobt_FechaModificacion = DateTime.Now,
                dobt_Terreno_O_BienRaizId = 2,
                dobt_Terreno_O_BienRaizbit = true
            };
        }
  
    
    }
}
