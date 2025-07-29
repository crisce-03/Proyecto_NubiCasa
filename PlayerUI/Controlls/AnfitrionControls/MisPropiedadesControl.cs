using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI.Controlls.AnfitrionControls
{
    public partial class MisPropiedadesControl : Form
    {
        private int idAnfitrion;

        public MisPropiedadesControl(int ID_Anfitrion)
        {
            InitializeComponent();
            idAnfitrion = ID_Anfitrion;
    
        }

        private void btnAgregarPropiedad_Click(object sender, EventArgs e)
        {
            AgregarPropiedadForm agregarPropiedad =new  AgregarPropiedadForm(idAnfitrion);
            agregarPropiedad.Show();
        }
    }

}
