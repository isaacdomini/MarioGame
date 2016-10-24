using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class FireFlower : Item
    {
        public FireFlower(Vector2 position, ContentManager content) : base(position, content)
        {
            isCollidable = true;
        }
    }
}
