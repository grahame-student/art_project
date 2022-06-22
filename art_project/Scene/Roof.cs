using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Roof: Shape
    {
        public Roof(Int32 originX, Int32 originY, Int32 height, Int32 width)
        {
            Verticies.Add(new PointF(originX, originY));
            Verticies.Add(new PointF(originX + width, originY));
            Verticies.Add(new PointF(originX + (width / 2), height));
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            g.FillPolygon(new SolidBrush(Color.CornflowerBlue), Verticies.ToArray(), FillMode.Winding);
        }

        public override void DrawSlow(Graphics g)
        {
            Draw(g, 0);
            Init = true;
        }
    }
}
