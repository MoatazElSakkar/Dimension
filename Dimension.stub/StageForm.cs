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
            StructureData SD = new StructureData(new data.Point(0, 0, 0), new Triangle[] { new Triangle(TrianglePointset[0], TrianglePointset[1], TrianglePointset[2]) },System.Drawing.Color.Red);
            int triangleID = TriangleStage.addStructure(SD);
            Refrence.Add("Red Triangle", TriangleStage);

            //Test Case 2 the Pyramid of Giza

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
