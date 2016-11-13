using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    public class finishLine : Item
    {
        public finishLine(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            if (!IsVisible) return;
            if (otherObject is Mario)
            {
                CalculateBonus(Sprite.FrameSetPosition);
                //Right now it restarts on collision, so it doesn't look like mario gets points but he does.
                //We will switch it to the Game Finished screen once that's been made.
                MarioGame.Entities.Entity.Script.Reset();
            }
            else
            {
                base.OnCollide(otherObject, side, otherSide);
            }
        }
        private void CalculateBonus(int frameNumber)
        {
            int points = 0;
            if (frameNumber == 0)
                points = 100;
            else if (frameNumber == 1)
                points = 400;
            else if (frameNumber == 2)
                points = 800;
            else if (frameNumber == 3)
                points = 2000;
            else if (frameNumber == 4)
            {
                points = 0;
                Mario.Scoreboard.AddLife();
            }
            Mario.Scoreboard.AddPoint(points);
        }
    }
}
