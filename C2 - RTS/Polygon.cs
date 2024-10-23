using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2___RTS
{
    internal class MyPoint
    {
        public float X, Y;

        public MyPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, X - 3, Y - 3, 7, 7);
        }
    }

    internal class Polygon
    {
        MyPoint[] points;

        public Polygon(string filename)
        {
            string buffer;
            TextReader reader = new StreamReader(filename);
            List<string> data = new List<string>();

            while ((buffer = reader.ReadLine()) != null)
                data.Add(buffer);

            reader.Close();

            points = new MyPoint[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                points[i].X = float.Parse(data[i].Split(' ')[0]);
                points[i].Y = float.Parse(data[i].Split(' ')[1]);
            }
        }

        public void Draw(Graphics handler)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].Draw(handler);
                handler.DrawLine(Pens.Red, points[i].X, points[i].Y, points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y);
            }
        }
    }
}
