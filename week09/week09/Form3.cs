using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week09
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int edges = Convert.ToInt32(numericUpDown1.Value);
            drawPolygon(edges);
        }

        private void drawPolygon(int edges)
        {
            Graphics graphics = label2.CreateGraphics();
            graphics.Clear(Color.White);

            float dt = (2 * (float)Math.PI / edges);
            float theta = 0;
            int R = 100;
            Point center = new Point(200, 200);
            Point[] points = new Point[edges];
            for (int i = 0; i < edges; i++)
            {
                theta += dt;
                int x = (int)(center.X + R * Math.Sin(theta));
                int y = (int)(center.Y + R * Math.Cos(theta));
                points[i] = new Point(x, y);
            }
            graphics.DrawPolygon(Pens.BurlyWood, points);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int edges = Convert.ToInt32(numericUpDown2.Value);
            drawHeart(edges);
        }

        private void drawHeart(int edges)
        {
            Graphics graphics = label2.CreateGraphics();
            graphics.Clear(Color.White);

            float dt = (2 * (float)Math.PI / edges);
            float theta = 0;
            int R = 5;
            Point center = new Point(200, 200);
            Point[] points = new Point[edges];
            for (int i = 0; i < edges; i++)
            {
                theta += dt;
                int x = (int)(center.X - R* (16 * Math.Sin(theta) * Math.Sin(theta) * Math.Sin(theta)));
                int y = (int)(center.Y - R* (13 * Math.Cos(theta) - 5 * Math.Cos(2 * theta) - 2 * Math.Cos(3 * theta) - Math.Cos(4 * theta)));
                points[i] = new Point(x, y);
            }
            graphics.DrawPolygon(Pens.BurlyWood, points);
            graphics.FillPolygon(Brushes.HotPink, points);
        }
    }
}
