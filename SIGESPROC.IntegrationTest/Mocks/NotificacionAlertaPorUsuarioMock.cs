using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class NotificacionAlertaPorUsuarioMock
    {
        public static tbNotificacionesAlertarPorUsuario InsertarNotificacionAlertaPorUsuarioMock()
        {
            return new tbNotificacionesAlertarPorUsuario
            {
                usua_Id = 3,
                napu_AlertaOnoti = false,
                napu_AlertaONotiId = 1315,
                usua_Creacion = 32,
                napu_FechaModificacion = DateTime.Now
            };
        }
    }
}
