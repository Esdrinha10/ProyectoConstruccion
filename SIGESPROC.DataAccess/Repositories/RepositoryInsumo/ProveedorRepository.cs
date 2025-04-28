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
    public class ProveedorRepository : IRepository<tbProveedores>
    {
        /// <summary>
        /// Elimina un proveedor específico por su ID.
        /// </summary>
        /// <param name="id">El ID del proveedor a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("prov_Id", id);

                var result = db.QueryFirst<RequestStatus>(
                    ScriptsDataBase.Eliminar_Proveedor,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }


        /// <summary>
        /// Busca y devuelve un proveedor específico por su ID.
        /// </summary>
        /// <param name="id">El ID del proveedor a buscar.</param>
        /// <returns>Un objeto tbProveedores que representa el proveedor encontrado.</returns>
        public tbProveedores Find(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("prov_Id", id);

                var result = db.QueryFirst<tbProveedores>(
                    ScriptsDataBase.Buscar_Proveedor,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }



        /// <summary>
        /// Inserta un nuevo proveedor en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbProveedores que contiene los datos del proveedor a insertar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Insert(tbProveedores item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("prov_Descripcion", item.prov_Descripcion);
                parametro.Add("prov_Correo", item.prov_Correo);
                parametro.Add("prov_InsumoOMaquinariaOEquipoSeguridad", item.prov_InsumoOMaquinariaOEquipoSeguridad);
                parametro.Add("prov_Telefono", item.prov_Telefono);
                parametro.Add("prov_SegundoTelefono", item.prov_SegundoTelefono);
                parametro.Add("ciud_Id", item.ciud_Id);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("prov_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<int>(
                    ScriptsDataBase.Insertar_Proveedor,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = "Comunicarse con un administrador";
                if (result == -2)
                {
                    mensaje = "El correo ya existe.";
                }
                else if (result == -1)
                {
                    mensaje = "El proveedor ya existe.";
                }else {
                    mensaje = "Insertado con Éxito.";
                }


                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }



        /// <summary>
        /// Obtiene una lista de todos los proveedores en la base de datos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbProveedores que representa la lista de proveedores.</returns>
        public IEnumerable<tbProveedores> List()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbProveedores>(
                    ScriptsDataBase.Listar_Proveedores,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }


        /// <summary>
        /// Actualiza un proveedor existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbProveedores que contiene los datos actualizados del proveedor.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Update(tbProveedores item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("prov_Id", item.prov_Id);
                parametro.Add("prov_Descripcion", item.prov_Descripcion); 
                parametro.Add("prov_Correo", item.prov_Correo); 
                parametro.Add("prov_InsumoOMaquinariaOEquipoSeguridad", item.prov_InsumoOMaquinariaOEquipoSeguridad);
                parametro.Add("prov_Telefono", item.prov_Telefono); 
                parametro.Add("prov_SegundoTelefono", item.prov_SegundoTelefono); 
                parametro.Add("ciud_Id", item.ciud_Id);
                parametro.Add("usua_Modificacion", item.usua_Modificacion); 
                parametro.Add("prov_FechaModificacion", DateTime.Now); 

                var result = db.QueryFirst<int>(
                    ScriptsDataBase.Actualizar_Proveedor,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = "Comunicarse con un administrador";
                if (result == -2)
                {
                    mensaje = "El correo ya existe.";
                }
                else if (result == -1)
                {
                    mensaje = "El proveedor ya existe.";
                }
                else
                {
                    mensaje = "Actualizado con Éxito.";
                }

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

    }
}
