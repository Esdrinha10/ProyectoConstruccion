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
    public class ProyectoConstruccionBienRaizUnitTest
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        private Mock<ProyectoConstruccionBienRaizRepository> MockProyectoConstruccionBienRaizRepository { get; set; }

        public ProyectoConstruccionBienRaizUnitTest()
        {
            MockProyectoConstruccionBienRaizRepository = new Mock<ProyectoConstruccionBienRaizRepository>();

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
            var tipoDocumentoRepository = new TipoDocumentoRepository();
            var mantenimientoRepository = new MantenimientoRepository();

            _bienRaizService = new BienRaizService(agentesBienesRaicesRepository, bienRaizRepository, documentoBienRaizRepository,
                empresaBienRaizRepository, MockProyectoConstruccionBienRaizRepository.Object, terrenoRepository, tipoDocumentoRepository, mantenimientoRepository);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void ProyectoConstruccionBienRaizCrear()
        {
            try
            {
                MockProyectoConstruccionBienRaizRepository.Setup(pl => pl.Insert(It.IsAny<tbProyectosConstruccionBienesRaices>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _bienRaizService.InsertarProyectoConstruccionBienRaiz(new tbProyectosConstruccionBienesRaices());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }
        [TestMethod]
        public void ProyectoConstruccionBienRaizEditar()
        {
            try
            {
                MockProyectoConstruccionBienRaizRepository.Setup(pl => pl.Update(It.IsAny<tbProyectosConstruccionBienesRaices>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _bienRaizService.ActualizarProyectoConstruccionBienRaiz(It.IsAny<tbProyectosConstruccionBienesRaices>());

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
