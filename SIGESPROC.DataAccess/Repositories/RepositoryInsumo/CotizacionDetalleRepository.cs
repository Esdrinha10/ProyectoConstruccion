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
    public class CotizacionDetalleRepository : IRepository<tbCotizacionesDetalle>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@code_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarCotizacionDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Elimina un detalle específico de una cotización en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbCotizacionesDetalle que contiene los datos del detalle de cotización a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación, incluyendo el código de estado.</returns>
        public RequestStatus Delete(tbCotizacionesDetalle item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Agrega los parámetros necesarios para el procedimiento almacenado
                parameter.Add("@coti_Id", item.coti_Id);
                parameter.Add("@cime_Id", item.cime_Id);
                parameter.Add("@cime_InsumoOMaquinariaOEquipoSeguridad", item.cime_InsumoOMaquinariaOEquipoSeguridad);

                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarCotizacionDetalle, parameter, commandType: CommandType.StoredProcedure);

                result.CodeStatus = answer;

                return result;
            }
        }


        public tbCotizacionesDetalle Find(int? id)
        {
            tbCotizacionesDetalle result = new tbCotizacionesDetalle();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@code_Id", id);
                result = db.QueryFirst<tbCotizacionesDetalle>(ScriptsDataBase.BuscarCotizacionDetalle, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Inserta un nuevo detalle de cotización en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbCotizacionesDetalle que contiene los datos del detalle de cotización a insertar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación, incluyendo el código de estado y un mensaje en caso de éxito o error.</returns>
        public RequestStatus Insert(tbCotizacionesDetalle item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Agrega los parámetros necesarios para el procedimiento almacenado
                parameter.Add("@code_Cantidad", item.code_Cantidad);
                parameter.Add("@code_PrecioCompra", item.code_PrecioCompra);
                parameter.Add("@coti_Id", item.coti_Id);
                parameter.Add("@cime_Id", item.cime_Id);
                parameter.Add("@code_Renta", item.code_Renta);
                parameter.Add("@cime_InsumoOMaquinariaOEquipoSeguridad", item.cime_InsumoOMaquinariaOEquipoSeguridad);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@code_FechaCreacion", item.code_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarCotizacionDetalle, parameter, commandType: CommandType.StoredProcedure);

                string mensaje = answer > 0 ? "Exito" : "Error";

                return new RequestStatus { CodeStatus = answer, MessageStatus = mensaje };
            }
        }



        public IEnumerable<tbCotizacionesDetalle> List()
        {
            List<tbCotizacionesDetalle> result = new List<tbCotizacionesDetalle>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbCotizacionesDetalle>(ScriptsDataBase.ListarCotizacionesDetalles, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public virtual RequestStatus Update(tbCotizacionesDetalle item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@code_Id", item.code_Id);
                parameter.Add("@code_Cantidad", item.code_Cantidad);
                parameter.Add("@code_PrecioCompra", item.code_PrecioCompra);
                parameter.Add("@coti_Id", item.coti_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@code_FechaModificacion", item.code_FechaModificacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarCotizacionDetalle, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
