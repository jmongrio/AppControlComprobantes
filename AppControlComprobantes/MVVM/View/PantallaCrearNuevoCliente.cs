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
    public partial class PantallaCrearNuevoCliente : Form
    {
        public PantallaCrearNuevoCliente()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var pUsuaro = (PantallaUsuario)Tag;
            pUsuaro.Show();
            Close();
        }

        private void btnAgregarNuevoCliente_Click(object sender, EventArgs e)
        {
            var pUsuaro = (PantallaCrearNuevoCliente)Tag;
            pUsuaro.Show();
            Close();
        }
    }
}
