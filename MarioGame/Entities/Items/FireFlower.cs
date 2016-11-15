using System;
using MarioGame.Entities.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class FireFlower : PowerUp
    {
        public FireFlower(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
        }
    }
}
