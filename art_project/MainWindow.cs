using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using art_project.Scene;
using art_project.Scene.Shapes;

namespace art_project
{
    public partial class MainWindow : Form
    {
        private readonly Shape _scene;
        private readonly Stopwatch _timer = new();

        public MainWindow()
        {
            InitializeComponent();
            _scene = SceneFactory.GetScene(Width, Height, 100, 50);
        }

        private void picSurface_Paint(Object sender, PaintEventArgs e)
        {
            Int64 ms = _timer.IsRunning ? _timer.ElapsedMilliseconds : 1;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            _scene.Draw(e.Graphics, ms);

            Font drawFont = new Font("Arial", 16);
            e.Graphics.DrawString($"{1000/ms} FPS", drawFont, new SolidBrush(Color.White), 0, 0);
            _timer.Restart();
        }

        private void tmrRenderTick_Tick(object sender, EventArgs e)
        {
            picSurface.Invalidate();
        }
    }
}
