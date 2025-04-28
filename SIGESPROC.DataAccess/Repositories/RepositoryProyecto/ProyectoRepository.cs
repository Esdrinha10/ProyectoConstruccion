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
    public class ProyectoRepository : IRepository<tbProyectos>
    {
        public RequestStatus Delete(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("proy_Id", id);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Eliminar_Proyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public tbProyectos Find(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("proy_Id", id);

                var result = db.QueryFirst<tbProyectos>(ScriptsDataBase.Buscar_Proyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public tbProyectos ProyectoBuscarPorNombre(string? proy_Nombre)
        {
            tbProyectos result = new tbProyectos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@proy_Nombre", proy_Nombre);
                result = db.QueryFirst<tbProyectos>(ScriptsDataBase.BuscarProyectoPorNombre, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public virtual RequestStatus Insert(tbProyectos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("tipr_Id", item.tipr_Id);
                parametro.Add("proy_Nombre", item.proy_Nombre);
                parametro.Add("proy_Descripcion", item.proy_Descripcion);
                parametro.Add("proy_FechaInicio", item.proy_FechaInicio);
                parametro.Add("proy_FechaFin", item.proy_FechaFin);
                parametro.Add("proy_DireccionExacta", item.proy_DireccionExacta);
                parametro.Add("clie_Id", item.clie_Id);
                parametro.Add("ciud_Id", item.ciud_Id);
                parametro.Add("usua_Creacion", item.usua_Creacion);
                parametro.Add("proy_FechaCreacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Insertar_Proyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public IEnumerable<tbProyectos> List()
        {
            List<tbProyectos> result = new List<tbProyectos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbProyectos>(ScriptsDataBase.ListarProyectos, commandType: CommandType.Text, commandTimeout: 0).ToList();
                return result;
            }
        }

        public IEnumerable<tbProyectos> ProyectoListarActividades(int id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@proy_Id", id);
                return db.Query<tbProyectos>(ScriptsDataBase.ProyectoListarActividades, parameter, commandType: CommandType.StoredProcedure);
            }
        }



        public virtual RequestStatus Update(tbProyectos item)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("proy_Id", item.proy_Id);
                parametro.Add("tipr_Id", item.tipr_Id);
                parametro.Add("proy_Nombre", item.proy_Nombre);
                parametro.Add("proy_Descripcion", item.proy_Descripcion);
                parametro.Add("proy_FechaInicio", item.proy_FechaInicio);
                parametro.Add("proy_FechaFin", item.proy_FechaFin);
                parametro.Add("proy_DireccionExacta", item.proy_DireccionExacta);
                parametro.Add("clie_Id", item.clie_Id);
                parametro.Add("frec_Id", item.frec_Id);
                parametro.Add("ciud_Id", item.ciud_Id);
                parametro.Add("usua_Modificacion", item.usua_Modificacion);
                parametro.Add("proy_FechaModificacion", DateTime.Now);

                var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.Actualizar_Proyecto,
                    parametro,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
