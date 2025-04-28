using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.DataAccess.Repositories.RepositoryGeneral;
using SIGESPROC.DataAccess.Repositories.RepositoryPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.BusinessLogic.Services.ServicePlanilla
{
  public  class PlanillaService
    {
        private readonly CategoriaViaticoRepository _categoriaViaticoRepository;
        private readonly DeduccionRepository _deduccionRepository;
        private readonly PlanillaRepository _planillaRepository;
        private readonly PlanillaJefeCuadrillaRepository _planillaJefeCuadrillaRepository;

        public PlanillaService(
               CategoriaViaticoRepository categoriaViaticoRepository,DeduccionRepository deduccionRepository,
               PlanillaRepository planillaRepository, PlanillaJefeCuadrillaRepository planillaJefeCuadrillaRepository
             )

        {
            _categoriaViaticoRepository = categoriaViaticoRepository;
            _deduccionRepository = deduccionRepository;
            _planillaRepository = planillaRepository;
            _planillaJefeCuadrillaRepository = planillaJefeCuadrillaRepository;

        }

        #region CategoriasViaticos
        public ServiceResult ListarCategoriasViaticos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaViaticoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult BuscarCategoriaViatico(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _categoriaViaticoRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarCategoriaViatico(tbCategoriasViaticos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _categoriaViaticoRepository.Insert(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarCategoriaViatico(tbCategoriasViaticos item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _categoriaViaticoRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarCategoriaViatico(int id)
        {
            // Inicializamos el objeto ServiceResult que contendrá el resultado de la operación
            var result = new ServiceResult();

            try
            {
                // Llamamos al método Delete del repositorio para eliminar la categoría de viático y obtenemos el resultado
                var request = _categoriaViaticoRepository.Delete(id);

                // Verificamos el estado de la respuesta
                // Si CodeStatus es mayor o igual a 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                return request.CodeStatus >= 0 ? result.Ok(request) : result.Error(request);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Deducciones

        public ServiceResult BuscarDeduccion(int id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _deduccionRepository.Find(id);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
       

        public ServiceResult ActualizarDeduccion(tbDeducciones item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _deduccionRepository.Update(item);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        #endregion

        #region planilla

        public ServiceResult ListarPlanilla(int saber)
        {
            var result = new ServiceResult();
            try
            {
                var list = _planillaRepository.List(saber);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        public ServiceResult InsertarPlanilla(tbPlanillas item)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método Insert del repositorio para insertar la planilla y obtenemos el resultado
                var map = _planillaRepository.Insert(item);

                // Verificamos el estado de la respuesta
                // Si CodeStatus no es 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                if (map.CodeStatus != 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarPlanillaDetalle(string item, string item2)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método Insert del repositorio para insertar la planilla y obtenemos el resultado
                var map = _planillaRepository.InsertPlanillaDetalle(item, item2);

                // Verificamos el estado de la respuesta
                // Si CodeStatus no es 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                if (map.CodeStatus == 2)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeduccionesPorEmpleados(int id, int frec_Id)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método DeduccionesPorEmpelados del repositorio para obtener las deducciones por empleado
                var map = _planillaRepository.DeduccionesPorEmpelados(id, frec_Id);

                // Retornamos un resultado exitoso con los datos obtenidos
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPrestamosEmpleados(int id)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método DeduccionesPorEmpelados del repositorio para obtener las deducciones por empleado
                var map = _planillaRepository.ListarPrestamosEmpleados(id);

                // Retornamos un resultado exitoso con los datos obtenidos
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult VerDetallesPlanilla(int id)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método DeduccionesPorEmpelados del repositorio para obtener las deducciones por empleado
                var map = _planillaRepository.VerDetallesPlanilla(id);

                // Retornamos un resultado exitoso con los datos obtenidos
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult VerDeduccionPorEmpleadoPorPlanilla(int id, int empl_Id)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método DeduccionesPorEmpelados del repositorio para obtener las deducciones por empleado
                var map = _planillaRepository.VerDeduccionPorEmpleadoPorPlanilla(id, empl_Id);

                // Retornamos un resultado exitoso con los datos obtenidos
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarDeduccionesPorPlanilla(int id)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método DeduccionesPorEmpelados del repositorio para obtener las deducciones por empleado
                var map = _planillaRepository.BuscarDeduccionesPorPlanilla(id);

                // Retornamos un resultado exitoso con los datos obtenidos
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarDeduccionesPorPlanillaPorEmpleado(int id)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método DeduccionesPorEmpelados del repositorio para obtener las deducciones por empleado
                var map = _planillaRepository.BuscarDeduccionesPorPlanillaPorEmpleado(id);

                // Retornamos un resultado exitoso con los datos obtenidos
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPlanillaJefesObra(DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var map = _planillaJefeCuadrillaRepository.List(fecha);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListarDeduccionesJefesObra(DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var map = _planillaJefeCuadrillaRepository.ListDeducciones(fecha);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListarDeduccionesJefesObra2(DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var map = _planillaJefeCuadrillaRepository.ListDeducciones2(fecha);
                return result.Ok(map);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarPlanillaDetalleJefeObra(string item, DateTime fecha)
        {
            // Creamos un objeto ServiceResult para almacenar el resultado de la operación
            var result = new ServiceResult();
            try
            {
                // Llamamos al método Insert del repositorio para insertar la planilla y obtenemos el resultado
                var map = _planillaJefeCuadrillaRepository.InsertPlanillaDetalle(item, fecha);

                // Verificamos el estado de la respuesta
                // Si CodeStatus no es 0, retornamos un resultado exitoso
                // De lo contrario, retornamos un resultado de error
                if (map.CodeStatus == 2)
                {
                    return result.Ok(map);
                }
                else
                {
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, retornamos el error en el objeto result
                return result.Error(ex.Message);
            }
        }

        #endregion

    }
}
