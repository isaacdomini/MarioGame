using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.Blocks
{
    abstract class BumpableBlock : Block, IBumpable
    {
        private enum bumpedStatus
        {
            Bottom,
            OneQuarter,
            Half,
            ThreeQuarters,
            Top
        }
        public BumpableBlock(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
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
