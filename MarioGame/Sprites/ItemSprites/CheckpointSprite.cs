using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class CheckpointSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public CheckpointSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "checkpoint";
        }
    }
}
