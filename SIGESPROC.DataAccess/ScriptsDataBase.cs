using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess
{
    public class ScriptsDataBase
    {
        #region Acceso

        #region Usuario
        public static string Actualizar_Usuario = "[Acce].[SP_Usuario_Actualizar]";
        public static string Buscar_Usuario = "[Acce].[SP_Usuario_Buscar]";
        public static string Eliminar_Usuario = "[Acce].[SP_Usuario_Eliminar]";
        public static string InicioSesion_Usuario = "[Acce].[SP_Usuario_InicioSesion]";
        public static string Insertar_Usuario = "[Acce].[SP_Usuario_Insertar]";
        public static string Reestablecer_Usuario = "[Acce].[SP_Usuario_Reestablecer]";
        public static string Listar_Usuarios = "[Acce].[SP_Usuarios_Listar]";
        public static string Listar_UsuariosNotificaciones = "[Acce].[SP_UsuariosPorNotificacionesActivos_Listar]";
        public static string RestablecerFlutter = "[Acce].[SP_Usuario_ReestablecerFlutter]";
        public static string RestablecerCorreo = "[Gral].[SP_CorreoEmpleado_Actualizar]";
        public static string InsertarCodigoVerificacion = "[Acce].[SP_Usuario_IngresarCodigoRestablecer]";
        public static string VerificarCodigoReestablecer = "[Acce].[SP_Usuario_VerificarCodigoRestablecer]";

        #endregion

        #region Pantalla
        public static string Actualizar_Pantalla = "[Acce].[SP_Pantalla_Actualizar]";
        public static string Buscar_Pantalla = "[Acce].[SP_Pantalla_Buscar]";
        public static string Eliminar_Pantalla = "[Acce].[SP_Pantalla_Eliminar]";
        public static string Insertar_Pantalla = "[Acce].[SP_Pantalla_Insertar]";
        public static string Listar_Pantallas = "[Acce].[SP_Pantallas_Listar]";
        public static string Listar_PantallasPorRol = "[Acce].[SP_PantallasAgrupadasPorRoles_Listar]";
        #endregion

        #region Roles
        public static string ListarRoles = "Acce.SP_Roles_Listar";
        public static string BuscarRol = "Acce.SP_Rol_Buscar";
        public static string InsertarRol = "Acce.SP_Rol_Insertar";
        public static string InsertarRol2 = "Acce.SP_Rol2_Insertar";
        public static string ActualizarRol = "Acce.SP_Rol_Actualizar";
        public static string EliminarRol = "Acce.SP_Rol_Eliminar";
        #endregion

        #region PantallasPorRoles
        public static string ListarPantallasPorRoles = "Acce.SP_PantallasPorRoles_Listar";
        public static string BuscarPantallaPorRol = "Acce.SP_PantallaPorRol_Buscar";
        public static string BuscarPantallaPorRol2 = "Acce.SP_PantallaPorRol2_Buscar";
        public static string InsertarPantallaPorRol = "Acce.SP_PantallaPorRol_Insertar";
        public static string ActualizarPantallaPorRol = "Acce.SP_PantallaPorRol_Actualizar";
        public static string EliminarPantallaPorRol = "Acce.SP_PantallaPorRol_Eliminar";
        #endregion

        #endregion

        #region Flete

        #region Flete Encabezado
        public static string ListarFletes = "Flet.SP_FletesEncabezado_Listar";
        public static string InsertarFlete = "Flet.SP_FleteEncabezado_Insertar";
        public static string BuscarFlete = "Flet.SP_FleteEncabezado_Buscar";
        public static string EliminarFlete = "Flet.SP_FleteEncabezado_Eliminar";
        public static string ActualizarFlete = "[Flet].[SP_FleteEncabezado_Actualizar]";

        #endregion

        #region Flete Control Calidad
        public static string ActualizarFleteControlCalidad = "[Flet].[SP_FleteControlCalidad_Actualizar]";
        public static string BuscarFleteControlCalidad = "[Flet].[SP_FleteControlCalidad_Buscar]";
        public static string EliminarFleteControlCalidad = "[Flet].[SP_FleteControlCalidad_Eliminar]";
        public static string InsertarFleteControlCalidad = "[Flet].[SP_FleteControlCalidad_Insertar]";
        public static string ListarFletesControlCalidades = "[Flet].[SP_FletesControlCalidades_Listar]";
        public static string BuscarFleteControlCalidadIncidencias = "[Flet].[SP_FletesControlCalidadesIncidencias_Listar]";
        #endregion



        #region FletesDetalle
        public static string ActualizarFleteDetalle = "[Flet].[SP_FletesDetalle_Actualizar]";
        public static string EliminarFleteDetalle = "[Flet].[SP_FletesDetalle_Eliminar]";
        public static string InsertarFleteDetalle = "[Flet].[SP_FletesDetalle_Insertar]";
        public static string ListarFleteDetalle = "[Flet].[SP_FletesDetalle_Listar]";
        public static string ListarFleteDetalles = "[Flet].[SP_FletesDetalles_Listar]";
        public static string ListarInsumoPorActividadEtapaFlitrado = "[Proy].[SP_InsumosPorActividades_Buscar]";
        public static string ListarInsumoPorActividadEtapa = "[Proy].[SP_InsumosPorActividades_Listar]";
        public static string ListarquiposPorActividadEtapa = "[Proy].[SP_EquiposSeguridadPorActividades_Listar]";

        #endregion



        #region Incidencia Por Flete
        public static string ActualizarIncidenciaPorFlete = "[Flet].[SP_IncidenciaPorFlete_Actualizar]";
        public static string BuscarIncidenciaPorFlete = "[Flet].[SP_IncidenciaPorFlete_Buscar]";
        public static string EliminarIncidenciaPorFlete = "[Flet].[SP_IncidenciaPorFlete_Eliminar]";
        public static string InsertarIncidenciaPorFlete = "[Flet].[SP_IncidenciaPorFlete_Insertar]";
        public static string ListarIncidenciasPorFletes = "[Flet].[SP_IncidenciasPorFletes_Listar]";
        #endregion



        #endregion


        #region Generales

        #region UnidadesDeMedida
        public static string ListarUnidadesDeMedidas = "Gral.SP_UnidadesMedida_Listar";
        public static string BuscarUnidadDeMedida = "Gral.SP_UnidadMedida_Buscar";
        public static string InsertarUnidadDeMedida = "Gral.SP_UnidadMedida_Insertar";
        public static string ActualizarUnidadDeMedida = "Gral.SP_UnidadMedida_Actualizar";
        public static string EliminarUnidadDeMedida = "Gral.SP_UnidadMedida_Eliminar";
        #endregion

        #region TasasCambios
        public static string ListarTasaCambios = "Gral.SP_TasasCambio_Listar";
        public static string ObtenerConversionTasasCambio = "Gral.SP_TasasCambio_ObtenerConversiones";
        public static string BuscarTasaCambio = "Gral.SP_TasaCambio_Buscar";
        public static string InsertarTasaCambio = "Gral.SP_TasaCambio_Insertar";
        public static string ActualizarTasaCambio = "Gral.SP_TasaCambio_Actualizar";
        public static string EliminarTasaCambio = "Gral.SP_TasaCambio_Eliminar";
        #endregion

        #region Tipo Proyecto
        public static string Eliminar_TipoProyecto = "Gral.SP_TipoProyecto_Eliminar";
        public static string Buscar_TipoProyecto = "Gral.SP_TipoProyecto_Buscar";
        public static string Insertar_TipoProyecto = "Gral.SP_TipoProyecto_Insertar";
        public static string Listar_TipoProyectos = "Gral.SP_TiposProyecto_Listar";
        public static string Actualizar_TipoProyecto = "Gral.SP_TipoProyecto_Actualizar";
        #endregion

        #region Clientes
        public static string ListarClientes = "Gral.SP_Clientes_Listar";
        public static string BuscarClientes = "Gral.SP_Cliente_Buscar";
        public static string InsertarClientes = "Gral.SP_Cliente_Insertar";
        public static string ActualizarClientes = "Gral.SP_Cliente_Actualizar";
        public static string EliminarClientes = "Gral.SP_Cliente_Eliminar";
        #endregion

        #region Ciudades
        public static string ListarCiudades = "Gral.SP_Ciudades_Listar";
        public static string BuscarCiudades = "Gral.SP_Ciudad_Buscar";
        public static string InsertarCiudades = "Gral.SP_Ciudad_Insertar";
        public static string ActualizarCiudades = "Gral.SP_Ciudad_Actualizar";
        public static string EliminarCiudades = "Gral.SP_Ciudad_Eliminar";
        public static string DropDownCiudades = "Gral.SP_Ciudad_DropDown";
        public static string CiudadPorEstado = "[Gral].[SP_CiudadPorEstado]";

        #endregion

        #region Paises
        public static string ListarPaises = "Gral.SP_Paises_Listar";
        public static string BuscarPais = "Gral.SP_Pais_Buscar";
        public static string InsertarPais = "Gral.SP_Pais_Insertar";
        public static string ActualizarPais = "Gral.SP_Pais_Actualizar";
        public static string EliminarPais = "Gral.SP_Pais_Eliminar";
        public static string DropDownPaises = "Gral.SP_Pais_DropDown";
        #endregion

        #region Niveles
        public static string ListarNiveles = "Gral.SP_Niveles_Listar";
        public static string BuscarNivel = "Gral.SP_Nivel_Buscar";
        public static string InsertarNivel = "Gral.SP_Nivel_Insertar";
        public static string ActualizarNivel = "Gral.SP_Nivel_Actualizar";
        public static string EliminarNivel = "Gral.SP_Nivel_Eliminar";
        #endregion

        #region EstadosCiviles
        public static string ListarEstadosCiviles = "Gral.SP_EstadosCiviles_Listar";
        public static string BuscarEstadoCivil = "Gral.SP_EstadoCivil_Buscar";
        public static string InsertarEstadoCivil = "Gral.SP_EstadoCivil_Insertar";
        public static string ActualizarEstadoCivil = "Gral.SP_EstadoCivil_Actualizar";
        public static string EliminarEstadoCivil = "Gral.SP_EstadoCivil_Eliminar";

        public static string DropDownEstadoCivil = "Gral.SP_EstadoCivil_DropDown";


        #endregion

        #region Bancos
        public static string ListarBancos = "Gral.SP_Bancos_Listar";
        public static string BuscarBanco = "Gral.SP_Banco_Buscar";
        public static string InsertarBanco = "Gral.SP_Banco_Insertar";
        public static string ActualizarBanco = "Gral.SP_Banco_Actualizar";
        public static string EliminarBanco = "Gral.SP_Banco_Eliminar";
        #endregion

        #region Cargos
        public static string ListarCargos = "Gral.SP_Cargos_Listar";
        public static string BuscarCargo = "Gral.SP_Cargo_Buscar";
        public static string InsertarCargo = "Gral.SP_Cargo_Insertar";
        public static string ActualizarCargo = "Gral.SP_Cargo_Actualizar";
        public static string EliminarCargo = "Gral.SP_Cargo_Eliminar";
        #endregion

        #region Empleados
        public static string ListarEmpleados = "Gral.SP_Empleados_Listar";
        public static string BuscarEmpleado = "Gral.SP_Empleado_Buscar";
        public static string BuscarEmpleadoPorDNI = "Gral.SP_Empleado_BuscarPorDNI";
        public static string ObtenerImagen = "Gral.SP_Empleado_ObtenerImagen";
        public static string InsertarEmpleado = "Gral.SP_Empleado_Insertar";
        public static string ActualizarEmpleado = "Gral.SP_Empleado_Actualizar";
        public static string ActualizarImagenDelEmpleado = "Gral.SP_Empleado_ActualizarImagen";
        public static string DesactivarEmpleado = "Gral.SP_Empleado_Desactivar";
        public static string ActivarEmpleado = "Gral.SP_Empleado_Activar";
        public static string HistorialEmpleado = "Gral.SP_Empleado_Historial";
        #endregion

        #region Impuestos
        public static string ListarImpuestos = "[Gral].[SP_Impuestos_Listar]";
        public static string BuscarImpuestos = "[Gral].[SP_Impuesto_Buscar]";
        public static string ActualizarImpuestos = "Gral.SP_Impuesto_Actualizar";
        #endregion

        #region Estados
        public static string ListarEstados = "Gral.SP_Estados_Listar";
        public static string BuscarEstado = "Gral.SP_Estado_Buscar";
        public static string InsertarEstado = "Gral.SP_Estado_Insertar";
        public static string ActualizarEstado = "Gral.SP_Estado_Actualizar";
        public static string EliminarEstado = "Gral.SP_Estado_Eliminar";
        public static string DropDownEstados = "Gral.SP_Estado_DropDown"; //EstadoPorPais
        public static string EstadoPorPais = "Gral.SP_EstadosPorPais"; //EstadoPorPais

        #endregion

        #region Monedas
        public static string ListarMonedas = "Gral.SP_Monedas_Listar";
        public static string BuscarMoneda = "Gral.SP_Moneda_Buscar";
        public static string InsertarMoneda = "Gral.SP_Moneda_Insertar";
        public static string ActualizarMoneda = "Gral.SP_Moneda_Actualizar";
        public static string EliminarMoneda = "Gral.SP_Moneda_Eliminar";
        public static string ObtenerValorMoneda = "Gral.SP_Moneda_ObtenerValor";

        #endregion

        #endregion

        #region INSUMOS

        #region Material
        public static string Actualizar_Material = "[Insu].[SP_Material_Actualizar]";
        public static string Buscar_Material = "[Insu].[SP_Material_Buscar]";
        public static string Eliminar_Material = "[Insu].[SP_Material_Eliminar]";
        public static string Insertar_Material = "[Insu].[SP_Material_Insertar]";
        public static string Listar_Materiales = "[Insu].[SP_Materiales_Listar]";
        #endregion

        #region Proveedor
        public static string Actualizar_Proveedor = "[Insu].[SP_Proveedor_Actualizar]";
        public static string Buscar_Proveedor = "[Insu].[SP_Proveedor_Buscar]";
        public static string Eliminar_Proveedor = "[Insu].[SP_Proveedor_Eliminar]";
        public static string Insertar_Proveedor = "[Insu].[SP_Proveedor_Insertar]";
        public static string Listar_Proveedores = "[Insu].[SP_Proveedores_Listar]";
        #endregion

        #region Renta Maquinaria Por Actividad
        public static string Actualizar_RentaMaquinariaPorActividad = "[Insu].[SP_RentaMaquinariaPorActividad_Actualizar]";
        //public static string Buscar_RentaMaquinariaPorActividad = "[Insu].[SP_RentaMaquinariaPorActividad_Buscar]";
        public static string Eliminar_RentaMaquinariaPorActividad = "[Insu].[SP_RentaMaquinariaPorActividad_Eliminar]";
        public static string Insertar_RentaMaquinariaPorActividad = "[Insu].[SP_RentaMaquinariaPorActividad_Insertar]";
        public static string Listar_RentaMaquinariasPorActividades = "[Insu].[SP_RentaMaquinariasPorActividades_Listar]";
        #endregion

        #region CotizacionDetalle
        public static string ListarCotizacionesDetalles = "Insu.SP_CotizacionesDetalles_Listar";
        public static string BuscarCotizacionDetalle = "Insu.SP_CotizacionDetalle_Buscar";
        public static string InsertarCotizacionDetalle = "Insu.SP_CotizacionDetalle_Insertar";
        public static string ActualizarCotizacionDetalle = "Insu.SP_CotizacionDetalle_Actualizar";
        public static string EliminarCotizacionDetalle = "Insu.SP_CotizacionDetalle_Eliminar";
        #endregion

        #region InsumoPorMedidas
        public static string InsertarInsumoPorMedida = "Insu.SP_InsumoPorMedida_Insertar";
        public static string EliminarInsumoPorMedida = "Insu.SP_InsumoPorMedida_Eliminar";
        public static string ListarInsumosPorMedidas = "Insu.SP_InsumosPorMedidas_Listar";
        public static string InsumoPorMedidasBuscar = "Insu.SP_InsumosPorMedidas_Buscar";
        #endregion

        #region InsumoPorProveedores
        public static string InsertarInsumoPorProveedores = "Insu.SP_InsumoPorProveedor_Insertar";
        public static string ActualizarInsumoPorProveedores = "Insu.SP_InsumoPorProveedor_Actualizar";
        public static string EliminarInsumoPorProveedores = "Insu.SP_InsumoPorProveedor_Eliminar";
        public static string ListarInsumoPorProveedores = "Insu.SP_InsumoPorProveedor_Listar";
        public static string ListarInsumosPorProveedores = "[Insu].[SP_InsumosPorProveedores_Listar]";
        public static string ListarInsumoPorProveedoresFiltrado = "[Insu].[SP_InsumoPorProveedores_Listar]";


        #endregion







        #region SubCategorias

        public static string ListarSubCategorias = "Gral.SP_Subcategorias_Listar";
        public static string BuscarSubCategoria = "Gral.SP_Subcategoria_Buscar";
        public static string InsertarSubCategoria = "Gral.SP_Subcategoria_Insertar";
        public static string ActualizarSubCategoria = "Gral.SP_Subcategoria_Actualizar";
        public static string EliminarSubCategoria = "Gral.SP_Subcategoria_Eliminar";
        public static string MostrarSubcategoriasPorCategorias = "[Gral].[SP_Subcategoria_PorCategorias]";
        public static string CateListar = "[Insu].[SP_Categorias_Listar]";

        #endregion
        #endregion 


        #region InsumoPorProyectos
        public static string InsertarInsumoPorProyectoDetalle = "Insu.SP_InsumoPorProyectoDetalle_Insertar";
        public static string BuscarInsumoPorProyectoDetalle = "Insu.SP_InsumoPorProyectoDetalle_Buscar";
        public static string ActualizarInsumoPorProyectoDetalle = "Insu.SP_InsumoPorProyectoDetalle_Actualizar";
        public static string EliminarInsumoPorProyectoDetalle = "Insu.SP_InsumoPorProyectoDetalle_Eliminar";

        #endregion

        #region Bodega
        public static string ListarBodegas = "Insu.SP_Bodegas_Listar";
        public static string ListarBodegaInsumos = "[Insu].[SP_InsumosPorProveedor_Listar]";
        public static string BuscarBodega = "Insu.SP_Bodega_Buscar";
        public static string BuscarInsumosEquiposSeguridad = "[Insu].[SP_BodegasPorInsumosEquiposSeguridad_Listar]";
        public static string InsertarBodega = "Insu.SP_Bodega_Insertar";
        public static string ActualizarBodega = "Insu.SP_Bodega_Actualizar";
        public static string EliminarBodega = "Insu.SP_Bodega_Eliminar";
        #endregion

        #region Bodega Por Insumo
        public static string ListarBodegasPorInsumos = "Insu.SP_BodegasPorInsumos_Listar";
        public static string InsertarBodegaPorInsumo = "Insu.SP_BodegaPorInsumo_Insertar";
        public static string ActualizarBodegaPorInsumo = "Insu.SP_BodegaPorInsumo_Actualizar";
        public static string EliminarBodegaPorInsumo = "Insu.SP_BodegaPorInsumo_Eliminar";
        #endregion

        #region Compra Detalle
        public static string ListarComprasDetalle = "Insu.SP_ComprasDetalles_Listar";
        public static string BuscarCompraDetalle = "Insu.SP_CompraDetalle_Buscar";
        public static string BuscarCompraDetalleEncabezado = "[Insu].[SP_CompraDetalle_BuscarEncabezado]";
        public static string InsertarCompraDetalle = "Insu.SP_CompraDetalle_Insertar";
        public static string ActualizarCompraDetalle = "Insu.SP_CompraDetalle_Actualizar";
        public static string EliminarCompraDetalle = "Insu.SP_CompraDetalle_Eliminar";
        public static string ListarActividadesPorEtapasFill = "Proy.SP_Actividades_ListarPorEtapaFiltrado";

        public static string ListarCompraDetalleDestinoPorProyecto = "insu.[SP_CompraDetalleDireccion_ListarPorDetalleDirecciones]";



        //public static string EliminarCompraDetalleDestino = "insu.SP_CompraDetalleDireccion_Eliminar";

        #endregion

        #region Compra Detalle Destino
        public static string ListarCompraDetalleDestino = "insu.SP_CompraDetalleDireccion_Listar";
        public static string InsertarCompraDetalleDestino = "insu.SP_CompraDetalleDireccion_Insertar";
        public static string InsertarCompraDetalleDestinoPorProyecto = "Insu.[SP_ComprasDetallesDireccionesPorMaquinaria_Insertar]";
        public static string InsertarCompraDetalleDestinoPorProyectoPorDefecto = "[Insu].[SP_ComprasDetallesDireccionesPorMaquinaria_InsertarPorDefecto]";
        public static string InsertarCompraDetalleDestinoPorDefecto = "[Insu].[SP_CompraDetalleDireccion_InsertarDestinoPorTefecto]";
        public static string ActualzarCompraDetalleDestinoPorDefecto = "[Insu].[SP_CompraDetalleDireccion_ActalizarDestinoPorTefecto]";
        public static string ActualizarCompraDetalleDestino = "insu.SP_CompraDetalleDireccion_Actualizar";
        public static string BuscarCompraDetalleDestino = "insu.SP_CompraDetalleDireccion_Buscar";
        public static string ListarPorDetalleCompraDetalleDestino = "insu.[SP_CompraDetalleDireccion_ListarPorDetalle]";
        public static string EliminarCompraDetalleDestino = "insu.SP_CompraDetalleDireccion_Eliminar";
        public static string EliminarCompraDetalleDestinoMaquinaria = "insu.[SP_CompraDetalleDireccionProyecto_Eliminar]";

        public static string ListarPorDetalleCompraDetalleDestinoMaquinarias = "[Insu].[SP_CompraDetalleDireccion_ListarPorDetalleDirecciones]";

        #endregion

        #region Compra Encabezado
        public static string ListarCompraEncabezado = "Insu.SP_ComprasEncabezados_Listar";
        public static string ListarCompraDetallesPorCotizaciones = "Insu.SP_CompraDetalles_ListarCotizacion";
        public static string ListarMetodosdPago = "[Gral].[SP_MetodosPagos_Listar]";
        public static string ListarCotizacionesporFechas = "Insu.SP_CotizacionArticulos_ListarPorFechas";
        public static string ListarCotizacionesPorCotizacion = "Insu.SP_CotizacionArticulos_ListarPorCotizacion";
        public static string BuscarCompraEncabezado = "Insu.SP_CompraEncabezado_Buscar";
        public static string InsertarCompraEncabezado = "Insu.SP_CompraEncabezado_Insertar";
        public static string ActualizarCompraEncabezado = "Insu.SP_CompraEncabezado_Actualizar";
        public static string ActualizarCompraEncabezadoNumeroCompra = "[Insu].[SP_CompraEncabezado_ActualizarEncabezado]";
        public static string EliminarCompraEncabezado = "Insu.SP_CompraEncabezado_Eliminar";
        public static string EliminarCompra = "[Insu].[SP_EliminarCompra]";
        public static string VerificarNumeroCompraUnico = "[Insu].[SP_VerificarNumeroCompraUnico]";
        #endregion

        #region Cotizacion
        public static string ListarCotizaciones = "Insu.SP_Cotizaciones_Listar";
        public static string ListarCotizacionesPorProveedor = "Insu.SP_Cotizaciones_ListarPorProveedor";
        public static string BuscarCotizacion = "Insu.SP_Cotizacion_Buscar";
        public static string InsertarCotizacion = "Insu.SP_Cotizacion_Insertar";
        public static string ActualizarCotizacion = "Insu.SP_Cotizacion_Actualizar";
        public static string EliminarCotizacion = "Insu.SP_Cotizacion_Eliminar";
        public static string FinalizarCotizacion = "[Insu].[SP_Cotizacion_Finalizar]";
        public static string ListarArticulos = "[Insu].[SP_Cotizaciones_ListarInsumosMaquinariasEquiposSeguridad]";
        public static string ListarArticulosPorCotizacion = "[Insu].[SP_Cotizaciones_ListarInsumosMaquinariasEquiposSeguridadPorCotizacion]";
        #endregion

        #region CotizacionPorDocumento
        public static string ListarCotizacionesPorDocumentosPDF = "Insu.SP_CotizacionesPorDocumentos_ListarPDF";
        public static string ListarCotizacionesPorDocumentosWord = "Insu.SP_CotizacionesPorDocumentos_ListarWord";
        public static string ListarCotizacionesPorDocumentosImagenes = "Insu.SP_CotizacionesPorDocumentos_ListarImagenes";
        public static string InsertarCotizacionPorDocumento = "Insu.SP_CotizacionPorDocumento_Insertar";
        public static string EliminarCotizacionPorDocumento = "Insu.SP_CotizacionPorDocumento_Eliminar";
        #endregion

        #region Insumos
        public static string ListarInsumos = "Insu.SP_Insumos_Listar";
        public static string BuscarInsumo = "Insu.SP_Insumo_Buscar";
        public static string InsertarInsumo = "Insu.SP_Insumo_Insertar";
        public static string ActualizarInsumo = "Insu.SP_Insumo_Actualizar";
        public static string EliminarInsumo = "Insu.SP_Insumo_Eliminar";
        #endregion

        #region InsumosPorProyectosEncabezados
        public static string ListarInsumosPorProyectosEncabezados = "Insu.SP_InsumosPorProyectosEncabezados_Listar";
        public static string BuscarInsumoPorProyectoEncabezado = "Insu.SP_InsumoPorProyectoEncabezado_Buscar";
        public static string InsertarInsumoPorProyectoEncabezado = "Insu.SP_InsumoPorProyectoEncabezado_Insertar";
        public static string ActualizarInsumoPorProyectoEncabezado = "Insu.SP_InsumoPorProyectoEncabezado_Actualizar";
        public static string EliminarInsumoPorProyectoEncabezado = "Insu.SP_InsumoPorProyectoEncabezado_Eliminar";
        #endregion

        #region Maquinarias
        public static string ListarMaquinarias = "Insu.SP_Maquinarias_Listar";
        public static string BuscarMaquinaria = "Insu.SP_Maquinaria_Buscar";
        public static string InsertarMaquinaria = "Insu.SP_Maquinaria_Insertar";
        public static string ActualizarMaquinaria = "Insu.SP_Maquinaria_Actualizar";
        public static string EliminarMaquinaria = "Insu.SP_Maquinaria_Eliminar";
        #endregion

        #region MaquinariasPorProveedores
        public static string ListarMaquinariasPorProveedores = "Insu.SP_MaquinariasPorProveedores_Listar";
        //public static string BuscarMaquinariaPorProveedor = "";
        public static string InsertarMaquinariaPorProveedor = "Insu.SP_MaquinariaPorProveedor_Insertar";
        public static string BuscarMaquinariasPorProveedor = "Insu.[SP_MaquinariasPorProveedores_Buscar]";
        public static string ActualizarMaquinariaPorProveedor = "Insu.SP_MaquinariaPorProveedor_Actualizar";
        public static string EliminarMaquinariaPorProveedor = "Insu.SP_MaquinariaPorProveedor_Eliminar";
        #endregion





        #region Proyectos
        #region Actividad Por Etapa
        public static string Eliminar_ActividadPorEtapa = "[Proy].[SP_ActividadPorEtapa_Eliminar]";
        public static string Buscar_ActividadPorEtapa = "[Proy].[SP_ActividadPorEtapa_Buscar]";
        public static string Insertar_ActividadPorEtapa = "[Proy].[SP_ActividadPorEtapa_Insertar]";
        public static string Listar_ActividadesPorEtapa = "[Proy].[SP_ActividadesPorEtapa_Listar]";
        public static string Actualizar_ActividadPorEtapa = "[Proy].[SP_ActividadPorEtapa_Actualizar]";
        public static string Listar_ActividadPorEtapa = "[Proy].[SP_ActividadesPorEtapa_DDL]";
        public static string Replicar_ActividadesPorEtapa = "[Proy].[SP_ActividadesPorEtapa_Replicar]";
        public static string AutoCompletar_ActividadPorEtapa = "[Proy].[SP_ActividadPorEtapa_AutoCompletar]";

        public static string Listar_InsumosPorProveedores = "[Proy].[SP_InsumosPorProveedores_Listar]";
        public static string Listar_MaquinariasPorProveedores = "[Proy].[SP_MaquinariasPorProveedores_Listar]";
        public static string Listar_EquiposSeguridadPorProveedores = "[Proy].[SP_EquiposSeguridadPorProveedores_Listar]";
        #endregion

        #region ImagenesPorGestionesAdicionales
        public static string listar_ImagenesPorGestionAdicional = "[Proy].[SP_ImagenesPorGestionesAdicionales_Listar]";
        public static string Eliminar_ImagenesPorGestionAdicional = "[Proy].[SP_ImagenesPorGestionAdicional_Eliminar]";
        public static string Buscar_ImagenesPorGestionAdicional = "[Proy].[SP_ImagenesPorGestionAdicional_Buscar]";
        public static string Insertar_ImagenesPorGestionAdicional = "[Proy].[SP_ImagenesPorGestionAdicional_Insertar]";
        public static string Actualizar_ImagenesPorGestionAdicional = "[Proy].[SP_ImagenesPorGestionAdicional_Actualizar]";
        #endregion

        #region Incidentes
        public static string ListarIncidentes = "[Proy].[SP_Incidentes_Listar]";
        public static string BuscarIncidente = "Proy.SP_Incidente_Buscar";
        public static string IncidentesPorActividadPorEtapa = "Proy.SP_IncidentesPorActivadPorEtapa_Listar";
        public static string InsertarIncidente = "Proy.SP_Incidente_Insertar"; 
        public static string ListarIncidentesPorProyecto = "[Proy].[SP_IncidentesPorProyecto]";
        public static string ListarProyectosPorIncidente = "[Proy].[SP_Proyectos_ListarProyectosPorIncidentes]";
        public static string ActualizarIncidente = "Proy.SP_Incidente_Actualizar";
        public static string EliminarIncidente = "Proy.SP_Incidente_Eliminar";
        #endregion

        #region Categorias
        public static string ListarCategorias = "[Insu].[SP_Categorias_Listar]";
        public static string BuscarCategoria = "[Insu].[SP_Categoria_Buscar]";
        public static string InsertarCategoria = "[Insu].[SP_Categoria_Insertar]";
        public static string ActualizarCategoria = "[Insu].[SP_Categoria_Actualizar]";
        public static string EliminarCategoria = "[Insu].[SP_Categoria_Eliminar]";
        #endregion

        #region Pagos
        public static string ListarPagos = "Proy.SP_Pagos_Listar";
        public static string BuscarPago = "Proy.SP_Pago_Buscar";
        public static string InsertarPago = "Proy.SP_Pago_Insertar";
        public static string ActualizarPago = "Proy.SP_Pago_Actualizar";
        public static string EliminarPago = "Proy.SP_Pago_Eliminar";
        #endregion

        #region Proyecto
        public static string Eliminar_Proyecto = "[Proy].[SP_Proyecto_Eliminar]";
        public static string Buscar_Proyecto = "[Proy].[SP_Proyecto_Buscar]";
        public static string BuscarProyectoPorNombre = "[Proy].[SP_Proyecto_BuscarPorNombre]";
        public static string Insertar_Proyecto = "[Proy].[SP_Proyecto_Insertar]";
        public static string Listar_Proyectos = "[Proy].[SP_Proyectos_Listar]";
        public static string ProyectoListarActividades = "[Proy].[SP_Proyecto_ListarActividades]";
        public static string Actualizar_Proyecto = "[Proy].[SP_Proyecto_Actualizar]";
        #endregion

        #region Retrasos
        public static string BuscarRetraso = "Proy.SP_Retraso_Buscar";
        public static string InsertarRetraso = "Proy.SP_Retraso_Insertar";
        public static string ActualizarRetraso = "Proy.SP_Retraso_Actualizar";
        public static string EliminarRetraso = "Proy.SP_Retraso_Eliminar";
        #endregion

        #region Notificaciones
        public static string ListarTiposNotificaciones = "Proy.SP_TipoNotificacion_Listar";
        public static string ListarNotificaciones = "Proy.SP_Notificacion_Listar";
        public static string ListarNotificaciones2 = "[Proy].[SP_Notificaciones_Listar]";
        public static string BuscarNotificacion = "Proy.SP_Notificacion_Buscar";
        public static string ContarNotificacion = "Proy.SP_Notificacion_Contar";
        public static string InsertarNotificacion = "Proy.SP_Notificacion_Insertar";
        public static string InsertarNotificacionPorUsuario = "[Proy].[SP_NotificacionPorUsuario_Insertar]";
        public static string ActualizarNotificacion = "Proy.SP_Notificacion_Actualizar";
        public static string EliminarNotificacion = "Proy.SP_Notificacion_Eliminar";
        #endregion

        #region NotificacionesAlertas por Usuario
        public static string FiltrarAlertaUsuario = "[Proy].[SP_AlertaUsuario_Filtrar]";
        public static string EliminarNotiAler = "[Proy].[SP_NotificacionAlerta_Eliminar]";
        public static string LeidaNotiAler = "[Proy].[SP_NotificacionAlerta_Leida]";
        public static string FiltrarNotiFicacion = "[Proy].[SP_NotificacionUsuario_Filtrar]";
        public static string GuardarToken = "[Proy].[SP_TokenFCM_Insertar]";
        public static string BuscarTokenPorProyecto = "Proy.SP_NotificacionPorProyectos";
        public static string BuscarTokenPoradministrador = "[Proy].[SP_NotificacionesAdministradores]";
        public static string EliminarToken = "[Proy].[SP_TokenFCM_Eliminar]";

        #endregion

        #region Tokens
        public static string InsertarToken = "Proy.SP_Token_Insertar";
        public static string ListarTokens = "Proy.SP_Tokens_Listar";
        public static string ListarTokensPorUsuario = "Proy.SP_Tokens_ListarPorUsuario";
        #endregion

        #region Contratos
        public static string ListarContratos = "Proy.SP_Contratos_Listar";
        public static string BuscarContrato = "Proy.SP_Contrato_Buscar";
        public static string InsertarContrato = "Proy.SP_Contrato_Insertar";
        public static string ActualizarContrato = "Proy.SP_Contrato_Actualizar";
        public static string EliminarContrato = "Proy.SP_Contrato_Eliminar";
        #endregion

        #region Contratos Empleados
        public static string ListarContratosEmpleados = "Proy.SP_ContratosEmpleados_Listar";
        public static string BuscarContratoEmpleado = "Proy.SP_ContratoEmpleado_Buscar";
        public static string InsertarContratoEmpleado = "Proy.SP_ContratoEmpleado_Insertar";
        public static string ActualizarContratoEmpleado = "Proy.SP_ContratoEmpleado_Actualizar";
        public static string EliminarContratoEmpleado = "Proy.SP_ContratoEmpleado_Eliminar";
        #endregion

        #region Control De Calidades
        public static string ListarControlDeCalidades = "Proy.SP_ControlesCalidad_Listar";
        public static string BuscarControlDeCalidades = "Proy.SP_ControlCalidad_Buscar";
        public static string InsertarControlDeCalidades = "Proy.SP_ControlCalidad_Insertar";
        public static string ActualizarControlDeCalidades = "[Proy].[SP_ControlCalidad_Actualizar]";
        public static string EliminarControlDeCalidades = "Proy.SP_ControlCalidad_Eliminar";
        public static string AprobarControlDeCalidades = "[Proy].[SP_ControlCalidad_Aprobar]";
        public static string ListarProyectosConControlesDeCalidad = "Proy.SP_Proyectos_ListarProyectosPorControlCalidad";
        public static string ListarControlesDeCalidadPorProyectos = "Proy.SP_ControlCalidad_filtradoProyecto";
        public static string FiltrarControlDeCalidades = "[Proy].[SP_ControlCalidad_Filtrado_Acet]";
        #endregion

        #region Control De Calidades Por Actividades
        public static string ListarControlDeCalidadesPorActividades = "Proy.SP_ControlesDeCalidadesPorActividades_Listar";
        public static string BuscarControlDeCalidadPorActividad = "Proy.SP_ControlDeCalidadPorActividad_Buscar";
        public static string InsertarControlDeCalidadPorActividad = "Proy.SP_ControlDeCalidadPorActividad_Insertar";
        public static string ActualizarControlDeCalidadPorActividad = "Proy.SP_ControlDeCalidadPorActividad_Actualizar";
        public static string EliminarControlDeCalidadPorActividad = "Proy.SP_ControlDeCalidadPorActividad_Eliminar";
        #endregion

        #region Etapas Por Proyectos
        public static string ListarEtapasPorProyectos = "Proy.SP_EtapasPorProyecto_Listar";
        public static string ListarEtapasPorProyecto = "Proy.SP_EtapasPorProyecto_Listar";
        public static string BuscarEtapaPorProyecto = "Proy.SP_EtapaPorProyecto_Buscar";
        public static string InsertarEtapaPorProyecto = "Proy.SP_EtapaPorProyecto_Insertar";
        public static string ActualizarEtapaPorProyecto = "Proy.SP_EtapaPorProyecto_Actualizar";
        public static string EliminarEtapaPorProyecto = "Proy.SP_EtapaPorProyecto_Eliminar";
        #endregion

        #region Gestion Adicional
        public static string BuscarGestionAdicional = "Proy.SP_GestionAdicional_Buscar";
        public static string InsertarGestionAdicional = "Proy.SP_GestionAdicional_Insertar";
        public static string ActualizarGestionAdicional = "Proy.SP_GestionAdicional_Actualizar";
        public static string EliminarGestionAdicional = "Proy.SP_GestionAdicional_Eliminar";
        public static string ListarGestionAdicional = "Proy.SP_GestionesAdicionales_Listar";

        #endregion

        #region Gestion Riesgo
        public static string BuscarGestionRiesgo = "Proy.SP_GestionRiesgo_Buscar";
        public static string InsertarGestionRiesgo = "Proy.SP_GestionRiesgo_Insertar";
        public static string Listar_GestionRiesgos = "Proy.SP_GestionRiesgos_Listar";
        public static string ActualizarGestionRiesgo = "Proy.SP_GestionRiesgo_Actualizar";
        public static string EliminarGestionRiesgo = "Proy.SP_GestionRiesgo_Eliminar";
        #endregion

        #region Imagen Por Control Calidad
        public static string ListarImagenesPorControlCalidades = "Proy.SP_ImagenesPorControlCalidades_Listar";
        public static string BuscarImagenPorControlCalidad = "Proy.SP_ImagenPorControlCalidad_Buscar";
        public static string InsertarImagenPorControlCalidad = "Proy.SP_ImagenPorControlCalidad_Insertar";
        public static string ActualizarImagenPorControlCalidad = "Proy.SP_ImagenPorControlCalidad_Actualizar";
        public static string EliminarImagenPorControlCalidad = "Proy.SP_ImagenPorControlCalidad_Eliminar";
        #endregion

        #region Documentos
        public static string ListarDocumentos = "Proy.SP_Documentos_Listar";
        public static string BuscarDocumento = "Proy.SP_Documento_Buscar";
        public static string InsertarDocumento = "Proy.SP_Documento_Insertar";
        public static string ActualizarDocumento = "Proy.SP_Documento_Actualizar";
        public static string EliminarDocumento = "Proy.SP_Documento_Eliminar";
        #endregion

        #region EquiposSeguridad
        public static string ListarEquiposSeguridad = "Insu.SP_EquiposSeguridad_Listar";
        public static string BuscarEquipoSeguridad = "Insu.SP_EquipoSeguridad_Buscar";
        public static string BuscarEquipoSeguridadPorProveedores = "[Insu].[SP_EquiposSeguridadPorProveedores_Buscar]";
        public static string InsertarEquipoSeguridad = "Insu.SP_EquipoSeguridad_Insertar";
        public static string InsertarEquipoSeguridadPorProveedor = "Insu.SP_EquipoSeguridadPorProveedor_Insertar";
        public static string ActualizarEquipoSeguridad = "Insu.SP_EquipoSeguridad_Actualizar";
        public static string EliminarEquipoSeguridad = "Insu.SP_EquipoSeguridad_Eliminar";
        public static string EliminarEquipoSeguridadPorProveedor = "[Insu].[SP_EquipoSeguridadPorProveedor_Eliminar]";
        #endregion

        #region EquiposdeSeguridadPorProveedor
        public static string ListarEquiposSeguridadPorProveedor = "insu.[SP_EquipoSeguridadPorProveedor_Listar]";
        public static string ListarEquiposSeguridadPorProveedorFiltradoPorBodega = "[Insu].[SP_EquipoSeguridadPorProveedores_Listar]";
        #endregion

        #region EstadosProyectos
        public static string ListarEstadosProyectos = "Proy.SP_EstadosProyectos_Listar";
        public static string BuscarEstadoProyecto = "Proy.SP_EstadoProyecto_Buscar";
        public static string InsertarEstadoProyecto = "Proy.SP_EstadoProyecto_Insertar";
        public static string ActualizarEstadoProyecto = "Proy.SP_EstadoProyecto_Actualizar";
        public static string EliminarEstadoProyecto = "Proy.SP_EstadoProyecto_Eliminar";
        #endregion

        #region Etapas
        public static string ListarEtapas = "Proy.SP_Etapas_Listar";
        public static string BuscarEtapa = "Proy.SP_Etapa_Buscar";
        public static string BuscarEtapaPorNombre = "Proy.SP_Etapa_BuscarPorNombre";
        public static string InsertarEtapa = "Proy.SP_Etapa_Insertar";
        public static string ActualizarEtapa = "Proy.SP_Etapa_Actualizar";
        public static string EliminarEtapa = "Proy.SP_Etapa_Eliminar";
        #endregion

        #region Imagenes por Incidente
        public static string ListarImagenesPorIncidente = "Proy.SP_ImagenesPorIncidencias_Listar";
        public static string BuscarImagenPorIncidente = "Proy.SP_ImagenPorIncidencia_Buscar";
        public static string InsertarImagenPorIncidente = "Proy.SP_ImagenPorIncidencia_Insertar";
        public static string ActualizarImagenPorIncidente = "Proy.SP_ImagenPorIncidencia_Actualizar";
        public static string EliminarImagenPorIncidente = "Proy.SP_ImagenPorIncidencia_Eliminar";
        #endregion

        #region Incidentes por Actividad
        public static string ListarIncidentesPorActividad = "Proy.SP_IncidenciasPorActividades_Listar";
        public static string BuscarIncidentePorActividad = "Proy.SP_IncidenciasPorActividades_Buscar";
        public static string InsertarIncidentePorActividad = "Proy.SP_IncidenciaPorActividad_Insertar";
        public static string ActualizarIncidentePorActividad = "Proy.SP_IncidenciaPorActividad_Actualizar";
        public static string EliminarIncidentePorActividad = "Proy.SP_IncidenciaPorActividad_Eliminar";
        #endregion

        #region Insumos por Actividad
        public static string Listar_InsumosPorActividad = "[Proy].[SP_InsumosPorActividad_Listar]";
        #endregion

        #region Renta Maquinaria Por Actividad
        public static string Listar_RentaMaquinariasPorActividad = "[Proy].[SP_RentaMaquinariasPorActividad_Listar]";
        #endregion

        #region Equipo Seguridad Por Actividad
        public static string Listar_EquiposSeguridadPorActividad = "[Proy].[SP_EquiposSeguridadPorActividad_Listar]";
        #endregion
        #endregion


        #region Presupuesto Encabezado
        public static string ListarPresupuestosEncabezado = "Proy.SP_PresupuestosEncabezado_Listar";
        public static string BuscarPresupuestoEncabezado = "Proy.SP_PresupuestoEncabezado_Buscar";
        public static string InsertarPresupuestoEncabezado = "Proy.SP_PresupuestoEncabezado_Insertar";
        public static string ActualizarPresupuestoEncabezado = "Proy.SP_PresupuestoEncabezado_Actualizar";
        public static string EliminarPresupuestoEncabezado = "Proy.SP_PresupuestoEncabezado_Eliminar";
        public static string AprobadoPresupuestoEncabezado = "Proy.SP_PresupuestoEncabezado_Aprobado";
        public static string RechazadoPresupuestoEncabezado = "Proy.SP_PresupuestoEncabezado_Rechazado";

        #endregion

        #region Renta Maquinaria Actividades
        public static string ListarRentasMaquinariasPorActividades = "[Proy].[SP_RentaMaquinariasPorActividad_Listar]";
        public static string ListarPresupuestoRentasMaquinariasPorActividades = "[Proy].[SP_RentaMaquinariasPorActividad_ListarPresupuesto]";
        public static string InsertarRentaMaquinariaPorActividad = "Proy.SP_RentaMaquinariaPorActividad_Insertar";
        public static string ActualizarRentaMaquinariaPorActividad = "Proy.SP_RentaMaquinariaPorActividad_Actualizar";
        public static string EliminarRentaMaquinariaPorActividad = "Proy.SP_RentaMaquinariaPorActividad_Eliminar";
        #endregion

        #region Insumos Por Actividades
        public static string ListarInsumosPorActividades = "Proy.[SP_InsumosPorActividad_Listar]";
        public static string ListarPresupuestoInsumosPorActividades = "Proy.[SP_InsumosPorActividad_ListarPresupuesto]";
        public static string InsertarInsumoPorActividad = "Proy.[SP_InsumoPorActividad_Insertar]";
        public static string ActualizarInusmoPorActividad = "Proy.[SP_InsumoPorActividad_Actualizar]";
        public static string EliminarInsumoPorActiviad = "Proy.[SP_InsumoPorActividad_Eliminar]";
        #endregion


        #region Prsupuesto Detalle
        public static string ListarPresupuestosDetalle = "Proy.SP_PresupuestosDetalle_Listar";
        public static string InsertarPresupuestoDetalle = "Proy.SP_PresupuestoDetalle_Insertar";
        public static string ActualizarPresupuestoDetalle = "Proy.SP_PresupuestoDetalle_Actualizar";
        public static string EliminarPresupuestoDetalle = "Proy.SP_PresupuestoDetalle_Eliminar";
        #endregion

        #region Prsupuesto Por TasasCambio
        public static string ListarPresupuestosPorTasasCambio = "Proy.SP_PresupuestosPorTasasCambio_Listar";
        public static string InsertarPresupuestoPorTasaCambio = "Proy.SP_PresupuestoPorTasaCambio_Insertar";
        public static string ActualizarPresupuestoPorTasaCambio = "Proy.SP_PresupuestoPorTasaCambio_Actualizar";
        public static string EliminarPresupuestoPorTasaCambio = "Proy.SP_PresupuestoPorTasaCambio_Eliminar";

        #endregion


        #region Alertas
        public static string ListarAlertas = "Proy.SP_Alertas_Listar";
        public static string BuscarAlerta = "Proy.SP_Alerta_Buscar";
        public static string InsertarAlerta = "Proy.SP_Alerta_Insertar";
        public static string ActualizarAlerta = "Proy.SP_Alerta_Actualizar";
        public static string EliminarAlerta = "Proy.SP_Alerta_Eliminar";
        #endregion

        #region Actividades
        public static string ListarActividades = "Proy.SP_Actividades_Listar";
        public static string ListarActividadesPorEtapas = "Proy.SP_Actividades_ListarPorEtapa";
        public static string ListarCostosActividades = "Proy.SP_Actividades_ListarCostos";
        public static string BuscarActividad = "Proy.SP_Actividad_Buscar";
        public static string InsertarActividad = "Proy.SP_Actividad_Insertar";
        public static string ActualizarActividad = "Proy.SP_Actividad_Actualizar";
        public static string EliminarActividad = "Proy.SP_Actividad_Eliminar";

        public static string ListarActividadesPorEtapasFiltrado = "Proy.[SP_Actividades_ListarPorEtapaFiltrado]";

        #endregion

        #region Proyectos
        public static string ListarProyectos = "Proy.SP_Proyectos_Listar";

        #endregion

        #region Bienes y Raices
        #region Imagenes de proceso de venta
        public static string ListarImagenesProcesoVenta = "Raiz.SP_ImagenesPorProcesosVentas_Listar";
        public static string InsertarImagenesProcesoVenta = "Raiz.SP_ImagenesPorProcesosVentas_Insertar";
        public static string ActualizarImagenesProcesoVenta = "Raiz.SP_ImagenesPorProcesosVentas_Actualizar";
        public static string EliminarImagenesProcesoVenta = "Raiz.SP_ImagenesPorProcesosVentas_Eliminar";
        public static string BuscardocumentosProcesoventa = "Raiz.SP_DocumentosVenta_Listar";

        #endregion
        #region Procesos de Venta
        public static string ListarProcesosVenta = "Raiz.SP_ProcesosVentas_Listar";
        public static string BuscarProcesoVenta = "Raiz.SP_ProcesoVenta_Buscar";
        public static string BuscarClienteVendido = "Raiz.SP_ProcesoVenta_Buscar_Vendido2";
        public static string InsertarProcesoVenta = "Raiz.SP_ProcesoVenta_Insertar";
        public static string ActualizarProcesoVenta = "Raiz.SP_ProcesoVenta_Actualizar";
        public static string EliminarProcesoVenta = "Raiz.SP_ProcesoVenta_Eliminar";
        public static string VendidoProcesoVenta = "Raiz.SP_ProcesoVenta_Vendido";

        public static string VenderProcesoVenta = "Raiz.SP_ProcesoVenta_Actualizar_Vendido";

        #endregion

        #region agente bienes raices
        public static string ActualizarAgenteBienesRaices = "Raiz.SP_AgenteBienesRaices_Actualizar";
        public static string BuscarAgenteBienesRaices = "Raiz.SP_AgenteBienesRaices_Buscar";
        public static string EliminarAgenteBienesRaices = "Raiz.SP_AgenteBienesRaices_Eliminar";
        public static string InsertarAgenteBienesRaices = "Raiz.SP_AgenteBienesRaices_Insertar";
        public static string ListarAgenteBienesRaices = "Raiz.SP_AgentesBienesRaices_Listar";
        #endregion

        #region bienes raices
        public static string ListarBienesRaices = "Raiz.SP_BienesRaices_Listar";
        public static string ActualizarBienRaiz = "Raiz.SP_BienRaiz_Actualizar";
        public static string BuscarBienRaiz = "Raiz.SP_BienRaiz_Buscar";
        public static string EliminarBienRaiz = "Raiz.SP_BienRaiz_Eliminar";
        public static string InsertarBienRaiz = "Raiz.SP_BienRaiz_Insertar";
        public static string DesactivarIdentificadorbienraiz = "[Raiz].[SP_BienRaizIdentificador_Actualizar]";

        #endregion

        #region documentos bienes raices
        public static string ActuzalizarDocumentoBienRaiz = "Raiz.SP_DocumentoBienRaiz_Actualizar";
        public static string BuscarDocumentoBienRaiz = "Raiz.SP_DocumentoBienRaiz_Buscar";
        public static string EliminarDocumentoBienRaiz = "Raiz.SP_DocumentoBienRaiz_Eliminar";
        public static string EliminarDocumentoTerreno = "Raiz.SP_DocumentoTerreno_Eliminar";

        public static string InsertarDocumentoBienRaiz = "Raiz.SP_DocumentoBienRaiz_Insertar";
        public static string ListarDocumentoBienRaiz = "Raiz.SP_DocumentosBienesRaices_Listar";
        public static string ListarPDF = "Raiz.SP_DocumentoPDF_Listar";
        public static string ListarImagen = "Raiz.SP_DocumentoImagen_Listar";
        public static string ListarWord = "Raiz.SP_DocumentoWord_Listar";
        public static string ListarOtros = "Raiz.SP_DocumentoOtros_Listar";

        public static string ListarExcel = "Raiz.SP_DocumentoExcel_Listar";
        public static string ListarTerrenoPDF = "[Raiz].[SP_DocumentoTerrenoPDF_Listar]";
        public static string ListarTerrenoImagen = "[Raiz].[SP_DocumentoTerrenoImagen_Listar]";
        public static string ListarTerrenoExcel = "[Raiz].[SP_DocumentoTerrenoExcel_Listar]";
        public static string ListarTerrenoWord = "[Raiz].[SP_DocumentoTerrenoWord_Listar]";
        public static string ListarTerrenoOtros = "[Raiz].[SP_DocumentoTerrenoOtros_Listar]";

        public static string ListarTipoDocumentoBienRaiz = "[Raiz].[SP_TipoDocumentos_Listar]";
        public static string BuscarDocumentoPorTerreno = "[Raiz].[SP_DocumentoPorTerreno_Buscar]";
        public static string DocuemntoPorBienRaizListar = "[Raiz].[SP_DocumentosPorBienRaiz_Listar]";

        #endregion

        #region empresa bienes raices
        public static string BuscarEmpresaBienesRaices = "Raiz.SP_EmpresaBienesRaices_Buscar";
        public static string EliminarEmpresaBienesRaices = "Raiz.SP_EmpresaBienesRaices_Eliminar";
        public static string InsertarEmpresaBienesRaices = "Raiz.SP_EmpresaBienesRaices_Insertar";
        public static string ListarEmpresaBienesRaices = "Raiz.SP_EmpresasBienesRaices_Listar";
        public static string ActualizarEmpresaBienesRaices = "Raiz.SP_EmpresaBienRaiz_Actualizar";
        #endregion

        #region proyectos construccion bienes raices
        public static string ListarProyectosConstruccionBienesRaices = "[Raiz].[SP_ProyectosConstruccionBienesRaices_Listar]";
        public static string EliminarProyectoConstruccionBienRaiz = "[Raiz].[SP_ProyectoConstruccionBienRaiz_Eliminar]";
        public static string ActualizarProyectoConstruccionBienRaiz = "[Raiz].[SP_ProyectoConstruccionBienRaiz_Actualizar]";
        public static string InsertarProyectoConstruccionBienRaiz = "[Raiz].[SP_ProyectoConstruccionBienRaiz_Insertar]";
        public static string BuscarProyectoConstruccionBienRaiz = "[Raiz].[SP_ProyectoConstruccionBienRaiz_Buscar]";
        #endregion

        #region terrenos
        public static string ListarTerrenos = "[Raiz].[SP_Terrenos_Listar]";
        public static string Eliminarterreno = "[Raiz].[SP_Terreno_Eliminar]";
        public static string DesactivarIdentificador = "[Raiz].[SP_TerrenoIdentificador_Actualizar]";
        public static string ActualizarTerreno = "[Raiz].[SP_Terreno_Actualizar]";
        public static string InsertarTerreno = "[Raiz].[SP_Terreno_Insertar]";
        public static string BuscarTerreno = "[Raiz].[SP_Terreno_Buscar]";
        public static string DocuemntoPorTerrenosListar = "[Raiz].[SP_DocumentosPorTerreno_Listar]";
        public static string ListarTerrenos_Indentificador = "Raiz.SP_Terrenos_Listar_Identificador";
        #endregion
        #region TipoDocumentos
        public static string ActualizarTipoDocumentos = "Raiz.SP_TipoDocumentos_Actualizar";
        public static string BuscarTipoDocumentos = "Raiz.SP_TipoDocumentos_Buscar";
        public static string EliminarTipoDocumentos = "Raiz.SP_TipoDocumentos_Eliminar";
        public static string InsertarTipoDocumentos = "Raiz.SP_TipoDocumentos_Insertar";
        public static string ListarTipoDocumentos = "Raiz.SP_TipoDocumentos_Listar";
        #endregion

        #region mantenimiento de cliente proceso venta
        public static string ActualizarClienteProcesosVenta = "Raiz.SP_Mantenimiento_Actualizar";
        public static string EliminarClienteProcesosVenta = "Raiz.SP_Mantenimiento_Eliminar";
        public static string InsertarClienteProcesosVenta = "Raiz.SP_Mantenimiento_Insertar";
        public static string ListarClienteProcesosVenta = "Raiz.SP_Mantenimiento_Listar";
        public static string BuscarClienteProcesosVenta = "Gral.SP_Cliente_BuscarPorDNI";

        #endregion

        #endregion

        #region Planillas

        #region Deducciones
        public static string DeduccionPorEmpleado = "[Nomi].[SP_DeduccionPorEmpleado_Actualizar]";
        public static string ListarDeduccionPorEmpleado = "[Nomi].[SP_DeduccionPorEmpleado_Listar]";
        public static string BuscarDeduccionPorEmpleado = "[Nomi].[SP_DeduccionPorEmpleado_Buscar]";
        public static string EliminarDeduccion = "[Nomi].SP_Deduccion_Eliminar";
        public static string BuscarDeduccion = "[Nomi].[SP_Deduccion_Buscar]";
        public static string ActualizarDeduccion = "[Nomi].[SP_Deduccion_Actualizar]";
        public static string InsertarDeduccion = "[Nomi].[SP_Deduccion_Insertar]";
        public static string ListarDeducciones = "[Nomi].[SP_Deducciones_Listar]";
        public static string InsertarDeduccionesPorPlanilla = "Nomi.SP_DeduccionesPorPlanilla_Insertar";
        public static string BuscarDeduccionesPorPlanilla = "[Nomi].[SP_Deducciones_BuscarPorPlanilla]";
        public static string BuscarDeduccionesPorPlanillaPorEmpleado = "[Nomi].[SP_Deducciones_BuscarPorPlanillaPorEmpleado]";
        #endregion

        #region Frecuencia
        public static string ActualizarFrecuencia = "[Nomi].[SP_Frecuencia_Actualizar]";
        public static string BuscarFrecuencia = "[Nomi].[SP_Frecuencia_Buscar]";
        public static string EliminarFrecuencia = "[Nomi].[SP_Frecuencia_Eliminar]";
        public static string InsertarFrecuencia = "[Nomi].[SP_Frecuencia_Insertar]";
        public static string ListarFrecuencias = "[Nomi].[SP_Frecuencias_Listar]";
        #endregion

        #region Prestamos
        public static string ActualizarPrestamo = "[Nomi].[SP_Prestamo_Actualizar]";
        public static string BuscarPrestamo = "[Nomi].[SP_Prestamo_Buscar]";
        public static string EliminarPrestamo = "[Nomi].[SP_Prestamo_Eliminar]";
        public static string InsertarPrestamo = "[Nomi].[SP_Prestamo_Insertar]";
        public static string InsertarPrestamoPlanilla = "Nomi.SP_PrestamosPorEmpleadoCuota_InsertarJSON";
        public static string ListarPrestamos = "[Nomi].[SP_Prestamos_Listar]";
        public static string ListarAbonos = "[Nomi].[SP_Abonos_Listar]";
        public static string ListarPrestamosEmpleado = "[Nomi].[SP_PrestamosPorEmpleado_ObtenerCuotaSiguiente]";
        public static string InsertarCuotaEmpleadosPorPrestamos = "Nomi.SP_PrestamoPorEmpleadoCuota_Insertar";
        #endregion

        #region CategoriaViaticos
        public static string ListarCategoriaViaticos = "[Nomi].[SP_CategoriasViaticos_Listar]";
        public static string EliminarCategoriaViatico = "[Nomi].[SP_CategoriaViatico_Eliminar]";
        public static string ActualizarcategoriaViatico = "[Nomi].[SP_CategoriaViatico_Actualizar]";
        public static string InsertarcategoriaViatico = "[Nomi].[SP_CategoriaViatico_Insertar]";
        public static string BuscarCategoriaViatico = "[Nomi].[SP_CategoriaViatico_Buscar]";
        public static string ListarCostoActividad = "[Nomi].[SP_CostoPorActividad_Listar]";
        public static string ActualizarCostoActividad = "[Nomi].[SP_CostoPorActividad_Actualizar]";
        public static string BuscarCostoActividad = "[Nomi].[SP_CostoPorActividad_Buscar]";
        public static string InsertarCostoActividad = "[Nomi].[SP_CostoPorActividad_Insertar]";
        public static string EliminarCostoActividad = "[Nomi].[SP_CostoPorActividad_Eliminar]";
        public static string BuscarViaticosEncDet = "[Nomi].[SP_ViaticosEncabezadosDet_Listar]";

        #endregion

        #region Planilla
        public static string InsertarPlanilla = "[Nomi].[SP_PlanillaEncabezado_Insertar]";
        public static string ListarPlanilla = "Nomi.SP_Planillas_Listar";
        #endregion

        #region PlanillaDetalle
        public static string InsertarPlanillaDetalle = "[Nomi].[SP_PlanillDetalle_InsertarJSON]";
        public static string InsertarPlanillaDetalleJefeObra = "[Nomi].[SP_PlanillDetalle_InsertarJefeObra]";
        public static string VerDetallesPlanilla = "[Nomi].[SP_PlanillaDetalles_BuscarPorPlanilla]";
        public static string DeduccionesPorEmpleados = "[Nomi].[SP_DeduccionPorEmpleado_Listar]";
        public static string VerDeduccionPorEmpleadoPorPlanilla = "[Nomi].[SP_Deducciones_BuscarPorPlanillaPorEmpleado]";
        #endregion

        #region Viaticos
        public static string ViaticosDetActualizar = "[Nomi].[SP_ViaticosDetalles_Actualizar]";
        public static string ViaticosDetBuscar = "[Nomi].[SP_ViaticosDetalles_Buscar]";
        public static string ViaticosDetEliminar = "[Nomi].[SP_ViaticosDetalles_Eliminar]";
        public static string ViaticosDetInsertar = "[Nomi].[SP_ViaticosDetalles_Insertar]";
        public static string ViaticosDetListar = "[Nomi].[SP_ViaticosDetalles_Listar]";
        public static string ViaticosEncActualizar = "[Nomi].[SP_ViaticosEncabezados_Actualizar]";
        public static string ViaticosEncBuscar = "[Nomi].[SP_ViaticosEncabezados_Buscar]";
        public static string ViaticosEncEliminar = "[Nomi].[SP_ViaticosEncabezados_Eliminar]";
        public static string ViaticosEncFinalizar = "Nomi.SP_ViaticosEnc_EstadoFacturas";
        public static string ViaticosEncInsertar = "[Nomi].[SP_ViaticosEncabezados_Insertar]";
        public static string ViaticosEncListar = "[Nomi].[SP_ViaticosEncabezados_Listar]";
        public static string PlanillaJefeObraListar = "[Nomi].[SP_ListadoJefesObra2]";
        public static string DeduccionesJefeListar = "Nomi.SP_DeduccionesXEmpleado";
        public static string DeduccionesJefeListar2 = "[Nomi].[SP_ListadoJefesObra3]";

        #endregion


        #endregion

        #region Reportes

        public static string ReporteTerrenoFechaCreacion = "Raiz.SP_ReporteTerrenosPorFechaCreacion";
        public static string ReporteTerrenosPorEstadoProyecto = "Raiz.SP_ReporteTerrenosPorEstadoProyecto";
        public static string ReporteVentasPorEmpresa = "[Raiz].[SP_ReporteVentasPorEmpresa]";
        public static string ReporteEmpleadoPorEstado = "Gral.SP_ReporteEmpleadoPorEstado";
        public static string ReporteFletesPorFecha = "Flet.SP_ReporteFletesPorFecha";
        public static string ReporteHistorialCotizaciones = "Insu.SP_ReporteHistorialCotizaciones";
        public static string ReporteComprasRealizadas = "Insu.SP_ReporteComprasRealizadas";
        public static string ReporteComparacionMonetaria = "[Proy].[SP_ReporteCostoPorProyecto]";
        public static string ReporteCotizacionesPorRangoPrecios = "[Insu].[SP_ReporteCotizacionesPorRangoPrecios]";
        public static string ReporteInsumosBodega = "[Insu].[SP_ReporteInsumosBodega]";
        public static string ReporteInsumosAProyecto = "[Insu].[SP_ReporteInsumosAProyecto]";
        public static string ReporteHistorialPagosPorProyecto = "[Nomi].[SP_ReporteHistorialPagosPorProyecto]";
        public static string ReporteComparativoProductos = "[Insu].[SP_ComparativoCotizacionPorProveedores]";
        public static string ReportecomprasPendientesEnvio = "[Insu].[SP_ReportecomprasPendientesEnvio]";
        public static string ReporteProgresoActividades = "[Proy].[SP_ReporteProgresoActividades]";
        public static string ReportePorUbicacion = "[Insu].[SP_ReportePorUbicacion]";
        public static string EstadisticasFletes_Comparacion = "[Flet].[SP_EstadisticasFletes_Comparacion]";
        public static string istarBienesRaicesEnVenta = "[Raiz].[SP_ListarBienesRaicesEnVenta]";
        public static string ReporteProcesoVenta = "[Raiz].[SP_ReporteProcesoVenta]";
        public static string EstadisticasFletes_Llegada = "[Flet].[SP_EstadisticasFletes_Llegada]";
        public static string ReporteInsumosTransportadosPorActividad = "[Flet].[SP_ReporteInsumosTransportadosPorActividad]";
        public static string ReporteInsumosUltimoPrecio = "[Insu].[SP_ReporteInsumosUltimoPrecio]";
        public static string ReporteArticulosActividades = "Proy.SP_ReporteArticulosActividades";
        #endregion

        #region Referencias
        public static string ReferenciasCeldasListar = "Proy.SP_ReferenciasCeldas_Listar";
        public static string ReferenciasCeldasInsertar = "Proy.SP_ReferenciasCeldas_Insertar";
        public static string ReferenciasCeldasEliminar = "Proy.SP_ReferenciasCeldas_Eliminar";
        #endregion


        #region Dashboards
        //insumos
        public static string DashboardTop5Proveedores = "[Insu].[SP_tbProveedores_ListadoTop5_Dasboard]";
        public static string DashboardTop5Articulos = "Insu.SP_CompraDetalles_Top5Articulos_Dashboard";
        public static string DashboardTotalesComprasMensuales = "[Insu].[SP_CompraDetalles_TotalesComprasMensulaes_Dashboard]";
        public static string DashboardTop5Articulosfiltrados = "[Insu].[SP_CompraDetalles_Top5ArticulosFiltrado_Dashboard]";
        public static string DashboardTop5PorcadaArticulos = "[Insu].[SP_CompraDetalles_Top5PocadaArticulos_Dashboard]";

        public static string DashboardTotalesComprasFiltrado = "[Gral].[SP_Dashboard_CompraDetalles_TotalesComprasFillFechas]";
        public static string DashboardTop5ProveedoresComprados = "[Gral].[SP_Dashboard_CompraDetalle_Top5ProveedoresComprados]";
        public static string DashboardTop5DestinosCompraEnviados = "[Gral].[SP_Dashboard_CompraDetalle_Top5Destinos]";
        //fletes
        public static string DashboardProyectosRelacionados = "[Flet].[SP_FletesEncabezado_ProyectosRelacionados_Dashboard]";
        public static string DashboardTop5BodegasMasFrecuentesDestino = "[Flet].[SP_FletesEncabezado_BodegasDestino_Dashboard]";
        public static string DashboardTasaIncidencias = "[Flet].[SP_FletesEncabezado_IncidenciasMensuales_Dashboard]";

        public static string DashboardFletesTopBodegasMasFrecuentesDestino = "[Gral].[SP_Dashboard_FletesEncabezado_TopBodegasDestino]";
        public static string DashboardTasaIncidenciasMeses = "[Gral].[SP_Dashboard_FletesEncabezado_IncidenciasMensuales]";
        public static string DashboardFletesPorProyectoMensuales = "[Gral].[SP_Dashboard_Fletes_ProyectosRelacionadosFill]";
        //Bienes raices
        public static string DashboardTerrenosVendidosPorMes = "Raiz.SP_ProcesosVentas_TerrenosPorMes_Dashboard";
        public static string DashboardVentasPorAgente = "Raiz.SP_ProcesosVentas_VentasPorAgente_Dashboard";
        public static string DashboardEstadisticaVentaBienesRaices = "[Raiz].[SP_ProcesosVentas_BienesRaices_PorcentajeVentas_Dashboard]";
        public static string DashboarVentamensualesTerrenos = "[Raiz].[SP_ProcesosVentas_Terrenos_Ventasmensuales_Dashboard]";
        public static string DashboarVentamensualesBienesRaices = "[Raiz].[SP_ProcesosVentas_BienesRaices_Ventasmensuales_Dashboard]";

        //proyecto
        public static string DashboardTop5ProyectosConMayorpresuepuesto = "Proy.SP_Proyecto_Top5ProyectosMayorPresupuesto_Dashboard";
        public static string DashboardProyectosPorDepartamento = "[Proy].[SP_Proyectos_EjecitadosPorDepartamento_Dashboard]";//filtrado
        public static string DashboardIncidentesporActividad = "Proy].[SP_IncidentesPorActividad_Dashboard]";//filtrado
        public static string DashboardIncidentesPorMes = "Proy.SP_Incidentes_DashboardTotalIncidenciasDelMesActual";
        public static string DashboardProyectospordepartamentoos = "[Proy].[SP_Proyectos_ProyectosPorDepartamento_Dashboard]";


        public static string DashboardProyectosIncidenciasPorrangofechas = "[Proy].[SP_Incidentes_DashboardTotalIncidenciasPorRangoFechas]";
        public static string DashboardProyectosMayorcostoporRangofechas = "[Proy].[SP_Top5ProyectosConMayorCostoPorRangoFechas]";
        public static string DashboardProyectosconMayorCostoporDepartamento = "[Proy].[SP_Top5ProyectosConMayorCostoPorEstado]";

        //planilla
        public static string DashboardDeudaPorEmpleados = "[Nomi].[SP_Prestamos_DeudaPorEmpleado_Dashboard]";//filtrado
        public static string DashboardTotalNominaMensual = "[Nomi].[SP_Planilla_TotalNominaMensual_Dashboard]";//filtrado



        //faltantes
        public static string DashboardProcesosVentasVentasAgente = "[Gral].[SP_Dashboard_ProcesosVentas_VentasPorAgente]";
        public static string DashboardProcesosVentasTerrenosVendidosPorMes = "[Gral].[SP_Dashboard_ProcesoVenta_TotalTerrenos]";
        public static string DashboardProcesosVentasBienesRaicesVendidosPorMes = "[Gral].[SP_Dashboard_ProcesoVenta_TotalBienesRaices]";
        public static string DashboardProcesosVendidosNoVendidosPorMes = "[Gral].[SP_Dashboard_ProcesosVentas_TotalFill]";
        public static string DashboardPlanillaPagosJefesObra = "[Gral].[SP_Dashboard_Planilla_PagosJefeObra]";
        public static string DashboardPlanillaTop5BancosConMasAcreditaciones = "[Gral].[SP_Banco_Top5Acreditaciones_Dashboard]";
        //public static string DashboardTotalIncidenciasAtividades = "[Gral].[SP_Dashboard_Incidentes_TotalIncidenciasDelMesActual]";
        public static string DashboardPlanillaTotalAnual = "Gral.SP_Dashboard_Planilla_TotalAnual";

        public static string DashboardTop5Bancos = "[Nomi].[SP_Banco_Top5Acreditaciones_Dashboard]";//filtrado
        public static string DashboardPrestamoMesViatico = "Nomi.SP_Viaticos_PrestadoMes_Dashboard";//filtrado
        public static string DashboardPrestamoMes = "Nomi.SP_Prestamos_PorDiasMes_Dashboard";//filtrado

        public static string JefesdeObra= "[Gral].[SP_Dashboard_Empleados_ListarJefeObra]";//filtrado

        #endregion
    }
}
