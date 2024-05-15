using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPerezEtapa6
{
    public partial class frmEtapa6 : Form
    {
        clsVehiculo objVehiculo = new clsVehiculo();
        public frmEtapa6()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            objVehiculo.CrearVehiculoAleatorio(picVehiculos);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            objVehiculo.LimpiarPictureBox(picVehiculos);
        }
    }
}
