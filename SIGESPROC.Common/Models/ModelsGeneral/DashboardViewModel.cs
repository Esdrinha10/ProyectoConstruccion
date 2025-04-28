using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.Common.Models.ModelsGeneral
{

    public class DashboardViewModel
    {
        //top 5 porveedores mas cotizados
        public int prov_Id { get; set; }
        public string prov_Descripcion { get; set; }
        public int numeroDeCotizaciones { get; set; }

        public string banco{ get; set; }
        public int numeroAcreditaciones{ get; set; }

        //totales compras totales por mes
        public int año { get; set; }

        public int mes { get; set; }

        public string meses { get; set; }

        public double totalCompraMes { get; set; }
        public DateTime? fechaPrimeraCompraMes { get; set; }
        public int numeroCompras { get; set; }
        public DateTime? fechaUltimaCompraMes { get; set; }

        //top 5 articulos generales mas vendidos
        //xD
        public string articulo { get; set; }
        public double totalCompra { get; set; }
        public string tipoArticulo { get; set; }



        //FLETES
        //proyectos relacionados
        public int proy_Id { get; set; }
        public string proy_Nombre { get; set; }

        public decimal presupuestoTotal { get; set; }
        public double totalFletesDestinoProyecto { get; set; }

       
        public string esta_Codigo { get; set; }
        public int esta_Id { get; set; }
        public string ciud_Descripcion { get; set; }
        public int Cantidad_Proyectos { get; set; }
        public int cantidad { get; set; }
        public string esta_Nombre { get; set; }


        //bodegas destino top 5
        public int codigo { get; set; }
        public string Destino { get; set; }
        public int numeroFletes { get; set; }

        //tasa de incidencias
        public int totalFletes { get; set; }
        public int totalFletesConIncidencias { get; set; }
        public double tasaIncidenciasPorcentaje { get; set; }
        public int incidenciasTotales { get; set; }
        public int numeroFletesMensuales { get; set; }
        public int numeroIncidenciasMensuales { get; set; }
        public string rangoTasaIncidencias { get; set; }
        public int anio { get; set; }



        //BIENES RAICES
        public double totalVentasMes { get; set; }
        public int cantidadVendidosMes { get; set; }




        //Top 5 agentes de bienes raices con mas ventas

        public int agen_Id { get; set; }
        public float cantidadVendida { get; set; }
        public string agen_NombreCompleto { get; set; }
        //terrenos vendidos por el mes
        public string nombreTerreno { get; set; }
        public double precioFinalVenta { get; set; }
        public DateTime fechaVenta { get; set; }
        public string nombreAgente { get; set; }

        //mes y anio tambien se usan


        //porcentaje de ventas de bienes raices vendidos y no vendidos
        public int totalBienesRaices { get; set; }
        public int totalVendidos { get; set; }
        public int totalNoVendidos { get; set; }
        public double porcentajeVendidos { get; set; }
        public double porcentajeNoVendidos { get; set; }





        //PROYECTOS
        //Top 5 proyectos con mayores presupuestos

        //pory_Id y proy_Nombre se usa tambien
        //public double presupuestoTotal { get; set; }


        ////proyectos ejecutados por departamento filtrado por id de departamento
        //public string ciud_Descripcion { get; set; }
        //public string esta_Nombre { get; set; }
        //public string esta_Codigo { get; set; }
        //public int esta_Id { get; set; }
        public string pais_Nombre { get; set; }
        //se usan proy_Nombre y proy_Id tambien


        //Incidencias por actividad mensual, con costos y total de incidencias

        //anio y mes se usan
        public double costoIncidencia { get; set; }
        public int incidenciasMensuales { get; set; }



        //PLANILLA
        //deudas por empleado filtrado por id de eempleado
        public int empl_Id { get; set; }
        public string empleado { get; set; }
        public double deudaTotal { get; set; }

        public double totalM { get; set; }
        public int totalMC { get; set; }
        //Top 5 bancos



        //Prestamo viatico 
        public double totalGastado { get; set; }
        public double montoEstimado { get; set; }

        public int cantidadViaticos { get; set; }

        //Prestamo Mes Dia
        public int dia { get; set; }

        public int totalPrestamos { get; set; }

        public double totalMontoPrestado { get; set; }

        public double totalSaldoRestante { get; set; }
        public int totalIncidencias { get; set; }
        public decimal totalCostoIncidencias { get; set; }
        public int cantidadEnvios { get; set; }



        public string proyecto { get; set; }

        public decimal TotalCostoProyecto { get; set; }






    }
}