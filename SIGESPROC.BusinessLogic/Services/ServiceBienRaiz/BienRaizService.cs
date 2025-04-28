using SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceBienRaiz
{

    public class BienRaizService
    {
        private readonly AgenteBienesRaicesRepository _agentesBienesRaicesRepository;
        private readonly BienRaizRepository _bienRaizRepository;
        private readonly DocumentoBienRaizRepository _documentoBienRaizRepository;
        private readonly EmpresaBienRaizRepository _empresaBienRaizRepository;
        private readonly ProyectoConstruccionBienRaizRepository _proyectoConstruccionBienRaizRepository;
        private readonly TerrenoRepository _terrenoRepository;
        private readonly TipoDocumentoRepository _tipoDocumentoRepository;
        private readonly MantenimientoRepository _mantenimientoRepository;    


        /// <summary>
        /// Servicio que gestiona la lógica de negocio relacionada con Bienes Raices.
        /// </summary>
        public BienRaizService(
               AgenteBienesRaicesRepository agentesBienesRaicesRepository,
               BienRaizRepository bienRaizRepository,
               DocumentoBienRaizRepository documentoBienRaizRepository,
               EmpresaBienRaizRepository empresaBienRaizRepository,
               ProyectoConstruccionBienRaizRepository proyectoConstruccionBienRaizRepository, TerrenoRepository terrenoRepository
            ,TipoDocumentoRepository tipoDocumentoRepository,
               MantenimientoRepository mantenimientoRepository

             )
        // Constructor para inyectar los repositorios.


        {
            _agentesBienesRaicesRepository = agentesBienesRaicesRepository;
            _bienRaizRepository = bienRaizRepository;
            _documentoBienRaizRepository = documentoBienRaizRepository;
            _empresaBienRaizRepository = empresaBienRaizRepository;
            _proyectoConstruccionBienRaizRepository = proyectoConstruccionBienRaizRepository;
            _terrenoRepository = terrenoRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _mantenimientoRepository = mantenimientoRepository;

        }
        #region Agente Bienes Raices
        public ServiceResult ListarAgenteBienesRaices()
        {
            var result = new ServiceResult();
            try
            {
                // Obtenemos la lista de agentes de bienes raíces.
                var list = _agentesBienesRaicesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarAgenteBienesRaices(string id)
        {
            var result = new ServiceResult();
            try
            {
                // Buscamos un agente de bienes raíces por su ID.
                var map = _agentesBienesRaicesRepository.buscar(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarAgenteBienesRaices(tbAgentesBienesRaices item)
        {
            var result = new ServiceResult();
            try
            {
                // Insertamos un nuevo agente de bienes raíces.
                var map = _agentesBienesRaicesRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarAgenteBienesRaices(tbAgentesBienesRaices item)
        {
            var result = new ServiceResult();
            try
            {
                // Actualizamos un agente de bienes raíces existente.
                var map = _agentesBienesRaicesRepository.Update(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarAgenteBienesRaices(int? id)
        {
            // Inicializamos el objeto ServiceResult que contendrá el resultado de la operación.
            var result = new ServiceResult();

            try
            {
                // Llamamos al método Delete del repositorio para eliminar el agente de bienes raíces y obtenemos el resultado.
                var request = _agentesBienesRaicesRepository.Delete(id);

                // Verificamos el estado de la respuesta.
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso.
                // De lo contrario, retornamos un resultado de error.
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result.
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Cliente Proceso venta

        public ServiceResult ListarClienteBienesRaices()
        {
            var result = new ServiceResult();
            try
            {
                // Obtenemos la lista de Cliente de bienes raíces.
                var list = _mantenimientoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarClienteBienesRaices(string id)
        {
            var result = new ServiceResult();
            try
            {
                // Buscamos un Cliente de bienes raíces por su ID.
                var map = _mantenimientoRepository.Buscar(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarClienteBienesRaices(tbMantenimientos item)
        {
            var result = new ServiceResult();
            try
            {
                // Insertamos un nuevo Cliente de bienes raíces.
                var map = _mantenimientoRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarClienteBienesRaices(tbMantenimientos item)
        {
            var result = new ServiceResult();
            try
            {
                // Actualizamos un Cliente de bienes raíces existente.
                var map = _mantenimientoRepository.Update(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error.
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarClienteBienesRaices(int? id)
        {
            // Inicializamos el objeto ServiceResult que contendrá el resultado de la operación.
            var result = new ServiceResult();

            try
            {
                // Llamamos al método Delete del repositorio para eliminar el Cliente/ de bienes raíces y obtenemos el resultado.
                var request = _mantenimientoRepository.Delete(id);

                // Verificamos el estado de la respuesta.
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso.
                // De lo contrario, retornamos un resultado de error.
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result.
                return result.Error(ex.Message);
            }
        }

        #endregion


        #region BienRaiz
        /// <summary>
        /// Lista de Bienes Raices.
        /// </summary>

        public ServiceResult ListarBienesRaices()
        {

            var result = new ServiceResult();
            try
            {
                var list = _bienRaizRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        /// <summary>
        /// Busca un Bien Raiz específica.
        /// </summary>
        /// <param name="id">ID de la Bien Raiz a buscar.</param>
        /// <returns>Del Bien Raiz encontrado o un mensaje de error.</returns>
        public ServiceResult BuscarBienRaiz(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bienRaizRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un Bien Raiz.
        /// </summary>
        /// <param name="item">Entidad de Bien Raiz.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult InsertarBienRaiz(tbBienesRaices item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bienRaizRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza un Bien Raiz existente.
        /// </summary>
        /// <param name="item">Entidad de Bien Raiz.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ActualizarBienRaiz(tbBienesRaices item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _bienRaizRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una Bien Raiz específica.
        /// </summary>
        /// <param name="id">ID del Bien Raiz a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>

        public ServiceResult EliminarBienRaiz(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _bienRaizRepository.Delete(id);

                
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult Desactivaridentificadorbienraiz(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _bienRaizRepository.DesactivarIdentificador(id);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        // servicio para buscar documentos por bien raiz por el id
        public ServiceResult DocumentoPorBienRaiz(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llamamos al motodo de buscar 
                var map = _bienRaizRepository.DocumentoPorBienRaiz(id);
                // Retorna el resultado exitoso si el estado del código es 1.
                return result.Ok(map);

            }
            catch (Exception ex)
            {
                // Retorna un error si el estado del código no es 1.
                return result.Error(ex.Message);
            }
        }

        #endregion

        // servicio para Listar todos los  documentos por bien raiz 

        public ServiceResult ListarTipoDocumentoBienRaiz()
        {
            var result = new ServiceResult();
            try
            {
                var list = _documentoBienRaizRepository.ListTipodocumento();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        // listar documentos solo de pdf pero para la pantalla de terreno
        public ServiceResult ListarTerrenoPDF(int id)
        {
            // llama al servicio
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar .

                var list = _documentoBienRaizRepository.ListTerrenoPDF(id);
                // Retorna una lista 
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        // listar solo de imagen pero para la pantalla de terreno

        public ServiceResult ListarTerrenoImagen(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar imagenes.

                var list = _documentoBienRaizRepository.ListTerenoImagen(id);

                // Retorna una lista 
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }

        // listar solo de excel pero para la pantalla de terreno

        public ServiceResult ListarTerrenoExcel(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar excel.
                var list = _documentoBienRaizRepository.ListTerrenoExcel(id);
                // Retorna una lista 
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        // listar solo de Worrd pero para la pantalla de terreno

        public ServiceResult ListarTerrenoWord(int id)
        {
            var result = new ServiceResult();
            try
            {                // Llama al método del repositorio para listar .
                var list = _documentoBienRaizRepository.ListTerrenoWord(id);
                // Retorna el resultado
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        // listar solo de otros documentos diferentes a imagenes, word, excel,pdf pero para la pantalla de terreno

        public ServiceResult ListarTerrenoOtros(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar .

                var list = _documentoBienRaizRepository.ListTerrenoOtro(id);
                // Retorna el resultado
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }





        // listar documentos solo de pdf pero para la pantalla de bien raiz
        public ServiceResult ListarPDF(int id)
        {
            var result = new ServiceResult();
            try
            {
                // llama al servicio de listar
                var list = _documentoBienRaizRepository.ListPDF(id);
                // Retorna us estado si todo es correcto manda la lista 

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        // listar solo de imagen pero para la pantalla de Bien raiz
        public ServiceResult ListarImagen(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar imagenes.
                var list = _documentoBienRaizRepository.ListImagen(id);
                // Retorna una lista 
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        // listar solo de Worrd pero para la pantalla de bienes raices

        public ServiceResult ListarWord(int id)
        {
            
            var result = new ServiceResult();
            try
            {// Llama al método del repositorio para listar excel.
                var list = _documentoBienRaizRepository.ListWord(id);
                // Retorna una lista 
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        // listar solo de otros documentos diferentes a imagenes, word, excel,pdf pero para la pantalla de terreno
        public ServiceResult ListarOtros(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar .
                var list = _documentoBienRaizRepository.ListOtros(id);
                // Retorna el resultado
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }


        // listar solo de excel pero para la pantalla de Bien Raiz
        public ServiceResult ListarExcel(int id)
        {
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar excel.
                var list = _documentoBienRaizRepository.ListExcel(id);
                // Retorna una lista 
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
        //lista los documentos de bienes raices
        public ServiceResult ListarDocumentoBienRaizs()
        {
            var result = new ServiceResult();
            try
            {
                var list = _documentoBienRaizRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        // lista los documentos de terrenos por el id d
        public ServiceResult DocumentoPorTerreno(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _terrenoRepository.DocumentoPorTerreno(id);

                return result.Ok(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
    

   
        //busca documentos por el id del bien raiz
        public ServiceResult BuscarDocumentoBienRaiz(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _documentoBienRaizRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //busca documentos por el id del terreno
        public ServiceResult BuscarDocumentoPorTerreno(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _documentoBienRaizRepository.DocumentoPorTerrenos(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //hace un filtrado del proyecto o construccion por el id 
        public ServiceResult BuscarProyectoConstruccionBienRaiz(int id)
        {
            
            var result = new ServiceResult();
            try
            {
                // llama al metodo para encontar el registro
                var map = _proyectoConstruccionBienRaizRepository.Find(id);
                // devuelve el resultado
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // retorna exepcion en caso sea error
                return result.Error(ex.Message);
            }
        }

        
        // inserta documentos bien raiz y terrenos
        public ServiceResult InsertarDocumentoBienRaiz(tbDocumentosBienRaiz item)
        {
            var result = new ServiceResult();
            try
            {
                //llama al metodo en el repositorio
                var map = _documentoBienRaizRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    // si el codigo estatud fue mayor a uno devuelve el resultado
                    return result.Ok(map);
                }
                else
                {
                    //si no retorna un error
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {   //si no retorna un error
                return result.Error(ex.Message);
            }
        }
        // servicio para insertar el proyecto asisgnado a un bien raiz
        public virtual ServiceResult InsertarProyectoConstruccionBienRaiz(tbProyectosConstruccionBienesRaices item)
        {
            var result = new ServiceResult();
            try
            {
                // llamada al metodo del repositorio
                var map = _proyectoConstruccionBienRaizRepository.Insert(item);
                if (map.CodeStatus == 1)
                {
                    // devolucion del resultado si todo salo correcto
                    return result.Ok(map);
                }
                else
                {
                    //retorna error 
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                //retorna error 
                return result.Error(ex.Message);
            }
        }

     

        //metodo para actualizar bien Raiz
        public ServiceResult ActualizarDocumentoBienRaiz(tbDocumentosBienRaiz item)
        {
            var result = new ServiceResult();
            try
            {
                //llama al metodo en el repositorio para actualizar
                var map = _documentoBienRaizRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    // retorna un valor si fue exitosa la actualizacion
                    return result.Ok(map);
                }
                else
                {
                    //retorna error
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                //retorna error
                return result.Error(ex.Message);
            }
        }



     // eliminar documentos bienes raices solamente
        public ServiceResult EliminarDocumentoBienRaiz(int id)
        {
            var result = new ServiceResult();
            try
            {
                // llama al servicio
                var map = _documentoBienRaizRepository.Delete(id);
                if (map.CodeStatus >= 1)
                {
                    //retorna el valor del resultado si fue correcto 
                    return result.Ok(map);
                }
                else
                {
                    //Retorna error
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {//Retorna error
                return result.Error(ex.Message);
            }
        }

        // elimina documentos relacionados con el terreno
        public ServiceResult EliminarDocumentoTerreno(int id)
        {
            var result = new ServiceResult();
            try
            {
                // manda a llamar el metodo del repositorio
                var map = _documentoBienRaizRepository.DeleteTerreno(id);
                if (map.CodeStatus >= 1)
                {
                    // retorna el resultado
                    return result.Ok(map);
                }
                else
                {
                    // En caso de excepción, retorna el error.

                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.

                return result.Error(ex.Message);
            }
        }
        // Método para listar .
        public ServiceResult ListarProyectosConstruccionBienesRaices()
        {
            // Inicializa el resultado del servicio.
            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para listar .
                var list = _proyectoConstruccionBienRaizRepository.List();
                // Retorna el resultado
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
         // Método para actualizar
         public ServiceResult ActualizarProyectoConstruccionBienRaiz(tbProyectosConstruccionBienesRaices item)
        {
            // Inicializa el resultado del servicio.

            var result = new ServiceResult();
            try
            {
                // Llama al método del repositorio para actualizar
                var map = _proyectoConstruccionBienRaizRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    // Retorna el resultado exitoso si el estado del código es 1.
                    return result.Ok(map);
                }
                else
                {
                    // Retorna un error si el estado del código no es 1.
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retorna el error.
                return result.Error(ex.Message);
            }
        }
       
        //Metodo eliminar
        public ServiceResult EliminarProyectoConstruccionBienRaiz(int id)
        {
            var result = new ServiceResult();
            try
            {

                // Llamamos al motodo Delete del repositorio para eliminar el proveedor y obtenemos el resultado
                var map = _proyectoConstruccionBienRaizRepository.Delete(id);
              
                if (map.CodeStatus >= 1)
                {
                    // Retorna el resultado exitoso si el estado del código es 1.
                    return result.Ok(map);
                }
                else
                {
                    // En caso de excepción, retorna el error
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepcion, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }




        public ServiceResult ListarTerrenos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _terrenoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarTerrenosIdentificador()
        {
            var result = new ServiceResult();
            try
            {
                var list = _terrenoRepository.ListIdentificador();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServiceResult BuscarEmpresaBienRaiz(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empresaBienRaizRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarTerreno(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _terrenoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #region Empresa Bien Raiz
        public ServiceResult ListarEmpresaBienRaizs()
        {
            var result = new ServiceResult();
            try
            {
                var list = _empresaBienRaizRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarEmpresaBienRaiz(tbEmpresasBienesRaices item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empresaBienRaizRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
        public ServiceResult InsertarTerreno(tbTerrenos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _terrenoRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
      

        public ServiceResult ActualizarEmpresaBienRaiz(tbEmpresasBienesRaices item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empresaBienRaizRepository.Update(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarTerreno(tbTerrenos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _terrenoRepository.Update(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
      

       



        public ServiceResult EliminarEmpresaBienRaiz(int? id)
        {
            // Inicializamos el objeto ServiceResult que contendr� el resultado de la operacion
            var result = new ServiceResult();

            try
            {
                // Llamamos al motodo Delete del repositorio para eliminar el proveedor y obtenemos el resultado
                var request = _empresaBienRaizRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepcion, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarTerreno(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _terrenoRepository.Delete(id);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult Desactivaridentificador(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _terrenoRepository.DesactivarIdentificador(id);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

  




        #region Tipo Documento
        public ServiceResult ListarTipoDocumento()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipoDocumentoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
   
        public ServiceResult InsertarTipoDocumento(tbTiposDocumentos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _tipoDocumentoRepository.Insert(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarTipoDocumento(tbTiposDocumentos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _tipoDocumentoRepository.Update(item);
                if (map.CodeStatus >= 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //public ServiceResult EliminarTipoDocumento(int id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _tipoDocumentoRepository.Delete(id);

        //        return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}


        public ServiceResult EliminarTipoDocumento(int id)
        {
            // Inicializamos el objeto ServiceResult que contendr� el resultado de la operacion
            var result = new ServiceResult();

            try
            {
                // Llamamos al motodo Delete del repositorio para eliminar el proveedor y obtenemos el resultado
                var request = _tipoDocumentoRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepcion, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        #endregion

    }
}
