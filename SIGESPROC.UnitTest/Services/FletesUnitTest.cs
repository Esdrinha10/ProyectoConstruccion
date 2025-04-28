using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceFlete;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryFlete;
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
    public class FletesUnitTest
    {
        private readonly FleteService _fleteService;
        private readonly IMapper _mapper;
        public Mock<FleteEncabezadoRepository> MockFleteRepositiry { get; private set; }
        public Mock<FleteDetalleRepository> MockFleteDetalleRepository { get; private set; }
        public FletesUnitTest()
        {
             MockFleteDetalleRepository = new Mock<FleteDetalleRepository>();
            MockFleteRepositiry = new Mock<FleteEncabezadoRepository>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var fleteDetalleRepository = new FleteDetalleRepository();
            _fleteService = new FleteService(MockFleteRepositiry.Object, fleteDetalleRepository);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void ListarFletes()
        {
            var modelo = new List<tbFletesEncabezado>() {
                new tbFletesEncabezado {flen_Id = 1, usua_Creacion = 3,flen_DestinoProyecto =true},
                new tbFletesEncabezado {flen_Id = 2, usua_Creacion =3,flen_DestinoProyecto = true},
                new tbFletesEncabezado {flen_Id = 3, usua_Creacion = 3, flen_DestinoProyecto = false}
            }.AsEnumerable();

            MockFleteRepositiry.Setup(pl => pl.List())
                .Returns(modelo);


            var result = _fleteService.ListarFletes();
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
           
        }

        [TestMethod]
        public void CrearFlete()
        {
            MockFleteRepositiry.Setup(pl => pl.Insert(It.IsAny<tbFletesEncabezado>()))
              .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Exito" });

            var result = _fleteService.InsertarFlete(It.IsAny<tbFletesEncabezado>());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<ServiceResult>(result);
        }

        [TestMethod]
        public void EditarFlete()
        {
            MockFleteRepositiry.Setup(pl => pl.Update(It.IsAny<tbFletesEncabezado>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización exitosa" });
            var result = _fleteService.ActualizarFlete(It.IsAny<tbFletesEncabezado>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<ServiceResult>(result);
            MockFleteRepositiry.Verify(pl => pl.Update(It.IsAny<tbFletesEncabezado>()), Times.Once);
        }
    }
}
