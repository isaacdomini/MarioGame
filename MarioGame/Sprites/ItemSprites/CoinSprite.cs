using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public class CoinsSprite : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            Full = 0,
            Waning = 1,
            Sliver = 2,
            Waxing = 3
        }

        public CoinsSprite(ContentManager content) : base(content)
        {
            _assetName = "fireFlower";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int>{Frames.Full.GetHashCode(), Frames.Waning.GetHashCode(), Frames.Sliver.GetHashCode(), Frames.Waxing.GetHashCode() } },
            };
        }

    }
}

