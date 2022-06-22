using System;
using System.Drawing;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Sky: Square
    {
        public Sky(Int32 originX, Int32 originY, Int32 width, Int32 height, Int32 starCount) : base(originX, originY, width, height, new SolidBrush(Color.Black))
        {
            Int32 maxY = height / 2;
            for (UInt32 i = 0; i < starCount; i++)
            {
                Int32 size = Entropy.Next(5, 15);
                Elements.Add(new Star(Entropy.Next(size, width - size), 
                                          Entropy.Next(size, maxY - size), size));
            }
        }

        public override void Draw(Graphics g, Int64 msElapsed)
        {
            base.Draw(g, msElapsed);
            foreach (Shape element in Elements)
            {
                element.Draw(g, msElapsed);
            }

            g.ResetTransform();
        }

        public override void DrawSlow(Graphics g)
        {
            // ElementCount = number of elements // protected property
            // DrawCount    = 0                  // protected property
            // Init         = False              // protected property

            // draw elements from 0 -> DrawCount
            // if element.Init == True
            //     DrawCount++
            //
            // if DrawCount == ElementCount
            //     Init = True
            //
            // wait 250ms

            for (var i = 0; i < DrawCount; ++i)
            {
                Elements[i].DrawSlow(g);
                if (Elements[i].Init && DrawCount < Elements.Count)
                {
                    DrawCount++;
                }

                if (DrawCount == Elements.Count)
                {
                    Init = true;
                }
            }
        }
    }
}
