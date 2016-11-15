using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class FireballSprite: AnimatedSprite
    {
        public FireballSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "fireball";
        }
    }
}
