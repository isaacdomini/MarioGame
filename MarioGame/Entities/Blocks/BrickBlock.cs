using MarioGame.Sprites;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;

namespace MarioGame.Entities
{ 
    public class BrickBlock : Block
    {
        Vector2 bumpingVelocity = new Vector2(0, -1);
        Vector2 bumpingAcceleration = new Vector2()
        Queue<Item> _items;
        public BrickBlock(Vector2 position, ContentManager content) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            _items = null;
        }
        public BrickBlock(Vector2 position, ContentManager content, bool visibility) : base (position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            isVisible = visibility;
            _items = null;
        }
        public BrickBlock(Vector2 position, ContentManager content, Queue<Item> items) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            _items = items;
        }
        public BrickBlock(Vector2 position, ContentManager content, bool visibility, Queue<Item> items) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            isVisible = visibility;
            _items = items;
        }
        public override void Bump()
        {
            bState.Bump();
            // TODO: MAKE BRICK BLOCK BUMP
            SetVelocityToBumping();
            SetAccelerationToFalling();
            if (_items != null)
            {
                if (_items.Count > 0)
                {
                    Item item = _items.Dequeue();
                    item.Show();
                }
            }
        }

        private void SetVelocityToBumping()
        {
            _velocity = bumpingVelocity;
        }

        private void SetAccelerationToFalling()
        {
            throw new NotImplementedException();
        }

        public override void Break()
        {
            bState.Break();
        }
        public override void Reveal()
        {
            isVisible = true;
        }
        public override void ChangeToUsed()
        {
            bState.ChangeToUsed();
            
        }
    }
}
