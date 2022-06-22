using System;
using art_project.Scene.Shapes;

namespace art_project.Scene
{
    public class SceneFactory
    {
        public static Shape GetScene(Int32 width, Int32 height, Int32 starCount, Int32 flowerCount)
        {
            var sky = new Sky(0, 0, width, height, starCount);
            var ground = new Ground(0, 0, width, height, flowerCount);

            return new Scene(sky, ground);
        }
    }
}
