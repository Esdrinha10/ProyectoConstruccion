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
    public class CategoriaViaticoUnitTest
    {
        private readonly PlanillaService _planillaService;
        private readonly IMapper _mapper;

        public Mock<CategoriaViaticoRepository> MockCategoriaViaticoRepository{ get; private set; }

        public CategoriaViaticoUnitTest()
        {
            MockCategoriaViaticoRepository = new Mock<CategoriaViaticoRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var planillaRepository = new PlanillaRepository();
            var categoriaViaticoRepository = new CategoriaViaticoRepository();
            var deduccionRepository = new DeduccionRepository();
            var planillaJefeCuadrillaRepository = new PlanillaJefeCuadrillaRepository();

            _planillaService = new PlanillaService(
                MockCategoriaViaticoRepository.Object,
                deduccionRepository,
                planillaRepository,
                planillaJefeCuadrillaRepository
                );

        }

        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void CategoriaViaticoInsertar()
        {
            MockCategoriaViaticoRepository.Setup(pl => pl.Insert(It.IsAny<tbCategoriasViaticos>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _planillaService.InsertarCategoriaViatico(It.IsAny<tbCategoriasViaticos>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void CategoriaViaticoActualizar()
        {
            MockCategoriaViaticoRepository.Setup(pl => pl.Update(It.IsAny<tbCategoriasViaticos>()))
            .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _planillaService.ActualizarCategoriaViatico(It.IsAny<tbCategoriasViaticos>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);

        }
    }
}
