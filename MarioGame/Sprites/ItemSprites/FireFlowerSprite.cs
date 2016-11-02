using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame.Sprites
{
    public class FireFlowerSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            Blue = 0,
            Red = 1,
            Purple = 2,
            Halo = 3
        }
        public FireFlowerSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "fireFlower";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, Collection<int>> {
                { 0, new Collection<int> { Frames.Blue.GetHashCode(), Frames.Red.GetHashCode(), Frames.Purple.GetHashCode(), Frames.Halo.GetHashCode() } },
            };
            FrameSet = FrameSets[Frames.Blue.GetHashCode()];
        }
        public override void Draw(SpriteBatch batch)
        {
            if (isVisible)
            {
                base.Draw(batch);
            }
        }
    }
}

