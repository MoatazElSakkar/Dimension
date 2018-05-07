using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dimension.API;
using Dimension.Renderer;
using Dimension.simulator;
using Dimension.data;

namespace Dimension.stub
{
    public partial class StageForm : Form
    {
        public StageForm()
        {
            InitializeComponent();
        }

        Dictionary<string, Stage> Refrence = new Dictionary<string, Stage>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Test Case 1 the Red triangle
            Stage TriangleStage = new Stage();
            List<Point> TrianglePointset = new List<Point>();
            TrianglePointset.Add(new Point(0, 200, 120));
            TrianglePointset.Add(new Point(-200, -200,120));
            TrianglePointset.Add(new Point(200, -200, 120));
            StructureData Triangle_SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(TrianglePointset[0], TrianglePointset[1], TrianglePointset[2]) },new System.Drawing.Color[]{System.Drawing.Color.Red});
            int triangleID = TriangleStage.addStructure(Triangle_SD);
            LightSource RedTriangleLight = new LightSource(System.Drawing.Color.White, new Point(0, 100 , 100));
            Refrence.Add("Red Triangle", TriangleStage);

            //Test Case 2 the Pyramid of Giza
            Stage PyramidOfGiza = new Stage();

            List<Point> PyramidOfGizaPointSet = new List<Point>();
            PyramidOfGizaPointSet.Add(new Point(-25, 200, 60));
            PyramidOfGizaPointSet.Add(new Point(-400, -200, 200));
            PyramidOfGizaPointSet.Add(new Point(150, -200, 100));
            PyramidOfGizaPointSet.Add(new Point(350, -200, 240));


            StructureData Giza_Khofo = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[1], PyramidOfGizaPointSet[2]), new Triangle(PyramidOfGizaPointSet[2], PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[3]) }, new System.Drawing.Color[] { System.Drawing.Color.Gold, System.Drawing.Color.Gold });
            StructureData Giza_Khfraa = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[1], PyramidOfGizaPointSet[2]), new Triangle(PyramidOfGizaPointSet[2], PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[3]) }, new System.Drawing.Color[] { System.Drawing.Color.Gold, System.Drawing.Color.Gold });
            StructureData Giza_Mankura = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[1], PyramidOfGizaPointSet[2]), new Triangle(PyramidOfGizaPointSet[2], PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[3]) }, new System.Drawing.Color[] { System.Drawing.Color.Gold, System.Drawing.Color.Gold});
            int PyramidOfGizaID = PyramidOfGiza.addStructure(Giza_Khofo);
            PyramidOfGiza.addStructure(Giza_Khfraa);
            PyramidOfGiza.addStructure(Giza_Mankura);

            PyramidOfGiza.SetLightSource(new Point(100, 100, 80), System.Drawing.Color.White);

            PyramidOfGiza.Transform(0, Transformation.Translation, -100, -45, 100);
            PyramidOfGiza.Transform(1, Transformation.Translation, -1200, 55, 600);
            PyramidOfGiza.Transform(2, Transformation.Translation, -500, 10, 300);

            PyramidOfGiza.StageBackcolor = System.Drawing.Color.LightBlue;

            Refrence.Add("Pyramid Of Giza", PyramidOfGiza);

            //Test Case 3 the Dimension Logo
            Stage CubeStage = new Stage();
            List<Point> CubePoints = new List<Point>();
            CubePoints.Add(new Point(50, 50, 50));
            CubePoints.Add(new Point(-50,50,50));
            CubePoints.Add(new Point(-50, -50, 50));
            CubePoints.Add(new Point(50,-50 , 50));


            StructureData CubeFace=new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink });

            CubeStage.addStructure(new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink }));
            CubeStage.addStructure(new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink }));
            CubeStage.addStructure(new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink }));
            CubeStage.addStructure(new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink }));
            CubeStage.addStructure(new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink }));
            CubeStage.addStructure(new StructureData(new Point(0,0,0),new Triangle[]{new Triangle(CubePoints[0],CubePoints[1],CubePoints[2]),
                new Triangle(CubePoints[0],CubePoints[2],CubePoints[3])
           }, new System.Drawing.Color[] {System.Drawing.Color.LightPink, System.Drawing.Color.LightPink }));

            CubeStage.Transform(0, Transformation.Rotation, 0, 90, 0);
            //CubeStage.Transform(0, Transformation.Translation, 25, 0, 0);

            CubeStage.Transform(1, Transformation.Rotation, 0, -90, 0);
            //CubeStage.Transform(1, Transformation.Translation, -25, 0, 0);

            CubeStage.Transform(2, Transformation.Rotation, 90, 0, 0);
            //CubeStage.Transform(2, Transformation.Translation, 0, -25, 0);

            CubeStage.Transform(3, Transformation.Rotation, -90, 0, 0);
            //CubeStage.Transform(3, Transformation.Translation, 0, 25, 0);

            //CubeStage.Transform(4, Transformation.Translation, 0, 0, 25);

            CubeStage.Transform(5, Transformation.Translation, 0, 0, -100);

            CubeStage.Transform(Transformation.Rotation, 45, 45, 0);

            Refrence.Add("Cube", CubeStage);

            CubeStage.SetLightSource(new Point(0, 0, 80), System.Drawing.Color.White);

            CubeStage.StageBackcolor = System.Drawing.Color.Black;

            updateStageSelectionBox();
        }

        void updateStageSelectionBox()
        {
            foreach (KeyValuePair<string, Stage> stageNamePair in Refrence)
            {
                StageSelector.Items.Add(stageNamePair.Key);
            }

            if (StageSelector.Items.Count == 0)
            {
                Render_btn.Enabled = false;
                StageSelector.Enabled = false;
            }
            else
            {
                StageSelector.SelectedIndex = 0;
            }
        }


        private void Test_Click(object sender, EventArgs e)
        {
            if(StageSelector.SelectedItem.ToString().Equals("Cube"))
            {
                cubeTimer.Start();
            } else
            {
                cubeTimer.Stop();
            }
            System.Drawing.Bitmap B = Refrence[StageSelector.SelectedItem.ToString()].Render();
            preview.Image = B;
            Refrence[StageSelector.SelectedItem.ToString()].Reintialize();
        }

        private void cubeTimer_Tick(object sender, EventArgs e)
        {
            Refrence["Cube"].Transform(Transformation.Rotation, 5, 5, 0);
            preview.Image = Refrence["Cube"].Render();
            Refrence[StageSelector.SelectedItem.ToString()].Reintialize();
        }
    }
}
