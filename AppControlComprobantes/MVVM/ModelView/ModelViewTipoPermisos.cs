using AppControlComprobantes.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppControlComprobantes.MVVM.ModelView
{
    public class ModelViewTipoPermisos
    {
        //Obtener todos los tipos de monedas
        #region ObtenerTipoPermiso
        /// <summary>
        /// ObtenerTipoPermiso
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoPermisos> ObtenerTipoPermiso()
        {
            IEnumerable<TipoPermisos> tipoPermisos = null;
            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    tipoPermisos = ctx.TipoPermisos.ToList();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return tipoPermisos;
        }
        #endregion

    }
}
