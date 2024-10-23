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

/* TODO:
 * 
 */

namespace C2___RTS
{
    public partial class Form1 : Form
    {
        MyGraphics grp;

        public Form1()
        {
            InitializeComponent();
            grp = new MyGraphics(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Matrix A = new Matrix(@"../../Inputs/mat1.txt");
            Matrix B = new Matrix(@"../../Inputs/mat2.txt");

            Matrix Sum = A + B;

            foreach (string s in Sum.View())
                listBox1.Items.Add(s);

            Polygon poligon = new Polygon(@"../../Inputs/poligon.txt");
            poligon.Draw(grp.g);
            grp.RefreshGraphics();
        }
    }
}
