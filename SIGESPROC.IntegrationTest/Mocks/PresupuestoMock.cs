using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class PresupuestoMock
    {
        public static tbPresupuestosEncabezado PresupuestoEncabezadoModel()
        {
            return new tbPresupuestosEncabezado
            {
                pren_Id = 100,
                clie_Id = 1,
                empl_Id = 2,
                pren_Descripcion = "Presupuesto de Integration Test de Prueba",
                pren_Fecha = DateTime.Now,
                pren_FechaCreacion = DateTime.Now,
                pren_Impuesto = 15,
                pren_Maquinaria = false,
                pren_Titulo = "Presupuesto de Integration Test",
                pren_PorcentajeGanancia = 30,
                proy_Id = 4,
                usua_Modificacion = 3,
                pren_FechaModificacion = DateTime.Now,
                usua_Creacion = 3
            };
        }

        public static tbPresupuestosEncabezado PresupuestoEncabezadoCreate()
        {
            return new tbPresupuestosEncabezado
            {
                pren_Titulo = "Presupuesto de Integration Testsss",
                pren_Descripcion = "Presupuesto de Integration Test de Pruebasss",
                pren_Fecha = DateTime.Now,
                pren_PorcentajeGanancia = 30,
                pren_Maquinaria = false,
                pren_Impuesto = 15,
                empl_Id = 2,
                proy_Id = 4,
                clie_Id = 1,
                usua_Creacion = 3,
                 pren_FechaCreacion = DateTime.Now
                
            };
        }

        public static tbPresupuestosDetalle PresupuestoDetalleModel()
        {
            return new tbPresupuestosDetalle
            {

            };
        }
    }
}
