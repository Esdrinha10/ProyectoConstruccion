using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryPlanilla
{
    public class PlanillaRepository : IRepository<tbPlanillas>
    {

        //class Planilla{
        //    public int plan_Id { get; set; }
        //    public int plan_NumNomina { get; set; }
        //    public string plan_FechaPago { get; set; }
        //    public string plan_Observaciones { get; set; }
        //    public bool? plan_PlanillaJefes { get; set; }
        //    public int? frec_Id { get; set; }
        //}

        //List<Planilla> plan = new List<Planilla>();

        public RequestStatus Delete(int? id)
        {
            // Método no implementado
            throw new NotImplementedException();
        }

        public tbPlanillas Find(int? id)
        {
            // Método no implementado
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbPlanillas item)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@plan_FechaPago", item.plan_FechaPago);
                parameter.Add("@plan_FechaPeriodoFin", item.plan_FechaPeriodoFin);  
                parameter.Add("@plan_Observaciones", item.plan_Observaciones);
                parameter.Add("@plan_PlanillaJefes", item.plan_PlanillaJefes);
                parameter.Add("@frec_Id", item.frec_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@plan_FechaCreacion", item.plan_FechaCreacion);

                parameter.Add("@ultimoID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameter.Add("@Usuario", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameter.Add("@FechaPago", dbType: DbType.DateTime, size: 100, direction: ParameterDirection.Output);
                parameter.Add("@FechaEmision", dbType: DbType.DateTime, size: 100, direction: ParameterDirection.Output);
                parameter.Add("@NumNomina", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameter.Add("@JefeEmpleado", dbType: DbType.Int32, size: 100, direction: ParameterDirection.Output);
                parameter.Add("@Frecuencia", dbType: DbType.String, size: 100 ,direction: ParameterDirection.Output);

                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.InsertarPlanilla, parameter, commandType: CommandType.StoredProcedure);

                // Recuperamos los valores de los parámetros de salida
                int ultimoID = parameter.Get<int>("@ultimoID");
                string usuario = parameter.Get<string>("@Usuario");
                DateTime fechapago = parameter.Get<DateTime>("@FechaPago");
                DateTime fechaemision = parameter.Get<DateTime>("@FechaEmision");
                int NumNomina = parameter.Get<int>("@NumNomina");
                int JefeEmpleado = parameter.Get<int>("@JefeEmpleado");
                string Frecuencia = parameter.Get<string>("@Frecuencia");

                // Convertimos los parámetros de salida a una cadena de texto separada por barras verticales
                var outputParams = new object[] { usuario, fechapago, fechaemision, NumNomina, JefeEmpleado, Frecuencia, ultimoID };
                string outputParamsString = string.Join("|", outputParams.Select(p => p.ToString()));

                // Asignamos el código de estado y el mensaje de resultado
                result.CodeStatus = ultimoID;
                result.Message = outputParamsString;
                return result;
            }
        }

        public RequestStatus InsertPlanillaDetalle(string item, string item2)
        {
            // Creamos un objeto RequestStatus para almacenar el resultado de la operación
            RequestStatus result = new RequestStatus();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@json", item);
                parameter.Add("@jsonDeducciones", item2);

                // Ejecutamos el procedimiento almacenado "InsertarPlanilla" y obtenemos los parámetros de salida
                var ansewer = db.Query(ScriptsDataBase.InsertarPlanillaDetalle, parameter, commandType: CommandType.StoredProcedure);

                var saber = ansewer.Select(ans =>
                {
                    return ans;

                }).ToList();

                result.CodeStatus = saber.Count;

                return result;
            }
        }

        public virtual IEnumerable<tbPlanillas> List(int saber)
        {

            {
                List<tbPlanillas> result = new List<tbPlanillas>();

                // Conexión con la base de datos
                using (var db = new SqlConnection(SIGESPROC.ConnectionString))
                {
                    // Ejecutar el procedimiento almacenado para listar las frecuencias y obtener el resultado
                    result = db.Query<tbPlanillas>(ScriptsDataBase.ListarPlanilla, commandType: CommandType.Text).ToList();
                    // Verificar que la lista tenga al menos dos elementos
                    
                    if (result.Count >= 1 && saber == 1)
                    {
                        yield return result.ElementAt(result.Count - 2); // Devuelve el penultimo elemento 
                    }

                    else if (result.Count >= 1 && saber == 2) 
                    {
                        yield return result.LastOrDefault(); // Devuelve el ultimo elemento
                    }

                    else if (result.Count >= 1 && saber == 3)
                    {
                        foreach (var item in result)
                        {
                            yield return item;           //Devuelve todo el listado de manera descendente segun el id de la planilla.
                        }
                    }

                    else
                    {
                        yield break; // No hay elementos en la lista, no devolver nada
                    }
                }
            }
        }

        public IEnumerable<PrestamoViewModel> ListarPrestamosEmpleados(int? id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", id);

                // Ejecutamos el procedimiento almacenado "DeduccionesPorEmpleados" y obtenemos los resultados
                return db.Query<PrestamoViewModel>(ScriptsDataBase.ListarPrestamosEmpleado, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<DeduccionViewModel> DeduccionesPorEmpelados(int? id, int? frec_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", id);
                parameter.Add("@frec_Id", frec_Id);

                // Ejecutamos el procedimiento almacenado "DeduccionesPorEmpleados" y obtenemos los resultados
                return db.Query<DeduccionViewModel>(ScriptsDataBase.DeduccionesPorEmpleados, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<PagoPlanillaEmpleadosViewModel> VerDetallesPlanilla(int? plan_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@plan_Id", plan_Id);

                // Ejecutamos el procedimiento almacenado "DeduccionesPorEmpleados" y obtenemos los resultados
                return db.Query<PagoPlanillaEmpleadosViewModel>(ScriptsDataBase.VerDetallesPlanilla, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<DeduccionViewModel> VerDeduccionPorEmpleadoPorPlanilla(int? plan_Id, int? emple_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@plan_Id", plan_Id);
                parameter.Add("@empl_Id", emple_Id);

                // Ejecutamos el procedimiento almacenado "DeduccionesPorEmpleados" y obtenemos los resultados
                return db.Query<DeduccionViewModel>(ScriptsDataBase.VerDeduccionPorEmpleadoPorPlanilla, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<DeduccionViewModel> BuscarDeduccionesPorPlanilla(int? plan_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@plan_Id", plan_Id);

                // Ejecutamos el procedimiento almacenado "DeduccionesPorEmpleados" y obtenemos los resultados
                return db.Query<DeduccionViewModel>(ScriptsDataBase.BuscarDeduccionesPorPlanilla, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<DeduccionViewModel> BuscarDeduccionesPorPlanillaPorEmpleado(int? plan_Id)
        {
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Creamos un objeto DynamicParameters para los parámetros del procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@plan_Id", plan_Id);

                // Ejecutamos el procedimiento almacenado "DeduccionesPorEmpleados" y obtenemos los resultados
                return db.Query<DeduccionViewModel>(ScriptsDataBase.BuscarDeduccionesPorPlanillaPorEmpleado, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public RequestStatus Update(tbPlanillas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPlanillas> List()
        {
            throw new NotImplementedException();
        }
    }
}
