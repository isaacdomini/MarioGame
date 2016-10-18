using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace MarioGame.Entities
{ 
    public class BrickBlock : Block
    {
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
            if (_items != null)
            {
                foreach (var item in _items)
                {
                    item.Show();
                }
            }

        }
        public override void Break()
        {
            bState.Break();
        }
        public override void Reveal()
        {
            isVisible = true;
        }
    }
}
