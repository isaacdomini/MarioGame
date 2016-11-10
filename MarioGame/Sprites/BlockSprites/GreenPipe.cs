using MarioGame.Entities;
using MarioGame.States;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame.Sprites
{
    public class GreenPipeSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public enum Frames
        {
            //frames are all facing left. 
            Pipe = 0
        }

        public GreenPipeSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "GreenPipe";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, Collection<int>> {
                { 0, new Collection<int>{Frames.Pipe.GetHashCode()} },
            };
            FrameSet = FrameSets[Frames.Pipe.GetHashCode()];
            FrameSetPosition = 0;
            RowSetPosition = 0;
        }
    }
}