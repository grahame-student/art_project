
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Tower: Shape
    {
        public Tower(Int32 originX, Int32 originY, Int32 baseWidth, Int32 height)
        {
            Int32 topWidth = baseWidth / 2;
            Verticies.Add(new PointF(originX, originY));
            Verticies.Add(new PointF(originX + baseWidth, originY));
            Verticies.Add(new PointF(originX + topWidth * 1.5f, originY - height));
            Verticies.Add(new PointF(originX + topWidth * 0.5f, originY - height));
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            g.FillPolygon(new SolidBrush(Color.Firebrick), Verticies.ToArray(), FillMode.Winding);
        }

        public override void DrawSlow(Graphics g)
        {
            Draw(g, 0);
            Init = true;
        }
    }
}
