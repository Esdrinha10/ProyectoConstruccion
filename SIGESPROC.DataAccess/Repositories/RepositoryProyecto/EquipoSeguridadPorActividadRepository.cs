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
    public class EquipoSeguridadPorActividadRepository
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEquiposSeguridadPorActividades Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEquiposSeguridadPorActividades item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una lista de los equipos de seguridad asociadas a una actividad específica.
        /// </summary>
        /// <param name="id">El ID de la actividad para la cual se desean listar los equipos de seguridad.</param>
        /// <returns>Una colección IEnumerable de objetos tbEquiposSeguridadPorActividades que representa los equipos encontrados.</returns>
        public IEnumerable<tbEquiposSeguridadPorActividades> List(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("acet_Id", id);

                var result = db.Query<tbEquiposSeguridadPorActividades>(ScriptsDataBase.Listar_EquiposSeguridadPorActividad,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public RequestStatus Update(tbEquiposSeguridadPorActividades item)
        {
            throw new NotImplementedException();
        }
    }
}
