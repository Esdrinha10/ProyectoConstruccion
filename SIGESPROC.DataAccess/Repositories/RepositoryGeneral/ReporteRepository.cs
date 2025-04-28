using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryGeneral
{
    public class ReporteRepository : IRepository<ReporteViewModel>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReporteViewModel> ReporteTerrenoFechaCreacion(string fechaInicio, string fechaFin)
        {
            if (string.IsNullOrWhiteSpace(fechaInicio) || string.IsNullOrWhiteSpace(fechaFin))
            {
                throw new ArgumentException("Las fechas no pueden estar vacías.");
            }

            var storedProcedure = ScriptsDataBase.ReporteTerrenoFechaCreacion;
            var parameters = new
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    // Registra el error en un log
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    // Opcionalmente, puedes devolver una lista vacía o relanzar la excepción
                    throw;
                }
            }
        }

        public IEnumerable<ReporteViewModel> ReporteTerrenosPorEstadoProyecto(string fechaInicio, string fechaFin, bool tipo)
        {
            if (string.IsNullOrWhiteSpace(fechaInicio) || string.IsNullOrWhiteSpace(fechaFin))
            {
                throw new ArgumentException("Las fechas no pueden estar vacías.");
            }

            var storedProcedure = ScriptsDataBase.ReporteTerrenosPorEstadoProyecto;
            var parameters = new
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                TerrenoEnProyecto = tipo
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    // Registra el error en un log
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    // Opcionalmente, puedes devolver una lista vacía o relanzar la excepción
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteVentasPorEmpresa(int empresa)
        {
           

            var storedProcedure = ScriptsDataBase.ReporteVentasPorEmpresa;
            var parameters = new
            {
                EmpresaId = empresa
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteEmpleadoPorEstado(bool estado)
        {


            var storedProcedure = ScriptsDataBase.ReporteEmpleadoPorEstado;
            var parameters = new
            {
                Estado = estado
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteFletesPorFecha(string fehaInicio,string fechaFin)
        {


            var storedProcedure = ScriptsDataBase.ReporteFletesPorFecha;
            var parameters = new
            {
                FechaInicio = fehaInicio,
                FechaFin = fechaFin
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteHistorialCotizaciones(string fehaInicio, string fechaFin, int id, bool todo)
        {


            var storedProcedure = ScriptsDataBase.ReporteHistorialCotizaciones;
            var parameters = new
            {
                RangoFechaInicio = fehaInicio,
                RangoFechaFin = fechaFin,
                ProveedorId = id,
                MostrarTodo = todo

            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteComprasRealizadas(string fechaInicio, string fechaFin)
        {


            var storedProcedure = ScriptsDataBase.ReporteComprasRealizadas;
            var parameters = new
            {
                fechaInicio = fechaInicio,
                fechaFin = fechaFin

            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteComparacionMonetaria(int proy_Id)
        {
            var parameters = new { proy_Id };

            using var db = new SqlConnection(SIGESPROC.ConnectionString);
            try
            {
                using var multi = db.QueryMultiple(ScriptsDataBase.ReporteComparacionMonetaria, parameters, commandType: CommandType.StoredProcedure);

                var etapasYActividades = multi.Read<ReporteViewModel>().ToList();
                var totalesEtapas = multi.Read<ReporteViewModel>().ToList();
                var result = etapasYActividades
                             .Concat(totalesEtapas)
                             .ToList();

                return result.Any() ? result : Enumerable.Empty<ReporteViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<ReporteViewModel> ReporteCotizacionesPorRangoPrecios(int tipo, string precio,bool mostrar)
        {


            var storedProcedure = ScriptsDataBase.ReporteCotizacionesPorRangoPrecios;
            var parameters = new
            {
                Tipo = tipo,
                RangoPrecioMax = precio,
                MostrarTodo = mostrar,

            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteInsumosBodega(string fechainicio,string fechafin)
        {


            var storedProcedure = ScriptsDataBase.ReporteInsumosBodega;
            var parameters = new
            {
                FechaInicio = fechainicio,
                FechaFin = fechafin

            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteInsumosAProyecto(string fechainicio, string fechafin)
        {


            var storedProcedure = ScriptsDataBase.ReporteInsumosAProyecto;
            var parameters = new
            {
                FechaInicio = fechainicio,
                FechaFin = fechafin

            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteHistorialPagosPorProyecto(string fechainicio, string fechafin, int proy_id)
        {
            var storedProcedure = ScriptsDataBase.ReporteHistorialPagosPorProyecto;
            var parameters = new
            {
                FechaInicio = fechainicio,
                FechaFin = fechafin,
                Proy_Id = proy_id
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsEnumerable();

                    if (!result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteComparativoProductos(int tipo)
        {
            var storedProcedure = ScriptsDataBase.ReporteComparativoProductos;
            var parameters = new
            {
                tipo = tipo
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    ).AsEnumerable();

                    if (!result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReportecomprasPendientesEnvio(string fechainicio, string fechafin)
        {


            var storedProcedure = ScriptsDataBase.ReportecomprasPendientesEnvio;
            var parameters = new
            {
                FechaInicio = fechainicio,
                FechaFin = fechafin

            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReporteProgresoActividades(int proy, string fechaInicio, string fechaFin)
        {
            var storedProcedure = ScriptsDataBase.ReporteProgresoActividades;
            var parameters = new
            {
                proyectoId = proy,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> ReportePorUbicacion(Boolean Ubicacion)
        {
            var storedProcedure = ScriptsDataBase.ReportePorUbicacion;
            var parameters = new
            {
                @tipoFiltro = Ubicacion
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<ReporteViewModel> EstadisticasFletes_Comparacion(int flen_Id)
        {
            var storedProcedure = ScriptsDataBase.EstadisticasFletes_Comparacion;
            var parameters = new
            {
                flen_Id = flen_Id
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<ReporteViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<ReporteViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<Reporte2ViewModel> ReporteProcesoVenta(int tipo, bool estado)
        {
            var storedProcedure = ScriptsDataBase.ReporteProcesoVenta;
            var parameters = new
            {
                Tipo = tipo,
                Estado = estado
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    var result = db.Query<Reporte2ViewModel>(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    ).AsEnumerable();

                    if (!result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<Reporte2ViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<Reporte2ViewModel> EstadisticasFletes_Llegada(string FechaInicio, string FechaFin)
        {
            var storedProcedure = ScriptsDataBase.EstadisticasFletes_Llegada;
            var parameters = new
            {
                FechaInicio = FechaInicio,
                FechaFin = FechaFin,
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<Reporte2ViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<Reporte2ViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<Reporte2ViewModel> ReporteInsumosTransportadosPorActividad(string FechaInicio, string FechaFin,int ActividadId)
        {
            var storedProcedure = ScriptsDataBase.ReporteInsumosTransportadosPorActividad;
            var parameters = new
            {
                FechaInicio = FechaInicio,
                FechaFin = FechaFin,
                ActividadId = ActividadId,
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<Reporte2ViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<Reporte2ViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public IEnumerable<Reporte2ViewModel> ReporteInsumosUltimoPrecio(string numeroCompra)
        {
            var storedProcedure = ScriptsDataBase.ReporteInsumosUltimoPrecio;
            var parameters = new
            {
                coen_Id = numeroCompra,
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<Reporte2ViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<Reporte2ViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<Reporte2ViewModel> ReporteArticuloActividades(int acti,int eleccion)
        {
            var storedProcedure = ScriptsDataBase.ReporteArticulosActividades;
            var parameters = new
            {
                acet_Id = acti,
                tipo = eleccion
            };

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                try
                {
                    db.Open();

                    var result = db.Query<Reporte2ViewModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();

                    if (result == null || !result.Any())
                    {
                        Console.WriteLine("No se encontraron datos.");
                        return new List<Reporte2ViewModel>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    throw;
                }
            }
        }
        public ReporteViewModel Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(ReporteViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReporteViewModel> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(ReporteViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
