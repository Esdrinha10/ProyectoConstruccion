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
    public class ActividadRepository : IRepository<tbActividades>
    {
        public RequestStatus Delete(int? id)//objeto de tipo RequestStatus que pide un id de parametro para eliminar un registro
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@acti_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_Etapas" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarActividad, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }

        public tbActividades Find(int? id)//objeto de tipo tbActividades que pide un id como parametro para buscar los campos de ese registro
        {
            tbActividades result = new tbActividades();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@acti_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_Actividad" y obtenemos el primer resultado como tbActividades
                result = db.QueryFirst<tbActividades>(ScriptsDataBase.BuscarActividad, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbActividades item)//objeto de tipo RequestStatus que pide como parametro el entitie de la tabla
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@acti_Descripcion", item.acti_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@acti_FechaCreacion", item.acti_FechaCreacion);


                // Ejecutamos el procedimiento almacenado "Insertar_Actividad" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarActividad, parameter, commandType: CommandType.StoredProcedure);

                string mensaje = ansewer > 0 ? "Insertado con Éxito" : "Ese registro ya existe";

                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbActividades> List()//objeto de tipo IEnumerable que sirve para listar los registros de la tabla
        {
            List<tbActividades> result = new List<tbActividades>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_Actividades" y obtenemos el resultado como List<tbActividades>
                result = db.Query<tbActividades>(ScriptsDataBase.ListarActividades, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        public IEnumerable<tbActividadesPorEtapas> ListarActividadesPorEtapas(int? etap_Id, int? proy_Id)//objeto de tipo IEnumerable que sirve para listar las actividades que tiene esa etapa y pide un id de parametro
        {
            List<tbActividadesPorEtapas> result = new List<tbActividadesPorEtapas>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@etap_Id", etap_Id);
                parameter.Add("@proy_Id", proy_Id);

                // Ejecutamos el procedimiento almacenado "Listar_Actividades_por_Etapa" y obtenemos el resultado como IEnumerable<tbActividadesPorEtapas>
                result = db.Query<tbActividadesPorEtapas>(ScriptsDataBase.ListarActividadesPorEtapas, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbActividadesPorEtapas> ListarActividadesPorEtapasFill(int? id)//objeto de tipo IEnumerable que lista la tabla ActividadesPorEtapa y pide un id de parametro 
        {
            List<tbActividadesPorEtapas> result = new List<tbActividadesPorEtapas>();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@etpr_Id", id);

                // Ejecutamos el procedimiento almacenado "Listado_ActvidadesPorEtapa" y obtenemos el resultado como IEnumerable<tbActividadesPorEtapas>
                result = db.Query<tbActividadesPorEtapas>(ScriptsDataBase.ListarActividadesPorEtapasFiltrado, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;

            }
        }

        public tbCostoPorActividad ListarCostosActividades(int? acti_Id, int? unme_Id)//objeto de tipo tbCostoPorActividad que pide como parametro el id de la actividad y la unidad de medida
        {
            tbCostoPorActividad result = new tbCostoPorActividad();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@acti_Id", acti_Id);
                parameter.Add("@unme_Id", unme_Id);

                // Ejecutamos el procedimiento almacenado "Listar Costos Por Etapa" y obtenemos el primer resultado como tbCostoPorActividad
                result = db.QueryFirst<tbCostoPorActividad>(ScriptsDataBase.ListarCostosActividades, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Update(tbActividades item)//objeto de tipo RequestStatus de actualizar que pide como parametro el entitie de la tabla actividades
        {
            RequestStatus result = new RequestStatus();//variable que usamos para almacenar y devolver el resultado del procedimiento almacenado
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@acti_Id", item.acti_Id);
                parameter.Add("@acti_Descripcion", item.acti_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@acti_FechaModificacion", item.acti_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_Actividad" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarActividad, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
    }
}
