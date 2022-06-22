using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace art_project.Scene.Shapes
{
    public class Triangle: Shape
    {
        public Triangle(UInt32 originX, UInt32 originY, Int32 radius)
        {
            Verticies.Add(GetVertice(originX, originY, radius));
            Verticies.Add(GetVertice(originX, originY, radius));
            Verticies.Add(GetVertice(originX, originY, radius));
        }

        private PointF GetVertice(UInt32 originX, UInt32 originY, Int32 radius)
        {
            Single x = GetRndValue(originX, radius);
            Single y = GetRndValue(originY, radius);

            return new PointF(x, y);
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPolygon(new SolidBrush(Color.Blue), Verticies.ToArray(), FillMode.Winding);
        }

        public override void DrawSlow(Graphics g)
        {
            Draw(g, 0);
            Init = true;
        }
    }
}
