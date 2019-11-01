using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Startup_Millenium
{
    public class b : Button
    {
        public b()
        {
            FlatAppearance.BorderSize = 0;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TabStop = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw Border using color specified in Flat Appearance
            Pen pen = new Pen(FlatAppearance.BorderColor, 1);
            Rectangle rectangle = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
            e.Graphics.DrawRectangle(pen, rectangle);
            e.Graphics.DrawRectangle(new Pen(this.BackColor, 5), this.ClientRectangle);
        }
    }
}
