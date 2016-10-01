using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.BlockEntities
{
    abstract class BumpableBlockEntity : BlockEntity, IBumpable
    {
        private enum bumpedStatus
        {
            Bottom,
            OneQuarter,
            Half,
            ThreeQuarters,
            Top
        }
        public BumpableBlockEntity(Vector2 position, ISprite sprite) : base(position, sprite)
        {
        }

        public void Bump()
        {
            bState.Bump();
        }
        public override void Update()
        {
            base.Update();

        }
    }
}
