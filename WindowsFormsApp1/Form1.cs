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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private List<Polygon> polygons = new List<Polygon>();
        private List<Polygon> closedPolygons = new List<Polygon>();
        private Type type = Type.Point;
        private PointF lastPoint;
        private bool first = true;
        private bool drawing = false;
        private double[,] transformationMatrix;
        private PointF rotatePoint;
        private List<Tuple<PointF, PointF>> edges = new List<Tuple<PointF, PointF>>();

        enum Type
        {
            Point, Edge, Polygon, Rotate, Scale
        }

        private class Polygon
        {
            public Type type;
            public List<PointF> points;

            public Polygon(Type t, List<PointF> p)
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
            pictureBox1.MouseMove += pictureBox1_MouseMove;
        }

        private double getDistance(PointF p1, PointF p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Draw(e.Location.X, e.Location.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && (type == Type.Polygon || type == Type.Edge))
            {
                pictureBox1.Refresh();

                var currentPoint = new PointF(e.Location.X, e.Location.Y);

                if (polygons.Last().points.Count > 0 && getDistance(polygons.Last().points[0], currentPoint) < 20)
                {
                    currentPoint = polygons.Last().points[0];
                }

                using (Graphics gTemp = pictureBox1.CreateGraphics())
                {
                    gTemp.DrawLine(new Pen(Color.Gray, 1), lastPoint, currentPoint);
                }
            }
        }

        private void Draw(int X, int Y)
        {
            var x = lastPoint.X;
            var y = lastPoint.Y;

            switch (type)
            {
                case Type.Rotate:
                    rotatePoint = new Point(X, Y);
                    //g.FillRectangle(new SolidBrush(Color.Red), X, Y, 3, 3);
                    turn();
                    EnableButtons();
                    break;
                case Type.Scale:
                    rotatePoint = new Point(X, Y);
                    //g.FillRectangle(new SolidBrush(Color.Red), X, Y, 3, 3);
                    Scale();
                    EnableButtons();
                    break;
                case Type.Point:
                    g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                    polygons.Add(new Polygon(Type.Point, new List<PointF> { new PointF(X, Y) }));
                    break;

                case Type.Edge:
                    //g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);

                    if (first)
                    {
                        polygons.Add(new Polygon(Type.Edge, new List<PointF> { }));
                        drawing = true;
                    }
                    if (!first)
                    {
                        polygons.Last().points.Add(lastPoint);
                        polygons.Last().points.Add(new Point(X, Y));
                        g.DrawLine(new Pen(Color.Black, 1), X, Y, x, y);

                        edges.Add(new Tuple<PointF, PointF>(new PointF(lastPoint.X, lastPoint.Y), new PointF(X, Y)));
                        comboBox2.Items.Add($"Edge ({lastPoint.X}, {lastPoint.Y}) -> ({X}, {Y})");

                        drawing = false;
                        first = true;
                        break;
                    }

                    first = false;
                    break;

                case Type.Polygon:
                    if (first)
                    {
                        polygons.Add(new Polygon(Type.Polygon, new List<PointF> { }));
                        closedPolygons.Add(polygons.Last());
                        comboBox1.Items.Add("Полигон" + closedPolygons.Count());
                        //g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                        drawing = true;
                    }
                    else
                    {
                        closedPolygons.Last().points.Add(lastPoint);
                        polygons.Last().points.Add(lastPoint);
                        if (getDistance(polygons.Last().points[0], new PointF(X, Y)) < 10)
                        {
                            g.DrawLine(new Pen(Color.Black, 1), polygons.Last().points[0].X, polygons.Last().points[0].Y, x, y);
                            drawing = false;
                            first = true;
                            break;
                        }
                        else
                        {
                            //g.FillRectangle(new SolidBrush(Color.Black), X, Y, 3, 3);
                            g.DrawLine(new Pen(Color.Black, 1), X, Y, x, y);
                        }
                    }
                    first = false;
                    break;
            }

            lastPoint = new PointF(X, Y);
            pictureBox1.Refresh();
        }

        // кнопки определяющие тип рисования
        private void clearButton(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            polygons.Clear();
            closedPolygons.Clear();
            comboBox1.Items.Clear();
            first = true;
            comboBox2.Items.Clear();
        }

        private void createPoint(object sender, EventArgs e)
        {
            type = Type.Point;
            first = true;
        }

        private void createEdge(object sender, EventArgs e)
        {
            type = Type.Edge;
            first = true;
        }

        private void createPolygon(object sender, EventArgs e)
        {
            type = Type.Polygon;
            first = true;
        }

        private double[,] matrix_multiplication(double[,] m1, double[,] m2)
        {
            double[,] res = new double[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); ++i)
                for (int j = 0; j < m2.GetLength(1); ++j)
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }

            return res;
        }

        private void matrixApplication(double[,] m, Polygon polygonToTransform)
        {
            // Преобразуем только один полигон
            Polygon newPolygon = new Polygon(polygonToTransform.type, new List<PointF>());

            for (int i = 0; i < polygonToTransform.points.Count; i++)
            {
                double[,] point = new double[,] { { polygonToTransform.points[i].X, polygonToTransform.points[i].Y, 1 } };
                double[,] result = matrix_multiplication(point, m); 
                newPolygon.points.Add(new Point(Convert.ToInt32(Math.Round(result[0, 0])), Convert.ToInt32(Math.Round(result[0, 1]))));
            }

            closedPolygons[comboBox1.SelectedIndex] = newPolygon;
            for (int i = 0; i < polygons.Count; i++)
            {
                if (polygons[i] == polygonToTransform)
                {
                    polygons[i] = newPolygon;
                    break;
                }
            }
            g.Clear(Color.White);

            foreach (var polygon in polygons)
            {
                if (polygon.points.Count > 1)
                {
                    for (int i = 0; i < polygon.points.Count - 1; i++)
                    {
                        g.DrawLine(new Pen(Color.Black, 1), polygon.points[i], polygon.points[i + 1]);
                    }
                    if (polygon.type == Type.Polygon)
                    {
                        g.DrawLine(new Pen(Color.Black, 1), polygon.points.Last(), polygon.points.First());
                    }
                }
                if (polygon.type == Type.Point)
                {
                    PointF lastPoint = polygon.points.Last();
                    g.FillRectangle(new SolidBrush(Color.Black), (float)lastPoint.X, (float)lastPoint.Y, 3, 3);
                }
            }
            pictureBox1.Invalidate();
        }

        private void shiftXY(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            var polygon = closedPolygons[comboBox1.SelectedIndex];
            double dx, dy;
            try
            {
                dx = System.Convert.ToDouble(textBox_dx.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для dx.");
                dx = 0;
            }

            try
            {
                dy = System.Convert.ToDouble(textBox_dy.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для dy.");
                dy = 0;
            }
            transformationMatrix = new double[,] { { 1.0, 0, 0 }, { 0, 1.0, 0 }, { dx, -dy, 1.0 } };

            matrixApplication(transformationMatrix, polygon);
        }

        private void unEnableButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = false;
                }
            }
            button2.Enabled = true;
        }

        private void EnableButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = true;
                }
            }
        }
            
        private void turnAroundCenter(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            var polygon = closedPolygons[comboBox1.SelectedIndex];
            double p;
                try
                {
                    p = System.Convert.ToDouble(textBox1.Text) * Math.PI / 180;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Пожалуйста, введите числовое значение для угла");
                    p = 0;
                }

                double cos = Math.Cos(p);
                double sin = Math.Sin(p);

               
                double centerX = polygon.points.Average(point => point.X);
                double centerY = polygon.points.Average(point => point.Y);

                transformationMatrix = new double[,] {
                    { cos, sin, 0 },
                    { -sin, cos, 0 },
                    { centerX * (1 - cos) + centerY * sin, centerY * (1 - cos) - centerX * sin, 1 } };
                
                matrixApplication(transformationMatrix, polygon);
        }                
        private void turnAroundPoint(object sender, EventArgs e)
        {
            type = Type.Rotate;
            unEnableButtons();
        }

        private void turn()
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            var polygon = closedPolygons[comboBox1.SelectedIndex];
            double a;
            double x = rotatePoint.X;
            double y = rotatePoint.Y;
            try
            {
                a = System.Convert.ToDouble(textBox1.Text) * Math.PI / 180;
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для угла");
                a = 0;
            }

            double cos = Math.Cos(a);
            double sin = Math.Sin(a);
            transformationMatrix = new double[,]
        {
            { cos, sin, 0 },
            { -sin, cos, 0 },
            { cos * (-x) + y * sin + x, (-x) * sin - y * cos + y, 1 } };
            matrixApplication(transformationMatrix, polygon);
            g.FillRectangle(new SolidBrush(Color.Red), rotatePoint.X, rotatePoint.Y, 3, 3);
        }

        private void scaleCenter(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            var polygon = closedPolygons[comboBox1.SelectedIndex];
            double scaleX, scaleY;
            try
            {
                scaleX = System.Convert.ToDouble(textBox2.Text); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для коэффициента масштабирования");
                scaleX = 1; 
            }
            try
            {
                scaleY = System.Convert.ToDouble(textBox3.Text); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для коэффициента масштабирования");
                scaleY = 1; 
            }

            double centerX = polygon.points.Average(point => point.X);
            double centerY = polygon.points.Average(point => point.Y);

            transformationMatrix = new double[,] {
                { scaleX, 0, 0 },
                { 0, scaleY, 0 },
                { centerX * (1 - scaleX), centerY * (1 - scaleY), 1 } };

            matrixApplication(transformationMatrix, polygon);
        }
        private void scalePoint(object sender, EventArgs e)
        {
            type = Type.Scale;
            unEnableButtons();
        }

        private void Scale()
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            var polygon = closedPolygons[comboBox1.SelectedIndex];

            double x = rotatePoint.X;
            double y = rotatePoint.Y;

            double scaleX, scaleY;

            try
            {
                scaleX = System.Convert.ToDouble(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для коэффициента масштабирования по оси X");
                scaleX = 1; 
            }

            try
            {
                scaleY = System.Convert.ToDouble(textBox3.Text); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовое значение для коэффициента масштабирования по оси Y");
                scaleY = 1;
            }

            transformationMatrix = new double[,] {
            { scaleX, 0, 0 },
            { 0, scaleY, 0 },
            { (-x) * scaleX + x, (-y) * scaleY + y, 1 } };
            
            matrixApplication(transformationMatrix, polygon);
            g.FillRectangle(new SolidBrush(Color.Red), rotatePoint.X, rotatePoint.Y, 3, 3);
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox2.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < edges.Count)
            {
                var selectedEdge = edges[selectedIndex];
            }

        }
       
        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

    }
};


