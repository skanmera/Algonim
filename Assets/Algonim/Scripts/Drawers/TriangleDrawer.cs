using Algonim.Drawers;
using Algonim.DrawProperties;

namespace Algonim.Drawers
{
    public class TriangleDrawer : Drawer
    {
        public TriangleDrawer(DrawProperty property) : base(property) { }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            var prop = Property as TriangleDrawProperty;
            if (prop == null)
                return;

            Drawers.Clear();

            var vertexAProp = new VertexDrawProperty();
            vertexAProp.Color = prop.VertexAColor;
            vertexAProp.Position = prop.VertexA;
            Drawers.Add(new VertexDrawer(vertexAProp));

            var lineABDrawerProp = new LineDrawerProperty();
            lineABDrawerProp.Color = prop.EdgeABColor;
            lineABDrawerProp.StartVertex = prop.VertexA;
            lineABDrawerProp.EndVertex = prop.VertexB;
            Drawers.Add(new LineDrawer(lineABDrawerProp));

            var vertexBProp = new VertexDrawProperty();
            vertexBProp.Color = prop.VertexAColor;
            vertexBProp.Position = prop.VertexB;
            Drawers.Add(new VertexDrawer(vertexBProp));

            var lineBCDrawerProp = new LineDrawerProperty();
            lineBCDrawerProp.Color = prop.EdgeBCColor;
            lineBCDrawerProp.StartVertex = prop.VertexB;
            lineBCDrawerProp.EndVertex = prop.VertexC;
            Drawers.Add(new LineDrawer(lineBCDrawerProp));

            var vertexCProp = new VertexDrawProperty();
            vertexCProp.Color = prop.VertexCColor;
            vertexCProp.Position = prop.VertexC;
            Drawers.Add(new VertexDrawer(vertexCProp));

            var lineCADrawerProp = new LineDrawerProperty();
            lineCADrawerProp.Color = prop.EdgeCAColor;
            lineCADrawerProp.StartVertex = prop.VertexC;
            lineCADrawerProp.EndVertex = prop.VertexA;
            Drawers.Add(new LineDrawer(lineCADrawerProp));
        }
    }
}
