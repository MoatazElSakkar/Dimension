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
            TrianglePointset.Add(new Point(0, 200, 1));
            TrianglePointset.Add(new Point(-200, -200, 1));
            TrianglePointset.Add(new Point(200, -200, 1));
            StructureData Triangle_SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(TrianglePointset[0], TrianglePointset[1], TrianglePointset[2]) },new System.Drawing.Color[]{System.Drawing.Color.Red});
            int triangleID = TriangleStage.addStructure(Triangle_SD);
            Refrence.Add("Red Triangle", TriangleStage);

            //Test Case 2 the Pyramid of Giza
            Stage PyramidOfGiza = new Stage();
            List<Point> PyramidOfGizaPointSet = new List<Point>();
            PyramidOfGizaPointSet.Add(new Point(-25, 200, 1));
            PyramidOfGizaPointSet.Add(new Point(-400, -200, 3));
            PyramidOfGizaPointSet.Add(new Point(150, -200, 2));
            PyramidOfGizaPointSet.Add(new Point(350, -200, 4));

            StructureData Giza_SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[1], PyramidOfGizaPointSet[2]), new Triangle(PyramidOfGizaPointSet[2], PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[3]) }, new System.Drawing.Color[] { System.Drawing.Color.Gold, System.Drawing.Color.Khaki });
            StructureData Giza_Khfraa = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[1], PyramidOfGizaPointSet[2]), new Triangle(PyramidOfGizaPointSet[2], PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[3]) }, new System.Drawing.Color[] { System.Drawing.Color.Gold, System.Drawing.Color.Khaki });
            StructureData Giza_Mankura = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[1], PyramidOfGizaPointSet[2]), new Triangle(PyramidOfGizaPointSet[2], PyramidOfGizaPointSet[0], PyramidOfGizaPointSet[3]) }, new System.Drawing.Color[] { System.Drawing.Color.Gold, System.Drawing.Color.Khaki });
            int PyramidOfGizaID = PyramidOfGiza.addStructure(Giza_SD);
            PyramidOfGiza.addStructure(Giza_Khfraa);
            PyramidOfGiza.addStructure(Giza_Mankura);
            PyramidOfGiza.SetLightSource(new Point(10, 0, 1), System.Drawing.Color.White);

            PyramidOfGiza.Transform(0, Transformation.Translation, 0, -20, 1);
            PyramidOfGiza.Transform(1, Transformation.Translation, -1100, 40, 6);
            PyramidOfGiza.Transform(2, Transformation.Translation, -400, 30, 3);

            Refrence.Add("Pyramid Of Giza", PyramidOfGiza);


            //Use the code above as a template

            //Test Case 3 the Dimension Logo



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
            System.Drawing.Bitmap B = Refrence[StageSelector.SelectedItem.ToString()].Render();
            preview.Image = B;

        }


    }
}
