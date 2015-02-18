using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TestGameLogic.main.Grafic
{
    public class baseGrafic
    {
        protected Bitmap bmp = null;
        protected Graphics gr = null;
        protected PictureBox pictureBox = null;

        protected Pen penStandart = new Pen(Brushes.Black);
        protected Pen penSelected = new Pen(Brushes.Green);
        protected Pen penTarget = new Pen(Brushes.Red);

        public baseGrafic(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void setPicturebox(int width, int height)
        {
            this.pictureBox.Width = width;
            this.pictureBox.Height = height;
            this.bmp = new Bitmap(width, height);
            this.gr = Graphics.FromImage(this.bmp);
        }

        public void clear()
        {
            this.gr.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            this.pictureBox.Image = bmp;
        }
    }
}
