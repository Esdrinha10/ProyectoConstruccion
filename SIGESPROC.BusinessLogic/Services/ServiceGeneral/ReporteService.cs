using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServiceGeneral
{
  public  class ReporteService
     {
        private readonly ReporteRepository _reporteRepository;

        public ReporteService(
               ReporteRepository reporteRepository
             )

        {
            _reporteRepository = reporteRepository;

        }

        #region ReporteTerrenoFechaCreacion
        public ServiceResult ReporteTerrenoFechaCreacion(string FechaInicio, string FechaFinal)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteTerrenoFechaCreacion(FechaInicio, FechaFinal);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteTerrenosPorEstadoProyecto(string FechaInicio, string FechaFinal, bool tipo)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteTerrenosPorEstadoProyecto(FechaInicio, FechaFinal, tipo);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteVentasPorEmpresa(int empresa)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteVentasPorEmpresa(empresa);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteEmpleadoPorEstado(bool estado)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteEmpleadoPorEstado(estado);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteFletesPorFecha(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteFletesPorFecha(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteHistorialCotizaciones(string fehaInicio, string fechaFin, int id, bool todo)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteHistorialCotizaciones(fehaInicio, fechaFin,id,todo);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteComprasRealizadas(string fehaInicio, string fechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteComprasRealizadas(fehaInicio, fechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteComparacionMonetaria(int proy_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteComparacionMonetaria(proy_Id);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteCotizacionesPorRangoPrecios(int tipo, string precio, bool mostrar)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteCotizacionesPorRangoPrecios(tipo,precio,mostrar);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteInsumosBodega(string fechainicio, string fechafin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteInsumosBodega(fechainicio,fechafin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteInsumosAProyecto(string fechainicio, string fechafin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteInsumosAProyecto(fechainicio, fechafin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteHistorialPagosPorProyecto(string fechainicio, string fechafin, int proy_id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteHistorialPagosPorProyecto(fechainicio, fechafin,proy_id);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteComparativoProductos(int tipo)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteComparativoProductos(tipo);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReportecomprasPendientesEnvio(string fechainicio, string fechafin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReportecomprasPendientesEnvio(fechainicio, fechafin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteProgresoActividades(int proy_id,string fechainicio, string fechafin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteProgresoActividades(proy_id,fechainicio, fechafin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReportePorUbicacion(Boolean ubicacion)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReportePorUbicacion(ubicacion);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult EstadisticasFletes_Comparacion(int flen_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.EstadisticasFletes_Comparacion(flen_Id);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteProcesoVenta(int tipo, bool estado)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteProcesoVenta(tipo,estado);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult EstadisticasFletes_Llegada(string FechaInicio, string FechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.EstadisticasFletes_Llegada(FechaInicio, FechaFin);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteInsumosTransportadosPorActividad(string FechaInicio, string FechaFin,int ActividadId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteInsumosTransportadosPorActividad(FechaInicio, FechaFin, ActividadId);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ReporteInsumosUltimoPrecio(string numeroCompra)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteInsumosUltimoPrecio(numeroCompra);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult ReporteArticulosActividades(int id,int eleccion)
        {
            var result = new ServiceResult();
            try
            {
                var list = _reporteRepository.ReporteArticuloActividades(id, eleccion);
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
