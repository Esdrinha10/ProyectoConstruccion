using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.BusinessLogic.Services.ServiceBienRaiz;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersBienRaiz
{
    // Configuración de la ruta base para el controlador y especifica que es un controlador de API.
    [Route("api/[controller]")]
    [ApiController]
    public class AgenteBienesRaicesController : Controller
    {
        // Inyección de dependencias para los servicios y AutoMapper.
        private readonly BienRaizService _bienRaizService;
        private readonly IMapper _mapper;

        // Constructor del controlador que inicializa los servicios y AutoMapper.
        public AgenteBienesRaicesController(BienRaizService bienRaizService, IMapper mapper)
        {
            _bienRaizService = bienRaizService;
            _mapper = mapper;
        }

        // Método HttpGet para listar todos los agentes de bienes raíces.
        [HttpGet("Listar")]
        public IActionResult ListarAgenteBienesRaices()
        {
            var response = _bienRaizService.ListarAgenteBienesRaices(); // Llama al servicio para obtener la lista de agentes de bienes raíces.
            return Ok(response.Data); // Retorna un código 200 con la data obtenida.
        }

        // Método HttpGet para buscar un agente de bienes raíces por su ID.
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarAgenteBienRaiz(string id)
        {
            var response = _bienRaizService.BuscarAgenteBienesRaices(id); // Llama al servicio para buscar un agente específico por su ID.
            return Ok(response.Data); // Retorna un código 200 con la data obtenida.
        }

        // Método HttpPost para insertar un nuevo agente de bienes raíces.
        [HttpPost("Insertar")]
        public IActionResult Create(AgenteBienesRaicesViewModel AgenteBienesRaicesViewModel)
        {
            // Mapea los datos del ViewModel a la entidad correspondiente.
            var modelo = new tbAgentesBienesRaices()
            {
                agen_DNI = AgenteBienesRaicesViewModel.agen_DNI,
                agen_Nombre = AgenteBienesRaicesViewModel.agen_Nombre,
                agen_Apellido = AgenteBienesRaicesViewModel.agen_Apellido,
                agen_Telefono = AgenteBienesRaicesViewModel.agen_Telefono,
                agen_Correo = AgenteBienesRaicesViewModel.agen_Correo,
                usua_Creacion = AgenteBienesRaicesViewModel.usua_Creacion,
                agen_FechaCreacion = DateTime.Now, // Fecha de creación asignada automáticamente.
                embr_Id = AgenteBienesRaicesViewModel.embr_Id
            };
            var response = _bienRaizService.InsertarAgenteBienesRaices(modelo); // Llama al servicio para insertar el nuevo agente.
            return Ok(response); // Retorna un código 200 con la respuesta del servicio.
        }

        // Método HttpPut para actualizar un agente de bienes raíces existente.
        [HttpPut("Actualizar")]
        public IActionResult Update(AgenteBienesRaicesViewModel AgenteBienesRaicesViewModel)
        {
            // Mapea los datos del ViewModel a la entidad correspondiente, incluyendo la fecha de modificación.
            var modelo = new tbAgentesBienesRaices()
            {
                agen_Id = Convert.ToInt32(AgenteBienesRaicesViewModel.agen_Id),
                agen_DNI = AgenteBienesRaicesViewModel.agen_DNI,
                agen_Nombre = AgenteBienesRaicesViewModel.agen_Nombre,
                agen_Apellido = AgenteBienesRaicesViewModel.agen_Apellido,
                agen_Telefono = AgenteBienesRaicesViewModel.agen_Telefono,
                agen_Correo = AgenteBienesRaicesViewModel.agen_Correo,
                usua_Modificacion = AgenteBienesRaicesViewModel.usua_Modificacion,
                agen_FechaModificacion = DateTime.Now, // Fecha de modificación asignada automáticamente.
                embr_Id = AgenteBienesRaicesViewModel.embr_Id
            };
            var response = _bienRaizService.ActualizarAgenteBienesRaices(modelo); // Llama al servicio para actualizar el agente.
            return Ok(response); // Retorna un código 200 con la respuesta del servicio.
        }

        // Método HttpPut para eliminar un agente de bienes raíces.
        [HttpPut("Eliminar")]
        public IActionResult Delete([FromBody] int? id)
        {
            var result = _bienRaizService.EliminarAgenteBienesRaices(id); // Llama al servicio para eliminar el agente.
            return Ok(result); // Retorna un código 200 con la respuesta del servicio.
        }
    }
}
