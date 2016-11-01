using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public class BlockPieceSprite : AnimatedSprite

    {
        public BlockPieceSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "BrokenBrick";
        }
    }
}
