using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//                            1 0 x
// TRANSLATIE: P(px, py), T = 0 1 y  => P' = P * T
//                            0 0 1

//              cos t  -sin t  0
// ROTATIE: R = sin t   cos t  0  => P' = P * R
//                0       0    1
//              (fata de origine)

//
// ROTATIE: R = 
//

//              x 0 0
// SCALARE: S = 0 y 0  => P' = P * S
//              0 0 1

namespace C2___RTS
{
    public partial class Form1 : Form
    {
        MyGraphics grp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grp = new MyGraphics(pictureBox1);

            //Matrix A = new Matrix(@"../../Inputs/mat1.txt");
            //Matrix B = new Matrix(@"../../Inputs/mat2.txt");

            //Matrix Sum = A + B;
            //Matrix Prod = A * B;

            //foreach (string p in Prod.View())
            //   listBox1.Items.Add(p);

            Polygon polygon = new Polygon(@"../../Inputs/polygon.txt");
            polygon.Draw(grp.g, Color.Black);

            //Polygon translated = polygon.Translate(new PointF(30, 30));
            //translated.Draw(grp.g, Color.Red);

            //Polygon rotated = polygon.Rotate(10, new PointF(pictureBox1.Height / 2, pictureBox1.Width / 2));
            //rotated.Draw(grp.g, Color.Red);

            Polygon scaled = polygon.Scale(1.5f, 1.5f);
            scaled.Draw(grp.g, Color.Red);

            grp.Refresh();
        }
    }
}
