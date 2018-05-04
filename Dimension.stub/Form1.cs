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
            //List<Point> TrianglePointset = new List<Point>();
            //TrianglePointset.Add(new Point(0, 200, 1));
            //TrianglePointset.Add(new Point(-100, -100, 10));
            //TrianglePointset.Add(new Point(100, -100, 10));
            //StructureData SD=new StructureData(new data.Point(0, 0, 0),new Triangle[] {new Triangle(TrianglePointset[0],TrianglePointset[1],TrianglePointset[2])});
            //int triangleID = S.addStructure(SD);


            //Test Case 1 the Red (Azure) triangle
            List<Point> CubePointSet = new List<Point>();
            CubePointSet.Add(new Point(0, 0, 0));
            CubePointSet.Add(new Point(0, 0, 200));
            CubePointSet.Add(new Point(0, 200, 200));

            CubePointSet.Add(new Point(200, 0, 0));
            CubePointSet.Add(new Point(0, 200, 0));
            CubePointSet.Add(new Point(200, 200, 200));
            CubePointSet.Add(new Point(200, 200, 0));
            CubePointSet.Add(new Point(0, 200, 0));

            StructureData SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(TrianglePointset[0], TrianglePointset[1], TrianglePointset[2]) });
            int triangleID = S.addStructure(SD);
        }


        private void Test_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap B = S.Render();
            preview.Image = B;

        }


    }
}
