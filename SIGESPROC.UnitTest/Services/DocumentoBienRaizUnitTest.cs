using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class DocumentoBienRaizUnitTest
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        private Mock<DocumentoBienRaizRepository> MockDocumentoBienRaizRepository { get; set; }

        public DocumentoBienRaizUnitTest()
        {
            MockDocumentoBienRaizRepository = new Mock<DocumentoBienRaizRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }


            var agentesBienesRaicesRepository = new AgenteBienesRaicesRepository();
            var bienRaizRepository = new BienRaizRepository();
            var documentoBienRaizRepository = new DocumentoBienRaizRepository();
            var empresaBienRaizRepository = new EmpresaBienRaizRepository();
            var proyectoConstruccionBienRaizRepository = new ProyectoConstruccionBienRaizRepository();
            var terrenoRepository = new TerrenoRepository();
            var DocumentoBienRaizRepository = new DocumentoBienRaizRepository();
            var mantenimientoRepository = new MantenimientoRepository();
            var tipoDocumentoRepository = new TipoDocumentoRepository();

            _bienRaizService = new BienRaizService(agentesBienesRaicesRepository, bienRaizRepository, MockDocumentoBienRaizRepository.Object,
                empresaBienRaizRepository, proyectoConstruccionBienRaizRepository, terrenoRepository, tipoDocumentoRepository, mantenimientoRepository);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void DocumentoBienRaizCrear()
        {
            try
            {
                MockDocumentoBienRaizRepository.Setup(pl => pl.Insert(It.IsAny<tbDocumentosBienRaiz>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _bienRaizService.InsertarDocumentoBienRaiz(new tbDocumentosBienRaiz());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }
        [TestMethod]
        public void DocumentoBienRaizEditar()
        {
            try
            {
                MockDocumentoBienRaizRepository.Setup(pl => pl.Update(It.IsAny<tbDocumentosBienRaiz>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _bienRaizService.ActualizarDocumentoBienRaiz(It.IsAny<tbDocumentosBienRaiz>());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

    }
}
