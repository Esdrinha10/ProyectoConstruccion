using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class AgenteBienRaizMocks
    {
        public static tbAgentesBienesRaices CrearMockAgenteBienRaiz()
        {
            return new tbAgentesBienesRaices
            {
                agen_Id = 1,
                agen_DNI = "0611200500783",
                agen_Nombre = "Eduardo",
                agen_Apellido = "Varela",
                agen_Telefono = "99485930",
                agen_Correo = "eduardo.test@gmail.com",
                agen_FechaCreacion = System.DateTime.Now,
                embr_Id = 1,
                usua_Creacion = 3
            };
        }
    }
}
