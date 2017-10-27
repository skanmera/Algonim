using UnityEngine;

namespace Algonim.DrawProperties
{
    public class LineDrawerProperty : DrawProperty
    {
        public Vector3 StartVertex { get; set; }
        public Vector3 EndVertex { get; set; }
        public Color StartVertexColor { get; set; }
        public Color EndVertexColor { get; set; }
    }
}
