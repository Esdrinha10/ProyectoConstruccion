using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class EmpresaBienRaizMocks
    {
        public static EmpresaBienesRaicesViewModel CrearEmpresaBienRaiz()
        {
            return new EmpresaBienesRaicesViewModel
            {
                embr_Nombre = "Empresa Salinas",
                embr_ContactoA = "Jason Villanueva",
                embr_ContactoB = "Esdra Cerna",
                embr_TelefonoA = "97462882",
                embr_TelefonoB = "91002151",
                usua_Creacion = 3,
                embr_FechaCreacion = DateTime.Now
            };
        }



        public static EmpresaBienesRaicesViewModel EditarEmpresaBienRaiz()
        {
            return new EmpresaBienesRaicesViewModel
            {
                embr_Id = 1,
                embr_Nombre = "Empresa Salinas",
                embr_ContactoA = "Jason Villanueva",
                embr_ContactoB = "Esdra Cerna",
                embr_TelefonoA = "97462882",
                embr_TelefonoB = "91002151",
                usua_Modificacion = 3,
                embr_FechaModificacion = DateTime.Now
            };
        }


    }

}
