using System;
using System.Linq;
using System.Collections.Generic;

using Dimension.data;
using Dimension.simulator;
using Dimension.Renderer;

namespace Dimension.API
{
    public class StructureData
    {
        public Triangle[] wireframeData;
        public Point Location;
        public int ID;

        public StructureData(Point i_centerLocation, Triangle[] i_wireframeSet) //Constructor for shapes
        {
            wireframeData = i_wireframeSet;
        }
    }

    public class Stage //Where the boring stuff happen
    {
        public static Structure fromStructureData(StructureData i_struct)
        {
            int LocalID = 0;
            Structure S = new Structure();
            S.WireFrame = new List<Triangle>();
            foreach (Triangle T in i_struct.wireframeData)
            {
                S.WireFrame.Add(T);
            }
            S.ID = LocalID++;
            //S.updateCenterPoint();
            return S;
        } //converts structure data to structure

        SimulationStage stage = new SimulationStage();
        Simulator Simulex = new Simulator();
        Renderer.Renderer Rendex = new Renderer.Renderer(720,360);

        public int addStructure(StructureData i_StructData)
        {
            i_StructData.ID = stage.curID;
            stage.StageData.Add(fromStructureData(i_StructData));
            return stage.curID++;
        }

        public void Transform(Transformation T, params object[] value) //Rotation:angle, Translation point, scaling scalar xD
        {
            if (stage.StageData.Count == 1) //main case
            {
                stage.StageData[0]=Simulex.SimulateTransformation(stage.StageData[0], T, value);
            }
            else if (stage.StageData.Count > 1) //Optional
            {
                //stage = Simulex.SimulateTransformation(stage, T, value);
            }
            else
            {
                throw new Exception("Empty stage inapplicable for transformation");
            }
        }

        public void MapTexture()
        {
        }

        public System.Drawing.Bitmap Render()
        {
            Projector Projectex = new Projector(stage.StageData,stage.Locations,Rendex.stageWpx,Rendex.stageHpx);
            return Rendex.GenerateStageView(Projectex.GeneratePorjection());
        }
    }
}
