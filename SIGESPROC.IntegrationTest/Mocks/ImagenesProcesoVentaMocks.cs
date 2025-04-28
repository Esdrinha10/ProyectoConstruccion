using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class ImagenesProcesoVentaMocks
    {
        public static List<ImageneProcesoVentaViewModel> CrearMockProcesoVenta()
        {
            return new List<ImageneProcesoVentaViewModel>
    {
        new ImageneProcesoVentaViewModel
        {
            btrp_Id = 3,
            impr_Imagen = "url",
            usua_Creacion = 3,
            impr_FechaCreacion = DateTime.Now
        }
    };
        }


        public static ImageneProcesoVentaViewModel EditarMockProcesoVenta()
        {
            return new ImageneProcesoVentaViewModel
            {
                impr_Id = 1,
                btrp_Id = 3,
                impr_Imagen = "url",
                usua_Creacion = 3,
                impr_FechaCreacion = DateTime.Now
            };
        }
    }
}
