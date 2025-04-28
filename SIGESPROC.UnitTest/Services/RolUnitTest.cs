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
    public class RolUnitTest
    {
        private readonly Mock<RolRepository> _mockRolRepository;

        public RolUnitTest()
        {
            _mockRolRepository = new Mock<RolRepository>();
        }

        [TestMethod]
        public void RolInsertar()
        {
            var rol = new tbRoles()
            {
                role_Descripcion = "Administrador",
                usua_Creacion = 3
            };

            _mockRolRepository.Setup(repo => repo.Insert(It.IsAny<tbRoles>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Rol insertado exitosamente" });

            var result = _mockRolRepository.Object.Insert(rol);
            Assert.AreEqual(1, result.CodeStatus);
        }

        [TestMethod]
        public void RolActualizar()
        {
            var roles = new tbRoles()
            {
                role_Id = 1,
                role_Descripcion = "Administrador",
                usua_Modificacion = 3
            };

            _mockRolRepository.Setup(repo => repo.Update(It.IsAny<tbRoles>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización exitosa" });

            var result = _mockRolRepository.Object.Update(roles);
            Assert.AreEqual(1, result.CodeStatus);
        }

        //[TestMethod]
        //public void RolEliminar()
        //{
        //    _mockRolRepository.Setup(repo => repo.Delete(It.IsAny<int>()))
        //        .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Rol eliminado exitosamente" });

        //    var result = _mockRolRepository.Object.Delete(1);
        //    Assert.AreEqual(1, result.CodeStatus);
        //}

        [TestMethod]
        public void RolListar()
        {
            _mockRolRepository.Setup(repo => repo.List())
                .Returns(new List<tbRoles>());

            var result = _mockRolRepository.Object.List();
            Assert.IsNotNull(result);
        }
    }
}