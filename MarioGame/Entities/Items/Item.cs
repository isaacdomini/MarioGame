﻿using MarioGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using MarioGame.Core;

namespace MarioGame.Entities
{
    public abstract class Item : ContainableHidableEntity
    {
        public Vector2 movingVelocity = new Vector2(.5f, 0);
        private readonly static Vector2 fallingVelocity = new Vector2(0, velocityConstant * 1);

        public Item(Vector2 position, ContentManager content) : base(position, content)
        {
            boxPercentSizeOfEntity = 1.2f;
        }

        public override void Hide()
        {
            this._sprite.Hide();
        }

        public override void Show()
        {
            this._sprite.Show();
        }

        public override void leaveContainer()
        {
            throw new NotImplementedException();
        }
        public override void onCollide(IEntity otherObject, Sides side)
        {
            base.onCollide(otherObject, side);
            if (otherObject is Mario)
            {
                Delete();
            }
        }
        public void changeDirection()
        {
            Vector2 newVelocity = _velocity * -1;
            this.setVelocity(newVelocity);
        }
        public void SetVelocityToFalling()
        {
            this.setVelocity(fallingVelocity);
        }
    }
}
