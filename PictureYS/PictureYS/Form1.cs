using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureYS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Bitmap MyImage;
        public Graphics gImage;
        //获取图像单个像素数据
        Color pixel;

        private void but_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string imageFile=openFileDialog1.FileName;
                try
                {
                        //显示图像
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        MyImage = new Bitmap(imageFile);
                        picBox.Image=(Image)MyImage;                    

                }
                catch{}

            }
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
            //获取图像单个像素数据
            try
            {               
                pixel = MyImage.GetPixel(e.Location.X, e.Location.Y);
                label2.Text = pixel.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //以锐化效果显示图像
            try
            {
                int Height = this.picBox.Image.Height;
                int Width = this.picBox.Image.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.picBox.Image;
                Color pixel;
                //拉普拉斯模板
                int[] Laplacian ={ -1, -1, -1, -1, 9, -1, -1, -1, -1 };
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;
                        int Index = 0;
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                pixel = oldBitmap.GetPixel(x + row, y + col); 
                                r += pixel.R * Laplacian[Index];
                                g += pixel.G * Laplacian[Index];
                                b += pixel.B * Laplacian[Index];
                                Index++;
                            }
                        //处理颜色值溢出
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;
                        newBitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                    }
                this.picBoxNew.Image = newBitmap;
                this.picBoxNew.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //灰度图
            try
            {
                int Height = this.picBox.Image.Height;
                int Width = this.picBox.Image.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.picBox.Image;
                Color pixel;               
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        int Gray;
                        pixel = oldBitmap.GetPixel(x, y);
                        Gray = (pixel.R * 30 + pixel.G * 59 + pixel.B * 11) / 100;
                        newBitmap.SetPixel(x, y, Color.FromArgb(Gray, Gray, Gray));
                    }
                this.picBoxNew.Image = newBitmap;
                this.picBoxNew.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }        
    }
}
