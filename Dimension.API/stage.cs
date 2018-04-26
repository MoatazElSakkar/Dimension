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
        public bool Composite;
        public object[] pointSet;
        public Point Location;

        public StructureData(bool i_composite, Point i_centerLocation, Bound[] i_pointSet) //Constructor for shapes
        {
            Composite = i_composite;
            pointSet = i_pointSet;
        }

        public StructureData(bool i_composite,Point i_centerLocation, Shape[] i_pointSet)//Constructor for compositions
        {
            Composite = i_composite;
            pointSet = i_pointSet;
        }
    }

    public class Stage //Where the boring stuff happen
    {
        public static Structure fromStructureData(StructureData i_struct)
        {
            int LocalID = 0;
            Structure S = new Structure();
            S.Composite = i_struct.Composite;
            foreach (object obj in i_struct.pointSet)
            {
                S.WireFrame.Add(LocalID++, obj);
            }
            S.updateCenterPoint();
            return S;
        } //converts structure data to structure

        SimulationStage stage = new SimulationStage();
        Simulator Simulex = new Simulator();
        Rdenderer Rendex = new Rdenderer();

        public int addStructure(StructureData i_StructData)
        {
            stage.StageData.Add(stage.curID, fromStructureData(i_StructData));
            return stage.curID++;
        }

        public void Transform(Transformation T, object value) //Rotation:angle, Translation point, scaling scalar xD
        {
            if (stage.StageData.Count == 1) //main case
            {
                stage.StageData[0]=Simulex.SimulateTransformation(stage.StageData[0], T, value);
            }
            else if (stage.StageData.Count > 1) //Optional
            {
                stage = Simulex.SimulateTransformation(stage, T, value);
            }
            else
            {
                throw new Exception("Empty stage inapplicable for transformation");
            }
        }

        public void MapTexture(

        
    }
}
