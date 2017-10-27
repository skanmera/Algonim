using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using Algonim.Drawers;
using Algonim.DrawProperties;

namespace Algonim.Drawers
{
    public class CircleDrawer : Drawer
    {
        private float currentAngle;
        private float angleInterval;

        public CircleDrawer(DrawProperty property) : base(property) { }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            var prop = Property as CircleDrawProperty;

            currentAngle = 0f;
            angleInterval = 1f;
        }

        protected override void OnDraw()
        {
            var prop = Property as CircleDrawProperty;

            if (IsFinishedDraw())
            {
                Handles.color = new Color(prop.Color.r, prop.Color.g, prop.Color.b, prop.Color.a * 0.8f);
            }
            else
            {
                if (!DrawerManager.Instance.IsPausing)
                    currentAngle = Math.Min(currentAngle + angleInterval, prop.Angle);

                var currentPos = Quaternion.AngleAxis(currentAngle, prop.Normal) * prop.From;
                Handles.color = new Color(1.0f, 0.27f, 0.0f);
                Handles.SphereCap(0, currentPos, Quaternion.identity, HandleUtility.GetHandleSize(currentPos) / 15f);
                Handles.color = prop.Color;
            }

            Handles.DrawWireArc(prop.Center, prop.Normal, prop.From, currentAngle, prop.Radius);
        }

        public override bool IsFinishedDraw()
        {
            var prop = Property as CircleDrawProperty;

            return currentAngle == prop.Angle;
        }
    }
}
