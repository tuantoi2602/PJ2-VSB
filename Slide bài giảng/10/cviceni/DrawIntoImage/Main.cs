using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DrawIntoImage
{
    public partial class Main : Form
    {
        private PictureBox[] fields = null;
        private Image[] images;
        private int fieldsCount = 9;
        private int actualPos = -1;

        public Main()
        {
            InitializeComponent();
        }

        private void bInit_Click(object sender, EventArgs e)
        {
            // odregistrovani a zruseni komponent jiz vytvorenych
            if (fields != null)
            {
                foreach (PictureBox pb in fields)
                {
                    this.Controls.Remove(pb);
                    pb.Dispose();
                }
                fields = null;
            }

            // znovu nacteni obrazku z disku
            images = new Image[3];
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            
            images[0] = Image.FromFile(path + "/../../img/black128.png");
            images[1] = Image.FromFile(path + "/../../img/white128.png");
            images[2] = Image.FromFile(path + "/../../img/img128.png");

            // vytvoreni pole komponent a nastaveni obrazku a udalosti
            fields = new PictureBox[fieldsCount];
            for (int i = 0; i < fieldsCount; i++)
            {
                fields[i] = new PictureBox();
                fields[i].Image = images[i % 2];
                fields[i].Left = 20 + 128 * (i % 3);
                fields[i].Top = 120 + 128 * (i / 3);
                fields[i].Width = 128;
                fields[i].Height = 128;
                fields[i].Tag = i;
                fields[i].Click += FieldClick;
                Controls.Add(fields[i]);
            }

            lHint.Visible = true;
        }

        private void FieldClick(Object sender, EventArgs e)
        {
            if (!(sender is PictureBox))
                return;

            PictureBox pb = sender as PictureBox;
            // zrusit predchozi pozici
            if (actualPos >= 0)
            {
                fields[actualPos].Image = images[actualPos % 2];
            }
            // vykreslit obrazek
            actualPos = (int)pb.Tag;
            Image img = (Image)images[actualPos % 2].Clone();
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(images[2], 0, 0);

            fields[actualPos].Image = img;
        }

    }
}
