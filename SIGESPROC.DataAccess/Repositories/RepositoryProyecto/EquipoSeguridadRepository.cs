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
    public class EquipoSeguridadRepository : IRepository<tbEquiposSeguridad>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@equs_Id", id);

                // Ejecutamos el procedimiento almacenado "Eliminar_EquipoDeSeguridad" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEquipoSeguridad, parameter, commandType: CommandType.StoredProcedure);

                return ansewer;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public RequestStatus DeletePorProveedor(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@eqpp_Id", id);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.EliminarEquipoSeguridadPorProveedor, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }

        public tbEquiposSeguridad Find(int? id)
        {
            tbEquiposSeguridad result = new tbEquiposSeguridad();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@equs_Id", id);

                // Ejecutamos el procedimiento almacenado "Buscar_EquipoDeSeguridad" y obtenemos el primer resultado como Entitie
                result = db.QueryFirst<tbEquiposSeguridad>(ScriptsDataBase.BuscarEquipoSeguridad, parameter, commandType: CommandType.StoredProcedure);
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public IEnumerable<tbEquiposSeguridad> Buscar(int prov)
        {
            List<tbEquiposSeguridad> result = new List<tbEquiposSeguridad>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@prov_Id", prov);
                result = db.Query<tbEquiposSeguridad>(ScriptsDataBase.BuscarEquipoSeguridadPorProveedores, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public virtual RequestStatus Insert(tbEquiposSeguridad item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@equs_Nombre", item.equs_Nombre);
                parameter.Add("@equs_Descripcion", item.equs_Descripcion);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@equs_FechaCreacion", item.equs_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_EquipoDeSeguridad" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEquipoSeguridad, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                string mensaje = ansewer > 0 ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = ansewer, MessageStatus = mensaje };
            }
        }


        public virtual RequestStatus InsertPorProveedor(tbEquiposSeguridad item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@equs_Id", item.equs_Id);
                parameter.Add("@prov_Id", item.prov_Id);
                parameter.Add("@eqpp_PrecioCompra", item.eqpp_PrecioCompra);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@eqpp_FechaCreacion", item.equs_FechaCreacion);

                // Ejecutamos el procedimiento almacenado "Insertar_EquipoDeSeguridad" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEquipoSeguridadPorProveedor, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }
        public IEnumerable<tbEquiposSeguridad> List()
        {
            List<tbEquiposSeguridad> result = new List<tbEquiposSeguridad>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                // Ejecutamos el procedimiento almacenado "Listar_EquiposDeSeguridad" y obtenemos el resultado como IEnumerable
                result = db.Query<tbEquiposSeguridad>(ScriptsDataBase.ListarEquiposSeguridad, commandType: CommandType.Text).ToList();
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }

        public virtual RequestStatus Update(tbEquiposSeguridad item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))// Usamos una conexión a la base de datos SQL
            {
                var parameter = new DynamicParameters();// Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                parameter.Add("@equs_Id", item.equs_Id);
                parameter.Add("@equs_Nombre", item.equs_Nombre);
                parameter.Add("@equs_Descripcion", item.equs_Descripcion);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@equs_FechaModificacion", item.equs_FechaModificacion);

                // Ejecutamos el procedimiento almacenado "Actualizar_EquiposDeSeguridad" y obtenemos el primer resultado como RequestStatus
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEquipoSeguridad, parameter, commandType: CommandType.StoredProcedure);
                /*Agregar msj de exito*/
                result.CodeStatus = ansewer;
                return result;// Devolvemos el resultado de la ejecución del procedimiento almacenado
            }
        }



        //listado equipos por bodega
        public IEnumerable<tbEquiposSeguridad> ListPorBodega(int? id)
        {
            List<tbEquiposSeguridad> result = new List<tbEquiposSeguridad>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@bode_Id", id);
                result = db.Query<tbEquiposSeguridad>(ScriptsDataBase.ListarEquiposSeguridadPorProveedorFiltradoPorBodega, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        //listado equipos por proveedor
        public IEnumerable<tbEquiposSeguridad> ListInsumosPorProveedor()
        {
            List<tbEquiposSeguridad> result = new List<tbEquiposSeguridad>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbEquiposSeguridad>(ScriptsDataBase.ListarEquiposSeguridadPorProveedor, commandType: CommandType.Text).ToList();
                return result;
            }
        }
    }
}
