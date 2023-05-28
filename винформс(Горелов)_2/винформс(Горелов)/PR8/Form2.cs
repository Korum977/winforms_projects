using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR8
{
    public partial class Form2 : Form
    {
        Color colorResult;

        public Form2(Color color)
        {
            InitializeComponent();

            Scroll_red.Tag = numeric_red;
            Scroll_green.Tag = numeric_green;
            Scroll_blue.Tag = numeric_blue;

            numeric_red.Tag = Scroll_red;
            numeric_green.Tag = Scroll_green;
            numeric_blue.Tag = Scroll_blue;


            numeric_red.Value = color.R;
            numeric_green.Value = color.G;
            numeric_blue.Value = color.B;


        }

        private void updateColor()
        {
            colorResult = Color.FromArgb(Scroll_red.Value,Scroll_green.Value, Scroll_blue.Value);
            pictureBox1.BackColor = colorResult;
        }

        private void numeric_green_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        private void numeric_red_ValueChanged(object sender, EventArgs e)
        {
                        NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        private void Scroll_blue_ValueChanged(object sender, EventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
        }

        private void Scroll_green_ValueChanged(object sender, EventArgs e)
        {
                        ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
        }

        private void Scroll_red_ValueChanged(object sender, EventArgs e)
        {
                        ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
        }

        private void numeric_blue_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                Scroll_red.Tag = cd.Color.R;
                Scroll_green.Tag = cd.Color.G;
                Scroll_blue.Tag = cd.Color.B;

                colorResult = cd.Color;
                updateColor();
            }


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 m = this.Owner as Form1;
            if (m != null)
            {
                m.colorResult = colorResult;
                m.color_form1.Text = colorResult.ToString();
                this.Close();
            }
        }

        private void Scroll_red_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
