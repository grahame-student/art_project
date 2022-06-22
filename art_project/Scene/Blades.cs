using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Blades: Shape
    {
        private readonly Single _rotationalSpeedDegreeMs;

        public Blades(Int32 originX, Int32 originY, Int32 radius)
        {
            Angle = 0;
            Centre = new PointF(originX, originY);
            Elements.Add(new Square(originX, originY, 6, radius, new SolidBrush(Color.Azure)));
            Elements.Add(new Square(originX, originY - 297, 50, 50, null));
            Elements.Add(new Square(originX, originY - 247, 50, 50, null));
            Elements.Add(new Square(originX, originY - 197, 50, 50, null));
            Elements.Add(new Square(originX, originY - 147, 50, 50, null));
            Elements.Add(new Ellipse(originX - 20, originY - 20, 40, 40, Color.Orange));

            _rotationalSpeedDegreeMs = 0.005f;
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            for (var angle = 0; angle < 360; angle += 90)
            {
                Angle += _rotationalSpeedDegreeMs * msElapsed;
                Transform(g, (Single)(angle+ Angle));
                foreach (Shape element in Elements)
                {
                    element.Draw(g, msElapsed);
                }
                g.ResetTransform();
            }
        }

        public override void DrawSlow(Graphics g)
        {

        }

        private void Transform(Graphics g, Single angle)
        {
            var matrix = new Matrix();
            matrix.RotateAt(angle, Centre);
            g.Transform = matrix;
        }
    }
}
