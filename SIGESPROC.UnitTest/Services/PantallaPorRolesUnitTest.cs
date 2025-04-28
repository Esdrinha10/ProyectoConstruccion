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
    public class PantallaPorRolUnitTest
    {
        private readonly Mock<PantallaPorRolRepository> _mockPantallaPorRolRepository;

        public PantallaPorRolUnitTest()
        {
            _mockPantallaPorRolRepository = new Mock<PantallaPorRolRepository>();
        }

        [TestMethod]
        public void PantallaPorRolInsertar()
        {
            var pantallaPorRol = new tbPantallasPorRoles()
            {
                role_Id = 1,
                pant_Id = 2,
                usua_Creacion = 3
            };

            _mockPantallaPorRolRepository.Setup(repo => repo.Insert(It.IsAny<tbPantallasPorRoles>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Relación insertada exitosamente" });

            var result = _mockPantallaPorRolRepository.Object.Insert(pantallaPorRol);
            Assert.AreEqual(1, result.CodeStatus);
        }

        [TestMethod]
        public void PantallaPorRolEliminar()
        {
            _mockPantallaPorRolRepository.Setup(repo => repo.Delete(It.IsAny<int>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Relación eliminada exitosamente" });

            var result = _mockPantallaPorRolRepository.Object.Delete(1);
            Assert.AreEqual(1, result.CodeStatus);
        }

        [TestMethod]
        public void PantallaPorRolListar()
        {
            _mockPantallaPorRolRepository.Setup(repo => repo.List())
                .Returns(new List<tbPantallasPorRoles>());

            var result = _mockPantallaPorRolRepository.Object.List();
            Assert.IsNotNull(result);
        }
    }
}