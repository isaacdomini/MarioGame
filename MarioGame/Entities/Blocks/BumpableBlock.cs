﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
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
        public BumpableBlock(Vector2 position, ContentManager content) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
        }

        public void Bump()
        {
            bState.Bump();
        }
    }
}