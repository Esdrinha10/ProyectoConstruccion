using AutoMapper;
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
    public class AgenteBienRaizUnitTest
    {
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;
        private Mock<BienRaizRepository> MockBienesRaicesRepository { get; set; }

        public AgenteBienRaizUnitTest()
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
        public void AgenteBienRaizCrear()
        {
            var modelo = new tbAgentesBienesRaices()
            {

                agen_DNI = "0611200500783",
                agen_Nombre = "Eduardo",
                agen_Apellido = "Varela",
                agen_Telefono = "99485930",
                agen_Correo = "eduardo.test@gmail.com",
                agen_FechaCreacion = System.DateTime.Now,
                embr_Id = 1,
                usua_Creacion = 3
            };
            var result = _bienRaizService.InsertarAgenteBienesRaices(modelo);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<ServiceResult>(result);
        }
        [TestMethod]
        public void AgenteBienRaizEditar()
        {
            var modelo = new tbAgentesBienesRaices()
            {
                agen_Id = 1,
                agen_DNI = "0611200500783",
                agen_Nombre = "Eduardo",
                agen_Apellido = "Varela",
                agen_Telefono = "99485930",
                agen_Correo = "eduardo.test@gmail.com",
                agen_FechaCreacion = System.DateTime.Now,
                embr_Id = 1,
                usua_Creacion = 3
            };

            MockBienesRaicesRepository.Setup(tr => tr.Update(It.IsAny<tbBienesRaices>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Actualización Exitosa" });

            var result = _bienRaizService.ActualizarAgenteBienesRaices(modelo);

            Assert.IsInstanceOfType(result, typeof(ServiceResult));
            Assert.IsNotNull(result);
        }
    }
}
