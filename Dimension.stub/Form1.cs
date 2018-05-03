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
            TrianglePointset.Add(new Point(0, 100, 0));
            TrianglePointset.Add(new Point(-100, -100, 0));
            TrianglePointset.Add(new Point(100, -100, 0));
            StructureData SD=new StructureData(false, new data.Point(0, 0, 0), FromCyclicToShape(TrianglePointset).ToArray());
            int triangleID = S.addStructure(SD);

            
        }

        //Function that converts scattered points to lines
        //TODO: Morphs implmentation
        //To be moved to the API afterwards
        List<Bound> FromCyclicToShape(List<Point> Lines)
        {
            List<Bound> OutBound = new List<Bound>();
            for(int i=0;i<Lines.Count;i++)
            {
                if (i < Lines.Count - 1)
                    OutBound.Add(new Line(Lines[i], Lines[i + 1]));
                else
                    OutBound.Add(new Line(Lines[i], Lines[0]));
            }
            return OutBound;
        }



        private void Test_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap B = S.Render();
            preview.Image = B;
        }


    }
}
