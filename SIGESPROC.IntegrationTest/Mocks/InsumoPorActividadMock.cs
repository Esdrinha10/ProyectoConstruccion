using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class InsumoPorActividadMock
    {
        public static tbInsumosPorActividades InsertarInsumoPorActividadMock()
        {
            return new tbInsumosPorActividades
            {
                inpa_Id=0,
                acet_Id=675,
                inpa_stock=9,
                inpa_PrecioCompra=74,
                inpa_Desperdicio=0,
                inpa_Rendimiento=0,
                inpa_FormulaRendimiento="N/A",
                inpa_StockFormula= "N/A",
                inpa_PrecioCompraFormula= "N/A",
                inpa_ActividadLlenado=0,
                inpa_EsCompra=true,
                inpa_Fecha=DateTime.Now,
                inpp_Id=194,
                usua_Creacion=13,
                inpa_FechaCreacion= DateTime.Now,
                usua_Modificacion=13,
                inpa_FechaModificacion= DateTime.Now,
                inpa_Estado=true,
                row=0,
                insu_Descripcion="string",
                unme_Nombre="string",
                unme_Nomenclatura="string",
                bopi_Stock=0,
                mate_Descripcion="string",
                prov_Descripcion="string",
                suca_Descripcion="string",
                cate_Descripcion="string",
                inpp_Observacion="string",
                inpp_Preciocompra=0
            };
        }

        public static tbInsumosPorActividades ActualizarInsumoPorActividadMock()
        {
            return new tbInsumosPorActividades
            {
                inpa_Id = 1941,
                acet_Id = 675,
                inpa_stock = 9,
                inpa_PrecioCompra = 74,
                inpa_Desperdicio = 0,
                inpa_Rendimiento = 0,
                inpa_FormulaRendimiento = "N/A",
                inpa_StockFormula = "N/A",
                inpa_PrecioCompraFormula = "N/A",
                inpa_ActividadLlenado = 0,
                inpa_EsCompra = true,
                inpa_Fecha = DateTime.Now,
                inpp_Id = 194,
                usua_Creacion = 13,
                inpa_FechaCreacion = DateTime.Now,
                usua_Modificacion = 13,
                inpa_FechaModificacion = DateTime.Now,
                inpa_Estado = true,
                row = 0,
                insu_Descripcion = "string",
                unme_Nombre = "string",
                unme_Nomenclatura = "string",
                bopi_Stock = 0,
                mate_Descripcion = "string",
                prov_Descripcion = "string",
                suca_Descripcion = "string",
                cate_Descripcion = "string",
                inpp_Observacion = "string",
                inpp_Preciocompra = 0
            };
        }
    }
}
