using Dapper;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SIGESPROC.DataAccess.Repositories.RepositoryGeneral
{
    public class EmpleadoRepository : IRepository<tbEmpleados>
    {
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                //var parameter = new DynamicParameters();
                //parameter.Add("@empl_Id", id);

                //var ansewer = db.QueryFirst<int>(ScriptsDataBase.DesactivarEmpleado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = 1;
                return result;
            }
        }

        /// <summary>
        /// Actualiza un empleado y sus estados de inactivar existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbEmpleados que contiene los datos actualizados del empleado.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Desactivar(tbEmpleados item)
        {
            //RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@empl_ObservacionInactivar", item.empl_ObservacionInactivar);
                parameter.Add("@empl_Prestaciones", item.empl_Prestaciones);
                parameter.Add("@empl_OtrasRemuneraciones", item.empl_OtrasRemuneraciones);

                var ansewer = db.QueryFirst<RequestStatus>(ScriptsDataBase.DesactivarEmpleado, parameter, commandType: CommandType.StoredProcedure);
                return ansewer;
            }
        }
        /// <summary>
        /// Actualiza el estado de activacion un empleado existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbEmpleados que contiene los datos actualizados del empleado.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Activar(tbEmpleados item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@empl_ObservacionActivar", item.empl_ObservacionActivar);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActivarEmpleado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Busca y devuelve un empleado específico por su ID.
        /// </summary>
        /// <param name="id">El ID del empleado a buscar.</param>
        /// <returns>Un objeto tbEmpleados que representa el empleado encontrado.</returns>
        public tbEmpleados Find(int? id)
        {
            tbEmpleados result = new tbEmpleados();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", id);
                result = db.QueryFirst<tbEmpleados>(ScriptsDataBase.BuscarEmpleado, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// Busca y devuelve un empleado específico por su DNI.
        /// </summary>
        /// <param name="id">El DNI del empleado a buscar.</param>
        /// <returns>Un objeto tbEmpleados que representa el empleado encontrado.</returns>
        public tbEmpleados FindPorEmpleado(string? DNI)
        {
            tbEmpleados result = new tbEmpleados();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_DNI", DNI);
                result = db.QueryFirst<tbEmpleados>(ScriptsDataBase.BuscarEmpleadoPorDNI, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Busca y devuelve la imagen de un empleado específico por su Id.
        /// </summary>
        /// <param name="empl_Id">El Id del empleado a buscar.</param>
        /// <returns>Un objeto ImageDataResult que contiene la imagen y el tipo de contenido.</returns>
        public async Task<ImageDataResult> ObtenerImagen(int empl_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                await db.OpenAsync();  // Await the asynchronous opening of the connection

                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", empl_Id);

                using (var reader = await db.ExecuteReaderAsync(ScriptsDataBase.ObtenerImagen, parameter, commandType: CommandType.StoredProcedure))  // Await the asynchronous execution of the reader
                {
                    if (await reader.ReadAsync())  // Await the asynchronous reading of the results
                    {
                        return new ImageDataResult
                        {
                            ImageData = (byte[])reader["empl_Imagen"],
                            ContentType = "image/webp"
                        };
                    }
                }
            }

            return null; // Return null if no image is found
        }

        /// <summary>
        /// Inserta un nuevo empleado en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbEmpleados que contiene los datos del empleado a insertar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbEmpleados item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_DNI", item.empl_DNI);
                parameter.Add("@empl_Nombre", item.empl_Nombre);
                parameter.Add("@empl_Apellido", item.empl_Apellido);
                parameter.Add("@empl_CorreoElectronico", item.empl_CorreoElectronico);
                parameter.Add("@empl_Telefono", item.empl_Telefono);
                parameter.Add("@empl_Sexo", item.empl_Sexo);
                parameter.Add("@empl_FechaNacimiento", item.empl_FechaNacimiento);
                parameter.Add("@empl_Salario", item.empl_Salario);
                parameter.Add("@deduccionesJSON", item.deduccionesJSON);
                parameter.Add("@ciud_Id", item.ciud_Id);
                parameter.Add("@civi_Id", item.civi_Id);
                parameter.Add("@carg_Id", item.carg_Id);
                parameter.Add("@banc_Id", item.banc_Id);
                parameter.Add("@frec_Id", item.frec_Id);
                parameter.Add("@empl_NoBancario", item.empl_NoBancario);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@empl_FechaCreacion", item.empl_FechaCreacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarEmpleado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los empleados en la base de datos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbEmpleados que representa la lista de empleados.</returns>
        public IEnumerable<tbEmpleados> List()
        {
            List<tbEmpleados> result = new List<tbEmpleados>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbEmpleados>(ScriptsDataBase.ListarEmpleados, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<PagoPlanillaEmpleadosViewModel> Lisst()
        {
            List<PagoPlanillaEmpleadosViewModel> result = new List<PagoPlanillaEmpleadosViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<PagoPlanillaEmpleadosViewModel>(ScriptsDataBase.ListarEmpleados, commandType: CommandType.Text).ToList();
                return result;
            }
        }
        /// <summary>
        /// Actualiza un empleado existente en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbEmpleados que contiene los datos actualizados del empleado.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbEmpleados item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@empl_DNI", item.empl_DNI);
                parameter.Add("@empl_Nombre", item.empl_Nombre);
                parameter.Add("@empl_Apellido", item.empl_Apellido);
                parameter.Add("@empl_CorreoElectronico", item.empl_CorreoElectronico);
                parameter.Add("@empl_Telefono", item.empl_Telefono);
                parameter.Add("@empl_Sexo", item.empl_Sexo);
                parameter.Add("@empl_FechaNacimiento", item.empl_FechaNacimiento);
                parameter.Add("@empl_Salario", item.empl_Salario);
                parameter.Add("@ciud_Id", item.ciud_Id);
                parameter.Add("@civi_Id", item.civi_Id);
                parameter.Add("@carg_Id", item.carg_Id);
                parameter.Add("@banc_Id", item.banc_Id);
                parameter.Add("@frec_Id", item.frec_Id);
                parameter.Add("@empl_NoBancario", item.empl_NoBancario);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@empl_FechaModificacion", item.empl_FechaModificacion);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarEmpleado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }
        /// <summary>
        /// Actualiza la imagen de un empleado existente en la base de datos.
        /// </summary>
        /// <param name="imagen">El objeto tbEmpleados que contiene los datos actualizados del empleado.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>

        public async Task<RequestStatus> ActualizarImagen(IFormFile imagen)
        {
            RequestStatus result = new RequestStatus();
            if (imagen == null || imagen.Length == 0)
            {
                result.CodeStatus = 0;
                return result;
            }

            using (var ms = new MemoryStream())
            {
                await imagen.CopyToAsync(ms);
                var imageData = ms.ToArray();

                // Convert image data to WebP format using Magick.NET
                byte[] webpData;
                using (var inputStream = new MemoryStream(imageData))
                using (var image = new MagickImage(inputStream))
                using (var webpStream = new MemoryStream())
                {
                    image.Format = MagickFormat.WebP;
                    image.Write(webpStream);
                    webpData = webpStream.ToArray();
                }

                using (var db = new SqlConnection(SIGESPROC.ConnectionString))
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@empl_Imagen", webpData);
                    parameter.Add("@empl_Id", Convert.ToInt64(imagen.FileName));

                    var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarImagenDelEmpleado, parameter, commandType: CommandType.StoredProcedure);
                    result.CodeStatus = answer;
                    return result;
                }
            }
        }
        /// <summary>
        /// Quita la imagen de un empleado existente en la base de datos.
        /// </summary>
        /// <param name="empl_Id">El Id del empleado.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>

        public RequestStatus QuitarImagen(int empl_Id)
        {
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Imagen", null, DbType.Binary);
                parameter.Add("@empl_Id", empl_Id);

                var answer = db.QueryFirst<int>(ScriptsDataBase.ActualizarImagenDelEmpleado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = answer;
                return result;
            }   
        }
        /// <summary>
        /// Obtiene el historial de pago de un empleado.
        /// </summary>
        /// <returns>Una lista de objetos HistorialDePagoViewModel.</returns>
        public List<HistorialDePagoViewModel> Historial(int empl_Id)
        {
            List<HistorialDePagoViewModel> result = new List<HistorialDePagoViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", empl_Id);
                result = db.Query<HistorialDePagoViewModel>(ScriptsDataBase.HistorialEmpleado, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
    }
}
