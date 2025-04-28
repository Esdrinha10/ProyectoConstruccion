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
    public class ProyectoConstruccionBienRaizRepository : IRepository<tbProyectosConstruccionBienesRaices>
    {
        /// <summary>
        /// Elimina un proyecto de construcción de bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID del proyecto de construcción de bienes raíces que se desea eliminar.</param>
        /// <returns>Estado de la solicitud de eliminación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pcon_Id", id);
                var answer = db.QueryFirst<int>(ScriptsDataBase.EliminarProyectoConstruccionBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Busca un proyecto de construcción de bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID del proyecto de construcción de bienes raíces que se desea buscar.</param>
        /// <returns>El proyecto de construcción de bienes raíces encontrado.</returns>
        public tbProyectosConstruccionBienesRaices Find(int? id)
        {
            tbProyectosConstruccionBienesRaices result = new tbProyectosConstruccionBienesRaices();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pcon_Id", id);
                result = db.QueryFirst<tbProyectosConstruccionBienesRaices>(ScriptsDataBase.BuscarProyectoConstruccionBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo proyecto de construcción de bienes raíces.
        /// </summary>
        /// <param name="item">El objeto que representa el nuevo proyecto de construcción de bienes raíces a insertar.</param>
        /// <returns>Estado de la solicitud de inserción.</returns>
        public virtual RequestStatus Insert(tbProyectosConstruccionBienesRaices item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", item.terr_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@pcon_FechaCreacion", item.pcon_FechaCreacion);
                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarProyectoConstruccionBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los proyectos de construcción de bienes raíces.
        /// </summary>
        /// <returns>Lista de proyectos de construcción de bienes raíces.</returns>
        public IEnumerable<tbProyectosConstruccionBienesRaices> List()
        {
            List<tbProyectosConstruccionBienesRaices> result = new List<tbProyectosConstruccionBienesRaices>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbProyectosConstruccionBienesRaices>(ScriptsDataBase.ListarProyectosConstruccionBienesRaices, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza un proyecto de construcción de bienes raíces existente.
        /// </summary>
        /// <param name="item">El objeto con la información actualizada del proyecto de construcción de bienes raíces.</param>
        /// <returns>Estado de la solicitud de actualización.</returns>
        public virtual RequestStatus Update(tbProyectosConstruccionBienesRaices item)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pcon_Id", item.pcon_Id);
                parameter.Add("@terr_Id", item.terr_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pcon_FechaModificacion", item.pcon_FechaModificacion);
                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarProyectoConstruccionBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
            }
            return result;
        }

    }
}
