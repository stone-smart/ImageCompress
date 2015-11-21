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

        private void but_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string imageFile=openFileDialog1.FileName;
                try
                {
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        MyImage = new Bitmap(imageFile);
                        picBox.Image=(Image)MyImage;
                }
                catch{}

            }
        }
    }
}
