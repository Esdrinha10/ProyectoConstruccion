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
    public class UnidadMedidaUnitTest
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public Mock<UnidadMedidaRepository> MockUnidadMedidaRepository { get; private set; }

        public UnidadMedidaUnitTest()
        {
            MockUnidadMedidaRepository = new Mock<UnidadMedidaRepository>();

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
            var TasaCambioRepository = new TasaCambioRepository();
            var EmpleadoRepository = new EmpleadoRepository();
            var EstadoRepository = new EstadoRepository();
            var MonedaRepository = new MonedaRepository();
            var EstadoCivilRepository = new EstadoCivilRepository();
            var CargoRepository = new CargoRepository();
            var TipoProyectoRepository = new TipoProyectoRepository();
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
               MonedaRepository,
               EstadoCivilRepository,
               CargoRepository,
               MockUnidadMedidaRepository.Object,
               CategoriaRepository,
               CiudadRepository,
               ClienteRepository,
               ImpuestoRepository
                );

        }
        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void UnidadMedidaListar()
        {

            var result = _generalService.ListarUnidadesMedidas();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void UnidadMedidaCreate()
        {

            MockUnidadMedidaRepository.Setup(pl => pl.Insert(It.IsAny<tbUnidadesMedida>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.InsertarUnidadMedida(It.IsAny<tbUnidadesMedida>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void UnidadMedidaUpdate()
        {

            MockUnidadMedidaRepository.Setup(pl => pl.Update(It.IsAny<tbUnidadesMedida>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _generalService.ActualizarUnidadMedida(It.IsAny<tbUnidadesMedida>());

            Assert.IsInstanceOfType<ServiceResult>(result);
            Assert.IsNotNull(result);
        }

    }
}
