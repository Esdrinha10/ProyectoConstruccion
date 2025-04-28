using SIGESPROC.Entities.Entities;
using System;
using SIGESPROC.Common.Models.ModelsGeneral;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class NotificacionMock
    {
        public static NotificacionViewModel InsertarNotificacionMock()
        {
            return new NotificacionViewModel
            {
                noti_Descripcion = "s",
                noti_Fecha = DateTime.Now,
                noti_Ruta = "#/sigesproc/Paginaprincipal/Paginaprincipal",
                usua_Creacion = 3,
                noti_FechaCreacion = DateTime.Now
            };
        }

        public static NotificacionViewModel ActualizarNotificacionMock()
        {
            return new NotificacionViewModel
            {
                noti_Id = 1,
                noti_Descripcion = "s",
                noti_Fecha = DateTime.Now,
                noti_Ruta = "#/sigesproc/Paginaprincipal/Paginaprincipal",
                usua_Creacion = 3,
                noti_FechaCreacion = DateTime.Now,
                noti_Tipo = "",
                napu_Ruta = "#/sigesproc/Paginaprincipal/Paginaprincipal",
                noti_Leida = "",
                tian_Id = 0,
                usua_Modificacion = 3,
                noti_FechaModificacion = DateTime.Now
            };
        }
    }
}
