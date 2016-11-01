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
    class BrickBlock : BumpableContainerBlock
    {
        public BrickBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            if (!(otherObject is Mario)) return;
            if (side == Sides.Bottom && otherSide == Sides.Top && ((Mario)otherObject).Velocity.Y <= 0)
            {
                if (((Mario)otherObject).MarioPowerUpState.PowerUpState == MarioPowerUpStateEnum.Standard)
                {
                    Bump();
                }
                else
                {
                    Break();
                }
            }
        }
        public override void Break()
        {
            IsCollidable = false;
            ((BlockActionState)AState).Break();
        }
    }
}
