using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryProyecto
{
    public class ActividadPorEtapaRepository
    {
        /// <summary>
        /// Elimina una actividad específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la actividad a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("acet_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Eliminar_ActividadPorEtapa,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Busca y devuelve una actividad específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la actividad a buscar.</param>
        /// <returns>Un objeto tbActividadesPorEtapas que representa la actividad encontrada.</returns>
        public tbActividadesPorEtapas Find(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("acet_Id", id);

                var result = db.QueryFirst<tbActividadesPorEtapas>(ScriptsDataBase.Buscar_ActividadPorEtapa,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Inserta una nueva actividad en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbActividadesPorEtapas que contiene los datos de la nueva actividad.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbActividadesPorEtapas item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
                {
                var parametro = new DynamicParameters();
                parametro.Add("acet_Observacion", item.acet_Observacion);
                parametro.Add("acet_Cantidad", item.acet_Cantidad);
                parametro.Add("empl_Id", item.empl_Id);
                parametro.Add("acet_FechaInicio", item.acet_FechaInicio);
                parametro.Add("acet_FechaFin", item.acet_FechaFin);
                parametro.Add("acet_PrecioManoObraEstimado", item.acet_PrecioManoObraEstimado);
                parametro.Add("acet_PrecioManoObraFinal", item.acet_PrecioManoObraFinal);
                parametro.Add("acti_Id", item.acti_Id);
                parametro.Add("unme_Id", item.unme_Id);
                parametro.Add("etpr_Id", item.etpr_Id);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("acet_FechaCreacion", DateTime.Now);
                parametro.Add("acet_Estado", item.acet_Estado);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Insertar_ActividadPorEtapa,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de actividades asociadas a una etapa específica.
        /// </summary>
        /// <param name="id">El ID de la etapa para la cual se desean listar las actividades.</param>
        /// <returns>Una colección IEnumerable de objetos tbActividadesPorEtapas que representa las actividades encontradas.</returns>
        public virtual IEnumerable<tbActividadesPorEtapas> List(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("etpr_Id", id);

                var result = db.Query<tbActividadesPorEtapas>(ScriptsDataBase.Listar_ActividadesPorEtapa,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public IEnumerable<tbActividadesPorEtapas> ListarActividad()
        {
            List<tbActividadesPorEtapas> result = new List<tbActividadesPorEtapas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbActividadesPorEtapas>(ScriptsDataBase.Listar_ActividadPorEtapa, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbInsumosPorProveedores> ListInsumos(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("acet_Id", id);

                var result = db.Query<tbInsumosPorProveedores>(ScriptsDataBase.Listar_InsumosPorProveedores,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public IEnumerable<tbMaquinariasPorProveedores> ListMaquinarias(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("acet_Id", id);

                var result = db.Query<tbMaquinariasPorProveedores>(ScriptsDataBase.Listar_MaquinariasPorProveedores,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public IEnumerable<tbEquiposSeguridadPorProveedores> ListEquiposSeguridad()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {

                var result = db.Query<tbEquiposSeguridadPorProveedores>(ScriptsDataBase.Listar_EquiposSeguridadPorProveedores,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        /// <summary>
        /// Actualiza los datos de una actividad existente.
        /// </summary>
        /// <param name="item">El objeto tbActividadesPorEtapas que contiene los datos actualizados de la actividad.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbActividadesPorEtapas item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("acet_Id", item.acet_Id);
                parametro.Add("acet_Observacion", item.acet_Observacion);
                parametro.Add("acet_Cantidad", item.acet_Cantidad);
                parametro.Add("espr_Id", item.espr_Id);
                parametro.Add("empl_Id", item.empl_Id);
                parametro.Add("acet_FechaInicio", item.acet_FechaInicio);
                parametro.Add("acet_FechaFin", item.acet_FechaFin);
                parametro.Add("acet_PrecioManoObraEstimado", item.acet_PrecioManoObraEstimado);
                parametro.Add("acet_PrecioManoObraFinal", item.acet_PrecioManoObraFinal);
                parametro.Add("acti_Id", item.acti_Id);
                parametro.Add("unme_Id", item.unme_Id);
                parametro.Add("etpr_Id", item.etpr_Id);
                parametro.Add("usua_Modificacion", item.usua_Modificacion);
                parametro.Add("acet_FechaModificacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Actualizar_ActividadPorEtapa,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Replica las actividades de una etapa en otro proyecto.
        /// </summary>
        /// <param name="item">El objeto tbEtapasPorProyectos que contiene los datos de la etapa a replicar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Replicate(tbEtapasPorProyectos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("etpr_Id", item.etpr_Id);
                parametro.Add("etap_Id", item.etap_Id);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("etpr_FechaCreacion", DateTime.Now);
                parametro.Add("proy_FechaInicio", item.proy_FechaInicio);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Replicar_ActividadesPorEtapa,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        /// <summary>
        /// Autocompleta los datos de una actividad basada en un ID específico.
        /// </summary>
        /// <param name="id">El ID de la actividad a autocompletar.</param>
        /// <returns>Un objeto tbActividadesPorEtapas que representa la actividad autocompletada.</returns>
        public tbActividadesPorEtapas AutoComplete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("acti_Id", id);

                var result = db.QueryFirst<tbActividadesPorEtapas>(ScriptsDataBase.AutoCompletar_ActividadPorEtapa,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
