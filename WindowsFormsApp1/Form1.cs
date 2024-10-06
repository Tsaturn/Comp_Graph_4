using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private List<Polygon> polygons = new List<Polygon>();
        private Type type = Type.Point;
        private Point lastPoint;
        private bool first = true;
        private double[,] RotateMatrix = new double[3, 3];

        enum Type
        {
            Point, Edge, Polygon
        }

        private class Polygon
        {
            public Type type;
            public List<Point> points;

            public Polygon(Type t, List<Point> p)
            {
                type = t;
                points = p;
            }
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private double getDistance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Draw(e.Location.X, e.Location.Y);
        }

        private void Draw(int X, int Y)
        {
            var x = lastPoint.X;
            var y = lastPoint.Y;

            switch (type)
            {
                case Type.Point:
                    g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                    polygons.Add(new Polygon((Type.Point), new List<Point> { new Point(X, Y) }));
                    break;

                case Type.Edge:
                    g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);

                    if (first)
                        polygons.Add(new Polygon((Type.Edge), new List<Point> { }));
                    if (!first)
                    {
                        polygons.Last().points.Add(lastPoint);
                        polygons.Last().points.Add(new Point(X, Y));
                        g.DrawLine(new Pen(Color.Black, 1), X, Y, x, y);
                        first = true;
                        break;
                    }

                    first = false;
                    break;

                case Type.Polygon:
                    if (first)
                    {
                        polygons.Add(new Polygon((Type.Polygon), new List<Point> { }));
                        g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                    }
                    else
                    {
                        polygons.Last().points.Add(lastPoint);
                        if (getDistance(polygons.Last().points[0], new Point(X, Y)) < 5)
                        {
                            g.DrawLine(new Pen(Color.Black, 1), polygons.Last().points[0].X, polygons.Last().points[0].Y, x, y);

                            first = true;
                            break;
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                            g.DrawLine(new Pen(Color.Black, 1), X, Y, x, y);
                        }

                        break;
                    }
                    first = false;
                    break;
            }

            lastPoint = new Point(X, Y);
            pictureBox1.Refresh();
        }

        private void ReDraw(int X, int Y, int xFirst, int yFirst) {
            var x = lastPoint.X;
            var y = lastPoint.Y;

            switch (type)
            {
                case Type.Point:
                    g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                    break;

                case Type.Edge:
                    g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);

                    if (!first)
                    {
                        g.DrawLine(new Pen(Color.Black, 1), X, Y, x, y);
                        first = true;
                        break;
                    }

                    first = false;
                    break;

                case Type.Polygon:
                    if (first)
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                    }
                    else
                    {
                        if (getDistance(polygons.Last().points[0], new Point(X, Y)) < 5)
                        {
                            g.DrawLine(new Pen(Color.Black, 1), polygons.Last().points[0].X, polygons.Last().points[0].Y, x, y);

                            first = true;
                            break;
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                            g.DrawLine(new Pen(Color.Black, 1), X, Y, x, y);
                        }

                        break;
                    }
                    first = false;
                    break;
            }

            lastPoint = new Point(X, Y);
            pictureBox1.Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            polygons.Clear();
            first = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = Type.Point;
            first = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            type = Type.Edge;
            first = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            type = Type.Polygon;
            first = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                RotateMatrix[0, i] = i == 0 ? 1 : 0;

            for (int i = 0; i < 3; i++)
                RotateMatrix[1, i] = i == 1 ? 1 : 0;

            if (int.TryParse(textBox_dx.Text, out int number))
                RotateMatrix[2, 0] = -number;
            else
                RotateMatrix[2, 0] = 0;
            if (int.TryParse(textBox_dy.Text, out int numberY))
                RotateMatrix[2, 1] = -numberY;
            else
                RotateMatrix[2, 1] = 0;
            RotateMatrix[2, 2] = 1;

            // Применить преобразование смещения ко всем полигонам
            foreach (var polygon in polygons)
            {
                for (int i = 0; i < polygon.points.Count; i++)
                {
                    double[] point = new double[] { polygon.points[i].X, polygon.points[i].Y, 1 };
                    double[] result = new double[3];
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            result[j] += RotateMatrix[j, k] * point[k];
                        }
                    }
                    polygon.points[i] = new Point((int)result[0], (int)result[1]);
                }

            }

            // Обновить изображение
            g.Clear(Color.White);
            foreach (var polygon in polygons)
            {
                first = true;
                type = polygon.type;
                for (int i = 0; i < polygon.points.Count - 1; i++)
                    Draw(polygon.points[i].X, polygon.points[i].Y);
            }
            pictureBox1.Invalidate();
        }
    }
}

