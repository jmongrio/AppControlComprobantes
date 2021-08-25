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
    public class ModelViewTipoCedula
    {
        #region ObtenerTipoCedula
        /// <summary>
        /// ObtenerTipoCedula
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoCedula> ObtenerTipoCedula()
        {
            IEnumerable<TipoCedula> cedulas = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    cedulas = ctx.TipoCedula.ToList();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return cedulas;
        }

        #endregion

    }
}
