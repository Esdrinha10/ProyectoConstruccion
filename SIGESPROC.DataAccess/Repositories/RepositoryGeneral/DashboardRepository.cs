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
    public class DashboardRepository : IRepository<DashboardRepository>
    {
        //COTIZACIONES
        //Top 5 proveedores mas cotizados
        public IEnumerable<DashboardViewModel> Top5PorveedoresCotizados()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5Proveedores, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //Top 5 Articulos mas comprados
        public IEnumerable<DashboardViewModel> Top5ArticulosComprados()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5Articulos, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //Top 5 Articulos de cada tipo mas comprados
        public IEnumerable<DashboardViewModel> Top5ArticulosporcadaunoComprados()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros con múltiples resultados
                using (var multi = db.QueryMultiple(ScriptsDataBase.DashboardTop5PorcadaArticulos, commandType: CommandType.Text))
                {
                    // Lee cada uno de los conjuntos de resultados (Insumos, Maquinarias, Equipos de Seguridad)
                    var insumos = multi.Read<DashboardViewModel>().ToList();
                    var maquinarias = multi.Read<DashboardViewModel>().ToList();
                    var equiposSeguridad = multi.Read<DashboardViewModel>().ToList();

                    // Puedes combinar los resultados en una lista general si es necesario
                    result.AddRange(insumos);
                    result.AddRange(maquinarias);
                    result.AddRange(equiposSeguridad);
                }

                return result; // Retorna la lista combinada de resultados
            }
        }
        //Top 5 Proveedores a los que mas se a comprados
     

        public IEnumerable<DashboardViewModel> Top5ProveedoresMasComprados(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5ProveedoresComprados, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        //Top 5 Proveedores a los que mas se a comprados
        public IEnumerable<DashboardViewModel> Top5DestinosCompraEnviados(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5DestinosCompraEnviados, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        //Totales compras mensuales
        public IEnumerable<DashboardViewModel> TotalesComprasMensuales()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTotalesComprasMensuales, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }





        //Totales compras Por Fecha
        public IEnumerable<DashboardViewModel> TotalesComprasPorFecha(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTotalesComprasFiltrado, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }


        //Totales Terrenos vendidos Por Fecha
        public IEnumerable<DashboardViewModel> TotalesTerrenosVendidos(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProcesosVentasTerrenosVendidosPorMes, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        public IEnumerable<DashboardViewModel> DashboardProyectosIncidenciasPorrangofechas(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProyectosIncidenciasPorrangofechas, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        public IEnumerable<DashboardViewModel> DashboardProyectosMayorcostoporRangofechas(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProyectosMayorcostoporRangofechas, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        //Totales Bienes Raices vendidos Por Fecha
        public IEnumerable<DashboardViewModel> TotalesBienesRaicesVendidos(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProcesosVentasBienesRaicesVendidosPorMes, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }


        //Totales  vendidos y no vendidos Por Fecha
        public IEnumerable<DashboardViewModel> TotalesVendidosNovendidos(string fechaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProcesosVendidosNoVendidosPorMes, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        //Totales compras Por Agente
        public IEnumerable<DashboardViewModel> TotalesVentasPorAgente(string fehaInicio, string fechaFin)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fehaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProcesosVentasVentasAgente, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        public IEnumerable<DashboardViewModel> DashboardProyectosconMayorCostoporDepartamento(int id)
        {
            IEnumerable<DashboardViewModel> result;
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EstadoId", id);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProyectosconMayorCostoporDepartamento, parameter, commandType: CommandType.StoredProcedure);
                return result; // Retorna la lista de resultados
            }
        }

        //FLETES
        //proyectos destino con cantidad de fletes relacionados
        public IEnumerable<DashboardViewModel> ProyectosRelacionados()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProyectosRelacionados, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }
        public IEnumerable<DashboardViewModel> ProyectosRelacionados(string fehaInicio, string fechaFin)
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fehaInicio);
                parameter.Add("@fechaFin", fechaFin);
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardFletesPorProyectoMensuales, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna la lista de resultados
            }
        }


        //Top 5 bodegas destino mas frecuentes
        public IEnumerable<DashboardViewModel> Top5BodegasDestino()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5BodegasMasFrecuentesDestino, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //Top 5 bodegas destino mas frecuentes
        public IEnumerable<DashboardViewModel> TopBodegasDestinoFill(string fechaInicio, string fechaFin)
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardFletesTopBodegasMasFrecuentesDestino, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna la lista de resultados
            }
        }


        //tasa de incidencias de fletes
        public IEnumerable<DashboardViewModel> FletesTasaIncidencias()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTasaIncidencias, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }




        //tasa de incidencias de fletes
        public IEnumerable<DashboardViewModel> TasaIncidenciasMesFletes(string fechaInicio, string fechaFin)
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fechaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTasaIncidenciasMeses, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //BIENES RAICES
        //Teerrenos Vendidos por mes(el que se ingresa)
        public IEnumerable<DashboardViewModel> TerrenosPorMees()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTerrenosVendidosPorMes, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        // cantidad de ventas realizadas por agente
        public IEnumerable<DashboardViewModel> VentasPorAgente()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardVentasPorAgente, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        // jefes de obra
        public IEnumerable<DashboardViewModel> JefesObra()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.JefesdeObra, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        public IEnumerable<DashboardViewModel> VentasBienRaiz()
    {
         List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {   result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboarVentamensualesBienesRaices, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }


        public IEnumerable<DashboardViewModel> VentasTerrenos()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboarVentamensualesTerrenos, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        public IEnumerable<DashboardViewModel> comparativobienraiz()

        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardEstadisticaVentaBienesRaices, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }


        //PROYECTO
        //Top 5 proyectos con mayor presupuesto
        public IEnumerable<DashboardViewModel> Top5ProyectosMayorPresupuesto()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5ProyectosConMayorpresuepuesto, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //proyestos por departamento sin parametro
        public IEnumerable<DashboardViewModel> ProyectosPorDepartamentosinParametro()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProyectospordepartamentoos, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //incidencias por mes
        public IEnumerable<DashboardViewModel> incidenciasPorMes()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                // Ejecuta el comando SQL y obtiene la lista de registros
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardIncidentesPorMes, commandType: CommandType.Text).ToList();
                return result; // Retorna la lista de resultados
            }
        }

        //proyectos por departamento

        public IEnumerable<DashboardViewModel> ProyectosPorDepartamento(int? id)
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@esta_Id", id); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardProyectosPorDepartamento, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }



        //PLANILLA
        //deudas por empleado
        public IEnumerable<DashboardViewModel> DeudasPorEmpleado(int? id)
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@empl_Id", id); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardDeudaPorEmpleados, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }

        public IEnumerable<DashboardViewModel> PagosJefesObra(string fehaInicio, string fechaFin)
          {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fehaInicio); // Parámetro para el ID del flete
                parameter.Add("@fechaFin", fechaFin); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardPlanillaPagosJefesObra, parameter, commandType: CommandType.StoredProcedure).ToList();
                
                return result; // Retorna el resultado
            }
        }

        public IEnumerable<DashboardViewModel> DashboardTop5Bancos()
      {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();  


                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardTop5Bancos, commandType: CommandType.StoredProcedure).ToList();

                return result; // Retorna el resultado
            }
        }

        public IEnumerable<DashboardViewModel> NominaTotalAnual(string? id)
         {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                  parameter.Add("@FechaActual", id); // Parámetro para el ID del flete

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardPlanillaTotalAnual, parameter, commandType: CommandType.StoredProcedure).ToList();
                 return result; // Retorna el resultado
            }
        }

        public IEnumerable<DashboardViewModel> DashboardPrestamoViaticosMes()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardPrestamoMesViatico, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }

        public IEnumerable<DashboardViewModel> BancosMasAcreditados(string fehaInicio, string fechaFin)
         {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@fechaInicio", fehaInicio);
                parameter.Add("@fechaFin", fechaFin);

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardPlanillaTop5BancosConMasAcreditaciones, parameter, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }
        public IEnumerable<DashboardViewModel> DashboardPrestamoMes()
        {
            List<DashboardViewModel> result = new List<DashboardViewModel>();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();

                // Ejecuta el procedimiento almacenado y obtiene la lista de detalles de flete
                result = db.Query<DashboardViewModel>(ScriptsDataBase.DashboardPrestamoMes, commandType: CommandType.StoredProcedure).ToList();
                return result; // Retorna el resultado
            }
        }




        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public ReporteViewModel Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(ReporteViewModel item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(DashboardRepository item)
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

        public RequestStatus Update(DashboardRepository item)
        {
            throw new NotImplementedException();
        }

        DashboardRepository IRepository<DashboardRepository>.Find(int? id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DashboardRepository> IRepository<DashboardRepository>.List()
        {
            throw new NotImplementedException();
        }
    }
}
