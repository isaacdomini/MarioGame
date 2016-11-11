using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;

namespace MarioGame.Sprites
{
    public class StepBlockSprite : BlockSprite
    {
        public StepBlockSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "stepblock";
        }
    }
}
