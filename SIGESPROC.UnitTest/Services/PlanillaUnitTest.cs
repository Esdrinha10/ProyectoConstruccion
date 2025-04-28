using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
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
    public class PlanillaUnitTest
    {
        private readonly PlanillaService _planillaService;
        private readonly IMapper _mapper;
        public Mock<PlanillaRepository> MockPlanillaRepositiry { get; private set; }

        public PlanillaUnitTest()
        {
            MockPlanillaRepositiry = new Mock<PlanillaRepository>();

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
                categoriaViaticoRepository,
                deduccionRepository,
                MockPlanillaRepositiry.Object,
                planillaJefeCuadrillaRepository
                );

        }
        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void PlanillaCreate()
        {

            MockPlanillaRepositiry.Setup(pl => pl.Insert(It.IsAny<tbPlanillas>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _planillaService.InsertarPlanilla(It.IsAny<tbPlanillas>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PlanillaListar()
        {
            var modelo = new List<tbPlanillas>() {
                new tbPlanillas {plan_Id = 1, plan_PlanillaJefes = false, frec_Id = 3},
                new tbPlanillas {plan_Id = 2, plan_PlanillaJefes = true, frec_Id = 1},
                new tbPlanillas {plan_Id = 3, plan_PlanillaJefes = false, frec_Id = 7},
            }.AsEnumerable();

            MockPlanillaRepositiry.Setup(pl => pl.List(3))
                .Returns(modelo);

            var result = _planillaService.ListarPlanilla(3);

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }
    }
}
