using System;
using UnityEngine;

namespace Algonim.DrawProperties
{
    public class DrawProperty
    {
        public static DrawProperty Default = new DrawProperty
        {
            Color = Color.black,
            Delay = 0,
            Duration = -1,
        };

        public Color Color { get; set; }
        public int Delay { get; set; }
        public int Duration { get; set; }

        public DrawProperty()
        {
            Duration = -1;
        }
    }
}
