using UnityEngine;
using UnityEditor;
using Algonim.DrawProperties;

namespace Algonim.Drawers
{
    public class LineDrawer : Drawer
    {
        private Vector3 currentPos;
        private float maxDistance;

        public LineDrawer(DrawProperty property) : base(property) { }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            var prop = Property as LineDrawerProperty;
            currentPos = prop.StartVertex;

            maxDistance = Vector3.Distance(prop.StartVertex, prop.EndVertex) / 200f;
        }

        protected override void OnDraw()
        {
            var prop = Property as LineDrawerProperty;

            if (IsFinishedDraw())
            {
                Handles.color = new Color(prop.Color.r, prop.Color.g, prop.Color.b, prop.Color.a * 0.8f);
            }
            else
            {
                if (!DrawerManager.Instance.IsPausing)
                    currentPos = Vector3.MoveTowards(currentPos, prop.EndVertex, maxDistance);

                Handles.color = new Color(1.0f, 0.27f, 0.0f);
                Handles.SphereCap(0, currentPos, Quaternion.identity, HandleUtility.GetHandleSize(currentPos) / 10f);
                Handles.color = prop.Color;
            }

            Handles.DrawLine(prop.StartVertex, currentPos);
        }

        public override bool IsFinishedDraw()
        {
            var prop = Property as LineDrawerProperty;

            return currentPos == prop.EndVertex;
        }
    }
}
