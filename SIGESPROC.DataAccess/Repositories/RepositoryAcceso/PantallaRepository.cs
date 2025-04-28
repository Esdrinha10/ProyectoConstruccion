using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryAcceso
{
    public class PantallaRepository : IRepository<tbPantallas>
    {
        public virtual RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("pant_Id", id);

                var result = db.QueryFirst<int>(ScriptsDataBase.Eliminar_Pantalla,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Operación completada exitosamente" : result == 0 ? "El registro no se pudo encontrar" : "Hubo un error en el servidor";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public tbPantallas Find(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("pant_Id", id);

                var result = db.QueryFirst<tbPantallas>(ScriptsDataBase.Buscar_Pantalla,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );
                
                return result;
            }
        }

        public virtual RequestStatus Insert(tbPantallas item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("pant_Descripcion", item.pant_Descripcion);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("pant_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<int>(ScriptsDataBase.Insertar_Pantalla,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Operación completada exitosamente" : "Hubo un error en el servidor";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public virtual IEnumerable<tbPantallas> List()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbPantallas>(ScriptsDataBase.Listar_Pantallas,
                     commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public IEnumerable<tbPantallas> ListPorRol()
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var result = db.Query<tbPantallas>(ScriptsDataBase.Listar_PantallasPorRol,
                     commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public virtual RequestStatus Update(tbPantallas item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("pant_Id", item.pant_Id);
                parametro.Add("pant_Descripcion", item.pant_Descripcion);
                parametro.Add("usua_Modificacion", item.usua_Modificacion);
                parametro.Add("pant_FechaModificacion", DateTime.Now);

                var result = db.QueryFirst<int>(ScriptsDataBase.Actualizar_Pantalla,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Operación completada exitosamente" : result == 0 ? "El registro no se pudo encontrar" : "Hubo un error en el servidor";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
