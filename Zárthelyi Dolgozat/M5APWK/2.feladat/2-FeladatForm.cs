using Grafika_DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.feladat
{
    public partial class Form1 : Form
    {
        /*
         Jelenítse meg a képernyo közepén a
            x (t) = sin (2t)
            y (t) = sin (3t)
            koordinátafüggvényekkel definiált paraméteres görbét a t E [0; 2PI] intervallumon a mintának
            megfeleloen egyre vastagodó vonallal!
         */
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.DrawLine(Pens.Black, 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
            graphics.DrawLine(Pens.Black, canvas.Width / 2, 0, canvas.Width / 2, canvas.Height);

            PointF center = new PointF(canvas.Width / 2, canvas.Height / 2);

            float scale = 100;

         
            graphics.DrawParametricCurve2D(new Pen(Color.Red, 3f),
            t => scale * Math.Sin(2 * t) + center.X,
            t => scale * Math.Cos(3 * t) + center.Y,
            0, 2 * Math.PI);
       
            


        }
    }
}
