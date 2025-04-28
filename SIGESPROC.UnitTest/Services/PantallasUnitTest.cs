using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceAcceso;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class PantallasUnitTest
    {
        private readonly Mock<PantallaRepository> _mockPantallaRepository;

        public PantallasUnitTest()
        {
            _mockPantallaRepository = new Mock<PantallaRepository>();
        }

        [TestMethod]
        public void PantallaInsertar()
        {
            var pantalla = new tbPantallas()
            {
                pant_Descripcion = "Pantalla de Inicio",
                usua_Creacion = 3
            };

            _mockPantallaRepository.Setup(repo => repo.Insert(It.IsAny<tbPantallas>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Operación completada exitosamente" });

            var result = _mockPantallaRepository.Object.Insert(pantalla);
            Assert.AreEqual(1, result.CodeStatus);
            Assert.AreEqual("Operación completada exitosamente", result.MessageStatus);
        }

        [TestMethod]
        public void PantallaActualizar()
        {
            var pantalla = new tbPantallas()
            {
                pant_Id = 1,
                pant_Descripcion = "Pantalla Actualizada",
                usua_Modificacion = 3
            };

            _mockPantallaRepository.Setup(repo => repo.Update(It.IsAny<tbPantallas>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización exitosa" });

            var result = _mockPantallaRepository.Object.Update(pantalla);
            Assert.AreEqual(1, result.CodeStatus);
        }

        //[TestMethod]
        //public void PantallaEliminar()
        //{
        //    _mockPantallaRepository.Setup(repo => repo.Delete(It.IsAny<int>()))
        //        .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Eliminación exitosa" });

        //    var result = _mockPantallaRepository.Object.Delete(1);
        //    Assert.AreEqual(1, result.CodeStatus);
        //}

        [TestMethod]
        public void PantallasListar()
        {
            _mockPantallaRepository.Setup(repo => repo.List())
                .Returns(new List<tbPantallas>());

            var result = _mockPantallaRepository.Object.List();
            Assert.IsNotNull(result);
        }
    }
}