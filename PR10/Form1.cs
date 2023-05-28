using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR10
{
    public partial class Form1 : Form
    {
        
        bool rectClicked = false;
        bool circClicked = false;
        bool squaClicked = false;

        
        Point rectLocation = new Point(10, 10);
        Point circLocation = new Point(220, 10);
        Point squaLocation = new Point(380, 10);

        
        int lastClicked = 0;

        
        int offsetX = 0;
        int offsetY = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.FillRectangle(Brushes.Yellow, rectLocation.X, rectLocation.Y, 200, 100);
            e.Graphics.FillEllipse(Brushes.Red, circLocation.X, circLocation.Y, 150, 150);
            e.Graphics.FillRectangle(Brushes.Blue, squaLocation.X, squaLocation.Y, 150, 150);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (rectLocation.X <= e.X && e.X <= rectLocation.X + 200 &&
                rectLocation.Y <= e.Y && e.Y <= rectLocation.Y + 100)
            {
                rectClicked = true;
                lastClicked = 1;
                offsetX = e.X - rectLocation.X;
                offsetY = e.Y - rectLocation.Y;
            }
            else if (circLocation.X <= e.X && e.X <= circLocation.X + 150 &&
                     circLocation.Y <= e.Y && e.Y <= circLocation.Y + 150)
            {
                circClicked = true;
                lastClicked = 2;
                offsetX = e.X - circLocation.X;
                offsetY = e.Y - circLocation.Y;
            }
            else if (squaLocation.X <= e.X && e.X <= squaLocation.X + 150 &&
                     squaLocation.Y <= e.Y && e.Y <= squaLocation.Y + 150)
            {
                squaClicked = true;
                lastClicked = 3;
                offsetX = e.X - squaLocation.X;
                offsetY = e.Y - squaLocation.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            switch (lastClicked)
            {
                case 1:
                    if (rectClicked)
                    {
                        rectLocation.X = e.X - offsetX;
                        rectLocation.Y = e.Y - offsetY;
                    }
                    break;
                case 2:
                    if (circClicked)
                    {
                        circLocation.X = e.X - offsetX;
                        circLocation.Y = e.Y - offsetY;
                    }
                    break;
                case 3:
                    if (squaClicked)
                    {
                        squaLocation.X = e.X - offsetX;
                        squaLocation.Y = e.Y - offsetY;
                    }
                    break;
            }

            
            if (lastClicked == 1 && new Rectangle(rectLocation.X, rectLocation.Y, 200, 100).Contains(e.X, e.Y))
            {
                BringToFront(pictureBox1, Brushes.Yellow, rectLocation);
                l1.Text = "прямоугольник";
            }
            else if (lastClicked == 2 && new Rectangle(circLocation.X, circLocation.Y, 150, 150).Contains(e.X, e.Y))
            {
                BringToFront(pictureBox1, Brushes.Red, circLocation);
                l1.Text = "круг";
            }
            else if (lastClicked == 3 && new Rectangle(squaLocation.X, squaLocation.Y, 150, 150).Contains(e.X, e.Y))
            {
                BringToFront(pictureBox1, Brushes.Blue, squaLocation);
                l1.Text = "синий квадрат";
            }

            
            pictureBox1.Invalidate();

            
            rectClicked = false;
            circClicked = false;
            squaClicked = false;
            lastClicked = 0;
        }

        
        private void BringToFront(PictureBox pictureBox, Brush color, Point location)
        {
            
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            g.FillEllipse(Brushes.Red, circLocation.X, circLocation.Y, 150, 150);
            g.FillRectangle(Brushes.Blue, squaLocation.X, squaLocation.Y, 150, 150);
            g.FillRectangle(Brushes.Yellow, rectLocation.X, rectLocation.Y, 200, 100);

            
            pictureBox.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}