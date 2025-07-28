using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Forms
{
    public partial class OpcionesAnfitrion : Form
    {
        public OpcionesAnfitrion()
        {
            InitializeComponent();
        }

        private void btnDatosAlojamiento_Click(object sender, EventArgs e)
        {
            DatosAlojamiento datosAlojamiento = new DatosAlojamiento();
            datosAlojamiento.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoResidencia tipoResidencia = new TipoResidencia();
            tipoResidencia.Show();
            this.Close();
        }
    }
}
