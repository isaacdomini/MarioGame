using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using MarioGame.Core;

namespace MarioGame.Entities
{
    class QuestionBlock : BumpableContainerBlock
    {
        public QuestionBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            if (!(otherObject is Mario)) return;
            if (side == Sides.Bottom && otherSide == Sides.Top)
            {
                Bump();
            }
        }
    }
}
