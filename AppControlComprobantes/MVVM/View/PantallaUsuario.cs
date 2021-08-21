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
    public partial class PantallaUsuario : Form
    {
        public PantallaUsuario()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var pInicio = (PantallaInicio)Tag;
            pInicio.Show();
            Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            PantallaCrearNuevoCliente pCliente = new PantallaCrearNuevoCliente();
            pCliente.Tag = this;
            pCliente.Show(this);
            Hide();
        }
    }
}
