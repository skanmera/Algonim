using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Algonim.DrawProperties
{
    public class CircleDrawProperty : DrawProperty
    {
        public Vector3 Center { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 From { get; set; }
        public float Radius { get; set; }
        public float Angle { get; set; }
    }
}
