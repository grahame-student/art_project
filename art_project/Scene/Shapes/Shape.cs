using System;
using System.Collections.Generic;
using System.Drawing;

namespace art_project.Scene.Shapes
{
    public abstract class Shape
    {
        protected const Int32 POSITIVE = 0;

        protected IList<Shape> Elements;
        protected IList<PointF> Verticies;
        protected Int32 DrawCount;
        protected Random Entropy;
        protected Double Angle;

        public Boolean Init;

        public PointF Centre { get; protected set; }

        protected Shape()
        {
            Elements = new List<Shape>();
            Verticies = new List<PointF>();
            Entropy = new Random();
            DrawCount = 1;
            Init = false;
        }

        protected Single GetRndValue(UInt32 midPoint, Int32 range)
        {
            Int32 delta = Entropy.Next(0, range);
            Int32 direction = Entropy.Next(0, 2);
            return direction == POSITIVE ? midPoint + delta : midPoint - delta;
        }

        public abstract void Draw(Graphics g, Int64 msElapsed);
        public abstract void DrawSlow(Graphics g);
    }
}
