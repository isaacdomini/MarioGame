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
    public class CloudSprite : AnimatedSprite
    {
        public enum Frames
        {
            //frames are all facing left. 
            Cloud = 0
        }
        public CloudSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            _assetName = "ScenerySprite";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                {0, new List<int>{Frames.Cloud.GetHashCode()} }
            };
            _frameSet = _frameSets[0];
            _frameSetPosition = 0;
            _rowSetPosition = 0;
            _numberOfFramesPerRow = 1;
        }
        public override void Update(float elapsed)
        {
        }
    }
}
