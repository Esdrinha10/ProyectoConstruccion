using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using SIGESPROC.DataAccess.Context;

namespace SIGESPROC.DataAccess.Repositories.RepositoryFlete
{
    public class FleteDetalleRepository : IRepository<tbFletesDetalle>
    {
        // Método para eliminar un detalle de flete por su ID
        public RequestStatus Delete(int? flcc_Id)
        {
            string sql = ScriptsDataBase.EliminarFleteDetalle;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@flde_Id", flcc_Id); // Parámetro para el ID del detalle de flete

                // Ejecuta el procedimiento almacenado y obtiene el resultado
                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error"; // Mensaje basado en el resultado
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje }; // Retorna el estado de la operación
            }
        }

        // Método para insertar un nuevo detalle de flete
        public RequestStatus Insert(tbFletesDetalle item)
        {
            string sql = ScriptsDataBase.InsertarFleteDetalle;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                // Agrega parámetros al comando SQL
                parametro.Add("@flde_Cantidad", item.flde_Cantidad);
                parametro.Add("@flen_Id", item.flen_Id);
                parametro.Add("@inpp_Id", item.inpp_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@flde_FechaCreacion", item.flde_FechaCreacion);
                parametro.Add("@flde_TipodeCarga", item.flde_TipodeCarga);

                // Ejecuta el procedimiento almacenado y obtiene el resultado
                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : result == 2 ? "El registro ya existe y está activo" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje }; // Retorna el estado de la operación
            }
        }

        // Método para listar todos los detalles de flete (aún no implementado)
        public IEnumerable<tbFletesDetalle> List()
        {
            throw new NotImplementedException();
        }

        // Método para listar detalles de flete por ID de flete
        public tbFletesDetalle List(int? id)
        {
            string sql = ScriptsDataBase.ListarFleteDetalle;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@flen_Id", id); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene un solo registro o null
                var result = db.QuerySingleOrDefault<tbFletesDetalle>(sql, parametro, commandType: CommandType.StoredProcedure);
                return result; // Retorna el resultado
            }
        }

        // Método para actualizar un detalle de flete
        public RequestStatus Update(tbFletesDetalle item)
        {
            string sql = ScriptsDataBase.ActualizarFleteDetalle;

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                // Agrega parámetros al comando SQL
                parametro.Add("@flde_Id", item.flde_Id);
                parametro.Add("@flde_Cantidad", item.flde_Cantidad);
                parametro.Add("@flen_Id", item.flen_Id);
                parametro.Add("@usua_Modificacion", item.usua_Modificacion);
                parametro.Add("@flde_FechaModificacion", item.flde_FechaModificacion);
                parametro.Add("@inpp_Id", item.inpp_Id);
                parametro.Add("@flde_llegada", item.flde_llegada);

                // Ejecuta el procedimiento almacenado y obtiene el resultado
                var result = db.ExecuteScalar<int>(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = result == 1 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje }; // Retorna el estado de la operación
            }
        }

        // Método para buscar detalles de flete por ID de flete
        public IEnumerable<tbFletesDetalle> Find(int? id)
        {
            List<tbFletesDetalle> result = new List<tbFletesDetalle>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@flen_Id", id); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<tbFletesDetalle>(ScriptsDataBase.ListarFleteDetalle, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }


        // Método para buscar detalles de flete por ID de flete
        public IEnumerable<tbFletesDetalle> FindDetalle(int? id)
        {
            List<tbFletesDetalle> result = new List<tbFletesDetalle>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@flen_Id", id); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<tbFletesDetalle>(ScriptsDataBase.ListarFleteDetalles, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }

        // Método no implementado para buscar un detalle de flete por su ID
        tbFletesDetalle IRepository<tbFletesDetalle>.Find(int? id)
        {
            throw new NotImplementedException();
        }


        //listado de insumos por actividad por etapa
        public IEnumerable<tbInsumosPorActividades> FindInsumoPorActividadEtapa(int? id)
        {
            List<tbInsumosPorActividades> result = new List<tbInsumosPorActividades>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.Query<tbInsumosPorActividades>(ScriptsDataBase.ListarInsumoPorActividadEtapaFlitrado, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        //listado de equipos de seguridad por actividad por etapa
        public IEnumerable<tbInsumosPorActividades> FindEquipoPorActividadEtapa(int? id)
        {
            List<tbInsumosPorActividades> result = new List<tbInsumosPorActividades>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@acet_Id", id);
                result = db.Query<tbInsumosPorActividades>(ScriptsDataBase.ListarquiposPorActividadEtapa, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbInsumosPorActividades> ListInsumoPorActividadEtapa()
        {
            List<tbInsumosPorActividades> result = new List<tbInsumosPorActividades>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbInsumosPorActividades>(ScriptsDataBase.ListarInsumoPorActividadEtapa, commandType: CommandType.Text).ToList();
                return result;
            }
        }
    }
}