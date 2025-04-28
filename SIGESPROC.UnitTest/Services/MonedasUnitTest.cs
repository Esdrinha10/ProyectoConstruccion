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
    public class MonedaUnitTest
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public Mock<MonedaRepository> MockMonedaRepository { get; private set; }

        public MonedaUnitTest()
        {
            MockMonedaRepository = new Mock<MonedaRepository>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var NivelRepository = new NivelRepository();
            var PaisRepository = new PaisRepository();
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
               PaisRepository,
               TasaCambioRepository,
               TipoProyectoRepository,
               EmpleadoRepository,
               EstadoRepository,
               MockMonedaRepository.Object,
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
        public void MonedaListar()
        {

            var result = _generalService.ListarMonedas();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void MonedaCreate()
        {

            MockMonedaRepository.Setup(pl => pl.Insert(It.IsAny<tbMonedas>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.InsertarMoneda(It.IsAny<tbMonedas>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MonedaUpdate()
        {

            MockMonedaRepository.Setup(pl => pl.Update(It.IsAny<tbMonedas>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.ActualizarMoneda(It.IsAny<tbMonedas>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

    }
}
