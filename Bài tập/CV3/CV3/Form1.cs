using CV3Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CV3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Stack Logic

        private MyStack stack = new MyStack();

        private void button1_Click(object sender, EventArgs e)
        {
            stack.Push(Convert.ToInt32(txtStack.Text));
            txtStack.Text = String.Empty;
            VisualizeStack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int element = stack.Pop();
            MessageBox.Show(element.ToString());
            VisualizeStack();
        }

        private void VisualizeStack()
        {
            listStack.Items.Clear();
            int[] elements = stack.Emelents;

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                listStack.Items.Add(elements[i]);
            }
        }

        #endregion

        #region Queue Logic

        private MyQueue queue = new MyQueue();

        private void button4_Click(object sender, EventArgs e)
        {
            queue.Add(Convert.ToInt32(txtQueue.Text));
            txtQueue.Text = String.Empty;
            VisualizeQueue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int element = queue.Get();
            MessageBox.Show(element.ToString());
            VisualizeQueue();
        }

        private void VisualizeQueue()
        {
            listQueue.Items.Clear();
            int[] elements = queue.Emelents;

            for (int i = 0; i < elements.Length; i++)
            {
                listQueue.Items.Add(elements[i]);
            }
        }

        #endregion

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.CreateGraphics().DrawRectangle(Pens.Red, 10, 10, 100, 300);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.CreateGraphics().DrawEllipse(Pens.Blue, 100, 100, 150, 100);
        }
    }
}
