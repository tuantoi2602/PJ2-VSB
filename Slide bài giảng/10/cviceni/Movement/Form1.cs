using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Movement.Properties;

namespace Movement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Create an image and draw few geometric shapes on it
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);

                g.DrawLine(Pens.Black, 0, 0, b.Width, b.Height);
                g.DrawRectangle(Pens.Blue, 10, 10, 50, 50);
                g.DrawEllipse(Pens.Green, 100, 100, 60, 60);
                g.FillEllipse(Brushes.Red, 100, 10, 30, 40);
            }
            pictureBox.Image = b;
        }

        // Load image form Resources and place it into picture
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;
            Image img = pictureBox.Image;
            Random r = new Random();
            int x = r.Next(img.Width);
            int y = r.Next(img.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawImage(Resources.car, x, y);
            }
            pictureBox.Invalidate(new Rectangle(x, y, 
                Resources.car.Width, Resources.car.Height));
        }

        // Add a new car into list, if no car exists in list, enable timer
        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
                return;
            if (background == null)
                background = new Bitmap(pictureBox.Image);
            // vytvoreni noveho auticka
            positions.Add(new Point(0, 
                random.Next(background.Height-Resources.car.Height)));

            if (!timer.Enabled)
            {
                timer.Enabled = true;
                this.Text = "Timer enabled";
            }
        }

        // background image for animation
        private Bitmap background = null;
        // positions of cars
        private List<Point> positions = new List<Point>();
        // Uniform random number generator
        private Random random = new Random();

        // Drawer of images when timer ticks
        private void timer_Tick(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(background);
            // draw all cars
            using (Graphics g = Graphics.FromImage(b))
            {
                foreach(Point p in positions)
                    g.DrawImage(Resources.car, p.X, p.Y);
            }
            pictureBox.Image = b;

            // increment car positions
            for (int i = 0; i < positions.Count; i++)
            {
                Point p = positions[i];
                p.X += 2;
                positions[i] = p;
            }

            // remove cars which are out of picture
            while (positions.Count > 0 && positions[0].X >= background.Width)
                positions.RemoveAt(0);
            // if no car remain, clear backgrou and disable timer
            if (positions.Count==0)
            {
                timer.Enabled = false;
                this.Text = "Timer disabled";
                background = null;
            }
        }
    }
}
