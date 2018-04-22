using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace prelucrare_tema
{
    public partial class Form1 : Form
    {
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            lab3ToolStripMenuItem.Enabled = false;
            lAb4ToolStripMenuItem.Enabled = false;
            lab5ToolStripMenuItem.Enabled = false;
            lab6ToolStripMenuItem.Enabled = false;
        }

        Bitmap bmp1;

        int MedR(int i, int j)
        {
            int s = 0;
            for (int ii = -1; ii <= 1; ii++)
                for (int jj = -1; jj <= 1; jj++)
                    s += bmp1.GetPixel(i + ii, j + jj).R;
            return s / 9;
        }

        int MedG(int i, int j)
        {
            int s = 0;
            for (int ii = -1; ii <= 1; ii++)
                for (int jj = -1; jj <= 1; jj++)
                    s += bmp1.GetPixel(i + ii, j + jj).G;
            return s / 9;
        }

        int MedB(int i, int j)
        {
            int s = 0;
            for (int ii = -1; ii <= 1; ii++)
                for (int jj = -1; jj <= 1; jj++)
                    s += bmp1.GetPixel(i + ii, j + jj).B;
            return s / 9;
        }

        private void lAb4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bmp = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            bmp1 = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            pictureBox1.Image = Image.FromFile("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            Console.WriteLine("-------" + bmp.Width);
            label5.Text = bmp.Width + "";

            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int r = MedR(x, y);
                    int g = MedG(x, y);
                    int b = MedB(x, y);
                    if (r > 255)
                        r = 255;
                    if (b > 255)
                        b = 255;
                    if (g > 255)
                        g = 255;
                    bmp1.SetPixel(x, y, Color.FromArgb(255, r, g, b));


                }
            }

            pictureBox2.Image = bmp1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //save (write) sepia image

        }

        private void incarcareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            pictureBox1.Image = Image.FromFile("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            Console.WriteLine("-------" + bmp.Width);
            label5.Text = bmp.Width + "";

        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp.Save("C:\\Users\\Bogdan\\Desktop\\nou.png");
        }

        private void lab1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //read image
            bmp = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");

            //load original image in picturebox1


            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            //load sepia image in picturebox2
            pictureBox2.Image = bmp;
        }

        private void lab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //read image
            bmp = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");

            //load original image in picturebox1


            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = 255 - r;
                    int tg = 255 - g;
                    int tb = 255 - b;

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            pictureBox2.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bmp = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");

            int a = int.Parse(textBoxA.Text.ToString());
            int b = int.Parse(textBoxB.Text.ToString());
            int va = int.Parse(textBoxVA.Text.ToString());
            int vb = int.Parse(textBoxVB.Text.ToString());

            int width = bmp.Width;
            int height = bmp.Height;



            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);
                    int rC = p.R;
                    int bC = p.B;
                    int gC = p.G;
                    int xx = (rC + bC + gC) / 3;
                    int tr = 255, tb = 255, tg = 255;

                    //extract pixel component ARGB
                    if (xx <= a)
                    {
                        tr = rC * va / a;
                        tb = bC * va / a;
                        tg = gC * va / a;
                    }

                    if (a < xx && xx <= b)
                    {
                        tr = (int)(1.0 * (rC - a) / (b - a) * (vb - va) + va);
                        tb = (int)(1.0 * (bC - a) / (b - a) * (vb - va) + va);
                        tg = (int)(1.0 * (gC - a) / (b - a) * (vb - va) + va);
                    }

                    if (b < xx)
                    {
                        tr = (int)(1.0 * (rC - b) / (255 - b) * (255 - vb) + vb);
                        tb = (int)(1.0 * (bC - b) / (255 - b) * (255 - vb) + vb);
                        tg = (int)(1.0 * (gC - b) / (255 - b) * (255 - vb) + vb);
                    }


                    //set new RGB value
                    if (tr > 255)
                    {
                        rC = 255;
                    }
                    else
                    {
                        rC = tr;
                    }
                    if (tr < 0)
                        rC = 0;

                    if (tg > 255)
                    {
                        gC = 255;
                    }
                    else
                    {
                        gC = tg;
                    }

                    if (tg < 0)
                        gC = 0;

                    if (tb > 255)
                    {
                        bC = 255;
                    }
                    else
                    {
                        bC = tb;
                    }
                    if (tb < 0)
                        bC = 0;
                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(p.A, rC, gC, bC));

                }

            }
            pictureBox2.Image = bmp;
        }

        private void lab6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            bmp1 = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            pictureBox1.Image = Image.FromFile("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            Console.WriteLine("-------" + bmp.Width);
            label5.Text = bmp.Width + "";

            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    bmp1.SetPixel(x, y, Color.FromArgb(255, 63, 31, 0));

                }
            }

            pictureBox2.Image = bmp1;
        }

        private void lab3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}

