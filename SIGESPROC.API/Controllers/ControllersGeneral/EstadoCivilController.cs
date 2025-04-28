 using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    [Route("api/[controller]")]//nombra la ruta con el nombre del controlador
    [ApiController]
    public class EstadoCivilController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public EstadoCivilController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;//instancia de el servicio de general
            _mapper = mapper;//instancia del nugget IMapper
        }

        //Endpoint de listar tasa de cambio de tipo httpGet para recibir datos
        [HttpGet("Listar")]
        public IActionResult ListarEstadosCiviles()
        {
            var response = _generalService.ListarEstadosCiviles();//entra al servicio general de listado estados civiles y setea el resultado en una variable
            return Ok(response.Data);//retorna un codigo 200 y la data de la variable response
        }

        //Ednpoint de tipo httpGet que devuelve el listado de estado civil para colocarlo en un dropdown
        [HttpGet("DropDownEstadoCivil")]
        public IActionResult DropDownEstadoCivil()
        {
            var response = _generalService.DropDownEstadoCiviles();//entra al servicio de general y devuelve los registros para se usados como dropdownlist
            return Ok(response.Data);//retorna un codigo 200 y la data de la variable response
        }

        //Endpint de tipo httpGet que busca el registro en la tabla por medio del id de devuelve sus campos
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarEstadoCivil(int id)
        {
            var response = _generalService.BuscarEstadoCivil(id);//entra al servicio de general, pasandole el id del registro y devuelve la data en la variable response
            return Ok(response.Data);//retorna un codigo 200 y la data de la variable response
        }

        //endpoint de tipo httpPost que sirve para insertar, donde envias los datos del viewmodel a la base de datos
        [HttpPost("Insertar")]
        public IActionResult Create(EstadoCivilViewModel EstadoCivilViewModel)
        {
            var modelo = new tbEstadosCiviles() //mapeo de los datos pedidos del viewmodel al entitie de la tabla
            {

                civi_Descripcion = EstadoCivilViewModel.civi_Descripcion,
                usua_Creacion = EstadoCivilViewModel.usua_Creacion,
                civi_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarEstadoCivil(modelo);//envia el modelo mapeado al servicio general de insertar y setea su resultado en una variable
            return Ok(response);//retorna un codigo 200 y la variable response
        }

        [HttpPut("Actualizar")] //endpoint de tipo httpPut que actualiza un registro de la tabla pidiendo un viewmodel con datos
        public IActionResult Update(EstadoCivilViewModel EstadoCivilViewModel)
        {
            var modelo = new tbEstadosCiviles()//mapeo de los datos pedidos del viewmodel al entitie de la tabla
            {
                civi_Id = EstadoCivilViewModel.civi_Id,
                civi_Descripcion = EstadoCivilViewModel.civi_Descripcion,
                usua_Modificacion = EstadoCivilViewModel.usua_Modificacion,
                civi_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarEstadoCivil(modelo);//envia el modelo mapeado al servicio general de actualizar y setea su resultado en una variable
            return Ok(response);
        }

        [HttpDelete("Eliminar")]//endpoint de tipo httpDelete donde se elimina un registro, se pide el identificador de el registro a eliminar
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarEstadoCivil(id); //envio del id al servicio de eliminar
            return Ok(response);//retorna un codigo 200 y el resultado de el servicio
        }
    }
}
