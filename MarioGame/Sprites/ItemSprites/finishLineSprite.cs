using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class FinishLineSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        private enum Frames
        {
            One = 0,
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        protected override void DefineFrameSets()
        {
            base.DefineFrameSets();
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;
            FrameSets = new Dictionary<int, Collection<int>> {
                {0, new Collection<int> { Frames.One.GetHashCode(), Frames.Two.GetHashCode(), Frames.Three.GetHashCode(), Frames.Four.GetHashCode(), Frames.Five.GetHashCode() } },
            };
        }
        public FinishLineSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "finishLine";
        }
    }
}

