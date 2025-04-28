using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTests.Mocks
{
    public static class ComprasMocks
    {
            public static List<CompraDetalleViewModel> CrearMockCompraEncabezado()
            {
                var detalles = new List<CompraDetalleViewModel>
                {
                    new CompraDetalleViewModel
                    {
                        code_Id = 1,
                        coen_Id = 799, // Será asignado en el controlador
                        codt_cantidad = 5,
                        codt_preciocompra = 1500,
                        codt_InsumoOMaquinariaOEquipoSeguridad = 1,
                        codt_Renta = 1,
                        usua_Creacion = 3,
                        codt_FechaCreacion = DateTime.Now,
                        empl_Id = 10,
                        meto_Id = 4,
                        coen_numeroCompra = "2024-0001",
                        identificador = 1 
                    },
                    new CompraDetalleViewModel
                    {
                        code_Id = 2,
                        coen_Id = 799, // Será asignado en el controlador
                        codt_cantidad = 10,
                        codt_preciocompra = 2500.50M,
                        codt_InsumoOMaquinariaOEquipoSeguridad = 0,
                        codt_Renta = 1,
                        usua_Creacion = 3,
                        codt_FechaCreacion = DateTime.Now,
                        empl_Id = 10,
                        meto_Id = 4,
                        coen_numeroCompra = "2024-0001",
                        identificador = 1 // Mismo grupo que el anterior
                    },
                    new CompraDetalleViewModel
                    {
                        code_Id = 3,
                        coen_Id = 799, // Será asignado en el controlador
                        codt_cantidad = 7,
                        codt_preciocompra = 1800.00M,
                        codt_InsumoOMaquinariaOEquipoSeguridad = 1,
                        codt_Renta = 1,
                        usua_Creacion = 3,
                        codt_FechaCreacion = DateTime.Now,
                        empl_Id = 10,
                        meto_Id = 4,
                        coen_numeroCompra = "2024-0002",
                        identificador = 2 // Nuevo grupo de detalles
                    },
                    new CompraDetalleViewModel
                    {
                        code_Id = 4,
                        coen_Id = 799, // Será asignado en el controlador
                        codt_cantidad = 15,
                        codt_preciocompra = 3000.00M,
                        codt_InsumoOMaquinariaOEquipoSeguridad = 0,
                        codt_Renta = 1,
                        usua_Creacion = 3,
                        codt_FechaCreacion = DateTime.Now,
                        empl_Id = 10,
                        meto_Id = 4,
                        coen_numeroCompra = "2024-0002",
                        identificador = 2 // Mismo grupo que el anterior
                    }
                };

                return detalles;
            }


        public static List<CompraDetalleViewModel> CrearMockCompraDetalle()
        {
            var detalles = new List<CompraDetalleViewModel>
                {
                    new CompraDetalleViewModel
                    {
                        code_Id = 825,
                        codt_Id = 1977,
                        coen_Id = 792, // Será asignado en el controlador
                        codt_cantidad = 5,
                        codt_preciocompra = 150,
                        codt_InsumoOMaquinariaOEquipoSeguridad = 1,
                        codt_Renta = 1,
                        usua_Modificacion = 3,
                        codt_FechaModificacion = DateTime.Now,
                        empl_Id = 10,
                        meto_Id = 4,
                        coen_numeroCompra = "2024-0001",
                        identificador = 1
                    },
        };

            return detalles;
        }
    }
}