using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR8
{
    public partial class Form1 : Form
    {

        public Color colorResult;

        bool drawing;
        int historyCouter;

        GraphicsPath curPath;
        Point oldLoc;
        public Pen curPen;
        Color historyColor;
        List<Image> History;

        
        public void messageNewPic()
        {
            var result = MessageBox.Show(
                "Сохранить текущее изображение пред созданием нового рисунка?",
                "Предупреждение", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    SaveFile();
                    break;
                case DialogResult.No:
                    break;

            }
        }

        public void OpenFile()
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            OpenDlg.Title = "Open an image File";
            OpenDlg.FilterIndex = 1;

            if (OpenDlg.ShowDialog() == DialogResult.Cancel)
                picDrawingSurface.Load(OpenDlg.FileName);
            picDrawingSurface.AutoSize = true;
        }

        public void SaveFile()
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            SaveDlg.Title = "Save an image File";
            SaveDlg.FilterIndex = 4;
            SaveDlg.ShowDialog();

            if(SaveDlg.FileName != "")
            {
                FileStream fs = (FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.picDrawingSurface.Image
                            .Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.picDrawingSurface.Image
                            .Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picDrawingSurface.Image
                            .Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.picDrawingSurface.Image
                            .Save(fs, ImageFormat.Png);
                        break;
                    default:
                        break;
                }

                fs.Close();
            }
        }


        public Form1()
        {
            InitializeComponent();
            drawing = false;
            curPen = new Pen(Color.Black);
            curPen.Width = trackBar1.Value;
            History = new List<Image>();

        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.Clear();
            historyCouter = 0;
            Bitmap pic = new Bitmap(750, 500);
            picDrawingSurface.Image = pic;
            History.Add(new Bitmap(picDrawingSurface.Image));
        }

        private void picDrawingSurface_MouseDown(object sender, MouseEventArgs e)
        {
            if (picDrawingSurface == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;
                oldLoc = e.Location;
                curPath = new GraphicsPath();
            }
        }



        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            messageNewPic();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            messageNewPic();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }


        private void picDrawingSurface_MouseUp(object sender, MouseEventArgs e)
        {
            History.RemoveRange(historyCouter + 1,
                History.Count - historyCouter - 1);

            History.Add(new Bitmap(picDrawingSurface.Image));
            if (historyCouter + 1 < 10) historyCouter++;
            if (historyCouter - 1 == 10) History.RemoveAt(0);
            drawing = false;
            try
            {
                curPath.Dispose();
            }
            catch (Exception){}
        }

        private void picDrawingSurface_MouseMove(object sender, MouseEventArgs e)
        {
            label_XY.Text = e.X.ToString() + ", " + e.Y.ToString();

            if (picDrawingSurface == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                using (Graphics g = Graphics.FromImage(picDrawingSurface.Image))
                {
                    curPath = new GraphicsPath();
                    curPath.AddEllipse(e.Location.X - 5, e.Location.Y - 5, 10, 10);
                    Region region = new Region(curPath);
                    g.SetClip(region, CombineMode.Replace);
                    g.Clear(Color.Transparent);
                    picDrawingSurface.Invalidate();
                }
            }
            else
            {
                if (drawing)
                {
                    Graphics g = Graphics.FromImage(picDrawingSurface.Image);
                    curPath.AddLine(oldLoc, e.Location);
                    g.DrawPath(curPen, curPath);
                    oldLoc = e.Location;
                    g.Dispose();
                    picDrawingSurface.Invalidate();
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            curPen.Width = trackBar1.Value;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.Count != 0 && historyCouter != 0)
            {
                picDrawingSurface.Image = new Bitmap(History[--historyCouter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCouter < History.Count -1)
            {
                picDrawingSurface.Image = new Bitmap(History[++historyCouter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curPen.DashStyle = DashStyle.Solid;
            solidToolStripMenuItem.Checked= true;
            dotToolStripMenuItem.Checked= false;
            dashDotDotToolStripMenuItem.Checked= false;
        }
        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curPen.DashStyle = DashStyle.Dot;
            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = true;
            dashDotDotToolStripMenuItem.Checked = false;
        }
        private void dashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curPen.DashStyle = DashStyle.DashDotDot;
            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = true;
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(colorResult);
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void iconPictureBox3_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(colorResult);
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void picDrawingSurface_Click(object sender, EventArgs e)
        {

        }
    }
}
