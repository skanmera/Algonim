using Algonim.DrawProperties;
using UnityEngine;
using UnityEditor;

namespace Algonim.Drawers
{
    public class VertexDrawer : Drawer
    {
        public VertexDrawer(DrawProperty property) : base(property) { }

        protected override void OnDraw()
        {
            var prop = Property as VertexDrawProperty;
            if (prop == null)
                return;

            Handles.color = prop.Color;
            Handles.SphereCap(0, prop.Position, Quaternion.identity, HandleUtility.GetHandleSize(prop.Position) / 10f);
        }

        public override bool IsFinishedDraw()
        {
            return true;
        }
    }
}
