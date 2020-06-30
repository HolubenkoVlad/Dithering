using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Color[] colors;

        Dithering dithering;

        public Form1()
        {
            InitializeComponent();
            colors = new Color[10];
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            dithering = new Dithering();
            var bmp = pictureBox1.Image as Bitmap;
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            int k = bmp.Height;
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            dithering.doReplace(rgbValues, bmpData.Stride, colors);
            Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
            pictureBox1.Image = bmp;
        }

        private Color getColor()
        {
            colorDialog1.ShowDialog();
            return colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(filename);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            colors[0] = getColor();
            pictureBox2.BackColor = colors[0];
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            colors[1] = getColor();
            pictureBox3.BackColor = colors[1];
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            colors[2] = getColor();
            pictureBox4.BackColor = colors[2];
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            colors[3] = getColor();
            pictureBox5.BackColor = colors[3];
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            colors[4] = getColor();
            pictureBox6.BackColor = colors[4];
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            colors[5] = getColor();
            pictureBox7.BackColor = colors[5];
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            colors[6] = getColor();
            pictureBox8.BackColor = colors[6];
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            colors[7] = getColor();
            pictureBox9.BackColor = colors[7];
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            colors[8] = getColor();
            pictureBox10.BackColor = colors[8];
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            colors[9] = getColor();
            pictureBox11.BackColor = colors[9];
        }
    }
}
