using MarioGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace MarioGame.Entities
{
    public abstract class Item : ContainableHidableEntity
    {
        public Item(Vector2 position, ContentManager content) : base(position, content)
        {
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
    }
}