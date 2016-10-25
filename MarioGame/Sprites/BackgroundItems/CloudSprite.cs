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
            AssetName = "ScenerySprite";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, List<int>> {
                {0, new List<int>{Frames.Cloud.GetHashCode()} }
            };
            FrameSet = FrameSets[0];
            FrameSetPosition = 0;
            RowSetPosition = 0;
            NumberOfFramesPerRow = 1;
        }
        public override void Update(float elapsed)
        {
        }
    }
}
