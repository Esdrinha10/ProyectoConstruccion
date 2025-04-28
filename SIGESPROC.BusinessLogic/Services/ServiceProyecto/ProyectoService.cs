using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.DataAccess.Repositories.RepositoryProyecto;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceProyecto
{
    /// <summary>
    /// Servicio que gestiona la lógica de negocio relacionada con proyectos.
    /// </summary>
    public class ProyectoService
    {
        private readonly DocumentoRepository _documentoRepository;
        private readonly EquipoSeguridadRepository _equipoSeguridadRepository;
        private readonly EstadoProyectoRepository _estadoProyectoRepository;
        private readonly EtapaRepository _etapaRepository;
        private readonly EtapaPorProyectoRepository _etapaPorProyectoRepository;
        private readonly GestionAdicionalRepository _gestionAdicionalRepository;
        private readonly GestionRiesgoRepository _gestionRiesgoRepository;
        private readonly ImagenPorControlCalidadRepository _imagenPorControlCalidadRepository;
        //private readonly ContratoRepository _contratoRepository;
        //private readonly ContratoEmpleadoRepository _contratoempleadoRepository;
        private readonly ControlDeCalidadRepository _controldecalidadRepository;
        private readonly ControlDeCalidadPorActividadRepository _controldecalidadporactividadRepository;
        private readonly NotificacionRepository _notificacionRepository;
        private readonly PagoRepository _pagoRepository;
        private readonly RetrasoRepository _retrasoRepository;
        private readonly IncidenteRepository _incidenteRepository;
        private readonly NotificacionAlertaPorUsuarioRepository _notificacionAlertaPorUsuarioRepository;
        private readonly ActividadPorEtapaRepository _actividadPorEtapaRepository;
        private readonly ArchivoAdjuntoRepository _archivoAdjuntoRepository;
        private readonly ActividadRepository _actividadRepository;
        private readonly AlertaRepository _alertaRepository;
        private readonly PresupuestoEncabezadoRepository _presupuestoencabezadoRepository;
        private readonly PresupuestoDetalleRepository _presupuestodetalleRepository;
        private readonly InsumoPorActividadRepository _insumoporactividadRepository;
        private readonly RentaMaquinariaPorActividadRepository _rentamaquinariaporactividadRepository;
        private readonly PresupuestoPorTasaCambioRepository _presupuestoportasacambioRepository;
        private readonly ProyectoRepository _proyectoRepository;
        private readonly InsumoPorActividadRepository _insumoPorActividadRepository;
        private readonly RentaMaquinariaPorActividadRepository _rentaMaquinariaPorActividadRepository;
        private readonly EquipoSeguridadPorActividadRepository _equipoSeguridadPorActividadRepository;
        private readonly ReferenciasRepository _referenciasRepository;
        /// <summary>
        /// Constructor que inicializa las dependencias del servicio.
        /// </summary>
        public ProyectoService(
               DocumentoRepository documentoRepository, 
               EquipoSeguridadRepository equipoSeguridadRepository, 
               EstadoProyectoRepository estadoProyectoRepository,
               EtapaRepository etapaRepository,
               IncidenteRepository incidenteRepository,
               NotificacionAlertaPorUsuarioRepository notificacionAlertaPorUsuarioRepository,
               EtapaPorProyectoRepository etapaPorProyectoRepository,
               GestionAdicionalRepository gestionAdicionalRepository,
               GestionRiesgoRepository gestionRiesgoRepository,
               ImagenPorControlCalidadRepository imagenPorControlCalidadRepository,
               //ContratoRepository contratoRepository,
               //ContratoEmpleadoRepository contratoempleadoRepository,
               ControlDeCalidadRepository controldecalidadRepository,
               ControlDeCalidadPorActividadRepository controldecalidadporactividadRepository,
               NotificacionRepository notificacionRepository,
               PagoRepository pagoRepository,
               RetrasoRepository retrasoRepository,
               InsumoPorActividadRepository insumoporactividadRepository,
               RentaMaquinariaPorActividadRepository rentamaquinariaporactividadRepository,
               ActividadPorEtapaRepository actividadPorEtapaRepository,
               ArchivoAdjuntoRepository archivoAdjuntoRepository,
               ActividadRepository actividadRepository, 
               AlertaRepository alertaRepository,
               PresupuestoEncabezadoRepository presupuestoencabezadoRepository,
               PresupuestoDetalleRepository presupuestodetalleRepository,
               PresupuestoPorTasaCambioRepository presupuestoportasacambioRepository,
               ProyectoRepository proyectoRepository,
               InsumoPorActividadRepository insumoPorActividadRepository,
               RentaMaquinariaPorActividadRepository rentaMaquinariaPorActividadRepository,
               EquipoSeguridadPorActividadRepository equipoSeguridadPorActividadRepository,
               ReferenciasRepository referenciasRepository
             )

        {
            _actividadPorEtapaRepository = actividadPorEtapaRepository;
            _documentoRepository = documentoRepository;
            _incidenteRepository = incidenteRepository;
            _equipoSeguridadRepository = equipoSeguridadRepository;
            _estadoProyectoRepository = estadoProyectoRepository;
            _etapaRepository = etapaRepository;
            _etapaPorProyectoRepository = etapaPorProyectoRepository;
            _gestionAdicionalRepository = gestionAdicionalRepository;
            _gestionRiesgoRepository = gestionRiesgoRepository;
            _imagenPorControlCalidadRepository = imagenPorControlCalidadRepository;
            //_contratoRepository = contratoRepository;
            //_contratoempleadoRepository = contratoempleadoRepository;
            _notificacionAlertaPorUsuarioRepository = notificacionAlertaPorUsuarioRepository;
            _controldecalidadRepository = controldecalidadRepository;
            _controldecalidadporactividadRepository = controldecalidadporactividadRepository;
            _notificacionRepository = notificacionRepository;
            _pagoRepository = pagoRepository;
            _insumoporactividadRepository = insumoporactividadRepository;
            _rentamaquinariaporactividadRepository = rentamaquinariaporactividadRepository;
    _retrasoRepository = retrasoRepository;
            _archivoAdjuntoRepository = archivoAdjuntoRepository;
             _actividadRepository = actividadRepository;
            _alertaRepository = alertaRepository;
            _presupuestoencabezadoRepository = presupuestoencabezadoRepository;
            _presupuestodetalleRepository = presupuestodetalleRepository;
            _presupuestoportasacambioRepository = presupuestoportasacambioRepository;
            _proyectoRepository = proyectoRepository;
            _insumoPorActividadRepository = insumoPorActividadRepository;
            _rentaMaquinariaPorActividadRepository = rentaMaquinariaPorActividadRepository;
            _equipoSeguridadPorActividadRepository = equipoSeguridadPorActividadRepository;
            _referenciasRepository = referenciasRepository;
        }
        #region Actividad Por Etapa
        /// <summary>
        /// Elimina una actividad por etapa específica.
        /// </summary>
        /// <param name="id">ID de la actividad a eliminar.</param>
        /// <returns>Un mensaje de éxito o error dependiendo del resultado.</returns>
        public ServiceResult EliminarActividadPorEtapa(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _actividadPorEtapaRepository.Delete(id);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Busca una actividad por etapa específica.
        /// </summary>
        /// <param name="id">ID de la actividad a buscar.</param>
        /// <returns>La actividad encontrada o un mensaje de error.</returns>
        public ServiceResult BuscarActividadPorEtapa(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var actividadporetapa = _actividadPorEtapaRepository.Find(id);

                return result.Ok(actividadporetapa);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        /// <summary>
        /// Inserta una nueva actividad por etapa.
        /// </summary>
        /// <param name="item">Entidad de actividad por etapa.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult InsertarActividadPorEtapa(tbActividadesPorEtapas item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _actividadPorEtapaRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListarActividad()
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadPorEtapaRepository.ListarActividad();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        /// <summary>
        /// Lista todas las actividades por etapa para una etapa de proyecto específica.
        /// </summary>
        /// <param name="id">ID de la etapa del proyecto.</param>
        /// <returns>Una lista de actividades.</returns>
        public ServiceResult ListarActividadesPorEtapa(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadPorEtapaRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarInsumosPorProveedores(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadPorEtapaRepository.ListInsumos(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarMaquinariasPorProveedores(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadPorEtapaRepository.ListMaquinarias(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult ListarEquiposSeguridadPorProveedores()
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadPorEtapaRepository.ListEquiposSeguridad();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza una actividad por etapa existente.
        /// </summary>
        /// <param name="item">Entidad de actividad por etapa.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ActualizarActividadPorEtapa(tbActividadesPorEtapas item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _actividadPorEtapaRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Replica actividades de una etapa de proyecto en otra.
        /// </summary>
        /// <param name="item">Entidad de la etapa por proyecto.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult ReplicarActividadesPorEtapa(tbEtapasPorProyectos item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _actividadPorEtapaRepository.Replicate(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        /// <summary>
        /// Autocompleta la información de una actividad por etapa.
        /// </summary>
        /// <param name="id">ID de la actividad a autocompletar.</param>
        /// <returns>Resultado de la operación.</returns>
        public ServiceResult AutoCompletarActividadesPorEtapa(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _actividadPorEtapaRepository.AutoComplete(id);

                return result.Ok(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Archivo Adjunto
        public ServiceResult ListarImagenesPorGestionesAdicionales(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _archivoAdjuntoRepository.List1(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }


        public ServiceResult EliminarArchivoAdjunto(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _archivoAdjuntoRepository.Delete(id);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }

        public ServiceResult BuscarArchivoAdjunto(int adic_Id)
        {
            var result = new ServiceResult();

            try
            {
                var material = _archivoAdjuntoRepository.List1(adic_Id);

                return result.Ok(material);
            }
            catch (Exception ex)
            {
                result.Error(ex.Message);

                throw;
            }
        }

        public virtual ServiceResult InsertarArchivoAdjunto(tbImagenesPorGestionesAdicionales item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _archivoAdjuntoRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Conflict();
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult ActualizarArchivoAdjunto(tbImagenesPorGestionesAdicionales item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _archivoAdjuntoRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Documento
        public ServiceResult ListarDocumento(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _documentoRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarDocumento(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _documentoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public virtual ServiceResult InsertarDocumento(tbDocumentos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _documentoRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult ActualizarDocumento(tbDocumentos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _documentoRepository.Update(item);
                
                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarDocumento(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _documentoRepository.Delete(id);
                
                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region EquipoSeguridad
        public ServiceResult ListarEquipoSeguridad()//Serivicio de listar equipos de seguridad que retorna un service result
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var list = _equipoSeguridadRepository.List();//variable que almacena el resultado que retorna el listado del repositorio de equipo de seguridad
                return result.Ok(list);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }

        }
        public ServiceResult BuscarEquipoSeguridad(int id)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _equipoSeguridadRepository.Find(id);//variable que almacena el resultado que retorna el buscar del repositorio
                return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        public ServiceResult BuscarEquipoPorProveedores(int prov)
        {
            var result = new ServiceResult();
            try
            {
                var map = _equipoSeguridadRepository.Buscar(prov);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public virtual  ServiceResult InsertarEquipoSeguridad(tbEquiposSeguridad item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _equipoSeguridadRepository.Insert(item);//variable que almacena el resultado que retorna el insertar del repositorio
                if (map.CodeStatus != 0)//valida si el codigo enviado por la api es distinto de 0
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }


        public ServiceResult InsertarEquipoSeguridadPorProveedor(tbEquiposSeguridad item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _equipoSeguridadRepository.InsertPorProveedor(item);//variable que almacena el resultado que retorna el insertar del repositorio
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
 
        public virtual ServiceResult ActualizarEquipoSeguridad(tbEquiposSeguridad item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _equipoSeguridadRepository.Update(item);//variable que almacena el resultado que retorna el actualizar del repositorio
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult EliminarEquipoSeguridad(int id)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _equipoSeguridadRepository.Delete(id);//variable que almacena el resultado que retorna el eliminar del repositorio

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult EliminarEquiposPorProveedor(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _equipoSeguridadRepository.DeletePorProveedor(id);
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Equipo de Seguridad Por Actividad
        /// <summary>
        /// Lista los equipos de seguridad para una actividad específica.
        /// </summary>
        /// <param name="id">ID de la actividad.</param>
        /// <returns>Una lista de equipos de seguridad.</returns>
        public ServiceResult ListarEquiposSeguridadPorActividad(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _equipoSeguridadPorActividadRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Equipos de seguridad por proveeedor
        public ServiceResult ListarEquiposPorProveedor()
        {
            var result = new ServiceResult();
            try
            {
                var list = _equipoSeguridadRepository.ListInsumosPorProveedor();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarEquiposPorProveedor(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _equipoSeguridadRepository.ListPorBodega(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region EstadoProyecto
        public ServiceResult ListarEstadosProyectos()//Serivicio de listar estados de proyecto que retorna un service result
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var list = _estadoProyectoRepository.List();//variable que almacena el resultado que retorna el listado del repositorio
                return result.Ok(list);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }

        }
        public ServiceResult BuscarEstadoProyecto(int id)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _estadoProyectoRepository.Find(id);//variable que almacena el resultado que retorna el buscar del repositorio
                return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        public virtual ServiceResult InsertarEstadoProyecto(tbEstadosProyectos item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _estadoProyectoRepository.Insert(item);//variable que almacena el resultado que retorna el insertar del repositorio
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public virtual ServiceResult ActualizarEstadoProyecto(tbEstadosProyectos item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _estadoProyectoRepository.Update(item);//variable que almacena el resultado que retorna el actualizar del repositorio
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult EliminarEstadoProyecto(int id)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _estadoProyectoRepository.Delete(id);//variable que almacena el resultado que retorna el eliminar del repositorio

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        #endregion

        #region Etapa
        public ServiceResult ListarEtapas()//Serivicio de listar etapas que retorna un service result
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var list = _etapaRepository.List();//variable que almacena el resultado que retorna el listado del repositorio
                return result.Ok(list);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }

        }
        public ServiceResult BuscarEtapa(int id)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _etapaRepository.Find(id);//variable que almacena el resultado que retorna el buscar del repositorio
                return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        public ServiceResult BuscarEtapaPorNombre(string etap_Descripcion)
        {
            var result = new ServiceResult();
            try
            {
                var map = _etapaRepository.BuscarPorNombre(etap_Descripcion);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public virtual ServiceResult InsertarEtapa(tbEtapas item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _etapaRepository.Insert(item);//variable que almacena el resultado que retorna el insertar del repositorio
                if (map.CodeStatus > 0 )
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public virtual ServiceResult ActualizarEtapa(tbEtapas item)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _etapaRepository.Update(item);//variable que almacena el resultado que retorna el actualizar del repositorio
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);//retorno de la variable tipo service result y el resultado del repositorio
                }
                else
                {
                    return result.Error(map);//retorna un error si hubo algun error
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }

        public ServiceResult EliminarEtapa(int id)
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try
            {
                var map = _etapaRepository.Delete(id);//variable que almacena el resultado que retorna el eliminar del repositorio

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }
        #endregion

        #region Etapa Por Proyecto
        public ServiceResult BuscarEtapasPorProyectos(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _etapaPorProyectoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListarEtapasPorProyectos(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _etapaPorProyectoRepository.Listar(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult InsertarEtapaPorProyecto(tbEtapasPorProyectos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _etapaPorProyectoRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult ActualizarEtapaPorProyecto(tbEtapasPorProyectos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _etapaPorProyectoRepository.Update(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarEtapaPorProyecto(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _etapaPorProyectoRepository.Delete(id);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Gestion Adicional


        public ServiceResult ListarGestionAdicional()
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionAdicionalRepository.List();
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarGestionAdicional(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionAdicionalRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult InsertarGestionAdicional(tbGestionesAdicionales item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionAdicionalRepository.Insert(item);
                if (map.CodeStatus != 0)
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

        public virtual ServiceResult ActualizarGestionAdicional(tbGestionesAdicionales item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionAdicionalRepository.Update(item);
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

        public ServiceResult EliminarGestionAdicional(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionAdicionalRepository.Delete(id);
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
        #endregion

        #region Gestion Riesgo
        public ServiceResult ListarGestionRiesgos(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionRiesgoRepository.List(id);

                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarGestionRiesgo(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionRiesgoRepository.Find(id);

                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult InsertarGestionRiesgo(tbGestionRiesgos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionRiesgoRepository.Insert(item);
                
                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult ActualizarGestionRiesgo(tbGestionRiesgos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionRiesgoRepository.Update(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarGestionRiesgo(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _gestionRiesgoRepository.Delete(id);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Gestion Riesgo

        public ServiceResult ListarImagenesPorControlCalidades(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _imagenPorControlCalidadRepository.List1(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarImagenPorControlCalidad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorControlCalidadRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public virtual ServiceResult InsertarImagenPorControlCalidad(tbImagenesPorControlesDeCalidades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorControlCalidadRepository.Insert(item);
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

        public virtual ServiceResult ActualizarImagenPorControlCalidad(tbImagenesPorControlesDeCalidades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorControlCalidadRepository.Update(item);
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

        public ServiceResult EliminarImagenPorControlCalidad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _imagenPorControlCalidadRepository.Delete(id);
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
        #endregion
  
        #region Contratos
        //public ServiceResult ListarContratos()
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var list = _contratoRepository.List();
        //        return result.Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }

        //}
        //public ServiceResult BuscarContrato(int id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoRepository.Find(id);
        //        return result.Ok(map);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}
        //public ServiceResult InsertarContrato(tbContratos item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoRepository.Insert(item);
        //        if (map.CodeStatus == 1)
        //        {
        //            return result.Ok(map);
        //        }
        //        else
        //        {
        //            return result.Error(map);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult ActualizarContrato(tbContratos item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoRepository.Update(item);
        //        if (map.CodeStatus == 1)
        //        {
        //            return result.Ok(map);
        //        }
        //        else
        //        {
        //            return result.Error(map);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult EliminarContrato(int id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoRepository.Delete(id);
        //        if (map.CodeStatus == 1)
        //        {
        //            return result.Ok(map);
        //        }
        //        else
        //        {
        //            return result.Error(map);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}
        #endregion

        #region Contratos Empleados
        //public ServiceResult ListarContratosEmpleados()
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var list = _contratoempleadoRepository.List();
        //        return result.Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }

        //}
        //public ServiceResult BuscarContratoEmpleado(int id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoempleadoRepository.Find(id);
        //        return result.Ok(map);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}
        //public ServiceResult InsertarContratoEmpleado(tbContratosEmpleados item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoempleadoRepository.Insert(item);
        //        if (map.CodeStatus == 1)
        //        {
        //            return result.Ok(map);
        //        }
        //        else
        //        {
        //            return result.Error(map);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult ActualizarContratoEmpleado(tbContratosEmpleados item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoempleadoRepository.Update(item);
        //        if (map.CodeStatus == 1)
        //        {
        //            return result.Ok(map);
        //        }
        //        else
        //        {
        //            return result.Error(map);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult EliminarContratoEmpleado(int id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _contratoempleadoRepository.Delete(id);
        //        if (map.CodeStatus == 1)
        //        {
        //            return result.Ok(map);
        //        }
        //        else
        //        {
        //            return result.Error(map);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}
        #endregion

        #region Control De Calidades
        public ServiceResult ListarControlDeCalidades()
        {
            var result = new ServiceResult();
            try
            {
                var list = _controldecalidadRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult ListarControlDeCalidadesPorActividad(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _controldecalidadRepository.FindByActividad(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult ListarProyectosConControlesDeCalidad()
        {
            var result = new ServiceResult();
            try
            {
                var list = _controldecalidadRepository.ListProyectosConControlesDeCalidad();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarControlesDeCalidadPorProyectos(int proy_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _controldecalidadRepository.ListControlesDeCalidadPorProyectos(proy_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarControlDeCalidad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public virtual ServiceResult InsertarControlDeCalidad(tbControlDeCalidadesPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadRepository.Insert1(item);
                if (map.CodeStatus >0 )
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

        public virtual ServiceResult ActualizarControlDeCalidad(tbControlDeCalidadesPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadRepository.Update1(item);
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

        public ServiceResult AprobarControlDeCalidad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadRepository.Aprobar(id);
                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarControlDeCalidad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadRepository.Delete(id);
                return map.CodeStatus > 0 ? result.Ok(map) : result.Error(map);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Control De Calidades Por Actividades
        public ServiceResult ListarControlDeCalidadesPorActividades(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _controldecalidadporactividadRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
     
        public virtual ServiceResult InsertarControlDeCalidadPorActividad(tbControlDeCalidadesPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadporactividadRepository.Insert(item);
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

        public virtual ServiceResult ActualizarControlDeCalidadPorActividad(tbControlDeCalidadesPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadporactividadRepository.Update(item);
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

        public ServiceResult EliminarControlDeCalidadPorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _controldecalidadporactividadRepository.Delete(id);
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
        #endregion

        #region Retrasos
        public ServiceResult BuscarRetraso(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _retrasoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult InsertarRetraso(tbRetrasos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _retrasoRepository.Insert(item);

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
        public ServiceResult ActualizarRetraso(tbRetrasos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _retrasoRepository.Update(item);
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
        public ServiceResult EliminarRetraso(int id)
        {
            var result = new ServiceResult();
            try
            {

                var map = _retrasoRepository.Delete(id);

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
        #endregion

        #region Pagos
        public ServiceResult ListarPagos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pagoRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarPago(int id)
        {
            var result = new ServiceResult();
            try
            {

                var map = _pagoRepository.Find(id);

                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarPago(tbPagos item)
        {
            var result = new ServiceResult();
            try
            {

                var map = _pagoRepository.Insert(item);
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

        public ServiceResult ActualizarPago(tbPagos item)
        {
            var result = new ServiceResult();
            try
            {

                var map = _pagoRepository.Update(item);


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
        public ServiceResult EliminarPago(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _pagoRepository.Delete(id);
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
        #endregion

        #region Notificaciones
        public ServiceResult ListarNotificaciones()
        {
            var result = new ServiceResult();
            try
            {
                var list = _notificacionRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult ListarNotificaciones2()
        {
            var result = new ServiceResult();
            try
            {
                var list = _notificacionRepository.List2();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarTiposNotificaciones()
        {
            var result = new ServiceResult();
            try
            {
                var list = _notificacionRepository.ListTipos();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ContarNotificacion()

        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionRepository.Contar();
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult BuscarNotificacion(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarNotificacion(tbNotificaciones item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionRepository.Insert(item);
                if (map.CodeStatus != 0)
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


        public ServiceResult ActualizarNotificacion(tbNotificaciones item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionRepository.Update(item);
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
        public ServiceResult EliminarNotificacion(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionRepository.Delete(id);
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
        #endregion

        #region Notificaciones Alertar Por Usuario
        //public ServiceResult FiltrarAlertas(int id)

        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var map = _notificacionAlertaPorUsuarioRepository.Find(id);
        //        return result.Ok(map);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}


        public ServiceResult InsertarTokens(tbNotificacionesAlertarPorUsuario item)
        {
            var result = new ServiceResult();
            try
            {

                var map = _notificacionAlertaPorUsuarioRepository.InsertTokens(item);

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
        public ServiceResult ListarTokensPorUsuario(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.FindTokens(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListarTokens()

        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.ListTokens();
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FiltrarNotificaciones(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.FindNoti(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult TokenporProyectos(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.TokenProyecto(id);

                if (map != null && map.Any())
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Ok("No se encontraron tokens para el proyecto especificado.");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult tokenadmin()
        {

            var result = new ServiceResult();
            try
            {
                var list = _notificacionAlertaPorUsuarioRepository.tokenadmin();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

            public ServiceResult LeerNotificacionAlertaPorUsuario(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.Leida(id);
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

        public ServiceResult EliminarNotificacionAlertaPorUsuario(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.Delete(id);
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


        public ServiceResult EliminarToken(int id, string token)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.DeleteToken(id, token);
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

        
       public ServiceResult InsertarNotificacionUsuario(tbNotificacionesAlertarPorUsuario item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.Insert(item);
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

        public ServiceResult InsertarNotificacionPorUsuario(tbNotificacionesAlertarPorUsuario item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.InsertNotificacionPorUsuario(item);
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

        public ServiceResult InsertarNotificacionPorUsuario2(tbNotificacionesAlertarPorUsuario item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.InsertNotificacionPorUsuario(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);  // Esto debería marcar el resultado como exitoso
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes incluir más información del error
                return result.Error(ex.Message);
            }
        }


        public ServiceResult InsertarToken(tbNotificacionesAlertarPorUsuario item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _notificacionAlertaPorUsuarioRepository.GuardarToken(item);
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
        ///
        #endregion

        #region Alertas
        public ServiceResult ListarAlertas()

        {
            var result = new ServiceResult();
            try
            {
                var list = _alertaRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarAlerta(int id)


        {
            var result = new ServiceResult();
            try
            {
                var map = _alertaRepository.Find(id);

                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult InsertarAlerta(tbAlertas item)
        {
            var result = new ServiceResult();
            try
            {
                // Llamada al método Insert y captura del resultado
                var map = _alertaRepository.Insert(item);

                // Verificación si la inserción fue exitosa
                if (map.CodeStatus != 0)
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
                // Retorno de un error en caso de excepción
                return result.Error(ex.Message);
            }
        }


        public ServiceResult ActualizarAlerta(tbAlertas item)

        {
            var result = new ServiceResult();
            try
            {
                var map = _alertaRepository.Update(item);

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
        public ServiceResult EliminarAlerta(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _alertaRepository.Delete(id);
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




        #endregion

        #region Actividades

        public ServiceResult ListarActividades()
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarActividadesPorEtapas(int? etap_Id, int? proy_Id)
        
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadRepository.ListarActividadesPorEtapas(etap_Id, proy_Id);
                return result.Ok(list);
            }
            catch (Exception ex) 
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarActividadesPorEtapasFill(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadRepository.ListarActividadesPorEtapasFill(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarCostosActividades(int acti_Id, int unme_Id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _actividadRepository.ListarCostosActividades(acti_Id, unme_Id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult BuscarActividad(int id)

        {
            var result = new ServiceResult();
            try
            {
                var map = _actividadRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarActividad(tbActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _actividadRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ActualizarActividad(tbActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _actividadRepository.Update(item);
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
        public ServiceResult EliminarActividad(int id)//objeto de tipo service result que pide el id de un registro para eliminarlo
        {
            var result = new ServiceResult();//variable de tipo service result que retornaremos mas tarde
            try//manejo de errores try catch
            {
                var map = _actividadRepository.Delete(id);//variable que almacena el resultado que retorna el eliminar del repositorio

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return map.CodeStatus >= 0 ? result.Ok(map) : result.Error(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);//retorna un mensaje de error si hubo algun error
            }
        }


        #endregion

        #region Presupuestos Encabezados
        public ServiceResult ListarPresupuestosEncabezado()
        {
            var result = new ServiceResult();
            try
            {
                var list = _presupuestoencabezadoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult BuscarPresupuestoEncabezado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoencabezadoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarPresupuestoEncabezado(tbPresupuestosEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoencabezadoRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarPresupuestosEncabezado(tbPresupuestosEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoencabezadoRepository.Update(item);
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
        public ServiceResult RechazadoPresupuestosEncabezado(tbPresupuestosEncabezado item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoencabezadoRepository.Rechazado(item);
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
        public ServiceResult AprobadoPresupuestosEncabezado(int? pren_Id, int? proy_Id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoencabezadoRepository.Aprobado(pren_Id, proy_Id);
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

        public ServiceResult EliminarPresupuestoEncabezado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoencabezadoRepository.Delete(id);
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
        #endregion

        #region Insumos Por Actividad
        public ServiceResult ListarInsumosPorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoporactividadRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarPresupuestosInsumosPorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoporactividadRepository.ListarPresupuesto(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult InsertarInsumoPorActividad(tbInsumosPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoporactividadRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ActualizarInsumoPorActividad(tbInsumosPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoporactividadRepository.Update(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarInsumoPorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _insumoporactividadRepository.Delete(id);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
        #region Renta Maquinaria Por Actividad
        public ServiceResult ListarRentaMaquinariasPorActividades(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rentamaquinariaporactividadRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarPresupuestoRentaMaquinariasPorActividades(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rentamaquinariaporactividadRepository.ListarPresupuesto(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult InsertarRentaMaquinariaPorActividad(tbRentaMaquinariasPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _rentamaquinariaporactividadRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ActualizarRentaMaquinariaPorActividad(tbRentaMaquinariasPorActividades item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _rentamaquinariaporactividadRepository.Update(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarRentaMaquinariaPorActividad(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _rentamaquinariaporactividadRepository.Delete(id);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion


        #region Presupuestos Detalles
        public ServiceResult ListarPresupuestosDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _presupuestodetalleRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult InsertarPresupuestoDetalle(tbPresupuestosDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestodetalleRepository.Insert(item);

                return map.CodeStatus > 0 ? result.Ok(map) : result.Conflict();

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarPresupuestosDetalle(tbPresupuestosDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestodetalleRepository.Update(item);
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

        public ServiceResult EliminarPresupuestoDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestodetalleRepository.Delete(id);
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
        #endregion

        #region Presupuestos Por TasasCambio
        public ServiceResult ListarPresupuestosPorTasasCambio(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _presupuestoportasacambioRepository.List(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ActualizarPresupuestoPorTasaCamvbio(tbPresupuestosPorTasasCambio item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoportasacambioRepository.Update(item);
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

        public ServiceResult InsertarPresupuestoPorTasaCambio(tbPresupuestosPorTasasCambio item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoportasacambioRepository.Insert(item);
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
        public ServiceResult EliminarPresupuestoPorTasaCambio(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _presupuestoportasacambioRepository.Delete(id);
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


        #endregion

        #region Incidentes

        public ServiceResult ListarProyectosConIncidentes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _incidenteRepository.ListarProyectosConIncidentes();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        public ServiceResult ListarIncidentes(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _incidenteRepository.Listar(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult ListarIncidentesPorProyecto(int proy_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _incidenteRepository.ListarIncidentesPorProyecto(proy_Id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult IncidentesPorActicvidadPorEtapa(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.FiltrarIncidencias(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarIncidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarIncidente(tbIncidentes item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Insert(item);
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

        public ServiceResult ActualizarIncidente(tbIncidentes item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Update(item);
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

        public ServiceResult EliminarIncidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _incidenteRepository.Delete(id);
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
        #endregion

        #region Insumo Por Actividad
        /// <summary>
        /// Lista los insumos para una actividad específica.
        /// </summary>
        /// <param name="id">ID de la actividad.</param>
        /// <returns>Una lista de insumos.</returns>
        public ServiceResult ListarInsumosPorActividad(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _insumoPorActividadRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Proyecto
        public ServiceResult EliminarProyecto(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var request = _proyectoRepository.Delete(id);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult BuscarProyectoPorNombre(string proy_Nombre)
        {
            var result = new ServiceResult();
            try
            {
                var map = _proyectoRepository.ProyectoBuscarPorNombre(proy_Nombre);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarProyecto(int? id)
        {
            var result = new ServiceResult();

            try
            {
                var actividadporetapa = _proyectoRepository.Find(id);

                return result.Ok(actividadporetapa);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult InsertarProyecto(tbProyectos item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _proyectoRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ProyectoListarActividades(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _proyectoRepository.ProyectoListarActividades(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarProyectos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _proyectoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarProyecto(tbProyectos item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _proyectoRepository.Update(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Renta de Maquinaria Por Actividad
        /// <summary>
        /// Lista las rentas de maquinaria para una actividad específica.
        /// </summary>
        /// <param name="id">ID de la actividad.</param>
        /// <returns>Una lista de rentas de maquinaria.</returns>
        public ServiceResult ListarRentaMaquinariasPorActividad(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rentaMaquinariaPorActividadRepository.List((int)id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Referencias
        public ServiceResult ListarReferencias()
        {
            var result = new ServiceResult();

            try
            {
                var list = _referenciasRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarReferencia(tbReferenciasCeldas item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _referenciasRepository.Eliminar(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarReferencia(tbReferenciasCeldas item)
        {
            var result = new ServiceResult();

            try
            {
                var request = _referenciasRepository.Insert(item);

                return request.CodeStatus > 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex) {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
