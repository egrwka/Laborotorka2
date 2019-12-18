using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorka2
{
    public partial class Form1 : Form
    {
        bool drawing;
        int historyCounter;
        GraphicsPath currentPath;
        Point oldLocation;
        static public Pen currentPen;
        //Color historyColor;
        List<Image> History;
        Image imgOriginal;

        int Figur1 = 0;
        int localX = 0;
        int localY = 0;
        int localXD = 0;
        int localYD = 0;

        public Form1()
        {
            InitializeComponent();
            drawing = false;
            currentPen = new Pen(Color.Black);
            currentPen.Width = trackBar1.Value;
            pictureBox1.MouseDown += picturebox1_MouseDown;
            pictureBox1.MouseUp += picturebox1_MouseUp;
            pictureBox1.MouseMove += picturebox1_MouseMove;
            History = new List<Image>();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trackBar1.Value;
        }

        private void ToolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "JPEG Image |*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDialog.Title = "Save an Image File";
            SaveDialog.FilterIndex = 4;
            SaveDialog.ShowDialog();

            if (SaveDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDialog.OpenFile();
                switch (SaveDialog.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
            }
            if (pictureBox1.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: saveMenu_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
            imgOriginal = pictureBox1.Image;
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "JPEG Image |*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDialog.Title = "Save an Image File";
            SaveDialog.FilterIndex = 4;
            SaveDialog.ShowDialog();

            if (SaveDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDialog.OpenFile();
                switch (SaveDialog.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
                imgOriginal = pictureBox1.Image;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.Clear();
            historyCounter = 0;
            Bitmap pic = new Bitmap(820, 509);
            pictureBox1.Image = pic;
            History.Add(new Bitmap(pictureBox1.Image));
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image |*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;

            if (OP.ShowDialog() != DialogResult.Cancel)
                pictureBox1.Load(OP.FileName);
            pictureBox1.AutoSize = true;
            imgOriginal = pictureBox1.Image;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Application.Exit();
        }

        private void ToolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "JPEG Image |*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDialog.Title = "Save an Image File";
            SaveDialog.FilterIndex = 4;
            SaveDialog.ShowDialog();

            if (SaveDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDialog.OpenFile();
                switch (SaveDialog.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
                imgOriginal = pictureBox1.Image;
            }
        }

        private void ToolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image |*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;

            if (OP.ShowDialog() != DialogResult.Cancel)
                pictureBox1.Load(OP.FileName);
            pictureBox1.AutoSize = true;
        }

        private void picturebox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath();
            }
            if (e.Button == MouseButtons.Right)
            {
                drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath();
                currentPen.Color = Color.White;
            }
        }
        private void picturebox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Figur1 == 1)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                currentPath.AddRectangle(new Rectangle(localX, localY, localXD, localYD));
                g.DrawPath(currentPen, currentPath);
                oldLocation = e.Location;
                g.Dispose();
                pictureBox1.Invalidate();
            }
            else if (Figur1 == 2)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                currentPath.AddEllipse(localX, localY, localXD, localYD);
                g.DrawPath(currentPen, currentPath);
                oldLocation = e.Location;
                g.Dispose();
                pictureBox1.Invalidate();
            }

            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(pictureBox1.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10) History.RemoveAt(0);
            drawing = false;
            try
            {
                currentPath.Dispose();
            }
            catch { };
            imgOriginal = pictureBox1.Image;
        }
        private void picturebox1_MouseMove(object sender, MouseEventArgs e)
        {
            //label1.Text = e.X.ToString() + " , " + e.Y.ToString();
            if (drawing)
            {
                if (Figur1 == 0)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    currentPath.AddLine(oldLocation, e.Location);
                    g.DrawPath(currentPen, currentPath);
                    oldLocation = e.Location;
                    g.Dispose();
                    pictureBox1.Invalidate();
                }
                //else if (Figur1 == 1)
                //{
                //    Graphics g = Graphics.FromImage(pictureBox1.Image);
                //    currentPath.AddEllipse(localX, localY, localXD, localYD);
                //    g.DrawPath(currentPen, currentPath);
                //    oldLocation = e.Location;
                //    g.Dispose();
                //    pictureBox1.Invalidate();
                //}
                else
                {
                    localX = oldLocation.X;
                    localY = oldLocation.Y;
                    localXD = e.Location.X - oldLocation.X;
                    localYD = e.Location.Y - oldLocation.Y;
                }
                label1.Text = e.X.ToString() + " , " + e.Y.ToString();
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

            History.Clear();
            historyCounter = 0;
            Bitmap pic = new Bitmap(820, 509);
            pictureBox1.Image = pic;
            History.Add(new Bitmap(pictureBox1.Image));

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }
            if (pictureBox1.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: saveMenu_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
        }

        private void TrackBar1_Scroll_1(object sender, EventArgs e)
        {
            currentPen.Width = trackBar1.Value;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.Count != 0 && historyCounter != 0)
            {
                pictureBox1.Image = new Bitmap(History[--historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void RenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCounter < History.Count - 1)
            {
                pictureBox1.Image = new Bitmap(History[++historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void SolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Solid;

            solidToolStripMenuItem.Checked = true;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = false;

            Figur1 = 0;
        }

        private void DotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Dot;

            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = true;
            dashDotDotToolStripMenuItem.Checked = false;

            Figur1 = 0;
        }

    private void DashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.DashDotDot;

            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = true;

            Figur1 = 0;
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Form2 AddRec = new Form2();
          AddRec.Owner = this;
          AddRec.ShowDialog();
        }

        private void ToolStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creator : Egor Oleynik ♥");
            MessageBox.Show("Vkontakte : あなたの 好きな男の子 ♥");
            MessageBox.Show("Instagram : egrwka_ ♥");
            MessageBox.Show("Snapchat : olnke ♥");
        }

        private void FigureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Figur1 = 1;
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = Zoom(imgOriginal, trackBar2.Value);
        }
        Image Zoom(Image img, int size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size / 10), img.Height + (img.Height * size / 10));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Figur1 = 2;
        }
    }
}

