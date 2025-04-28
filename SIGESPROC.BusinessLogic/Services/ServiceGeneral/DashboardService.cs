using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceGeneral
{
   public class DashboardService
    {
        private readonly DashboardRepository _dashboardRepository;

        // Constructor que recibe repositorios de encabezado y detalle de fletes
        public DashboardService(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }



        #region insumos

        public ServiceResult DashboardTop5Proveedores()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5PorveedoresCotizados(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult DashboardTop5ArticulosCompradoss()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5ArticulosComprados(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        //clase de tipo service result que devuelve los proveedores
        public ServiceResult Top5ProveedoresMasComprados(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5ProveedoresMasComprados(fehaInicio, fechaFin); // Llama al repositorio para obtener la lista de proveedores
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult Top5DestinosComprasEnviados(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5DestinosCompraEnviados(fehaInicio, fechaFin); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult DashboardTop5ArticulosporcadaCompradoss()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5ArticulosporcadaunoComprados(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult DashboardTotalesComprasMensuales()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TotalesComprasMensuales(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult DashboardTotalesComprasPorFecha(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TotalesComprasPorFecha(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult DashboardTotalTerrenosVendidos(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TotalesTerrenosVendidos(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult DashboardProyectosIncidenciasPorrangofechas(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.DashboardProyectosIncidenciasPorrangofechas(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult DashboardProyectosMayorcostoporRangofechas(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.DashboardProyectosMayorcostoporRangofechas(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult DashboardTotalBienesRaicesVendidos(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TotalesBienesRaicesVendidos(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult DashboardTotalVendidosNovendidos(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TotalesVendidosNovendidos(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult DashboardVentasPorAgente(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TotalesVentasPorAgente(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult DashboardProyectosconMayorCostoporDepartamento(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.DashboardProyectosconMayorCostoporDepartamento(id);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        #endregion



        #region fletes

        public ServiceResult ProyectosRelacionados()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.ProyectosRelacionados(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult ProyectosRelacionados(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.ProyectosRelacionados(fehaInicio, fechaFin); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult Top5BodegasDestino()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5BodegasDestino(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }
        public ServiceResult Top5BodegasDestino(string fechaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TopBodegasDestinoFill(fechaInicio, fechaFin); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult FletesTasaIncidencias()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.FletesTasaIncidencias(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult TasaIncidenciasMesFletes(string fechaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TasaIncidenciasMesFletes(fechaInicio, fechaFin); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        #endregion


        #region bienes raices
        public ServiceResult VentasPorAgente()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.VentasPorAgente(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }
        public ServiceResult VentasBienRaiz()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.VentasBienRaiz(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }
        public ServiceResult VentasTerrenos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.VentasTerrenos(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult TerrenosPorMees()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.TerrenosPorMees(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult comparativoBienraiz()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.comparativobienraiz(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        #endregion



        #region proyectos
        public ServiceResult Top5ProyectosMayorPresupuesto()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.Top5ProyectosMayorPresupuesto(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult proyectospordepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.ProyectosPorDepartamentosinParametro(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult incidenciaspormes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.incidenciasPorMes(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }


        public ServiceResult ProyectosPorDepartamentoteDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _dashboardRepository.ProyectosPorDepartamento(id); // Llama al repositorio para buscar el detalle del flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }



        #endregion


        #region planilla

        public ServiceResult DeudasPorEmpleado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _dashboardRepository.DeudasPorEmpleado(id); // Llama al repositorio para buscar el detalle del flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult PagosJefesDeObra(string fehaInicio, string fechaFin)
         {
            var result = new ServiceResult();
            try
            {
                var map = _dashboardRepository.PagosJefesObra(fehaInicio, fechaFin); // Llama al repositorio para buscar el detalle del flete por su ID
                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult DashboardTop5Bancos()
        {
            var result = new ServiceResult();
            try
            {

                var map = _dashboardRepository.DashboardTop5Bancos(); // Llama al repositorio para buscar el detalle del flete por su ID

                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }


        public ServiceResult PlanillaTotalAnual(string id)
         {
            var result = new ServiceResult();
            try
            {
                var map = _dashboardRepository.NominaTotalAnual(id); // Llama al repositorio para buscar el detalle del flete por su ID
 return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult DashboardPrestamoViaticosMes()
        {
            var result = new ServiceResult();
            try
            {
                var map = _dashboardRepository.DashboardPrestamoViaticosMes(); // Llama al repositorio para buscar el detalle del flete por su ID

                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }


        public ServiceResult DashboardPrestamoMes(){
             var result = new ServiceResult();
            try
            {
                 var map = _dashboardRepository.DashboardPrestamoMes(); // Llama al repositorio para buscar el detalle del flete por su ID
         return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }

        public ServiceResult BancosMasAcreditados(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var map = _dashboardRepository.BancosMasAcreditados(fehaInicio, fechaFin) ; // Llama al repositorio para buscar el detalle del flete por su ID

                return result.Ok(map); // Retorna el resultado exitoso con el detalle del flete encontrado
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }
        #endregion


        public ServiceResult JefesObra()
        {
            var result = new ServiceResult();
            try
            {
                var list = _dashboardRepository.JefesObra(); // Llama al repositorio para obtener la lista de fletes
                return result.Ok(list); // Retorna el resultado exitoso con la lista de fletes
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna un error con el mensaje de la excepción
            }
        }
    }
}
