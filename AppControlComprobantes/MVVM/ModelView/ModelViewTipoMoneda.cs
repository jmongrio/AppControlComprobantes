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
    class ModelViewTipoMoneda
    {
        #region ObtenerTipoMoneda
        /// <summary>
        /// ObtenerTipoMoneda
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoMoneda> ObtenerTipoMoneda()
        {
            IEnumerable<TipoMoneda> monedas = null;
            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    monedas = ctx.TipoMoneda.ToList();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return monedas;
        }
        #endregion  
    }
}
