using MarioGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Item : Entity, IContainable
    {
        public Item(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}