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
    public class TasaCambioController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public TasaCambioController(GeneralService generaleService, IMapper mapper)
        {
            _generalService = generaleService;
            _mapper = mapper;//inicializamos el mapper
        }

        //Controlador de listar tasa de cambio
        [HttpGet("Listar")]
        public IActionResult ListarTasasCambios()
        {
            var response = _generalService.ListarTasasCambios();
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }

        //Controlador de buscar conversiones de tasa de cambio
        [HttpGet("ListarConversiones")]
        public IActionResult ListarConversiones(int id)
        {
            var response = _generalService.ObteneroConversionTasasCambio(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response.Data);//devuelve el codigo 200 y el resultado de la data del response
        }


        //Controlador de buscar tasa de cambio
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarTasasCambios(int id)
        {
            var response = _generalService.BuscarTasasCambios(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response.Data);//devuelve el codigo 200 y el resultado del response
        }

        //Controlador de insertar tasa de cambio
        [HttpPost("Insertar")]
        public IActionResult Create(TasaCambioViewModel TasaCambioViewModel)
        {
            var modelo = new tbTasasCambio()//mappeo de viewmodel al entitie de la tabla
            {
                mone_A = TasaCambioViewModel.mone_A,
                mone_B = TasaCambioViewModel.mone_B,
                taca_ValorA = TasaCambioViewModel.taca_ValorA,
                taca_ValorB = TasaCambioViewModel.taca_ValorB,
                usua_Creacion = TasaCambioViewModel.usua_Creacion,
                taca_FechaCreacion = DateTime.Now
            };
            var response = _generalService.InsertarTasasCambios(modelo);//envio de los datos mapeados al servicio de insertar tasas de cambio y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }


        //Controlador de actualizar tasa de cambio
        [HttpPut("Actualizar")]
        public IActionResult Update(TasaCambioViewModel TasaCambioViewModel)
        {
            var modelo = new tbTasasCambio()//mappeo de viewmodel al entitie de la tabla
            {
                taca_Id = Convert.ToInt32(TasaCambioViewModel.taca_Id),
                mone_A = TasaCambioViewModel.mone_A,
                mone_B = TasaCambioViewModel.mone_B,
                taca_ValorA = TasaCambioViewModel.taca_ValorA,
                taca_ValorB = TasaCambioViewModel.taca_ValorB,
                usua_Modificacion = TasaCambioViewModel.usua_Modificacion,
                taca_FechaModificacion = DateTime.Now
            };
            var response = _generalService.ActualizarTasasCambios(modelo);//envio de los datos mapeados al servicio de actualizar tasas de cambio y lo setea en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }

        //Controlador de eliminar tasa de cambio
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var response = _generalService.EliminarTasasCambios(id); //envia el id de el campo al servicio y setea el resultado en una variable
            return Ok(response);//devuelve el codigo 200 y el resultado del response
        }
    }
}
