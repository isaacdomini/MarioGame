using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class GreenPipe : Block
    {
        public GreenPipe(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
        }
    }
}
