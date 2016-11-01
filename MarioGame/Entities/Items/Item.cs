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

        public Item(Vector2 position, ContentManager content) : base(position, content)
        {
            IsCollidable = true;
            BoxPercentSizeOfEntity = 1.2f;
        }

        public override void Hide()
        {
            _isVisible = false;
        }

        public override void Show()
        {
            _isVisible = false;
        }

        public override void LeaveContainer()
        {
            Show(); 
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            base.OnCollide(otherObject, side, otherSide);
            if (otherObject is Mario)
            {
                Delete();
            }
            if (otherObject is Block)
            {
                if (side == Sides.Left || side == Sides.Right)
                {
                    this.FlipHorizontalVelocity();
                }
            }
        }
    }
}
