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
    public partial class Form2 : Form
    {
        private bool clearPanel = true;
        private Point startPoint = new Point(0, 0);
        private Point polygonStartPoint = new Point(0, 0);
        private Point endPoint = new Point(0, 0);
        private string drawing = "nothing";

        private int numOfPoints = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (clearPanel)
            {
                Graphics graphics = panel1.CreateGraphics();
                graphics.Clear(Color.White);
                clearPanel = false;
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            lblXY.Text = String.Format("X:{0}\nY:{1}", e.X, e.Y);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var button = (RadioButton)sender;

            drawing = button.Tag.ToString();
            updateStatus();
        }

        private void updateStatus()
        {
            lblStatus.Text = string.Format("{0}: Start: {1},{2} End: {3},{4}", drawing, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (numOfPoints == 0)
            {
                this.startPoint = new Point(e.X, e.Y);
                this.polygonStartPoint = new Point(e.X, e.Y);

                updateStatus();
                
                numOfPoints++;
            }
            else
            {
                this.endPoint = new Point(e.X, e.Y);
               
                updateStatus();
                Graphics graphics = panel1.CreateGraphics();
                switch (this.drawing)
                {
                    case "Nothing":
                        numOfPoints = 0;
                        break;
                    case "Line":
                        graphics.DrawLine(Pens.DarkMagenta, startPoint, endPoint);
                        numOfPoints = 0;
                        break;
                    case "Rectangle":
                        numOfPoints = 0;
                        if (startPoint.X > endPoint.X) {
                            int temp = startPoint.X;
                            startPoint.X = endPoint.X;
                            endPoint.X = temp;
                        }
                        if (startPoint.Y > endPoint.Y)
                        {
                            int temp = startPoint.Y;
                            startPoint.Y = endPoint.Y;
                            endPoint.Y = temp;
                        }
                        graphics.DrawRectangle(Pens.DarkMagenta, startPoint.X,startPoint.Y, endPoint.X-startPoint.X, endPoint.Y - startPoint.Y);
                        break;
                    case "Polygon":
                        graphics.DrawEllipse(Pens.DarkMagenta, polygonStartPoint.X - 5, polygonStartPoint.Y - 5, 10,10);
                        graphics.DrawLine(Pens.DarkMagenta, startPoint, endPoint);
                        startPoint = endPoint;
                        numOfPoints++;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter && this.drawing == "Polygon" && numOfPoints> 2)
            {
                Graphics graphics = panel1.CreateGraphics();
                graphics.DrawLine(Pens.DarkMagenta,endPoint, polygonStartPoint);
                this.numOfPoints = 0;
            }
        }
    }
}
