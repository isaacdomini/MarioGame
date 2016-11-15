using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Theming.Scenes
{
    class GameOver : Scene
    {
        public GameOver(Stage stage) : base(stage)
        {
        }
        public override void Initialize()
        {
            Stage.Initialize(this);
            Script.Initialize();

            _camera = new Camera(Stage.Game1.GraphicsDevice.Viewport);
            Layers = new List<Layer>
            {
                new Layer(Camera, new Vector2(0.1f, 1.0f)),
                new Layer(Camera, new Vector2(0.5f, 1.0f)),
                new Layer(Camera, new Vector2(1.0f, 1.0f))
            };
            var middle = new Vector2(Stage.Game1.GraphicsDevice.Viewport.Width / 2f,
                Stage.Game1.GraphicsDevice.Viewport.Height / 2f);

            LevelLoader.AddTileMapToScript("GameOver.json", Script, Stage.Game1);
        }
        protected override void DrawBackground()
        {
            Game1.GraphicsDevice.Clear(Color.Black);
        }
    }
}
