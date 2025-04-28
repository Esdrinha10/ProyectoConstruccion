using Dapper;
using Microsoft.Data.SqlClient;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.DataAccess.Repositories.RepositoryProyecto
{
    public class PresupuestoEncabezadoRepository : IRepository<tbPresupuestosEncabezado>
    {
        /// <summary>
        /// Elimina un presupuesto específico por su ID.
        /// </summary>
        /// <param name="id">El ID del presupuesto a eliminar.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Delete(int? id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", id);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.EliminarPresupuestoEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Aprueba el presupuesto encabezado específico por su ID y ID de proyecto.
        /// </summary>
        /// <param name="pren_Id">El pren_Id del presupuesto a buscar</param>
        /// /// <param name="proy_Id">El proy_Id del proyecto a buscar</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Aprobado(int? pren_Id, int? proy_Id)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", pren_Id);
                parameter.Add("@proy_Id", proy_Id);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.AprobadoPresupuestoEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Rechaza el presupuesto encabezado específico por el pren_Id y agrega una observacion.
        /// </summary>
        /// <param name="item">El item es el objeto tipo tbPresupuestosEncabezado a buscar.</param>
        /// <param name="pren_Id">El id del presupuesto a buscar.</param>
        /// <param name="pren_Observacion">La observacion que se agrega al rechazar el presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public RequestStatus Rechazado(tbPresupuestosEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", item.pren_Id);
                parameter.Add("@pren_Observacion", item.pren_Observacion);
                var ansewer = db.QueryFirst<int>(ScriptsDataBase.RechazadoPresupuestoEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Busca y devuelve un presupuesto específico por su ID.
        /// </summary>
        /// <param name="id">El ID del presupuesto a buscar.</param>
        /// <returns>Un objeto tbPresupuestosEncabezado que representa el presupuesto encontrado.</returns>
        public tbPresupuestosEncabezado Find(int? id)
        {
            tbPresupuestosEncabezado result = new tbPresupuestosEncabezado();

            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", id);
                result = db.QueryFirst<tbPresupuestosEncabezado>(ScriptsDataBase.BuscarPresupuestoEncabezado, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Inserta un nuevo presupuesto en la base de datos.
        /// </summary>
        /// <param name="item">El objeto tbPresupuestosEnzabezado que contiene los datos del nuevo presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Insert(tbPresupuestosEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Titulo", item.pren_Titulo);
                parameter.Add("@pren_Descripcion", item.pren_Descripcion);
                parameter.Add("@pren_Fecha", item.pren_Fecha);
                parameter.Add("@pren_PorcentajeGanancia", item.pren_PorcentajeGanancia);
                parameter.Add("@pren_Maquinaria", item.pren_Maquinaria);
                parameter.Add("@pren_Impuesto", item.pren_Impuesto);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@clie_Id", item.clie_Id);
                parameter.Add("@usua_Creacion", item.usua_Creacion);
                parameter.Add("@pren_FechaCreacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.InsertarPresupuestoEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los presupuestos.
        /// </summary>
        /// <returns>Una colección IEnumerable de objetos tbPresupuestosEncabezado que representa los presupuestos encontrados.</returns>
        public virtual IEnumerable<tbPresupuestosEncabezado> List()
        {
            List<tbPresupuestosEncabezado> result = new List<tbPresupuestosEncabezado>();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                result = db.Query<tbPresupuestosEncabezado>(ScriptsDataBase.ListarPresupuestosEncabezado, commandType: CommandType.Text).ToList();
                return result;
            }
        }


        /// <summary>
        /// Actualiza los datos de un presupuesto existente.
        /// </summary>
        /// <param name="item">El objeto tbPresupuestosEnzabezado que contiene los datos actualizados del presupuesto.</param>
        /// <returns>Un objeto RequestStatus que indica el resultado de la operación.</returns>
        public virtual RequestStatus Update(tbPresupuestosEncabezado item)
        {
            RequestStatus result = new RequestStatus();
            using (var db = new SqlConnection(SIGESPROC.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@pren_Id", item.pren_Id);
                parameter.Add("@pren_Titulo", item.pren_Titulo);
                parameter.Add("@pren_Descripcion", item.pren_Descripcion);
                parameter.Add("@pren_Fecha", item.pren_Fecha);
                parameter.Add("@pren_PorcentajeGanancia", item.pren_PorcentajeGanancia);
                parameter.Add("@pren_Maquinaria", item.pren_Maquinaria);
                parameter.Add("@empl_Id", item.empl_Id);
                parameter.Add("@clie_Id", item.clie_Id);
                parameter.Add("@proy_Id", item.proy_Id);
                parameter.Add("@usua_Modificacion", item.usua_Modificacion);
                parameter.Add("@pren_FechaModificacion", DateTime.Now);

                var ansewer = db.QueryFirst<int>(ScriptsDataBase.ActualizarPresupuestoEncabezado, parameter, commandType: CommandType.StoredProcedure);
                result.CodeStatus = ansewer;
                return result;
            }
        }

    }
}
