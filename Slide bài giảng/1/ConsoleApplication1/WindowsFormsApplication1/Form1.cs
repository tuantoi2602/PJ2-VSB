using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("{0} {1}", e.X, e.Y);
            Draw(e.X, e.Y);
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
