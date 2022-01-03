using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika_DLL;

namespace _1.Feladat
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            PointF center = new PointF(canvas.Width / 2, canvas.Height / 2);
            graphics.DrawRectangle(new Pen(Color.Blue), 100, 150, 400, 150);
            graphics.DrawEllipse(new Pen(Color.Red), 0,0,50,50);
        }
    }
}
