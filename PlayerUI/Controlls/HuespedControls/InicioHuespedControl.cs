using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class InicioHuespedControl : Form
    {
        //private int idHuesped;

        public InicioHuespedControl()
        {
            InitializeComponent();
          

            CargarBienvenida();
            CargarReservas();
            CargarRecomendaciones();
            CargarNotificaciones();
        }

        private void CargarBienvenida()
        {
            // Puedes traer el nombre desde BD si no lo tienes ya
            //lblBienvenida.Text = $"Hola, Cristopher 👋";
        }

        private void CargarReservas()
        {
            // Simulación
            /*foreach (var reserva in ObtenerReservasActivasDesdeBD(idHuesped))
            {
                var tarjeta = new TarjetaReserva(); // UserControl
                tarjeta.Configurar(reserva); // Le pasas la info
                flowReservas.Controls.Add(tarjeta);
            }*/
        }

        private void CargarRecomendaciones()
        {
            /*foreach (var propiedad in ObtenerRecomendaciones(idHuesped))
            {
                var tarjeta = new TarjetaPropiedad();
                tarjeta.Configurar(propiedad.Nombre, propiedad.Ubicacion, propiedad.Precio, propiedad.Imagen, true);
                flowRecomendaciones.Controls.Add(tarjeta);
            }*/
        }

        private void CargarNotificaciones()
        {
            /*var notificaciones = ObtenerNotificaciones(idHuesped);
            foreach (var n in notificaciones)
            {
                Label lbl = new Label();
                lbl.Text = "• " + n.Mensaje;
                lbl.AutoSize = true;
                panelNotificaciones.Controls.Add(lbl);*/
            }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }


