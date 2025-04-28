using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTests.Mocks
{
    public static class BienesRaicesMocks
    {
        public static tbBienesRaices CrearMockBienRaiz()
        {
            return new tbBienesRaices
            {
                bien_Id = 240,
                bien_Desripcion = "Hola",
                pcon_Id = 30,
                bien_Imagen = "imagen.png",
                bien_Precio = 300,
                usua_Creacion = 3,
                bien_FechaCreacion = DateTime.Now
            };
        }
    }
}