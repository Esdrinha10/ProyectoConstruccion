using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.ServiceProyecto;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersProyecto
{
    [Route("api/[controller]")]//nombra la ruta con el nombre del controlador
    [ApiController]
    public class ActividadeController : Controller
    {
        private readonly ProyectoService _proyectoService;
        private readonly IMapper _mapper;

        public ActividadeController(ProyectoService proyectoService, IMapper mapper)
        {
            _proyectoService = proyectoService;//instacia el servicio de proyectos
            _mapper = mapper;//instancia el nugger IMapper
        }

        [HttpGet("Listar")]//endpoint que sirver para el listado de los registros de la tabla
        public IActionResult ListarActividades()
        {
            var response = _proyectoService.ListarActividades();//entra al servicio y setea el resultado en una variable
            return Ok(response.Data);//devuelve la data de la variable resultado del servicio
        }

        [HttpGet("ListarActividadesPorEtapa")]//endpoint de tipo httpGet, que sirve para lista las actividades que tiene esa etapa
        public IActionResult ListarActividadesPorEtapa(int etap_Id,int proy_Id)//objeto de tipo IAction result que pide un id de parametro
            {

            var response = _proyectoService.ListarActividadesPorEtapas(etap_Id, proy_Id);//envia el id solicitado al servicio y setea el resultado en una variable
            return Ok(response.Data);//retorna la data de una variable
        }
      



        [HttpGet("ListarActividadesPorEtapaFill")]//endpoint que sirve para mostrar los campos actividades por etapa otro procedimiento igual pero distinto que ek de arriba
        public IActionResult ListarActividadesPorEtapaFill(int id)//objeto de tipo IActioresult que pide un id como parametro
        {
            var response = _proyectoService.ListarActividadesPorEtapasFill(id);//envia el id al servicio y setea el resultado en una variable
            return Ok(response.Data);//retorna la data de la variable anterior junto con un codigo 200
        }

        [HttpGet("ListarCostosActividades")]//endpoint que sirve para filtrar y listar los costos de las actividades
        public IActionResult ListarCostoActividad(int acti_Id, int unme_Id)//objeto que pide 2 parametros el id de la actividad y el id de la unidad de medida de esa actividad
        {
            var response = _proyectoService.ListarCostosActividades(acti_Id, unme_Id);//envia los 2 parametros al servicio y setea el resultado en una variable
            return Ok(response.Data);//retorna la data del resultado del servicio
        }

        [HttpGet("Buscar/{id}")]//endpoint de tipo httpget que sirve para buscar la actividad
        public IActionResult BuscarActividad(int id)//objeto de tipo IAction result que pide el id de la actividad para buscar los datos de ese registro filtrado por id
        {
            var response = _proyectoService.BuscarActividad(id);//envia el id al servicio de proyecto y setea el resultado en una variable
            return Ok(response.Data);//devuelve la data del resultado del servicio
        }

        [HttpPost("Insertar")]//nombre del endpoint de tipo httppost que sirve para insertar un nuevo registro
        public IActionResult Create(ActividadesViewModel ActividadViewModel)//objeto de tipo IAction result que pide como parametro el viewmodel de actividades
        {
            var modelo = new tbActividades()//mapeo del viewmodel al entitie de la tabla
            {
                acti_Descripcion = ActividadViewModel.acti_Descripcion,
                usua_Creacion = ActividadViewModel.usua_Creacion,
                acti_FechaCreacion = DateTime.Now
            };
            var response = _proyectoService.InsertarActividad(modelo);//envio del modelo mapeado al servicio y seteo del resultado en una variable

            return Ok(response);//retorno del resultado del servicio
        }

        [HttpPut("Actualizar")]//nombre del endpoint que sirve para actulizar un registro de la tabla
        public IActionResult Update(ActividadesViewModel ActividadViewModel)
        {
            var modelo = new tbActividades()//mapeo del viewmodel con el entitie de la tabla
            {
                acti_Id = ActividadViewModel.acti_Id,
                acti_Descripcion = ActividadViewModel.acti_Descripcion,
                usua_Modificacion = ActividadViewModel.usua_Modificacion,
                acti_FechaModificacion = DateTime.Now
            };
            var response = _proyectoService.ActualizarActividad(modelo);//envio del entitie mapeado al servicio y seteo del resultado en una variable
            return Ok(response);//retorno del resultado del servicio con codigo 200
        }

        [HttpDelete("Eliminar")]//nombre del endpoint de tipo htppDelete que sirve para eliminar un registro de la tabla
        public IActionResult Delete(int id)//objeto de tipo IAction result que pide como parametro el id del registro
        {
            var response = _proyectoService.EliminarActividad(id);//envio del id pedido al servicio de eliminar y seteo del resultado en una variable
            return Ok(response);//retorno del resultado del servicio con un codigo 200
        }
    }
}
