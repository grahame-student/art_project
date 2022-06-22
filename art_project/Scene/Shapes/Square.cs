using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace art_project.Scene.Shapes
{
    public class Square : Shape
    {
        protected readonly Int32 _originX;
        protected readonly Int32 _originY;
        protected readonly Int32 _width;
        protected readonly Int32 _height;
        private readonly SolidBrush _brush;

        public Square(Int32 originX, Int32 originY, Int32 width, Int32 height, SolidBrush brush)
        {
            _originX = originX;
            _originY = originY;
            _width = width;
            _height = height;
            _brush = brush;
            Verticies.Add(new PointF(originX, originY));
            Verticies.Add(new PointF(originX + width, originY));
            Verticies.Add(new PointF(originX + width, originY + height));
            Verticies.Add(new PointF(originX, originY + height));
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            if (_brush != null)
            {

                g.FillPolygon(_brush, Verticies.ToArray(), FillMode.Winding);
            }
            else
            {
                g.DrawPolygon(new Pen(Color.Azure, 6), Verticies.ToArray());
            }
        }

        public override void DrawSlow(Graphics g)
        {
            Draw(g, 0);
            Init = true;
        }
    }
}
