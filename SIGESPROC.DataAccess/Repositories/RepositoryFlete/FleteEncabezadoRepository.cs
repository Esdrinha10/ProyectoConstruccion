using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryFlete
{
    public class FleteEncabezadoRepository : IRepository<tbFletesEncabezado>
    {
        // Método para eliminar un registro de flete por su ID
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@flen_Id", id); // Agrega el ID del flete como parámetro

                // Ejecuta el procedimiento almacenado y obtiene el resultado como un entero
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarFlete, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer; // Asigna el código de estado al resultado
                return result; // Retorna el resultado
            }
        }

        // Método para buscar un registro de flete por su ID
        public tbFletesEncabezado Find(int? id)
        {
            tbFletesEncabezado result = new tbFletesEncabezado();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@etap_Id", id); // Agrega el ID del flete como parámetro

                // Ejecuta el procedimiento almacenado y obtiene el primer registro encontrado
                result = db.QueryFirst<tbFletesEncabezado>(ScriptsDataBase.BuscarFlete, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna el resultado
            }
        }

        // Método para insertar un nuevo registro de flete
        public virtual RequestStatus Insert(tbFletesEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                // Agrega parámetros al comando SQL
                parameter.Add("@flen_FechaHoraSalida", item.flen_FechaHoraSalida);
                parameter.Add("@flen_FechaHoraEstablecidaDeLlegada", item.flen_FechaHoraEstablecidaDeLlegada);
                parameter.Add("@emtr_Id", item.emtr_Id);
                parameter.Add("@emss_Id", item.emss_Id);
                parameter.Add("@emsl_Id", item.emsl_Id);
                parameter.Add("@boas_Id", item.boas_Id);
                parameter.Add("@flen_DestinoProyecto", item.flen_DestinoProyecto);
                parameter.Add("@flen_SalidaProyecto", item.flen_SalidaProyecto);

                parameter.Add("@boat_Id", item.boat_Id);
                parameter.Add("@flen_Estado", item.flen_Estado);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@flen_FechaCreacion", item.flen_FechaCreacion);

                // Ejecuta el procedimiento almacenado y obtiene el resultado como un entero
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarFlete, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer; // Asigna el código de estado al resultado
                return result; // Retorna el resultado
            }
        }

        // Método para listar todos los registros de fletes
        public virtual IEnumerable<tbFletesEncabezado> List()
        {
            List<tbFletesEncabezado> result = new List<tbFletesEncabezado>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<tbFletesEncabezado>(ScriptsDataBase.ListarFletes, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        // Método para actualizar un registro de flete existente
        public virtual RequestStatus Update(tbFletesEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                // Agrega parámetros al comando SQL
                parameter.Add("@flen_Id", item.flen_Id);
                parameter.Add("@flen_FechaHoraSalida", item.flen_FechaHoraSalida);
                parameter.Add("@flen_FechaHoraEstablecidaDeLlegada", item.flen_FechaHoraEstablecidaDeLlegada);
                parameter.Add("@flen_FechaHoraLlegada", item.flen_FechaHoraLlegada);
                parameter.Add("@emtr_Id", item.emtr_Id);
                parameter.Add("@emss_Id", item.emss_Id);
                parameter.Add("@emsl_Id", item.emsl_Id);
                parameter.Add("@boas_Id", item.boas_Id);
                parameter.Add("@flen_DestinoProyecto", item.flen_DestinoProyecto);
                parameter.Add("@flen_SalidaProyecto", item.flen_SalidaProyecto);
                parameter.Add("@flen_ComprobanteLLegada", item.flen_ComprobanteLLegada);
                parameter.Add("@flen_Estado", item.flen_Estado);
                parameter.Add("@boat_Id", item.boat_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@flen_FechaModificacion", item.flen_FechaModificacion);
                // Ejecuta el procedimiento almacenado y obtiene el resultado como un entero
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarFlete, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer; // Asigna el código de estado al resultado
                return result; // Retorna el resultado
            }
        }
    }
}
