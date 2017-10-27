using Algonim.DrawProperties;

namespace Algonim.Drawers
{
    public class EdgeDrawer : Drawer
    {
        public EdgeDrawer(DrawProperty property) : base(property) { }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            var prop = Property as EdgeDrawProperty;
            if (prop == null)
                return;

            Drawers.Clear();

            var startVertexDrawerProp = new VertexDrawProperty();
            startVertexDrawerProp.Color = prop.StartVertexColor;
            startVertexDrawerProp.Position = prop.StartVertex;
            Drawers.Add(new VertexDrawer(startVertexDrawerProp));

            var lineDrawerProp = new LineDrawerProperty();
            lineDrawerProp.Color = prop.LineColor;
            lineDrawerProp.StartVertex = prop.StartVertex;
            lineDrawerProp.EndVertex = prop.EndVertex;
            Drawers.Add(new LineDrawer(lineDrawerProp));

            var endVertexDrawerProp = new VertexDrawProperty();
            endVertexDrawerProp.Color = prop.EndVertexColor;
            endVertexDrawerProp.Position = prop.EndVertex;
            Drawers.Add(new VertexDrawer(endVertexDrawerProp));
        }
    }
}
