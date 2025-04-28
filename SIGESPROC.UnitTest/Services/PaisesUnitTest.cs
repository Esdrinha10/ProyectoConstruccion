using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsInsumo;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class PaisUnitTest
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public Mock<PaisRepository> MockPaisRepository { get; private set; }

        public PaisUnitTest()
        {
            MockPaisRepository = new Mock<PaisRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var MonedaRepository = new MonedaRepository();
            var NivelRepository = new NivelRepository();
            var TasaCambioRepository = new TasaCambioRepository();
            var TipoProyectoRepository = new TipoProyectoRepository();
            var EmpleadoRepository = new EmpleadoRepository();
            var EstadoRepository = new EstadoRepository();
            var ImpuestoRepository = new ImpuestoRepository();
            var EstadoCivilRepository = new EstadoCivilRepository();
            var CargoRepository = new CargoRepository();
            var UnidadMedidaRepository = new UnidadMedidaRepository();
            var CategoriaRepository = new CategoriaRepository();
            var CiudadRepository = new CiudadRepository();
            var ClienteRepository = new ClienteRepository();



            _generalService = new GeneralService(

               NivelRepository,
               MockPaisRepository.Object,
               TasaCambioRepository,
               TipoProyectoRepository,
               EmpleadoRepository,
               EstadoRepository,
               MonedaRepository,
               EstadoCivilRepository,
               CargoRepository,
               UnidadMedidaRepository,
               CategoriaRepository,
               CiudadRepository,
               ClienteRepository,
               ImpuestoRepository
                );

        }
        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void PaisListar()
        {

            var result = _generalService.ListarPaises();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void PaisCreate()
        {

            MockPaisRepository.Setup(pl => pl.Insert(It.IsAny<tbPaises>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.InsertarPaises(It.IsAny<tbPaises>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PaisUpdate()
        {

            MockPaisRepository.Setup(pl => pl.Update(It.IsAny<tbPaises>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.ActualizarPaises(It.IsAny<tbPaises>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

    }
}
