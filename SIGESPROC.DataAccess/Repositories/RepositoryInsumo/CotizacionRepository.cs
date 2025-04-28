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
    public class CotizacionRepository : IRepository<tbCotizaciones>
    {
        /// <summary>
        /// Finaliza una cotización específica por su ID utilizando un procedimiento almacenado.
        /// </summary>
        /// <param name="id">ID de la cotización a Finalizar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Finalizar(int? id)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", id);  

                var answer = db.QueryFirst<int>(ScriptsDataBase.FinalizarCotizacion, parameter, commandType: CommandType.StoredProcedure);

                result.CodeStatus = answer;

                return result;
            }
        }

        /// <summary>
        /// Elimina una cotización específica por su ID utilizando un procedimiento almacenado.
        /// </summary>
        /// <param name="id">ID de la cotización a Finalizar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", id);

                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarCotizacion, parameter, commandType: CommandType.StoredProcedure);

                result.CodeStatus = answer;

                return result;
            }
        }



        /// <summary>
        /// Busca y obtiene una cotización específica por su ID desde la base de datos.
        /// </summary>
        /// <param name="id">ID de la cotización a buscar.</param>
        /// <returns>El objeto tbCotizaciones que representa la cotización encontrada.</returns>
        public tbCotizaciones Find(int? id)
        {
            tbCotizaciones result = new tbCotizaciones();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", id);
                result = db.QueryFirst<tbCotizaciones>(ScriptsDataBase.BuscarCotizacion, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


        /// <summary>
        /// Busca y obtiene una lista de artículos relacionados con una cotización específica utilizando el ID del proveedor y el ID de la cotización.
        /// </summary>
        /// <param name="id">ID del proveedor.</param>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa los artículos encontrados.</returns>
        public IEnumerable<tbCotizaciones> BuscarArticulos(int? id, int coti)
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", id);  
                parameter.Add("@coti_Id", coti);

                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarArticulos, parameter, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }



        /// <summary>
        /// Busca y obtiene una lista de artículos relacionados con una cotización específica utilizando el ID de la cotización.
        /// </summary>
        /// <param name="coti">ID de la cotización.</param>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa los artículos encontrados.</returns>
        public IEnumerable<tbCotizaciones> BuscarArticulos(int coti)
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", coti);
                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarArticulosPorCotizacion, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        /// <summary>
        /// Obtiene una lista de cotizaciones asociadas a un proveedor específico desde la base de datos.
        /// </summary>
        /// <param name="id">ID del proveedor cuyas cotizaciones se desean listar.</param>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa la lista de cotizaciones del proveedor.</returns>
        public IEnumerable<tbCotizaciones> ListCotizacionPorProveedor(int id)
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", id);
                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarCotizacionesPorProveedor, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        /// <summary>
        /// Inserta una nueva cotización en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbCotizaciones que contiene los datos de la cotización a insertar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación, incluyendo el id de la cotizacion creada y un mensaje.</returns>
        public virtual RequestStatus Insert(tbCotizaciones item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Agrega los parámetros necesarios para el procedimiento almacenado
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@coti_Fecha", item.coti_Fecha);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@coti_Incluido", item.coti_Incluido);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@coti_CompraDirecta", item.coti_CompraDirecta);
                parameter.Add("@coti_FechaCreacion", DateTime.Now);  // Establece la fecha de creación como el momento actual

                var respuesta = db.QueryFirst<int>(ScriptsDataBase.InsertarCotizacion, parameter, commandType: CommandType.StoredProcedure);

                string mensaje = respuesta > 0 ? "Exito" : "Error";

                return new RequestStatus { CodeStatus = respuesta, MessageStatus = mensaje };
            }
        }


       

        /// <summary>
        /// Obtiene una lista de todas las cotizaciones desde la base de datos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbCotizaciones que representa la lista de cotizaciones.</returns>
        public virtual IEnumerable<tbCotizaciones> List()
        {
            List<tbCotizaciones> result = new List<tbCotizaciones>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCotizaciones>(ScriptsDataBase.ListarCotizaciones, commandType: CommandType.Text).ToList();

                return result;
            }
        }



        /// <summary>
        /// Actualiza una cotización existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbCotizaciones que contiene los datos de la cotización a actualizar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Update(tbCotizaciones item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@coti_Id", item.coti_Id);
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@coti_Fecha", item.coti_Fecha);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@coti_FechaModificacion", DateTime.Now);

                var respuesta = db.QueryFirst<int>(ScriptsDataBase.ActualizarCotizacion, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = respuesta;
                return result;
            }
        }

    }
}