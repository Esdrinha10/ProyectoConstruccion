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
   public class TerrenoRepository : IRepository<tbTerrenos>
    {
        /// <summary>
        /// Elimina un terreno usando su ID.
        /// </summary>
        /// <param name="id">El ID del terreno que se desea eliminar.</param>
        /// <returns>El estado de la operación de eliminación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", id);
                var answer = db.QueryFirst<int>(ScriptsDataBase.Eliminarterreno, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Desactiva un identificador de terreno usando su ID.
        /// </summary>
        /// <param name="id">El ID del terreno cuyo identificador se desea desactivar.</param>
        /// <returns>El estado de la operación de desactivación.</returns>
        public RequestStatus DesactivarIdentificador(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", id);
                var answer = db.QueryFirst<int>(ScriptsDataBase.DesactivarIdentificador, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de documentos relacionados con un terreno específico.
        /// </summary>
        /// <param name="coti">El ID del terreno para el cual se desean obtener los documentos.</param>
        /// <returns>Lista de documentos asociados al terreno.</returns>
        public IEnumerable<tbTerrenos> DocumentoPorTerreno(int coti)
        {
            List<tbTerrenos> result = new List<tbTerrenos>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", coti);
                result = db.Query<tbTerrenos>(ScriptsDataBase.DocuemntoPorTerrenosListar, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Busca un terreno por su ID.
        /// </summary>
        /// <param name="id">El ID del terreno que se desea buscar.</param>
        /// <returns>El terreno encontrado.</returns>
        public tbTerrenos Find(int? id)
        {
            tbTerrenos result = new tbTerrenos();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", id);
                result = db.QueryFirst<tbTerrenos>(ScriptsDataBase.BuscarTerreno, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo terreno en la base de datos.
        /// </summary>
        /// <param name="item">Los detalles del terreno que se desea agregar.</param>
        /// <returns>El estado de la operación de inserción.</returns>
        public virtual RequestStatus Insert(tbTerrenos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Descripcion", item.terr_Descripcion);
                parameter.Add("@terr_Area", item.terr_Area);
                parameter.Add("@terr_Estado", item.terr_Estado);
                parameter.Add("@terr_PecioCompra", item.terr_PecioCompra);
                parameter.Add("@terr_LinkUbicacion", item.terr_LinkUbicacion);
                parameter.Add("@terr_Imagen", item.terr_Imagen);
                parameter.Add("@terr_Longitud", item.terr_Longitud);
                parameter.Add("@terr_Latitud", item.terr_Latitud);
                //parameter.Add("@terr_PrecioVenta", item.terr_PrecioVenta);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@terr_FechaCreacion", item.terr_FechaCreacion);
                var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarTerreno, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los terrenos.
        /// </summary>
        /// <returns>Lista de terrenos disponibles.</returns>
        public virtual IEnumerable<tbTerrenos> List()
        {
            List<tbTerrenos> result = new List<tbTerrenos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbTerrenos>(ScriptsDataBase.ListarTerrenos, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de terrenos con identificador.
        /// </summary>
        /// <returns>Lista de terrenos con identificador.</returns>
        public IEnumerable<tbTerrenos> ListIdentificador()
        {
            List<tbTerrenos> result = new List<tbTerrenos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbTerrenos>(ScriptsDataBase.ListarTerrenos_Indentificador, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        /// <summary>
        /// Actualiza la información de un terreno existente.
        /// </summary>
        /// <param name="item">El objeto con la información actualizada del terreno.</param>
        /// <returns>El estado de la operación de actualización.</returns>
        public virtual RequestStatus Update(tbTerrenos item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", item.terr_Id);
                parameter.Add("@terr_Descripcion", item.terr_Descripcion);
                parameter.Add("@terr_Area", item.terr_Area);
                parameter.Add("@terr_Estado", item.terr_Estado);
                parameter.Add("@terr_PecioCompra", item.terr_PecioCompra);
                //parameter.Add("@terr_PrecioVenta", item.terr_PrecioVenta);
                parameter.Add("@terr_LinkUbicacion", item.terr_LinkUbicacion);
                parameter.Add("@terr_Imagen", item.terr_Imagen);
                parameter.Add("@terr_Longitud", item.terr_Longitud);
                parameter.Add("@terr_Latitud", item.terr_Latitud);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@terr_FechaModificacion", item.terr_FechaModificacion);
                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarTerreno, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }
        }

    }
}
