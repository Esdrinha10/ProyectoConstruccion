using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGESPROC.API.Extensions;
using SIGESPROC.BusinessLogic;
using SIGESPROC.BusinessLogic.Services.ServiceAcceso;
using SIGESPROC.DataAccess;
using SIGESPROC.DataAccess.Repositories.RepositoryAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.UnitTest.Services
{
    [TestClass]
    public class UsuariosUnitTest
    {
        private readonly AccesoService _accesoService;
        private readonly Mock<UsuarioRepository> _mockUsuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosUnitTest()
        {
            // Mock del repositorio de usuarios
            _mockUsuarioRepository = new Mock<UsuarioRepository>();

            // Configuración de AutoMapper
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfileExtensions());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            // Inicialización del servicio con los repositorios necesarios
            var pantallaRepository = new Mock<PantallaRepository>();
            var rolRepository = new Mock<RolRepository>();
            var pantallaPorRolRepository = new Mock<PantallaPorRolRepository>();

            _accesoService = new AccesoService(_mockUsuarioRepository.Object, pantallaRepository.Object, rolRepository.Object, pantallaPorRolRepository.Object);
        }

        [TestMethod]
        public void UsuariosListar()
        {
            // Simulación de datos
            _mockUsuarioRepository.Setup(repo => repo.List()).Returns(new List<tbUsuarios>());

            var result = _accesoService.ListarUsuarios();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void UsuarioCrear()
        {
            // Simulación de un nuevo usuario
            var usuario = new tbUsuarios()
            {
                usua_Usuario = "nuevoUsuario",
                usua_Clave = "clave123",
                usua_EsAdministrador = false,
                empl_Id = 108,
                role_Id = 63,
                usua_Creacion = 3
            };

            // Configuramos el mock para que al insertar retorne un estado exitoso
            _mockUsuarioRepository.Setup(repo => repo.Insert(It.IsAny<tbUsuarios>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Usuario creado con éxito" });

            var result = _accesoService.InsertarUsuario(usuario);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }

        [TestMethod]
        public void UsuarioActualizar()
        {
            // Simulación de un usuario actualizado
            var usuario = new tbUsuarios()
            {
                usua_Id = 3,
                usua_Usuario = "Admin",
                usua_Clave = "claveNueva",
                usua_EsAdministrador = true,
                empl_Id = 108,
                role_Id = 63,
                usua_Modificacion = 3
            };

            // Configuramos el mock para simular una actualización exitosa
            _mockUsuarioRepository.Setup(repo => repo.Update(It.IsAny<tbUsuarios>()))
                .Returns(new RequestStatus { CodeStatus = 1, MessageStatus = "Usuario actualizado con éxito" });

            var result = _accesoService.ActualizarUsuario(usuario);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceResult));
        }
    }
}