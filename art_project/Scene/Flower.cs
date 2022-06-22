using System;
using System.Drawing;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Flower: Shape
    {
        public Flower(Int32 originX, Int32 originY)
        {
            // create stem
            // originX delta = (pollen width - stem width) / 2
            //               = (20 - 6) / 2
            Elements.Add(new Square(originX, originY, 6, 50, new SolidBrush(Color.DarkGreen)));
            // create leaves
            Elements.Add(new Leaf(originX, originY + 50, 6, 30, LeftRight.Left));
            Elements.Add(new Leaf(originX, originY + 50, 6, 30, LeftRight.Right));
            // create petals
            Elements.Add(new Ellipse(originX - 2, originY - 20, 10, 40, Color.White));
            Elements.Add(new Ellipse(originX - 17, originY - 5, 40, 10, Color.White));
            // create pollen
            Elements.Add(new Ellipse(originX - 7, originY - 10, 20, 20, Color.Orange));
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            foreach (Shape element in Elements)
            {
                element.Draw(g, msElapsed);
            }
        }

        public override void DrawSlow(Graphics g)
        {

        }
    }
}
