using AppControlComprobantes.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppControlComprobantes.MVVM.ModelView
{
    public class ModelViewComprobanteDeposito
    {


        #region ObtenerComprobantes
        /// <summary>
        /// Obtener todos los comprobantes 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ComprobanteDeposito> ObtenerComprobantes()
        {
            IEnumerable<ComprobanteDeposito> comprobanteDepositos = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    comprobanteDepositos = ctx.ComprobanteDeposito.ToList();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return comprobanteDepositos;

        }

        #endregion



        #region ObtenerComprobanteDepositoConId
        /// <summary>
        /// ObtenerComprobanteDepositoConId
        /// </summary>
        /// <param name="id">Debe de ingresar un Id de un Comprobante</param>
        /// <returns></returns>
        public ComprobanteDeposito ObtenerComprobanteDepositoConId(int id)
        {
            ComprobanteDeposito comprobanteDeposito = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    comprobanteDeposito = ctx.ComprobanteDeposito.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (SqlException DbEx)
            {

                MessageBox.Show("Error: " + DbEx.ToString());
            }


            return comprobanteDeposito;
        }
        #endregion

        #region EliminarComprobante
        /// <summary>
        /// EliminarComprobante
        /// </summary>
        /// <param name="id">Debe de ingresar un Id de un Comprobante</param>
        public void EliminarComprobante(int id)
        {
            int retorno;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ComprobanteDeposito comprobanteDeposito = new ComprobanteDeposito()
                    {
                        Id = id
                    };
                    ctx.Entry(comprobanteDeposito).State = EntityState.Deleted;
                    retorno = ctx.SaveChanges();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
        }

        #endregion

        #region Guardar
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="comprobanteDeposito">Obtiene todos los parámetros del Comprobante</param>
        public void Guardar(ComprobanteDeposito comprobanteDeposito)
        {
            int retorno;
            ComprobanteDeposito oComprobanteDeposito;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oComprobanteDeposito = ObtenerComprobanteDepositoConId(comprobanteDeposito.Id);

                    if (oComprobanteDeposito == null)
                    {
                        ctx.ComprobanteDeposito.Add(comprobanteDeposito);
                    }
                    else
                    {
                        ctx.Entry(comprobanteDeposito).State = EntityState.Modified;
                    }

                    retorno = ctx.SaveChanges();

                }
            }
            catch (SqlException DbEx)
            {

                MessageBox.Show("Error: " + DbEx.ToString());
            }
        }
        #endregion
    }
}
