
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace art_project.Scene.Shapes
{
    public class Star : Shape
    {
        private readonly UInt32 _pointCount;
        private readonly Single _rotationalSpeedDegreeMs;

        public Star(Int32 originX, Int32 originY, Int32 size)
        {
            // Set the point count to an odd number between 5 and 21
            _pointCount = (UInt32)Entropy.Next(5, 21) | 1;
            Centre = new PointF(originX, originY);
            GeneratePoints(size);
            Angle = Entropy.Next(0, 360);
            Int32 direction = Entropy.Next(0, 2);
            _rotationalSpeedDegreeMs = direction == POSITIVE ?
                    (Single)Entropy.Next(1, 25)  / 100:
                    -(Single)Entropy.Next(1, 25) / 100;
        }

        private void GeneratePoints(Int32 size)
        {
            // Note an even number of points will cause issues
            PointF[] pointArray = GetPointArray(size);
            UInt32 deltaP = _pointCount / 2;
            UInt32 curPoint = 0;
            for (UInt32 i = 0; i < _pointCount; ++i)
            {
                UInt32 nextPoint = (curPoint + deltaP) % _pointCount;
                curPoint = nextPoint;
                Verticies.Add(pointArray[nextPoint]);
            }
        }

        private PointF[] GetPointArray(Int32 size)
        {
            Single angleRad = (360f / _pointCount) * (MathF.PI / 180);

            // x,y are centre point of star
            // px,py are co-ords of star point

            var points = new List<PointF>();
            for (UInt32 i = 0; i < _pointCount; ++i)
            {
                Single px = Centre.X + MathF.Sin(angleRad * i) * size;
                Single py = Centre.Y + MathF.Cos(angleRad * i) * size;
                points.Add(new PointF(px, py));
            }

            return points.ToArray();
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            Transform(g, msElapsed);

            g.FillPolygon(new SolidBrush(Color.Yellow), Verticies.ToArray(), FillMode.Winding);

            g.ResetTransform();
        }

        public override void DrawSlow(Graphics g)
        {
            Draw(g, 0);
            Init = true;
        }

        private void Transform(Graphics g, Int64 msElapsed)
        {
            Double inc = _rotationalSpeedDegreeMs * msElapsed;
            Angle += inc;
            Angle %= 360;
            var matrix = new Matrix();
            matrix.RotateAt((Single)Angle, Centre);
            g.Transform = matrix;
        }
    }
}
