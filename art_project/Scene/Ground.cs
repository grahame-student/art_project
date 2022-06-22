using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Ground: Square
    {
        private readonly IList<Shape> _flowers;
        private readonly Shape _windmill;

        public Ground(Int32 originX, Int32 originY, Int32 width, Int32 height, Int32 flowerCount) : base(originX, originY, width, height, new SolidBrush(Color.Chartreuse))
        {
            Angle = (Int32)GetRndValue(0, 7);
            _flowers = new List<Shape>();

            Int32 y = height / 2 + 100;
            Int32 dy = ((height - 100) - y) / flowerCount;
            for (UInt32 i = 0; i < flowerCount; ++i)
            {
                Int32 x = Entropy.Next(50, width - 50);
                _flowers.Add(new Flower(x, y));
                y += dy;
            }

            // Create windmill!
            Int32 wmX = Entropy.Next(300, width - 300);
            _windmill = new Windmill(wmX, height / 2 + 100, 160, 300);
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            Transform(g);
            base.Draw(g, msElapsed);
            g.ResetTransform();

            _windmill.Draw(g, msElapsed);

            foreach (Shape flower in _flowers)
            {
                flower.Draw(g, msElapsed);
            }

        }

        private void Transform(Graphics g)
        {
            var rotatePoint = new Point(_originX + _width / 2, _originY + _height / 2);
            var matrix = new Matrix();

            // scale world to make drawn items bigger
            matrix.Scale(2, 2, MatrixOrder.Append);
            // recenter world around new centre point of ground
            matrix.Translate(-(Single)_width / 4, -(Single)_height / 4);
            // rotate the world by +/- 10 degrees around the centre of the ground
            matrix.RotateAt((Single)Angle, rotatePoint, MatrixOrder.Append);
            // move the world up
            matrix.Translate(0, _height, MatrixOrder.Append);

            g.Transform = matrix;
        }
    }
}
