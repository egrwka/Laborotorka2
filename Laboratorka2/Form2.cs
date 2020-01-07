using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorka2
{
    public partial class Form2 : Form
    {
        Color colorResult;
        Color color;

        public Form2()
        {
            InitializeComponent();


            Scroll_Red.Tag = numericUpDown1;
            Scroll_Green.Tag = numericUpDown2;
            Scroll_Blue.Tag = numericUpDown3;

            numericUpDown1.Tag = Scroll_Red;
            numericUpDown2.Tag = Scroll_Green;
            numericUpDown3.Tag = Scroll_Blue;

            numericUpDown1.Value = color.R;
            numericUpDown2.Value = color.G;
            numericUpDown3.Value = color.B;

        }

        private void HScrollBar1_Scroll(object sender,EventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        private void UpdateColor()
        {
            colorResult = Color.FromArgb(Scroll_Red.Value, Scroll_Green.Value, Scroll_Blue.Value);
            pictureBox1.BackColor = colorResult;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Scroll_Red.Value = colorDialog.Color.R;
                Scroll_Green.Value = colorDialog.Color.G;
                Scroll_Blue.Value = colorDialog.Color.B;

                colorResult = colorDialog.Color;

                UpdateColor();
            }
            Form1 Main = Owner as Form1;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1.currentPen.Color = colorResult;
            Close();
        }

        private void Scroll_Green_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void Scroll_Blue_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
            UpdateColor();
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
            UpdateColor();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
