using MarioGame.Entities;
using MarioGame.States;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public class CoinSprite : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            //frames are all facing left. 
            Full = 0,
            Waning = 1,
            Sliver = 2,
            Waxing = 3
        }

        public CoinSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "coin";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, List<int>> {
                { 0, new List<int>{Frames.Full.GetHashCode(), Frames.Waning.GetHashCode(), Frames.Sliver.GetHashCode(), Frames.Waxing.GetHashCode() } },
            };
            FrameSet = FrameSets[Frames.Full.GetHashCode()];
            FrameSetPosition = 0;
            RowSetPosition = 0;
        }
    }
}

