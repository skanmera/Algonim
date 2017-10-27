using System.Collections.Generic;
using System.Linq;
using Algonim.Actions;
using Algonim.DrawProperties;

namespace Algonim.Drawers
{
    public class Drawer : IDrawers
    {
        public List<IAction> Actions { get; protected set; }
        public DrawProperty Property { get; protected set; }
        public int Life { get; protected set; }
        public bool ShouldDraw { get; protected set; }
        public List<Drawer> Drawers { get; protected set; }
        public bool BatchDraw { get; set; }

        public Drawer() : this(DrawProperty.Default) { }

        public Drawer(DrawProperty property)
        {
            Actions = new List<IAction>();
            Property = property;
            Life = property.Duration > 0 ? property.Duration : -1;
            Drawers = new List<Drawer>();
        }

        public void Initialize()
        {
            OnInitialize();

            foreach (var d in Drawers)
            {
                d.Initialize();
            }
        }

        protected virtual void OnInitialize() { }

        public void Draw()
        {
            if (!ShouldDraw)
                return;

            OnDraw();
        }

        protected virtual void OnDraw()
        {
            foreach (var drawer in Drawers)
            {
                drawer.Draw();
                if (!BatchDraw && !drawer.IsFinishedDraw())
                    break;
            }
        }

        public virtual bool IsFinishedDraw()
        {
            if (Drawers.Any())
                return Drawers.Last().IsFinishedDraw();

            return true;
        }

        public bool Update(int currentFrame)
        {
            ShouldDraw = false;

            if (Life != 0 && Property.Delay <= currentFrame)
            {
                Life--;
                ShouldDraw = Life != 0;
            }

            var ret = ShouldDraw | OnUpdate(currentFrame);

            Drawers.ForEach(d => ret |= d.Update(currentFrame));

            return ret;
        }

        protected virtual bool OnUpdate(int currentFrame)
        {
            return false;
        }
    }
}
