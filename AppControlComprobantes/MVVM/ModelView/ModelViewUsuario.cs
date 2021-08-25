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
    public class ModelViewUsuario
    {
        #region ObtenerUsuarios
        /// <summary>
        /// ObtenerUsuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            IEnumerable<Usuario> usuarios = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuarios = ctx.Usuario.ToList();
                }
            }
            catch (SqlException DbEx)
            {
                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return usuarios;
        }
        #endregion


        #region ObtenerUsuariosConId
        /// <summary>
        /// ObtenerUsuariosConId
        /// </summary>
        /// <param name="id">Debe de ingresar un Id de un Usuario</param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioConId(int id)
        {
            Usuario usuario = null;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (SqlException DbEx)
            {

                MessageBox.Show("Error: " + DbEx.ToString());
            }


            return usuario;
        }
        #endregion

        #region EliminarUsario
        /// <summary>
        /// EliminarUsuario
        /// </summary>
        /// <param name="id">Debe de ingresar un Id de un Usuario</param>
        public void EliminarUsuario(int id)
        {
            int retorno;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    Usuario usuario = new Usuario()
                    {
                        Id = id
                    };
                    ctx.Entry(usuario).State = EntityState.Deleted;
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
        /// <param name="usuario">Obtiene todos los parámentros del Usuario</param>
        public void Guardar(Usuario usuario)
        {
            int retorno;
            Usuario oUsuario;

            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = ObtenerUsuarioConId(usuario.Id);

                    if (oUsuario == null)
                    {
                        usuario.Contrasenna = Seguridad.GetSHA256(usuario.Contrasenna);
                        ctx.Usuario.Add(usuario);
                    }
                    else
                    {
                        usuario.Contrasenna = Seguridad.GetSHA256(usuario.Contrasenna);
                        ctx.Entry(usuario).State = EntityState.Modified;
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


        #region ObtenerUsuarioVeficacion
        /// <summary>
        /// ObtenerUsuarioVerificacion
        /// </summary>
        /// <param name="cedula">Obtiener la cedula de un Usuario</param>
        /// <param name="clave">Obtener la clave de un Usuario</param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioVeficacion(string cedula, string clave)
        {
            Usuario usuario = null;
            string claveCifrada = Seguridad.GetSHA256(clave);
            try
            {
                using (ContextoComprobante ctx = new ContextoComprobante())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.Where(x => x.NumeroCedula.Equals(cedula) && x.Contrasenna.Equals(claveCifrada)).FirstOrDefault();
                }

            }
            catch (SqlException DbEx)
            {

                MessageBox.Show("Error: " + DbEx.ToString());
            }
            return usuario;
        }
        #endregion

    }
}
