using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsPlanilla
{
    public class PagoJefeObraPlanillaViewModel
    {
        public int empl_Id { get; set; } // ID del empleado
        public string NombreCompleto { get; set; } // Nombre Completo del empleado
        public string Proyecto { get; set; } // Proyecto asignado
        public string Etapa { get; set; } // Etapa del proyecto
        public string Actividad { get; set; } // Actividad realizada
        public decimal TotalMetrosTrabajados { get; set; } // Total de metros trabajados
        public decimal PrecioPorMetro { get; set; } // Precio por metro trabajado
        public decimal SueldoTotal { get; set; } // Sueldo total
        public DateTime UltimaFechaControlCalidad { get; set; } // Última fecha de control de calidad
        public string carg_Descripcion { get; set; } // Descripción del cargo
        public decimal afag { get; set; } // Aporte de fondo de ahorro general (afag)
        public decimal? Deduccin { get; set; } // Deducción (campo mal escrito, revisar si es 'Deduccion')
        public decimal? Deduccion { get; set; } // Deducción
        public decimal? IHSS { get; set; } // Deducción IHSS
        public decimal? ImpuestoPersonal { get; set; } // Impuesto Personal
        public decimal? ISR { get; set; } // Impuesto sobre la renta
        public decimal? IVM { get; set; } // IVM (Instituto de Vivienda y Mutualidad)
        public decimal? Noje { get; set; } // Noje (Revisar si es correcto)
        public decimal? NuevaDeduEditada { get; set; } // Nueva deducción editada
        public decimal? PavelTax { get; set; } // Pavel Tax
        public decimal? RAP { get; set; } // RAP (Régimen de Aportaciones Privadas)
        public decimal? CuotaPrestamo { get; set; } // RAP (Régimen de Aportaciones Privadas)
        public decimal? Siu { get; set; } // Siu (Revisar si es correcto)
        public decimal SueldoDevengado { get; set; } // Sueldo devengado
    }
}
