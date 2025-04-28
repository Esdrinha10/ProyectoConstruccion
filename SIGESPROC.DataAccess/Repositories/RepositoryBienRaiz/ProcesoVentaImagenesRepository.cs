using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryBienRaiz
{
    public class ProcesoVentaImagenesRepository : IRepository<tbImagenesPorProcesosVentas>
    {
        /// <summary>
        /// Elimina Imagenes por proceso de venta por su ID.
        /// </summary>
        /// <param name="id">El Id de la Imagenes por proceso de ventaa eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@impr_Id", id);

                var response = db.QueryFirstOrDefault(ScriptsDataBase.EliminarImagenesProcesoVenta, parameter, commandType: CommandType.StoredProcedure);

                if (response != null && response.Success == 1)
                {
                    result.Success = true;
                    result.Message = "Eliminación exitosa.";
                }
                else
                {
                    result.Success = false;
                    result.Message = response?.ErrorMessage ?? "Error en la eliminación.";
                }

                return result;
            }
        }
        /// <summary>
        /// Busca y devuelve Imagenes por proceso de venta por su ID.
        /// </summary>
        /// <param name="id">El ID de la Imagenes por proceso de venta a buscar.</param>

        public tbImagenesPorProcesosVentas Find(int? id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserta una nueva Imagenes por proceso de venta en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbImagenes por proceso de ventaes que contiene los datos de la nueva Imagenes por proceso de venta.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>

        public IEnumerable<tbImagenesPorProcesosVentas> Bucardocumentos(int tipo, int id)
        {
            List<tbImagenesPorProcesosVentas> result = new List<tbImagenesPorProcesosVentas>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizbit", tipo);
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                result = db.Query<tbImagenesPorProcesosVentas>(ScriptsDataBase.BuscardocumentosProcesoventa, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Inserta una nueva Imagenes por proceso de venta en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbImagenes por proceso de ventaesPorEtapas que contiene los datos de la nueva Imagenes por proceso de venta.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbImagenesPorProcesosVentas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", item.btrp_Id);
                parameter.Add("@impr_Imagen", item.impr_Imagen);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@impr_FechaCreacion", item.impr_FechaCreacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarImagenesProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de Imagenes por proceso de venta.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbImagenesProcesoVenta que representa las actividades encontradas.</returns>
        public IEnumerable<tbImagenesPorProcesosVentas> List()
        {
            List<tbImagenesPorProcesosVentas> result = new List<tbImagenesPorProcesosVentas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbImagenesPorProcesosVentas>(ScriptsDataBase.ListarImagenesProcesoVenta, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbImagenesPorProcesosVentas> Buscar(int? id)
        {
            List<tbImagenesPorProcesosVentas> result = new List<tbImagenesPorProcesosVentas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", id);
                result = db.Query<tbImagenesPorProcesosVentas>(
                    ScriptsDataBase.ListarImagenesProcesoVenta,
                    parameter, 
                    commandType: CommandType.StoredProcedure
                ).ToList();
                return result;
            }
        }


        /// <summary>
        /// Actualiza los datos de una Imagenes por proceso de ventaexistente.
        /// </summary>
        /// <param name="item">El objeto tbImagenesprocesoventa que contiene los datos actualizados de la actividad.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbImagenesPorProcesosVentas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@impr_Id", item.impr_Id);
                parameter.Add("@btrp_Id", item.btrp_Id);
                parameter.Add("@impr_Imagen", item.impr_Imagen);  // Corregido: btrp_Id a impr_Imagen
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@impr_FechaModificacion", item.impr_FechaModificacion);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarImagenesProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

    }
}
