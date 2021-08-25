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
    public class ModelViewCliente
    {
        #region ObtenerClientes
        /// <summary>
        /// ObtenerClientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> ObtenerClientes()
        {
            IEnumerable<Cliente> clientes = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    clientes = ctx.Cliente.ToList();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return clientes;
        }
        #endregion


        //Obtener Cliente mediante el Id
        #region ObtenerCLienteConId
        /// <summary>
        /// ObtenerCLienteConId
        /// </summary>
        /// <param name="id">Debe de ingresar un Id de un Comprobante</param>
        /// <returns></returns>
        public Cliente ObtenerClienteConId(int id)
        {
            Cliente cliente = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    cliente = ctx.Cliente.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (SqlException DbEx)
            {

                MessageBox.Show("Error: " + DbEx.ToString());
            }


            return cliente;
        }
        #endregion

        #region EliminarCliente
        /// <summary>
        /// EliminarCliente
        /// </summary>
        /// <param name="id">Debe de ingresar un Id de un Cliente</param>
        public void EliminarCliente(int id)
        {
            int retorno;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    Cliente cliente = new Cliente()
                    {
                        Id = id
                    };
                    ctx.Entry(cliente).State = EntityState.Deleted;
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
        /// <param name="cliente">Obtiene todos los parámetros del Cliente</param>
        public void Guardar(Cliente cliente)
        {
            int retorno;
            Cliente oCliente;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oCliente = ObtenerClienteConId(cliente.Id);

                    if (oCliente == null)
                    {
                        ctx.Cliente.Add(cliente);
                    }
                    else
                    {
                        ctx.Entry(cliente).State = EntityState.Modified;
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
