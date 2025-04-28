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
    public class EmpresaBienRaizUnitTest
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        private Mock<EmpresaBienRaizRepository> MockEmpresaBienRaizRepository { get; set; }

        public EmpresaBienRaizUnitTest()
        {
            MockEmpresaBienRaizRepository = new Mock<EmpresaBienRaizRepository>();

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
                MockEmpresaBienRaizRepository.Object, proyectoConstruccionBienRaizRepository, terrenoRepository, tipoDocumentoRepository, mantenimientoRepository);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();


        [TestMethod]
        public void EmpresaBienRaizCrear()
        {
            try
            {
                MockEmpresaBienRaizRepository.Setup(pl => pl.Insert(It.IsAny<tbEmpresasBienesRaices>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _bienRaizService.InsertarEmpresaBienRaiz(new tbEmpresasBienesRaices());

                Assert.IsInstanceOfType<ServiceResult>(result);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"El error: {ex.Message}");
            }
        }
        [TestMethod]
        public void EmpresaBienRaizEditar()
        {
            try
            {
                MockEmpresaBienRaizRepository.Setup(pl => pl.Update(It.IsAny<tbEmpresasBienesRaices>()))
                    .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

                var result = _bienRaizService.ActualizarEmpresaBienRaiz(It.IsAny<tbEmpresasBienesRaices>());

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
