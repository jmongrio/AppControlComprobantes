using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppControlComprobantes.MVVM.View
{
    public partial class PantallaListaClientes : Form
    {
        public PantallaListaClientes()
        {
            InitializeComponent();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            PantallaCrearNuevoCliente pCliente = new PantallaCrearNuevoCliente();
            pCliente.Tag = this;
            pCliente.Show(this);
            Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var pUsuaro = (PantallaUsuario)Tag;
            pUsuaro.Show();
            Close();
        }

        #region btnAgregarCliente
        private void btnAgregarCliente_MouseEnter(object sender, EventArgs e)
        {
            btnAgregarCliente.BackColor = Color.FromArgb(80, 80, 80);
        }

        private void btnAgregarCliente_MouseLeave(object sender, EventArgs e)
        {
            btnAgregarCliente.BackColor = Color.FromArgb(50, 50, 50);
        }
        #endregion
    }
}
