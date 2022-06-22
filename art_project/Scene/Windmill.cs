using System;
using System.Drawing;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class Windmill : Shape
    {
        public Windmill(Int32 originX, Int32 originY, Int32 baseWidth, Int32 height)
        {
            // create tower
            Elements.Add(new Tower(originX, originY, baseWidth, height));
            // create door
            // create window
            // create roof
            Elements.Add(new Roof(originX, originY - height, 100, baseWidth));
            // create blades
            Elements.Add(new Blades(originX + (baseWidth / 2), originY - height - 50, 300));
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
                if (Elements[i].Init)
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
