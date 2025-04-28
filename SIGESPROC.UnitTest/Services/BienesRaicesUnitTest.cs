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
    public class BienesRaicesUnitTest
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        private Mock<BienRaizRepository> MockBienesRaicesRepository { get; set; }

        public BienesRaicesUnitTest()
        {
            MockBienesRaicesRepository = new Mock<BienRaizRepository>();

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
            var documentoBienRaizRepository = new DocumentoBienRaizRepository();
            var empresaBienRaizRepository = new EmpresaBienRaizRepository();
            var proyectoConstruccionBienRaizRepository = new ProyectoConstruccionBienRaizRepository();
            var terrenoRepository = new TerrenoRepository();
            var tipoDocumentoRepository = new TipoDocumentoRepository();
            var mantenimientoRepository = new MantenimientoRepository();

            _bienRaizService = new BienRaizService(agentesBienesRaicesRepository, MockBienesRaicesRepository.Object, documentoBienRaizRepository,
                empresaBienRaizRepository, proyectoConstruccionBienRaizRepository, terrenoRepository, tipoDocumentoRepository, mantenimientoRepository);
        }
        protected Mock<IMapper> map = new Mock<IMapper>();

        [TestMethod]
        public void BienesRaicesListar()
        {
            var result = _bienRaizService.ListarBienesRaices();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<ServiceResult>(result);
        }

        [TestMethod]
        public void BienesRaicesCrear()
        {
            var modelo = new tbBienesRaices()
            {

                bien_Desripcion = "Holas",
                pcon_Id = 1,
                bien_Imagen = "imagen",
                bien_Precio = 87,
                usua_Creacion = 3
            };
            var result = _bienRaizService.InsertarBienRaiz(modelo);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<ServiceResult>(result);
        }
        [TestMethod]
        public void BienesRaicesEditar()
        {
            var modelo = new tbBienesRaices()
            {
                bien_Desripcion = "Holas Editado",
                pcon_Id = 1,
                bien_Imagen = "imagenEditada",
                bien_Precio = 100,
                usua_Creacion = 3
            };

            MockBienesRaicesRepository.Setup(tr => tr.Update(It.IsAny<tbBienesRaices>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _bienRaizService.ActualizarBienRaiz(modelo);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
   
    
    }
}
