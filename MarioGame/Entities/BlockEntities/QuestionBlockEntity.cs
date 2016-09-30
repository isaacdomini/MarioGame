using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.BlockEntities
{
    public class QuestionBlockEntity : BlockEntity
    {
        public QuestionBlockEntity(Vector2 position, ISprite sprite) : base(position, sprite)
        {
        }
    }
}
