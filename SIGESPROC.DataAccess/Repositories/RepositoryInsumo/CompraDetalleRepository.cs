using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;

namespace SIGESPROC.DataAccess.Repositories.RepositoryInsumo
{
    /// <summary>
    /// Repositorio para manejar las operaciones CRUD relacionadas con los detalles de compra.
    /// </summary>
    public class CompraDetalleRepository : IRepository<tbComprasDetalle>
    {
        /// <summary>
        /// Elimina un detalle de compra por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra a eliminar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarCompraDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Lista todas las actividades por etapas asociadas a un ID de proyecto específico.
        /// </summary>
        /// <param name="id">ID del proyecto o etapa.</param>
        /// <returns>Una colección de <see cref="tbActividadesPorEtapas"/>.</returns>
        public IEnumerable<tbActividadesPorEtapas> ListarActividadesPorEtapas(int? id)
        {
            List<tbActividadesPorEtapas> result = new List<tbActividadesPorEtapas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@etpr_Id", id);
                result = db.Query<tbActividadesPorEtapas>(ScriptsDataBase.ListarActividadesPorEtapasFill, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista los detalles de compra asociados a un destino de maquinaria específico.
        /// </summary>
        /// <param name="id">ID del destino de maquinaria.</param>
        /// <returns>Una colección de <see cref="tbComprasDetalle"/>.</returns>
        public IEnumerable<tbComprasDetalle> ListPorDetalleCompraDetalleDestinoMaquinaria(int id)
        {
            List<tbComprasDetalle> result = new List<tbComprasDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", id);
                result = db.Query<tbComprasDetalle>(ScriptsDataBase.ListarCompraDetalleDestinoPorProyecto, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Elimina un detalle de compra asociado a un destino específico por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra con destino a eliminar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus DeleteCompraDetalleDestino(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codd_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarCompraDetalleDestino, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Busca un detalle de compra por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra.</param>
        /// <returns>Un objeto <see cref="tbComprasDetalle"/> que contiene el detalle de compra encontrado.</returns>
        public tbComprasDetalle Find(int? id)
        {
            tbComprasDetalle result = new tbComprasDetalle();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", id);
                result = db.QueryFirst<tbComprasDetalle>(ScriptsDataBase.BuscarCompraDetalle, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Busca un detalle de compra asociado a un destino específico por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra con destino.</param>
        /// <returns>Un objeto <see cref="tbComprasDetalle"/> que contiene el detalle de compra con destino encontrado.</returns>
        public tbComprasDetalle FindCompraDetalleDestino(int? id)
        {
            tbComprasDetalle result = new tbComprasDetalle();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codd_Id", id);
                result = db.QueryFirst<tbComprasDetalle>(ScriptsDataBase.BuscarCompraDetalleDestino, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra a insertar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", item.coen_Id);
                parameter.Add("@code_Id", item.code_Id);
                parameter.Add("@codt_cantidad", item.codt_cantidad);
                parameter.Add("@codt_preciocompra", item.codt_preciocompra);
                parameter.Add("@codt_InsumoOMaquinariaOEquipoSeguridad", item.codt_InsumoOMaquinariaOEquipoSeguridad);
                parameter.Add("@codt_Renta", item.codt_Renta);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@codt_FechaCreacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarCompraDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra asociado a un destino en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino a insertar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus InsertCompraDetalleDestino(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", item.coen_Id);
                parameter.Add("@codd_ProyectoOBodega", item.codd_ProyectoOBodega);
                parameter.Add("@codd_Boat_Id", item.codd_Boat_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@codd_FechaCreacion", DateTime.Now);

                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarCompraDetalleDestinoPorDefecto, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = respuesta;
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra asociado a un proyecto específico en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con proyecto a insertar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus InsertCompraDetalleDestinoProyecto(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            try
            {
                using (var db = new SqlConnection(SIGESPROC.ConnectionString))
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@coen_Id", item.coen_Id);
                    parameter.Add("@codm_HorasRenta", item.codm_HorasRenta);
                    parameter.Add("@acet_Id", item.acet_Id);
                    parameter.Add("@usua_Creacion", item.usua_Creacion);
                    parameter.Add("@codm_FechaCreacion", DateTime.Now);

                    var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarCompraDetalleDestinoPorProyectoPorDefecto, parameter, commandType: CommandType.StoredProcedure);
                    result.CodeStatus = respuesta;
                }
            }
            catch (Exception ex)
            {
                result.CodeStatus = -1;
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra con destino exacto en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino exacto a insertar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus InsertCompraDetalleDestinoExacto(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", item.codt_Id);
                parameter.Add("@codd_ProyectoOBodega", item.codd_ProyectoOBodega);
                parameter.Add("@codd_Cantidad", item.codd_Cantidad);
                parameter.Add("@codd_Boat_Id", item.codd_Boat_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@codd_FechaCreacion", DateTime.Now);

                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarCompraDetalleDestino, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = respuesta;
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo detalle de compra asociado a un proyecto específico con datos exactos en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con proyecto exacto a insertar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus InsertCompraDetalleDestinoProyectoExacto(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", item.codt_Id);
                parameter.Add("@codm_HorasRenta", item.codm_HorasRenta);
                parameter.Add("@codm_Cantidad", item.codm_Cantidad);
                parameter.Add("@acet_Id", item.acet_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@codm_FechaCreacion", DateTime.Now);

                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarCompraDetalleDestinoPorProyecto, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = respuesta;
                return result;
            }
        }

        /// <summary>
        /// Elimina un detalle de compra de maquinaria por su ID.
        /// </summary>
        /// <param name="id">ID del detalle de compra de maquinaria a eliminar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus DeleteDestinoMaquinaria(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codm_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarCompraDetalleDestinoMaquinaria, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra con destino por defecto en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino por defecto a actualizar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus UpdateCompraDetalleDestinoDefecto(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", item.coen_Id);
                parameter.Add("@codd_ProyectoOBodega", item.codd_ProyectoOBodega);
                parameter.Add("@codd_Boat_Id", item.codd_Boat_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@codd_FechaModificacion", DateTime.Now);

                var respuesta = db.QueryFirst<int>(ScriptsDataBase.ActualzarCompraDetalleDestinoPorDefecto, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = respuesta;
                return result;
            }
        }

        /// <summary>
        /// Busca todos los detalles de compra asociados a un encabezado de compra específico.
        /// </summary>
        /// <param name="id">ID del encabezado de compra.</param>
        /// <returns>Una colección de <see cref="tbComprasDetalle"/>.</returns>
        public IEnumerable<tbComprasDetalle> BuscardetallesEncabezado(int id)
        {
            List<tbComprasDetalle> result = new List<tbComprasDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", id);
                result = db.Query<tbComprasDetalle>(ScriptsDataBase.BuscarCompraDetalleEncabezado, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista todos los detalles de compra disponibles en la base de datos.
        /// </summary>
        /// <returns>Una colección de <see cref="tbComprasDetalle"/>.</returns>
        public IEnumerable<tbComprasDetalle> List()
        {
            List<tbComprasDetalle> result = new List<tbComprasDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbComprasDetalle>(ScriptsDataBase.ListarComprasDetalle, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista todos los detalles de compra asociados a destinos específicos.
        /// </summary>
        /// <returns>Una colección de <see cref="tbComprasDetalle"/>.</returns>
        public IEnumerable<tbComprasDetalle> ListCompraDetalleDestino()
        {
            List<tbComprasDetalle> result = new List<tbComprasDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbComprasDetalle>(ScriptsDataBase.ListarCompraDetalleDestino, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista los detalles de compra asociados a un destino específico por su ID.
        /// </summary>
        /// <param name="id">ID del destino de compra.</param>
        /// <returns>Una colección de <see cref="tbComprasDetalle"/>.</returns>
        public IEnumerable<tbComprasDetalle> ListPorDetalleCompraDetalleDestino(int id)
        {
            List<tbComprasDetalle> result = new List<tbComprasDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", id);
                result = db.Query<tbComprasDetalle>(ScriptsDataBase.ListarPorDetalleCompraDetalleDestino, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista los detalles de compra asociados a un destino de maquinaria específico por su ID.
        /// </summary>
        /// <param name="id">ID del destino de maquinaria.</param>
        /// <returns>Una colección de <see cref="tbComprasDetalle"/>.</returns>
        public IEnumerable<tbComprasDetalle> ListPorDetalleCompraDetalleDestinoMAquinaria(int id)
        {
            List<tbComprasDetalle> result = new List<tbComprasDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", id);
                result = db.Query<tbComprasDetalle>(ScriptsDataBase.ListarPorDetalleCompraDetalleDestinoMaquinarias, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra a actualizar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codt_Id", item.codt_Id);
                parameter.Add("@coen_Id", item.coen_Id);
                parameter.Add("@code_Id", item.code_Id);
                parameter.Add("@codt_Renta", item.codt_Renta);
                parameter.Add("@codt_cantidad", item.codt_cantidad);
                parameter.Add("@codt_preciocompra", item.codt_preciocompra);
                parameter.Add("@codt_InsumoOMaquinariaOEquipoSeguridad", item.codt_InsumoOMaquinariaOEquipoSeguridad);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@codt_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCompraDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Actualiza un detalle de compra con destino en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasDetalle"/> que contiene los datos del detalle de compra con destino a actualizar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus UpdateCompraDetalleDestino(tbComprasDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@codd_Id", item.codd_Id);
                parameter.Add("@codt_Id", item.codt_Id);
                parameter.Add("@codd_Cantidad", item.codd_Cantidad);
                parameter.Add("@codd_ProyectoOBodega", item.codd_ProyectoOBodega);
                parameter.Add("@codd_Boat_Id", item.codd_Boat_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@codd_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCompraDetalleDestino, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
