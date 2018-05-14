using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        private Bitmap fillWhiteColor(Bitmap b)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    b.SetPixel(i, j, Color.White);
                }
            }
            return b;
        }


        public static T[][] ArrayClone<T>(T[][] A)
        { return A.Select(a => a.ToArray()).ToArray(); }


        public static bool[][] ZhangSuenThinning(bool[][] s)
        {
            bool[][] temp = ArrayClone(s);  // make a deep copy to start.. 
            int count = 0;
            do  // the missing iteration
            {
                count = step(1, temp, s);
                temp = ArrayClone(s);      // ..and on each..
                count += step(2, temp, s);
                temp = ArrayClone(s);      // ..call!
            }
            while (count > 0);

            return s;
        }

        static int step(int stepNo, bool[][] temp, bool[][] s)
        {
            int count = 0;

            for (int a = 1; a < temp.Length - 1; a++)
            {
                for (int b = 1; b < temp[0].Length - 1; b++)
                {
                    if (SuenThinningAlg(a, b, temp, stepNo == 2))
                    {
                        // still changes happening?
                        if (s[a][b]) count++;
                        s[a][b] = false;
                    }
                }
            }
            return count;
        }

        static bool SuenThinningAlg(int x, int y, bool[][] s, bool even)
        {
            bool p2 = s[x][y - 1];
            bool p3 = s[x + 1][y - 1];
            bool p4 = s[x + 1][y];
            bool p5 = s[x + 1][y + 1];
            bool p6 = s[x][y + 1];
            bool p7 = s[x - 1][y + 1];
            bool p8 = s[x - 1][y];
            bool p9 = s[x - 1][y - 1];


            int bp1 = NumberOfNonZeroNeighbors(x, y, s);
            if (bp1 >= 2 && bp1 <= 6) //2nd condition
            {
                if (NumberOfZeroToOneTransitionFromP9(x, y, s) == 1)
                {
                    if (even)
                    {
                        if (!((p2 && p4) && p8))
                        {
                            if (!((p2 && p6) && p8))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (!((p2 && p4) && p6))
                        {
                            if (!((p4 && p6) && p8))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        static int NumberOfZeroToOneTransitionFromP9(int x, int y, bool[][] s)
        {
            bool p2 = s[x][y - 1];
            bool p3 = s[x + 1][y - 1];
            bool p4 = s[x + 1][y];
            bool p5 = s[x + 1][y + 1];
            bool p6 = s[x][y + 1];
            bool p7 = s[x - 1][y + 1];
            bool p8 = s[x - 1][y];
            bool p9 = s[x - 1][y - 1];

            int A = Convert.ToInt32((!p2 && p3)) + Convert.ToInt32((!p3 && p4)) +
                    Convert.ToInt32((!p4 && p5)) + Convert.ToInt32((!p5 && p6)) +
                    Convert.ToInt32((!p6 && p7)) + Convert.ToInt32((!p7 && p8)) +
                    Convert.ToInt32((!p8 && p9)) + Convert.ToInt32((!p9 && p2));
            return A;
        }
        static int NumberOfNonZeroNeighbors(int x, int y, bool[][] s)
        {
            int count = 0;
            if (s[x - 1][y]) count++;
            if (s[x - 1][y + 1]) count++;
            if (s[x - 1][y - 1]) count++;
            if (s[x][y + 1]) count++;
            if (s[x][y - 1]) count++;
            if (s[x + 1][y]) count++;
            if (s[x + 1][y + 1]) count++;
            if (s[x + 1][y - 1]) count++;
            return count;
        }
        public static Image Bool2Image(bool[][] s)
        {
            Bitmap bmp = new Bitmap(s[0].Length, s.Length);
            using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.White);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    if (s[y][x]) bmp.SetPixel(x, y, Color.Black);

            return (Bitmap)bmp;
        }

        public static bool[][] Image2Bool(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            bool[][] s = new bool[bmp.Height][];
            for (int y = 0; y < bmp.Height; y++)
            {
                s[y] = new bool[bmp.Width];
                for (int x = 0; x < bmp.Width; x++)
                    s[y][x] = bmp.GetPixel(x, y).GetBrightness() < 0.3;
            }
            return s;

        }

        private void lab6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("C:\\Users\\Bogdan\\Desktop\\download.png");
            Image img  = Image.FromFile("C:\\Users\\Bogdan\\Desktop\\download.png");
            bool[][] t = Image2Bool(img);
            t = ZhangSuenThinning(t);
            pictureBox2.Image = Bool2Image(t);
        }

        private unsafe void lab3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Image = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            int Size = 2;

            System.Drawing.Bitmap TempBitmap = Image;
            System.Drawing.Bitmap NewBitmap = new System.Drawing.Bitmap(TempBitmap.Width, TempBitmap.Height);
            System.Drawing.Graphics NewGraphics = System.Drawing.Graphics.FromImage(NewBitmap);
            NewGraphics.DrawImage(TempBitmap, new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), System.Drawing.GraphicsUnit.Pixel);
            NewGraphics.Dispose();
            Random TempRandom = new Random();
            int ApetureMin = -(Size / 2);
            int ApetureMax = (Size / 2);
            for (int x = 0; x < NewBitmap.Width; ++x)
            {
                for (int y = 0; y < NewBitmap.Height; ++y)
                {
                    int RValue = 0;
                    int GValue = 0;
                    int BValue = 0;
                    for (int x2 = ApetureMin; x2 < ApetureMax; ++x2)
                    {
                        int TempX = x + x2;
                        if (TempX >= 0 && TempX < NewBitmap.Width)
                        {
                            for (int y2 = ApetureMin; y2 < ApetureMax; ++y2)
                            {
                                int TempY = y + y2;
                                if (TempY >= 0 && TempY < NewBitmap.Height)
                                {
                                    Color TempColor = TempBitmap.GetPixel(TempX, TempY);
                                    if (TempColor.R > RValue)
                                        RValue = TempColor.R;
                                    if (TempColor.G > GValue)
                                        GValue = TempColor.G;
                                    if (TempColor.B > BValue)
                                        BValue = TempColor.B;
                                }
                            }
                        }
                    }
                    Color TempPixel = Color.FromArgb(RValue, GValue, BValue);
                    NewBitmap.SetPixel(x, y, TempPixel);
                }
            }

            pictureBox2.Image = NewBitmap;
        }

        private void lab5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            Bitmap b = new Bitmap("C:\\Users\\Bogdan\\Desktop\\double.jpg");
            List<int[,]> mask = new List<int[,]>();
            int[,] x0 = { { 255, 255, 255 }, { -1, 0, -1 }, { 0, 0, 0 } };
            mask.Add(x0);
            int[,] x1 = { { -1, 255, 255 }, { 0, 0, 255 }, { 0, 0, -1 } };
            mask.Add(x1);
            int[,] x2 = { { 0, -1, 255 }, { 0, 0, 255 }, { 0, -1, 255 } };
            mask.Add(x2);
            int[,] x3 = { { 0, 0, -1 }, { 0, 0, 255 }, { -1, 255, 255 } };
            mask.Add(x3);
            int[,] x4 = { { 0, 0, 0 }, { -1, 0, -1 }, { 255, 255, 255 } };
            mask.Add(x4);
            int[,] x5 = { { -1, 0, 0 }, { 255, 0, 0 }, { 255, 255, -1 } };
            mask.Add(x5);
            int[,] x6 = { { 255, -1, 0 }, { 255, 0, 0 }, { 255, -1, 0 } };
            mask.Add(x6);
            int[,] x7 = { { 255, 255, -1 }, { 255, 0, 0 }, { -1, 0, 0 } };
            mask.Add(x7);


            Bitmap im = b;
            Bitmap imResolt = im.Clone() as Bitmap; //new Bitmap(im.Width, im.Height);

            bool isChange = true;
            while (isChange)
            {
                isChange = false;
                for (int k = 0; k < mask.Count; k++)
                {

                    for (int j = 0; j < im.Height - 3; j++)
                    {
                        for (int i = 0; i < im.Width - 3; i++)
                        {
                            int sum = 0;
                            for (int m = 0; m < mask[k].GetLength(0); m++)
                            {
                                for (int n = 0; n < mask[k].GetLength(1); n++)
                                {
                                    int x = im.GetPixel(i + n, j + m).R;
                                    int y = mask[k][m, n];
                                    if (y == -1)
                                        sum++;
                                    else if (x == y)
                                        sum++;
                                    if (sum == 9)
                                    {
                                        imResolt.SetPixel(i + 1, j + 1, Color.White);
                                        isChange = true;
                                        //Invoke(new Action(() =>
                                        //{
                                        //}));
                                    }
                                }
                            }
                        }
                    }
                    //Invoke(new Action(() =>
                    //{
                    //}));
                    im = imResolt.Clone() as Bitmap;

                }
            }
            pictureBox2.Image = imResolt;
            //imResolt.Save(@"./IP/result.bmp");
        }

        private void incareImg2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void lab4ConturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int thresholdValue = 100;
            #region Conversion To grayscale
            Bitmap b = new Bitmap("C:\\Users\\Bogdan\\Desktop\\red-apple.png");
            Image<Gray, byte> grayImage = new Image<Gray, byte>(b);
            Image<Bgr, byte> color = new Image<Bgr, byte>(b);
            #endregion


            #region  Image normalization and inversion (if required)
            grayImage = grayImage.ThresholdBinary(new Gray(thresholdValue), new Gray(255));
            #endregion

            #region Extracting the Contours
            using (MemStorage storage = new MemStorage())
            {

                for (Contour<Point> contours = grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                {

                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                    if (currentContour.BoundingRectangle.Width > 20)
                    {
                        CvInvoke.cvDrawContours(color, contours, new MCvScalar(255), new MCvScalar(255), -1, 2, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
                        color.Draw(currentContour.BoundingRectangle, new Bgr(0, 255, 0), 1);
                    }
                }

            }
            #endregion


            pictureBox2.Image = color.ToBitmap();
        pictureBox1.Image = grayImage.ToBitmap();
        }
    }
}


