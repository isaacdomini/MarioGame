using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public class StarSprite : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            Orange = 0,
            Yellow = 1,
            Maroon = 2,
            Red = 3
        }
        public StarSprite(ContentManager content) : base(content)
        {
            _assetName = "star";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Orange.GetHashCode(), Frames.Yellow.GetHashCode(), Frames.Red.GetHashCode() } },
            };
            _frameSet = _frameSets[Frames.Orange.GetHashCode()];

        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }

    }
}

