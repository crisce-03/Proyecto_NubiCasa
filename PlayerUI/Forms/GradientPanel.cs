using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{

    public class GradientPanel : Panel
    {
        public Color ColorTop { get; set; } = Color.FromArgb(235, 42, 83);
        public Color ColorBottom { get; set; } = Color.FromArgb(255, 128, 150);

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle,
                this.ColorTop, this.ColorBottom, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
