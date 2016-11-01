using MarioGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using MarioGame.Core;

namespace MarioGame.Entities
{
    public abstract class Item : ContainableHidableEntity
    {
        public Vector2 MovingVelocity = new Vector2(.5f, 0);
        private static readonly Vector2 FallingVelocity = new Vector2(0, VelocityConstant * 1); //todo: can we just let this inherit/ override the parent?
        protected static int itemHeight = 16;

        public Item(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            BoxPercentSizeOfEntity = 1.2f;
        }

        public override void LeaveContainer()
        {
            _position.Y -= itemHeight;
            Show();
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            if (IsVisible && !(this is Coin))
            {
                base.OnCollide(otherObject, side, otherSide);
                if (otherObject is Mario)
                {
                    Delete();
                }
                if (otherObject is Block)
                {
                    if (((Block)otherObject).IsVisible == true)
                    {
                        if (side == Sides.Left || side == Sides.Right)
                        {
                            this.FlipHorizontalVelocity();
                        }
                    }
                }
            }
        }
        public override void Delete()
        {
            Hide();
            base.Delete();
        }
    }
}
