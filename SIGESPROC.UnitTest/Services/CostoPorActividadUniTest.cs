using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class CostoPorActividadUniTest
    {
        private readonly CostoPorActividadService _costoPorActividadService;
        private readonly IMapper _mapper;

        public Mock<CostoPorActividadRepository> MockCostoPorActividadRepository { get; private set; }

        public CostoPorActividadUniTest()
        {
            MockCostoPorActividadRepository = new Mock<CostoPorActividadRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _costoPorActividadService = new CostoPorActividadService(
                MockCostoPorActividadRepository.Object
                );

        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void CostoPorActividadInsertar()
        {
            MockCostoPorActividadRepository.Setup(pl => pl.Insert(It.IsAny<tbCostoPorActividad>()))
             .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _costoPorActividadService.InsertarCostoActividad(It.IsAny<tbCostoPorActividad>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CostoPorActividadActualizar()
        {
            MockCostoPorActividadRepository.Setup(pl => pl.Update(It.IsAny<tbCostoPorActividad>()))
             .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _costoPorActividadService.ActualizarCostoActividad(It.IsAny<tbCostoPorActividad>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
