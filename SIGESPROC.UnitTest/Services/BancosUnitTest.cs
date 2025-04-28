using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.BancoService;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities.Entities;
using System.Collections.Generic;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class BancosUnitTest
    {
        private readonly BancoService _bancoService;

        public Mock<BancoRepository> MockBancoRepository { get; private set; }

        public BancosUnitTest()
        {
            MockBancoRepository = new Mock<BancoRepository>();

            _bancoService = new BancoService(
                MockBancoRepository.Object
               
            );
        }

        [TestMethod]
        public void BancoCreateTest()
        {
            MockBancoRepository.Setup(repo => repo.Insert(It.IsAny<tbBancos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Éxito" });

            var result = _bancoService.InsertarBanco(It.IsAny<tbBancos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BancoUpdateTest()
        {
            MockBancoRepository.Setup(repo => repo.Update(It.IsAny<tbBancos>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _bancoService.ActualizarBanco(It.IsAny<tbBancos>());

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
