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
    public class DocumentoBienRaizRepository : IRepository<tbDocumentosBienRaiz>
    {
        /// <summary>
        /// Elimina un documento de bienes raíces por su ID.
        /// </summary>
        /// <param name="id">El ID del documento de bienes raíces que se desea eliminar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que contiene el estado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Id", id);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarDocumentoBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }


        /// <summary>
        /// Elimina un documento de terreno por su ID.
        /// </summary>
        /// <param name="id">El ID del documento de terreno que se desea eliminar.</param>
        /// <returns>Un objeto <see cref="RequestStatus"/> que indica el estado de la operación.</returns>
        public RequestStatus DeleteTerreno(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Id", id);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarDocumentoTerreno, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Busca un documento de bien raíz por su ID.
        /// </summary>
        /// <param name="id">El ID del documento de bien raíz que se desea buscar.</param>
        /// <returns>El documento de bien raíz asociado al ID proporcionado.</returns>
        public tbDocumentosBienRaiz Find(int? id)
        {
            tbDocumentosBienRaiz result = new tbDocumentosBienRaiz();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Id", id);
                result = db.QueryFirst<tbDocumentosBienRaiz>(ScriptsDataBase.BuscarDocumentoBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Busca un documento de bien raíz asociado a un terreno específico por su ID.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se busca el documento de bien raíz.</param>
        /// <returns>El documento de bien raíz asociado al terreno con el ID proporcionado.</returns>
        public tbDocumentosBienRaiz DocumentoPorTerrenos(int? id)
        {
            tbDocumentosBienRaiz result = new tbDocumentosBienRaiz();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@terr_Id", id);
                result = db.QueryFirst<tbDocumentosBienRaiz>(ScriptsDataBase.BuscarDocumentoPorTerreno, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Inserta un nuevo documento de bien raíz en la base de datos.
        /// </summary>
        /// <param name="item">El documento de bien raíz que se desea insertar.</param>
        /// <returns>El estado de la solicitud con un código y mensaje indicando el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbDocumentosBienRaiz item)
        {
            RequestStatus result = new RequestStatus();
                try
                {
                using (var db = new SqlConnection(SIGESPROC.ConnectionString))
                    {
                    var parameter = new DynamicParameters();
                    parameter.Add("@dobt_DescipcionDocumento", item.dobt_DescipcionDocumento);
                    parameter.Add("@tido_Id", item.tido_Id);
                    parameter.Add("@dobt_Imagen", item.dobt_Imagen);
                    parameter.Add("@usua_Creacion", item.usua_Creacion);
                        parameter.Add("@dobt_FechaCreacion", item.dobt_FechaCreacion);
                        parameter.Add("@dobt_Terreno_O_BienRaizId", item.dobt_Terreno_O_BienRaizId);
                        parameter.Add("@dobt_Terreno_O_BienRaizbit", item.dobt_Terreno_O_BienRaizbit);

                    var answer = db.QueryFirst<int>(ScriptsDataBase.InsertarDocumentoBienRaiz, parameter, commandType: CommandType.StoredProcedure);

                        
                        result.CodeStatus = answer;
                        result.Message = "Inserción exitosa";
                    return result;
                    }
                }
                catch (SqlException sqlEx)
                {
                   
                    result.CodeStatus = 0;
                    result.Message = "Error al insertar documento: " + sqlEx.Message; 
                                                                                      
                    return result;
                }
                catch (Exception ex)
                {
                   
                    result.CodeStatus = 0; 
                    result.Message = "Error general al insertar documento: " + ex.Message;
                                                                                         
                    return result;
                }
            

        }
        /// <summary>
        /// Obtiene una lista de todos los documentos de bien raíz almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de documentos de bien raíz.</returns>
        public IEnumerable<tbDocumentosBienRaiz> List()
        {
            List<tbDocumentosBienRaiz> result = new List<tbDocumentosBienRaiz>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarDocumentoBienRaiz, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los tipos de documentos de bien raíz almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de tipos de documentos de bien raíz.</returns>
        public IEnumerable<tbTiposDocumentos> ListTipodocumento()
        {
            List<tbTiposDocumentos> result = new List<tbTiposDocumentos>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbTiposDocumentos>(ScriptsDataBase.ListarTipoDocumentoBienRaiz, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        /// <summary>
        /// Actualiza la información de un documento de bien raíz existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto que contiene los datos actualizados del documento de bien raíz.</param>
        /// <returns>Un objeto que indica el estado de la operación de actualización.</returns>
        public virtual RequestStatus Update(tbDocumentosBienRaiz item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Id", item.dobt_Id);
                parameter.Add("@dobt_DescipcionDocumento", item.dobt_DescipcionDocumento);
                parameter.Add("@tido_Id", item.tido_Id);
                parameter.Add("@dobt_Imagen", item.dobt_Imagen);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@dobt_FechaModificacion", item.dobt_FechaModificacion);
                parameter.Add("@dobt_Terreno_O_BienRaizId", item.dobt_Terreno_O_BienRaizId);
                parameter.Add("@dobt_Terreno_O_BienRaizbit", item.dobt_Terreno_O_BienRaizbit);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActuzalizarDocumentoBienRaiz, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de documentos PDF asociados a un Bienraiz específico.
        /// </summary>
        /// <param name="id">El ID del Bienraiz para el cual se listan los documentos PDF.</param>
        /// <returns>Lista de documentos PDF asociados al Bienraiz especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListPDF(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarPDF, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de imágenes asociadas a un Bienraiz específico.
        /// </summary>
        /// <param name="id">El ID del Bienraiz para el cual se listan las imágenes.</param>
        /// <returns>Lista de imágenes asociadas al Bienraiz especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListImagen(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarImagen, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de documentos Word asociados a un Bienraiz específico.
        /// </summary>
        /// <param name="id">El ID del Bienraiz para el cual se listan los documentos Word.</param>
        /// <returns>Lista de documentos Word asociados al Bienraiz especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListWord(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarWord, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de otros tipos de documentos asociados a un Bienraiz específico.
        /// </summary>
        /// <param name="id">El ID del Bienraiz para el cual se listan otros tipos de documentos.</param>
        /// <returns>Lista de otros documentos asociados al Bienraiz especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListOtros(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarOtros, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de archivos Excel asociados a un Bienraiz específico.
        /// </summary>
        /// <param name="id">El ID del Bienraiz para el cual se listan los archivos Excel.</param>
        /// <returns>Lista de archivos Excel asociados al Bienraiz especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListExcel(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarExcel, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de documentos PDF asociados a un terreno específico.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se listan los documentos PDF.</param>
        /// <returns>Lista de documentos PDF asociados al terreno especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListTerrenoPDF(int? id)
        {
           
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
              
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);   
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarTerrenoPDF, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de imágenes asociadas a un terreno específico.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se listan las imágenes.</param>
        /// <returns>Lista de imágenes asociadas al terreno especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListTerenoImagen(int? id)
        {
        
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarTerrenoImagen, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de archivos Excel asociados a un terreno específico.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se listan los archivos Excel.</param>
        /// <returns>Lista de archivos Excel asociados al terreno especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListTerrenoExcel(int? id)
        {
           
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarTerrenoExcel, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de archivos Word asociados a un terreno específico.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se listan los archivos Word.</param>
        /// <returns>Lista de archivos Word asociados al terreno especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListTerrenoWord(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarTerrenoWord, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de otros tipos de archivos asociados a un terreno específico.
        /// </summary>
        /// <param name="id">El ID del terreno para el cual se listan otros tipos de archivos.</param>
        /// <returns>Lista de otros archivos asociados al terreno especificado.</returns>
        public IEnumerable<tbDocumentosBienRaiz> ListTerrenoOtro(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@dobt_Terreno_O_BienRaizId", id);
                var result = db.Query<tbDocumentosBienRaiz>(ScriptsDataBase.ListarTerrenoOtros, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }

        }
    }
}
