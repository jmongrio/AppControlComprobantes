using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        #region Mover ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void moveWindows(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
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
