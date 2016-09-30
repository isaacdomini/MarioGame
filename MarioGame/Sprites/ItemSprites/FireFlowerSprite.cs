using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public class FireFlowerSprite : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            Blue = 0,
            Red = 1,
            Purple = 2,
            Halo = 3
        }
        public FireFlowerSprite(ContentManager content) : base(content)
        {
            _assetName = "fireFlower";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Blue.GetHashCode(), Frames.Red.GetHashCode(), Frames.Purple.GetHashCode(), Frames.Halo.GetHashCode() } },
            };
        }

    }
}

