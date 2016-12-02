using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Core;

namespace MarioGame.Theming.Scenes
{
    class MainMenu : Scene
    {
        private String displayMessage = "Main Menu";
        private List<String> options = new List<String>();
        public MainMenu(Stage stage) : base(stage)
        {
            
        }
        public override void Initialize()
        {
            Stage.Initialize(this);
            Script.Initialize();
            Camera = new Camera(Stage.Game1.GraphicsDevice.Viewport);
            Layers = new List<Layer>
            {
                new Layer(Camera, new Vector2(0.1f, 1.0f)),
                new Layer(Camera, new Vector2(0.5f, 1.0f)),
                new Layer(Camera, new Vector2(1.0f, 1.0f))
            };
            var middle = new Vector2(Stage.Game1.GraphicsDevice.Viewport.Width / 2f,
                Stage.Game1.GraphicsDevice.Viewport.Height / 2f);
            options.Add("Play as Mario (press K)");
            options.Add("Play as Enemy (press E)");
            options.Add("Watch Hardcoded Mario (press H)");
            options.Add("Watch Level Learning AI (press T)");

            LevelLoader.AddTileMapToScript("MainMenu.json", Script, Stage.Game1);
        }
        protected override void DrawBackground()
        {
            Game1.GraphicsDevice.Clear(Color.Gray);
        }

        public override void Draw()
        {
            base.Draw();
            SpriteBatch.Begin();
            SpriteBatch.DrawString(Game1.Font, displayMessage, new Vector2(325, 250), Color.White);
            SpriteBatch.End();
            int xOffset = 300;
            int yOffset = 50;
            int xOrig = 100;
            int yOrig = 300;
            int yLoc = yOrig;
            int xLoc= xOrig;
            foreach (String item in options)
            {
                SpriteBatch.Begin();
                SpriteBatch.DrawString(Game1.Font, item, new Vector2(xLoc, yLoc), Color.Blue);
                SpriteBatch.End();
                xLoc = xLoc + xOffset;
                if (xLoc > LevelWidth)
                {
                    xLoc = xOrig;
                    yLoc += yOffset;
                }
            }
        }
    }
}
