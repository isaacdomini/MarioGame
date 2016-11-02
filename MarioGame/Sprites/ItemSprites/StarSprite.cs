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
    public class StarSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            Orange = 0,
            Yellow = 1,
            Maroon = 2,
            Red = 3
        }
        public StarSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "star";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, Collection<int>> {
                { 0, new Collection<int> { Frames.Orange.GetHashCode(), Frames.Yellow.GetHashCode(), Frames.Red.GetHashCode() } },
            };
            FrameSet = FrameSets[Frames.Orange.GetHashCode()];

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

