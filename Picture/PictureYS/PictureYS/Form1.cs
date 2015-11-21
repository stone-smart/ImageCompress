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
    }
}
