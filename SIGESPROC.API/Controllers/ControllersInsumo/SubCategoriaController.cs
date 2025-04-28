using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.BusinessLogic.Services.ServiceInsumo;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Controllers.ControllersGeneral
{
    // Atributo para definir la ruta base del controlador y especificar que es un controlador de API
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : Controller
    {
        private readonly InsumoService _insumoService;
        private readonly IMapper _mapper;

        // Constructor de la clase SubCategoriaController que recibe un servicio de insumos y un mapper
        public SubCategoriaController(InsumoService insumoService, IMapper mapper)
        {
            _insumoService = insumoService;
            _mapper = mapper;
        }

        // Método para listar todas las subcategorías
        [HttpGet("Listar")]
        public IActionResult ListarSubcategorias()
        {
            // Llama al servicio para obtener la lista de subcategorías y devuelve los datos en la respuesta
            var response = _insumoService.ListarSubcategorias();
            return Ok(response.Data);
        }

        // Método para listar las subcategorías por categoría
        [HttpGet("ListarPorCategoria/{id}")]
        public IActionResult ListarSubcategoriasPorCategoria(int id)
        {
            // Llama al servicio para obtener la lista de subcategorías filtradas por categoría y devuelve los datos en la respuesta
            var response = _insumoService.ListarSubcategorias(id);
            return Ok(response.Data);
        }

        // Método para buscar una subcategoría por su ID
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarSubcategorias(int id)
        {
            // Llama al servicio para buscar una subcategoría por su ID y devuelve los datos en la respuesta
            var response = _insumoService.BuscarSubcategorias(id);
            return Ok(response.Data);
        }

        // Método para insertar una nueva subcategoría
        [HttpPost("Insertar")]
        public IActionResult Create(SubCategoriaViewModel SubCategoriaViewModel)
        {
            // Crea un nuevo objeto de tipo tbSubcategorias con los datos recibidos en el modelo
            var modelo = new tbSubcategorias()
            {
                suca_Descripcion = SubCategoriaViewModel.suca_Descripcion,
                cate_Id = SubCategoriaViewModel.cate_Id,
                usua_Creacion = SubCategoriaViewModel.usua_Creacion,
                suca_FechaCreacion = DateTime.Now // Asigna la fecha actual como fecha de creación
            };
            // Llama al servicio para insertar la nueva subcategoría y devuelve la respuesta
            var response = _insumoService.InsertarSubcategorias(modelo);
            return Ok(response);
        }

        // Método para actualizar una subcategoría existente
        [HttpPut("Actualizar")]
        public IActionResult Update(SubCategoriaViewModel SubCategoriaViewModel)
        {
            // Crea un nuevo objeto de tipo tbSubcategorias con los datos recibidos en el modelo
            var modelo = new tbSubcategorias()
            {
                suca_Id = Convert.ToInt32(SubCategoriaViewModel.suca_Id), // Convierte el ID de la subcategoría a entero
                suca_Descripcion = SubCategoriaViewModel.suca_Descripcion,
                cate_Id = SubCategoriaViewModel.cate_Id,
                usua_Modificacion = SubCategoriaViewModel.usua_Modificacion,
                suca_FechaModificacion = DateTime.Now // Asigna la fecha actual como fecha de modificación
            };
            // Llama al servicio para actualizar la subcategoría existente y devuelve la respuesta
            var response = _insumoService.ActualizarSubcategorias(modelo);
            return Ok(response);
        }

        // Método para eliminar una subcategoría por su ID
        [HttpDelete("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            // Llama al servicio para eliminar una subcategoría por su ID y devuelve la respuesta
            var response = _insumoService.EliminarSubcategorias(id);
            return Ok(response);
        }
    }
}
