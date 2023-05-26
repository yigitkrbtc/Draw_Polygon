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
    public partial class Form1 : Form
    {
        private bool showLine = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            showLine = true;
            this.Invalidate();
        } 

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (showLine)
            {
                Graphics graphics = e.Graphics; //this.CreateGraphics();
                graphics.DrawLine(Pens.Red, 20, 20, 300, 100);

                graphics.DrawRectangle(Pens.Maroon, 100, 100, 200, 200);
                graphics.DrawEllipse(Pens.Maroon, 100, 100, 200, 100);

                String message = "Sample Text";
                Font font = new Font("Courier New", 16);
                Brush brush = new SolidBrush(Color.DarkGoldenrod);
                StringFormat format = new StringFormat();

                graphics.DrawString(message, font, brush, 100, 100, format);


                Point[] points = {
                    new Point(200,400),
                    new Point(300,400),
                    new Point(250,450)
                };
                graphics.DrawPolygon(Pens.DarkSlateBlue, points);

            }
            
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap("Cheapy.png");
            Graphics graphics = label1.CreateGraphics();

        
            graphics.DrawImage(bitmap, 20, 20);
        }
    }
}
