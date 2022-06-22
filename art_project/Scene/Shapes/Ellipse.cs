using System;
using System.Drawing;

namespace art_project.Scene.Shapes
{
    public class Ellipse : Shape
    {
        protected readonly Int32 _originX;
        protected readonly Int32 _originY;
        protected readonly Int32 _height;
        protected readonly Int32 _width;
        private readonly Color _colour;

        public Ellipse(Int32 originX, Int32 originY, Int32 width, Int32 height, Color colour)
        {
            _originX = originX;
            _originY = originY;
            _height = height;
            _width = width;
            _colour = colour;

            Centre = new PointF(_originX + width / 2, originY + height / 2);
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            g.FillEllipse(new SolidBrush(_colour), _originX, _originY, _width, _height);
        }

        public override void DrawSlow(Graphics g)
        {
            Draw(g, 0);
            Init = true;
        }
    }
}
