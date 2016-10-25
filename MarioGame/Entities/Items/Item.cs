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
        private static readonly Vector2 FallingVelocity = new Vector2(0, velocityConstant * 1); //todo: can we just let this inherit/ override the parent?

        public Item(Vector2 position, ContentManager content) : base(position, content)
        {
            boxPercentSizeOfEntity = 1.2f;
        }

        public override void Hide()
        {
            this.Sprite.Hide();
        }

        public override void Show()
        {
            this.Sprite.Show();
        }

        public override void LeaveContainer()
        {
            throw new NotImplementedException();
        }
        public override void OnCollide(IEntity otherObject, Sides side)
        {
            base.OnCollide(otherObject, side);
            if (otherObject is Mario)
            {
                Delete();
            }
        }
    }
}
