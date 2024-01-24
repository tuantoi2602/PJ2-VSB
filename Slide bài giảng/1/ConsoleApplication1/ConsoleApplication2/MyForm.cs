using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApplication2
{
    class MyForm : Form
    {
        public MyForm()
        {
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Draw(e.X, e.Y);
            base.OnMouseClick(e);
        }
        

        private void Draw(int x, int y)
        {
            Graphics g = null;
            Pen p = null;
            try
            {
                g = this.CreateGraphics();
                p = new Pen(Color.Blue);
                Rectangle r = new Rectangle(x, y, 50, 50);
                g.DrawRectangle(p, r);
            }
            finally
            {
                if (g != null) g.Dispose();
                if (p != null) p.Dispose();
            }
        }
    }
}
