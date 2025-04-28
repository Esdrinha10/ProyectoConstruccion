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
    public class TasaCambioUnitTest
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public Mock<TasaCambioRepository> MockTasaCambioRepository { get; private set; }

        public TasaCambioUnitTest()
        {
            MockTasaCambioRepository = new Mock<TasaCambioRepository>();

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
            var ImpuestoRepository = new ImpuestoRepository();
            var TipoProyectoRepository = new TipoProyectoRepository();
            var EmpleadoRepository = new EmpleadoRepository();
            var EstadoRepository = new EstadoRepository();
            var MonedaRepository = new MonedaRepository();
            var EstadoCivilRepository = new EstadoCivilRepository();
            var CargoRepository = new CargoRepository();
            var UnidadMedidaRepository = new UnidadMedidaRepository();
            var CategoriaRepository = new CategoriaRepository();
            var CiudadRepository = new CiudadRepository();
            var ClienteRepository = new ClienteRepository();



            _generalService = new GeneralService(

               NivelRepository,
               PaisRepository,
               MockTasaCambioRepository.Object,
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
        public void TasaCambioListar()
        {

            var result = _generalService.ListarTasasCambios();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void TasaCambioCreate()
        {

            MockTasaCambioRepository.Setup(pl => pl.Insert(It.IsAny<tbTasasCambio>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.InsertarTasasCambios(It.IsAny<tbTasasCambio>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TasaCambioUpdate()
        {

            MockTasaCambioRepository.Setup(pl => pl.Update(It.IsAny<tbTasasCambio>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.ActualizarTasasCambios(It.IsAny<tbTasasCambio>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

    }
}
