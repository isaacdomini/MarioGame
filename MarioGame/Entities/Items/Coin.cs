using System;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public class Coin : Item
    {
        private int coinPoppedVelocity = -5;
        private int timeTillDisappear; 
        public Coin(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            floating = true;
        }
        public override void LeaveContainer()
        {
            SetYVelocity(new Vector2(0, coinPoppedVelocity));
            timeTillDisappear = 10;
            base.LeaveContainer();
        }
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            if (Revealing)
            {
                base.Update(viewport, elapsedMilliseconds);
            }
            else if (timeTillDisappear > 0)
            {
                timeTillDisappear--;
                base.Update(viewport, elapsedMilliseconds);
            }
            else if (timeTillDisappear == 0 && IsVisible)
            {
                Delete();
            }
        }

        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            //intentionally do nothing.
        }
    }
}
