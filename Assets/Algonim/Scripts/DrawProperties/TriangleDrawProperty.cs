using UnityEngine;

namespace Algonim.DrawProperties
{
    public class TriangleDrawProperty : DrawProperty
    {
        public Vector3 VertexA { get; set; }
        public Vector3 VertexB { get; set; }
        public Vector3 VertexC { get; set; }
        public Color VertexAColor{ get; set; }
        public Color VertexBColor { get; set; }
        public Color VertexCColor { get; set; }
        public Color EdgeABColor { get; set; }
        public Color EdgeBCColor { get; set; }
        public Color EdgeCAColor { get; set; }
        public Color FaceColor { get; set; }
    }
}
