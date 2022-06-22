using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Leaf: Ellipse
    {
        private readonly LeftRight _direction;

        public Leaf(Int32 originX, Int32 originY, Int32 width, Int32 height, LeftRight direction) : base(originX, originY, width, height, Color.DarkSeaGreen)
        {
            _direction = direction;
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            Transform(g);

            base.Draw(g, msElapsed);

            g.ResetTransform();
        }

        private void Transform(Graphics g)
        {
            var matrix = new Matrix();
            switch (_direction)
            {
                case LeftRight.Left:
                    matrix.RotateAt(135, Centre, MatrixOrder.Append);
                    // coincidence? in relation to leaf width / height
                    // x -> -width * 2
                    // y -> -height
                    matrix.Translate(-(_width * 2), -_height, MatrixOrder.Append);
                    break;
                case LeftRight.Right:
                    matrix.RotateAt(225, Centre, MatrixOrder.Append);
                    // coincidence? in relation to leaf width / height
                    // x -> width * 2
                    // y -> -height
                    matrix.Translate((_width * 2), -_height, MatrixOrder.Append);
                    break;
            }
            g.Transform = matrix;
        }
    }
}
