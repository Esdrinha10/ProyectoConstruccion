using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGESPROC.BusinessLogic.Services.GeneralService;
using SIGESPROC.BusinessLogic.Services.ServicePlanilla;
using SIGESPROC.Common.Models.ModelsPlanilla;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGESPROC.BusinessLogic;
using SIGESPROC.DataAccess;
using System.Globalization;
using Newtonsoft.Json;

namespace SIGESPROC.API.Controllers.ControllersPlanilla
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanillaController : ControllerBase
    {
        private readonly PlanillaService _planillaService;
        private readonly FrecuenciaService _frecuenciaService;
        private readonly PrestamoService _prestamoService;
        private readonly DeduccionService _deduccionService;
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public PlanillaController(PlanillaService planillaService, IMapper mapper, GeneralService generalService, FrecuenciaService frecuenciaService, PrestamoService prestamoService,
                                  DeduccionService deduccionService)
        {
            _planillaService = planillaService;
            _frecuenciaService = frecuenciaService;
            _prestamoService = prestamoService;
            _deduccionService = deduccionService;
            _mapper = mapper;
            _generalService = generalService;
        }


        [HttpGet("Listar")]
        public IActionResult ListarPlanilla()
        {
            var response = _planillaService.ListarPlanilla(3);

            return Ok(response.Data);
        }

        public class PlanillaRequest
        {
            public List<PlanillaViewModel> planillaViewModel { get; set; }
            public List<PagoPlanillaEmpleadosViewModel> planillaEmpleado { get; set; }
        }

        public class PlanillaJefeRequest
        {
            public List<PlanillaViewModel> planillaViewModel { get; set; }

            public string DetalleJefes { get; set; }
            //public List<InsertPlanillaDetJefeObraViewModel> planillaJefeViewModel { get; set; }

        }

        // Método para insertar una nueva planilla
        [HttpPost("Insertar")]
        public IActionResult Create([FromBody] PlanillaRequest contenedor)
        {
            List<PlanillaViewModel> planillaViewModel = contenedor.planillaViewModel;

            DateTime fechapago = DateTime.Parse(planillaViewModel[0].plan_FechaPago);
            DateTime Fechadt = fechapago;
            var day = Fechadt.DayOfWeek.ToString();

            var serviceResult = new ServiceResult();
            RequestStatus requestStatus = new RequestStatus();

            // Verificar si la fecha de pago es domingo
            if (day == "Sunday")
            {
                requestStatus.CodeStatus = 500;
                serviceResult.Message = "55";
                return Ok(serviceResult);
            }

            // Asignar "N/A" a observaciones si está vacío
            if (string.IsNullOrEmpty(planillaViewModel[0].plan_Observaciones))
            {
                planillaViewModel[0].plan_Observaciones = "N/A";
            }

            var planillas = _planillaService.ListarPlanilla(2);
            

            //var frecuencia = _frecuenciaService.BuscarFrecuencia((int)planillaViewModel[0].frec_Id);
            //int diasFrec = int.Parse(frecuencia.Data.frec_NumeroDias);
            //string fechafinperiod = "";

            //if (planillas.Data == null)
            //{
            //    fechafinperiod = DateTime.Parse(planillaViewModel[0].plan_FechaPago).Date.AddDays(-diasFrec).ToString();
            //}

            //else
            //{
            //    if (planillas.Data != null)
            //    {
            //        foreach (var item in planillas.Data)
            //        {
            //            if (item.plan_FechaPago != null)
            //            {
            //                fechafinperiod = item.plan_FechaPago;
            //            }
            //            else
            //            {
            //                fechafinperiod = fechafinperiod = DateTime.Parse(planillaViewModel[0].plan_FechaPago).Date.AddDays(-diasFrec).ToString();
            //            }
                        
            //        }
            //    }
            //}

            var modelo = new tbPlanillas
            {
                plan_FechaPeriodoFin = DateTime.Parse(planillaViewModel[0].plan_FechaPeriodoFin),
                plan_FechaPago = DateTime.Parse(planillaViewModel[0].plan_FechaPago),
                plan_Observaciones = planillaViewModel[0].plan_Observaciones,
                plan_PlanillaJefes = planillaViewModel[0].plan_PlanillaJefes,
                frec_Id = planillaViewModel[0].frec_Id,
                usua_Creacion = planillaViewModel[0].usua_Creacion,
                plan_FechaCreacion = DateTime.Now
            };

            var response = _planillaService.InsertarPlanilla(modelo);

            var outputParams = response.Data.Message.Split('|');
            string usuario = outputParams[0];
            DateTime fechaPago = DateTime.Parse(outputParams[1]);
            DateTime fechaEmision = DateTime.Parse(outputParams[2]);
            int numNomina = int.Parse(outputParams[3]);
            int plan_Id = int.Parse(outputParams[6]);

            IEnumerable<PagoPlanillaEmpleadosViewModel> nuevo = (IEnumerable<PagoPlanillaEmpleadosViewModel>)contenedor.planillaEmpleado;

            var prestamosJson = JsonConvert.SerializeObject(
                nuevo.Select(pres => pres.prestamos.Select(pre =>
                {
                    pre.pres_FechaModificacion = DateTime.Now;
                    pre.usua_Modificacion = 3;
                    return pre;
                }))
            );
            var deduccionesJson = JsonConvert.SerializeObject(contenedor.planillaEmpleado.Select(empl => empl.deducciones));
            var deduccionesJsonCheck = deduccionesJson.Replace(@"[{""empl_Id""", @"{""empl_Id""").Replace(@"""dedu_Estado"":null}]", @"""dedu_Estado"":null}");
            var prestamosJsonCheck = prestamosJson.Replace(@"[{""pres_Id""", @"{""pres_Id""").Replace(@"""pres_Estado"":null}]", @"""pres_Estado"":null}");

            var planillaDetalleLista = nuevo.Select(empl =>
            {
                empl.usua_Creacion = planillaViewModel[0].usua_Creacion;
                empl.plan_Id = int.Parse(outputParams[6]);
                empl.empl_FechaCreacion = DateTime.Now;
                empl.deducciones = null;
                empl.prestamos = null;

                return empl;

            }).ToList();
            var planillaDetalleJson = JsonConvert.SerializeObject(planillaDetalleLista);
            var responseprestamos = _prestamoService.InsertPrestamosPlanilla(prestamosJsonCheck);
            var responseplde = _planillaService.InsertarPlanillaDetalle(planillaDetalleJson, deduccionesJsonCheck);



            return Ok(response);
        }


        [HttpPost("ListadoPlanilla")]
        public IActionResult ListarEmpleadosPlanilla(ListarEmpleadosPlanillaViewModel planilla)
        {
            string fechaModificada = planilla.fecha;
            DateTime FechaCrea = DateTime.Now;

            var frecuencia = _frecuenciaService.BuscarFrecuencia(planilla.frecid);
            int diasFrec = int.Parse(frecuencia.Data.frec_NumeroDias);
            var response = _generalService.Lisst();

            IEnumerable<PagoPlanillaEmpleadosViewModel> empleados = response.Data;
            IEnumerable<PagoPlanillaEmpleadosViewModel> empleadosFiltrados;

            if (planilla.jefeplani == false)
            {
                empleadosFiltrados = empleados.Where(empl => empl.carg_Id != 1 && empl.frec_NumeroDias == diasFrec && (empl.empl_Estado = true)).OrderBy(empl => empl.cargo); ;
            }
            else
            {
                empleadosFiltrados = empleados.Where(empl => empl.carg_Id == 1 && (empl.empl_Estado = true)).OrderBy(empl => empl.frec_NumeroDias); ;
            }


            var empleadosPlanilla = empleadosFiltrados.Select(empl =>
            {
                IEnumerable<DeduccionViewModel> Deducciones = _planillaService.DeduccionesPorEmpleados(empl.empl_Id, planilla.frecid).Data;
                empl.deducciones = Deducciones;
                empl.totalDeducido = Deducciones.Sum(dedu => dedu.totalPorDeduccion);

                return empl;
            }).ToList();

            DateTime FechaActual = DateTime.Now;
            double noDias;

            var planillas = _planillaService.ListarPlanilla(3);

            IEnumerable<tbPlanillas> planillaprew = planillas.Data;

            IEnumerable<tbPlanillas> planillaFiltrada = planillaprew.Where(pl => pl.frec_Id == planilla.frecid).ToList();

            DateTime fechapago = DateTime.Parse("08/07/2024");

            foreach (var item in planillaFiltrada)
            {
                fechapago = item.plan_FechaPago;
                break;
            }

            if (fechapago.Date >= DateTime.Parse(planilla.fecha).Date)
            {
                noDias = (fechapago.Date - DateTime.Parse(planilla.fecha).Date).TotalDays;
            }
            else
            {
                noDias = (DateTime.Parse(planilla.fecha).Date - fechapago.Date).TotalDays;
            }

            int codigo = 1;

            empleadosPlanilla = empleadosFiltrados.Select(empl =>
            {
                var prestamos = _planillaService.ListarPrestamosEmpleados(empl.empl_Id);

                IEnumerable<PrestamoViewModel> prestamo = prestamos.Data;
                IEnumerable<PrestamoViewModel> prestamoFiltrado = prestamo.Where(pres => pres.pres_FechaPrimerPago.Date <= DateTime.Parse(planilla.fecha).Date && pres.frec_NumeroDias <= noDias);

                empl.codigo = codigo;

                codigo = codigo + 1;

                empl.prestamos = prestamoFiltrado;
                empl.totalPrestamos = (int)prestamoFiltrado.Sum(pr => pr.cuotaSiguiente);

                return empl;
            }).ToList();

            return Ok(empleadosPlanilla);
        }

        [HttpGet("VerDetallesPlanilla/{plan_Id}")]
        public IActionResult VerDetallesPlanilla(int plan_Id)
        {
            var empleados = _planillaService.VerDetallesPlanilla(plan_Id);

            IEnumerable<PagoPlanillaEmpleadosViewModel> nuevosempleados = empleados.Data;

            nuevosempleados.Select(empl =>
            {
                empl.deducciones = _planillaService.VerDeduccionPorEmpleadoPorPlanilla(plan_Id, empl.empl_Id).Data;

                return empl;
            }).ToList();

            return Ok(nuevosempleados);
        }

        [HttpGet("BuscarDeduccionesPorPlanilla/{plan_Id}")]
        public IActionResult BuscarDeduccionesPorPlanilla(int plan_Id)
        {
            var response = _planillaService.BuscarDeduccionesPorPlanilla(plan_Id);

            return Ok(response.Data);
        }

        [HttpGet("BuscarDeduccionesPorPlanillaPorEmpleado/{plan_Id}")]
        public IActionResult BuscarDeduccionesPorPlanillaPorEmpleado(int plan_Id)
        {
            var response = _planillaService.BuscarDeduccionesPorPlanillaPorEmpleado(plan_Id);

            return Ok(response.Data);
        }

        //// Método para buscar deducciones por empleados
        //[HttpGet("DeduccionesPorEmpelados/{id}")]
        //public IActionResult BuscarNCategoriaViatico(int id)
        //{
        //    var response = _planillaService.DeduccionesPorEmpleados(id);
        //    decimal tdeducido = 0;
        //    decimal salario = 0;

        //    foreach (var item in response.Data)
        //    {
        //        tdeducido += item.totalPorDeduccion;
        //        salario = item.empl_Salario;
        //    }

        //    decimal salariototal = salario - tdeducido;

        //    foreach (var item in response.Data)
        //    {
        //        item.totalDeducido = tdeducido;
        //        item.sueldoTotal = salariototal;
        //    }

        //    return Ok(response.Data);
        //}

        [HttpGet("ListarPlanillaJefesObras/{fecha}")]
        public IActionResult ListarViaticosEncabezados(DateTime fecha)
        {
            var response = _planillaService.ListarPlanillaJefesObra(fecha);
            return Ok(response.Data);
        }
            
        [HttpGet("ListarDeduccionesJefesObras/{fecha}")]
        public IActionResult ListardeduccionesJefe(DateTime fecha)
        {
            var response = _planillaService.ListarDeduccionesJefesObra(fecha);
            return Ok(response.Data);
        }
        [HttpGet("ListarDeduccionesJefesObras2/{fecha}")]
        public IActionResult ListardeduccionesJefe2(DateTime fecha)
        {
            var response = _planillaService.ListarDeduccionesJefesObra2(fecha);
            return Ok(response.Data);
        }
        [HttpPost("InsertarJefe/{fecha}")]
        public IActionResult CreateJefe(DateTime fecha,[FromBody] PlanillaJefeRequest contenedor)
        {
            List<PlanillaViewModel> planillaViewModel = contenedor.planillaViewModel;

            DateTime fechapago = DateTime.Parse(planillaViewModel[0].plan_FechaPago);
            DateTime Fechadt = fechapago;
            //var day = Fechadt.DayOfWeek.ToString();

            //var serviceResult = new ServiceResult();
            //RequestStatus requestStatus = new RequestStatus();

            // Verificar si la fecha de pago es domingo
            //if (day == "Sunday")
            //{
            //    requestStatus.CodeStatus = 500;
            //    serviceResult.Message = "55";
            //    return Ok(serviceResult);
            //}

            // Asignar "N/A" a observaciones si está vacío
            if (string.IsNullOrEmpty(planillaViewModel[0].plan_Observaciones))
            {
                planillaViewModel[0].plan_Observaciones = "N/A";
            }

            //var planillas = _planillaService.ListarPlanilla(2);
            var modelo = new tbPlanillas
            {
                plan_FechaPeriodoFin = DateTime.Parse(planillaViewModel[0].plan_FechaPeriodoFin),
                plan_FechaPago = DateTime.Parse(planillaViewModel[0].plan_FechaPago),
                plan_Observaciones = planillaViewModel[0].plan_Observaciones,
                plan_PlanillaJefes = planillaViewModel[0].plan_PlanillaJefes,
                frec_Id = planillaViewModel[0].frec_Id,
                usua_Creacion = planillaViewModel[0].usua_Creacion,
                plan_FechaCreacion = DateTime.Now
            };

            var response = _planillaService.InsertarPlanilla(modelo);

            var outputParams = response.Data.Message.Split('|');
            string usuario = outputParams[0];
            DateTime fechaPago = DateTime.Parse(outputParams[1]);
            DateTime fechaEmision = DateTime.Parse(outputParams[2]);
            int numNomina = int.Parse(outputParams[3]);
            int plan_Id = int.Parse(outputParams[6]);

            IEnumerable<InsertPlanillaDetJefeObraViewModel> nuevo = JsonConvert.DeserializeObject<IEnumerable<InsertPlanillaDetJefeObraViewModel>>(contenedor.DetalleJefes);


            var planillaDetalleLista = nuevo.Select(empl =>
            {
                empl.usua_Creacion = planillaViewModel[0].usua_Creacion;
                empl.plan_Id = int.Parse(outputParams[6]);
                empl.empl_FechaCreacion = DateTime.Now;
                return empl;

            }).ToList();
            //var planillaDetalleJson = contenedor.DetalleJefes;

            var planillaDetalleJson = JsonConvert.SerializeObject(planillaDetalleLista);


            var response2 = _planillaService.InsertarPlanillaDetalleJefeObra(planillaDetalleJson, fecha);

            return Ok(response2);
        }


    }
}