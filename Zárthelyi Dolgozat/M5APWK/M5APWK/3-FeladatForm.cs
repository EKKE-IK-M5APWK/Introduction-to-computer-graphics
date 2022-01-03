using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafika_DLL;
namespace M5APWK
{
    public partial class Form1 : Form
    {
        //3. Feladat
        /*
         * Kezelje egyszerre egy képernyon a p0; p1; : : : ; pn és q0; q1; : : : ; qn poligonokat
           a szokásos módon. Egyiket az egér bal-, másikat az egér jobb gombjával!
           Rajzoljon csatlakozó B-Spline görbéket a p0; p1; : : : ; pn; q0; q1; : : : ; qn pontokhoz úgy,
           hogy aazok a minta szerint zárt görbét alkossanak!
         */
        Graphics g;
        List<PointF> P = new List<PointF>();
        List<PointF> Q = new List<PointF>();
        int caught = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int i = 0; i < P.Count; i++)
                g.DrawEllipse(Pens.Gray, P[i].X - 5, P[i].Y - 5, 10, 10);
            for (int i = 0; i < P.Count - 1; i++)
                g.DrawLine(Pens.Gray, P[i], P[i + 1]);

            if (P.Count > 3)
                for (int i = 0; i < P.Count - 3; i++)
                {
                    BSpline3 arc = new BSpline3(P[i], P[i + 1], P[i + 2], P[i + 3]);
                    g.DrawBSpline3(new Pen(Color.Blue, 3f), arc);
                }
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    for (int i = 0; i < P.Count; i++)
                    {
                        if (e.Catch(P[i]))
                            caught = i;
                    }
                    if (caught == -1)
                    {
                        P.Add(e.Location);
                        caught = P.Count - 1;
                        canvas.Invalidate();
                    }
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (caught != -1)
                    {
                        P[caught] = e.Location;
                        canvas.Invalidate();
                    }
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    caught = -1;
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }
    }
}
