using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class TerrenosMocks
    {

        public static tbTerrenos CrearMockTerrenos()
        {
            return new tbTerrenos
            {
                terr_Descripcion = "Holas",
                terr_Area = "34m2",
                terr_Estado = false,
                terr_PecioCompra = "7889",
                terr_LinkUbicacion = "ubicacion",
                terr_Imagen = "imagen",
                terr_Longitud = "-87.76156002428569",
                terr_Latitud = "11.762257447621977",
                usua_Creacion = 3,
                terr_FechaCreacion = DateTime.Now,
                DocumentoImagen = "2"
            };
        }



        public static tbTerrenos EditarMockTerrenos()
        {
            return new tbTerrenos
            {
                terr_Id = 1,  
                terr_Descripcion = "Holas",
                terr_Area = "34m2",
                terr_Estado = false,
                terr_PecioCompra = "7889",
                terr_LinkUbicacion = "ubicacion",
                terr_Imagen = "imagen",
                terr_Longitud = "-87.76156002428569",
                terr_Latitud = "11.762257447621977",
                usua_Modificacion = 3, 
                terr_FechaModificacion = DateTime.Now,
                DocumentoImagen = "2" 
            };
        }

    }
}
