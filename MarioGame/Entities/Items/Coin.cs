using System;
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
        public override void Update(Viewport viewport, GameTime gameTime)
        {
            if (revealing)
            {
                base.Update(viewport, gameTime);
            }
            else if (timeTillDisappear > 0)
            {
                timeTillDisappear--;
                base.Update(viewport, gameTime);
            }
            else if (timeTillDisappear == 0 && IsVisible)
            {
                Delete();
            }
        }
    }
}
