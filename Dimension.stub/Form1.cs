using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dimension.API;
using Dimension.Renderer;
using Dimension.simulator;
using Dimension.data;

namespace Dimension.stub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Stage S;
        private void Form1_Load(object sender, EventArgs e)
        {

            S = new Stage();
            //Test Case 1 the Red (Azure) triangle
            List<Point> TrianglePointset = new List<Point>();
            TrianglePointset.Add(new Point(0, 200, 1));
            TrianglePointset.Add(new Point(-200, -200, 2));
            TrianglePointset.Add(new Point(200, -200, 3));
            StructureData SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(TrianglePointset[0], TrianglePointset[1], TrianglePointset[2]) });
            int triangleID = S.addStructure(SD);
            //S.Transform(Transformation.Scaling,3,3,3);


            //Test Case 1 the Red (Azure) triangle
            //List<Point> CubePointSetF11 = new List<Point>();
            //CubePointSetF11.Add(new Point(0, 0, 5));
            //CubePointSetF11.Add(new Point(-100, 100, 5));
            //CubePointSetF11.Add(new Point(0, 100, 5));

            //List<Point> CubePointSetF12 = new List<Point>();
            //CubePointSetF12.Add(new Point(-100, 0, 1));
            //CubePointSetF12.Add(new Point(-100, 100, 1));
            //CubePointSetF12.Add(new Point(0, 0, 5));

            //StructureData SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(CubePointSetF11.ToArray()),new Triangle(CubePointSetF12.ToArray()) });
            //int triangleID = S.addStructure(SD);
        }


        private void Test_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap B = S.Render();
            preview.Image = B;

        }


    }
}
