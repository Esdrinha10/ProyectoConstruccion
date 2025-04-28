using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGESPROC.Common.Models.ModelsProyecto;

namespace SIGESPROC.DataAccess.Repositories.RepositoryProyecto
{
    public class ArchivoAdjuntoRepository : IRepository<tbImagenesPorGestionesAdicionales>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Imge_Id", id);

                var result = db.QueryFirst<int>(ScriptsDataBase.Eliminar_ImagenesPorGestionAdicional,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : result == 0 ? "Id no encontrado" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbImagenesPorGestionesAdicionales> List1(int id)
        {
            List<tbImagenesPorGestionesAdicionales> result = new List<tbImagenesPorGestionesAdicionales>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@adic_Id", id);

                result = db.Query<tbImagenesPorGestionesAdicionales>(ScriptsDataBase.listar_ImagenesPorGestionAdicional, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public tbImagenesPorGestionesAdicionales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbImagenesPorGestionesAdicionales item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Imge_Imagen", item.Imge_Imagen);
                parametro.Add("@adic_Id", item.adic_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@Imge_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<int>(ScriptsDataBase.Insertar_ImagenesPorGestionAdicional,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbImagenesPorGestionesAdicionales> List()
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Update(tbImagenesPorGestionesAdicionales item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Imge_Id", item.Imge_Imagen);
                parametro.Add("@Imge_Imagen", item.Imge_Imagen);
                parametro.Add("@adic_Id", item.adic_Id);
                parametro.Add("@usua_Creacion", item.usua_Creacion);
                parametro.Add("@Imge_FechaModificacion", DateTime.Now);

                var result = db.QueryFirst<int>(ScriptsDataBase.Actualizar_ImagenesPorGestionAdicional,
                    parametro,
                     commandType: CommandType.StoredProcedure
                    );

                string mensaje = result > 0 ? "Exito" : result == 0 ? "Id no encontrado" : "Error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }
    }
}
