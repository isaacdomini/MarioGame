using MarioGame.Core;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    public class FinishLine : Item
    {
        public FinishLine(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            if (!IsVisible) return;
            if (otherObject is Mario)
            {
                CalculateBonus(Sprite.FrameSetPosition);
                Mario.Scoreboard.FinishMultiplier();
                //Right now it restarts on collision, so it doesn't look like mario gets points but he does.
                //We will switch it to the Game Finished screen once that's been made.
                GameOver.Won = true;
                Script.Announce(EventTypes.Levelclear);
                Mario.GoToGameOver();
            }
            else
            {
                base.OnCollide(otherObject, side, otherSide);
            }
        }
        private static void CalculateBonus(int frameNumber)
        {
            int points = 0;
            switch (frameNumber)
            {
                case 0:
                    points = 100;
                    break;
                case 1:
                    points = 400;
                    break;
                case 2:
                    points = 800;
                    break;
                case 3:
                    points = 2000;
                    break;
                case 4:
                    points = 0;
                    Mario.Scoreboard.AddLife();
                    break;
            }
            Mario.Scoreboard.AddPoint(points);
        }
    }
}
