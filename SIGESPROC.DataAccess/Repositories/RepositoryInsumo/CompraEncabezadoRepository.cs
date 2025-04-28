using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryInsumo
{
    /// <summary>
    /// Repositorio para manejar las operaciones CRUD relacionadas con los encabezados de compra.
    /// </summary>
    public class CompraEncabezadoRepository : IRepository<tbComprasEncabezado>
    {
        /// <summary>
        /// Elimina un encabezado de compra por su ID.
        /// </summary>
        /// <param name="id">ID del encabezado de compra a eliminar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus Delete(string? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarCompraEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Busca un encabezado de compra por su ID.
        /// </summary>
        /// <param name="id">ID del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="tbComprasEncabezado"/> que contiene el encabezado de compra encontrado.</returns>
        public tbComprasEncabezado Find(int? id)
        {
            tbComprasEncabezado result = new tbComprasEncabezado();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", id);
                result = db.QueryFirst<tbComprasEncabezado>(ScriptsDataBase.BuscarCompraEncabezado, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo encabezado de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasEncabezado"/> que contiene los datos del encabezado de compra a insertar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbComprasEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@meto_Id", item.meto_Id);
                parameter.Add("@coen_numeroCompra", item.coen_numeroCompra);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@coen_FechaCreacion", DateTime.Now);
                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarCompraEncabezado, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = respuesta > 0 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = respuesta, MessageStatus = mensaje };
            }
        }

        /// <summary>
        /// Lista todos los encabezados de compra disponibles en la base de datos.
        /// </summary>
        /// <returns>Una colección de <see cref="tbComprasEncabezado"/>.</returns>
        public IEnumerable<tbComprasEncabezado> List()
        {
            List<tbComprasEncabezado> result = new List<tbComprasEncabezado>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbComprasEncabezado>(ScriptsDataBase.ListarCompraEncabezado, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Lista todos los métodos de pago disponibles en la base de datos.
        /// </summary>
        /// <returns>Una colección de <see cref="tbComprasEncabezado"/> que contiene los métodos de pago.</returns>
        public IEnumerable<tbComprasEncabezado> ListMeto()
        {
            List<tbComprasEncabezado> result = new List<tbComprasEncabezado>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbComprasEncabezado>(ScriptsDataBase.ListarMetodosdPago, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Busca encabezados de compra en un rango de fechas específico.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Una colección de <see cref="tbComprasEncabezado"/> que contiene los encabezados de compra encontrados.</returns>
        public IEnumerable<tbComprasEncabezado> FindFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            IEnumerable<tbComprasEncabezado> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@fechaInicio", fechaInicio);
                parameters.Add("@fechaFin", fechaFin);

                result = db.Query<tbComprasEncabezado>(ScriptsDataBase.ListarCotizacionesporFechas, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Busca encabezados de compra por el ID de cotización.
        /// </summary>
        /// <param name="coti_Id">ID de la cotización.</param>
        /// <returns>Una colección de <see cref="tbComprasEncabezado"/> que contiene los encabezados de compra asociados a la cotización.</returns>
        public IEnumerable<tbComprasEncabezado> FindByCotizacionId(int coti_Id)
        {
            IEnumerable<tbComprasEncabezado> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@coti_Id", coti_Id);

                result = db.Query<tbComprasEncabezado>(ScriptsDataBase.ListarCotizacionesPorCotizacion, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Busca los detalles de una cotización por su ID de encabezado de compra.
        /// </summary>
        /// <param name="coen_Id">ID del encabezado de compra.</param>
        /// <returns>Una colección de <see cref="tbComprasEncabezado"/> que contiene los detalles de la cotización.</returns>
        public IEnumerable<tbComprasEncabezado> FindByCotizacionCompraDetalleId(string coen_Id)
        {
            IEnumerable<tbComprasEncabezado> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@coen_Id", coen_Id);

                result = db.Query<tbComprasEncabezado>(ScriptsDataBase.ListarCompraDetallesPorCotizaciones, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Verifica si el número de compra es único para una cotización específica.
        /// </summary>
        /// <param name="coen_numeroCompra">Número de compra a verificar.</param>
        /// <param name="prov_Id">ID de la cotización asociada.</param>
        /// <returns>1 si es único, 0 si está duplicado.</returns>
        public int VerificarNumeroCompraUnico(string coen_numeroCompra, int prov_Id)
        {
            // Remover cualquier coma al final de la cadena si existe
            if (coen_numeroCompra.EndsWith(","))
            {
                coen_numeroCompra = coen_numeroCompra.TrimEnd(',');
            }

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@coen_numeroCompra", coen_numeroCompra);
                parameters.Add("@prov_Id", prov_Id);

                // El resultado será 0 o 1 según el procedimiento almacenado
                return db.QueryFirst<int>(ScriptsDataBase.VerificarNumeroCompraUnico, parameters, commandType: CommandType.StoredProcedure);
            }
        }



        /// <summary>
        /// Actualiza un encabezado de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasEncabezado"/> que contiene los datos del encabezado de compra a actualizar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus Update(tbComprasEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", item.coen_Id);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@meto_Id", item.meto_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@coen_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCompraEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Actualiza un encabezado de compra en la base de datos.
        /// </summary>
        /// <param name="item">Objeto <see cref="tbComprasEncabezado"/> que contiene los datos del encabezado de compra a actualizar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus UpdateCompra(tbComprasEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", item.coen_Id_numeroCompra);
                parameter.Add("@coen_numeroCompra", item.coen_numeroCompra);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCompraEncabezadoNumeroCompra, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Elimina una compra completa por su ID de encabezado de compra.
        /// </summary>
        /// <param name="coen_Id">ID del encabezado de compra.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el resultado de la operación.</returns>
        public RequestStatus EliminarCompra(string coen_Id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coen_Id", coen_Id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarCompra, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
