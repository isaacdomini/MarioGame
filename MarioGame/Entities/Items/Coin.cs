using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Coin : Item
    {
        public Coin(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}
