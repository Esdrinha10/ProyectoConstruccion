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
    public class ProcesoVentaRepository : IRepository<tbProcesosVentas>
    {
        // Método para eliminar un proceso de venta por su ID.
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", id);

                // Ejecución del procedimiento almacenado para eliminar el proceso de venta.
                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarProcesoVenta, parameter, commandType: CommandType.StoredProcedure);

                // Evaluación de la respuesta del procedimiento almacenado.
                if (answer == 1)
                {
                    result.Success = true;
                    result.Message = "Eliminación exitosa.";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error en la eliminación.";
                }

                return result;
            }
        }

        // Método para encontrar un proceso de venta por su ID.
        public tbProcesosVentas Find(int? id)
        {
            tbProcesosVentas result = new tbProcesosVentas();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", id);

                // Ejecución del procedimiento almacenado para buscar el proceso de venta.
                result = db.QueryFirst<tbProcesosVentas>(ScriptsDataBase.BuscarProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        // Método para buscar procesos de venta en base a varios criterios.
        public IEnumerable<tbProcesosVentas> buscar(int? id, int? tipo, int? id2)
        {
            List<tbProcesosVentas> result = new List<tbProcesosVentas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", id);
                parameter.Add("@btrp_Terreno_O_BienRaizId", tipo);
                parameter.Add("@btrp_BienoterrenoId", id2);

                // Ejecución del procedimiento almacenado para buscar procesos de venta.
                result = db.Query<tbProcesosVentas>(ScriptsDataBase.BuscarProcesoVenta, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbProcesosVentas> buscarcliente(int? id)
        {
            List<tbProcesosVentas> result = new List<tbProcesosVentas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", id);

                // Ejecución del procedimiento almacenado para buscar procesos de venta.
                result = db.Query<tbProcesosVentas>(ScriptsDataBase.BuscarClienteVendido, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        // Método para insertar un nuevo proceso de venta en la base de datos.
        public virtual RequestStatus Insert(tbProcesosVentas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_PrecioVenta_Inicio", item.btrp_PrecioVenta_Inicio);
                parameter.Add("@btrp_FechaPuestaVenta", item.btrp_FechaPuestaVenta);
                parameter.Add("@agen_Id", item.agen_Id);
                parameter.Add("@btrp_Terreno_O_BienRaizId", item.btrp_Terreno_O_BienRaizId);
                parameter.Add("@btrp_BienoterrenoId", item.btrp_BienoterrenoId);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@btrp_FechaCreacion", item.btrp_FechaCreacion);

                // Ejecución del procedimiento almacenado para insertar el proceso de venta.
                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        // Método para listar todos los procesos de venta.
        public IEnumerable<tbProcesosVentas> List()
        {
            List<tbProcesosVentas> result = new List<tbProcesosVentas>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecución del procedimiento almacenado para listar todos los procesos de venta.
                result = db.Query<tbProcesosVentas>(ScriptsDataBase.ListarProcesosVenta, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        // Método para actualizar un proceso de venta existente.
        public virtual RequestStatus Update(tbProcesosVentas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", item.btrp_Id);
                parameter.Add("@btrp_PrecioVenta_Inicio", item.btrp_PrecioVenta_Inicio);
                parameter.Add("@btrp_FechaPuestaVenta", item.btrp_FechaPuestaVenta);
                parameter.Add("@agen_Id", item.agen_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@btrp_FechaModificacion", item.btrp_FechaModificacion);

                // Ejecución del procedimiento almacenado para actualizar el proceso de venta.
                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        // Método para marcar un proceso de venta como vendido.
        public RequestStatus Vendido(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", id);

                // Ejecución del procedimiento almacenado para marcar el proceso de venta como vendido.
                var answer = db.QueryFirst<int>(ScriptsDataBase.VendidoProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        // Método para actualizar el proceso de venta con detalles de la venta final.
        public RequestStatus venderUpdate(tbProcesosVentas item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Definición de los parámetros para el procedimiento almacenado.
                var parameter = new DynamicParameters();
                parameter.Add("@btrp_Id", item.btrp_Id);
                parameter.Add("@btrp_PrecioVenta_Final", item.btrp_PrecioVenta_Final);
                parameter.Add("@btrp_FechaVendida", item.btrp_FechaVendida);
                parameter.Add("@clie_Id", item.clie_Id);

                // Ejecución del procedimiento almacenado para actualizar el proceso de venta con detalles de la venta final.
                var answer = db.QueryFirst<int>(ScriptsDataBase.VenderProcesoVenta, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }
    }
}
