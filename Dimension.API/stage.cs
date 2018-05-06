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
        public System.Drawing.Color[] StructureColor;

        public StructureData(Point i_centerLocation, Triangle[] i_wireframeSet) //Constructor for shapes
        {
            wireframeData = i_wireframeSet;
        }

        public StructureData(Point i_centerLocation, Triangle[] i_wireframeSet,System.Drawing.Color[] i_color) //Constructor for shapes
        {
            wireframeData = i_wireframeSet;
            StructureColor = i_color;
        }
    }

    public class Stage //Where the boring stuff happen
    {
        public static Structure fromStructureData(StructureData i_struct)
        {
            int LocalID = 0;
            Structure S = new Structure();
            S.WireFrame = new List<Triangle>();
            S.StructureColor = new List<System.Drawing.Color>();
            for (int i = 0; i < i_struct.wireframeData.Count();i++)
            {
                S.WireFrame.Add(i_struct.wireframeData[i]);
                S.StructureColor.Add(i_struct.StructureColor[i]);
            }
            S.ID = LocalID++;
            //S.updateCenterPoint();
            return S;
        } //converts structure data to structure

        SimulationStage stage = new SimulationStage();
        LightSource L = new LightSource();
        Simulator Simulex = new Simulator();
        Renderer.Renderer Rendex = new Renderer.Renderer(720,360);

        public System.Drawing.Color StageBackcolor=System.Drawing.Color.Blue;

        public int addStructure(StructureData i_StructData)
        {
            i_StructData.ID = stage.curID;
            stage.StageData.Add(fromStructureData(i_StructData));

            return stage.curID++;
        }

        public void Transform(Transformation T, params object[] value) //Rotation:angle, Translation point, scaling scalar xD
        {
            if (stage.StageData.Count == 1)
            {
                stage.StageData[0] = Simulex.SimulateTransformation(stage.StageData[0], T, value);
            }
            else if (stage.StageData.Count > 1)
            {
                foreach (Structure S in stage.StageData)
                {
                    Simulex.SimulateTransformation(S,T,value);
                }
            }
            else
            {
                throw new Exception("Empty stage inapplicable for transformation");
            }
        }

        public void Transform(int structureID,Transformation T, params object[] value) //Rotation:angle, Translation point, scaling scalar xD
        {
            stage.StageData[structureID] = Simulex.SimulateTransformation(stage.StageData[structureID], T, value);
        }

        public void MapTexture()
        {
        }

        public System.Drawing.Bitmap Render()
        {

            List<System.Drawing.Color> nList=new List<System.Drawing.Color>();
            foreach (Structure S in stage.StageData)
            {
               nList.AddRange(L.TuneStructureColorSet(S));
            }

            Projector Projectex = new Projector(stage.StageData.ToList(),stage.Locations,Rendex.stageWpx,Rendex.stageHpx);

            return Rendex.GenerateStageView(Projectex.GeneratePorjection(), nList,StageBackcolor);
        }

        public void SetLightSource(Point i_p, System.Drawing.Color i_Intensity)
        {
            L.Location.x = -i_p.x;
            L.Location.y = -i_p.y;
            L.Location.z = i_p.z;
            
            L.Intensity = i_Intensity;
        }

        public void Reintialize()
        {
            Rendex = new Renderer.Renderer(720, 360);
            
        }
    }
}
