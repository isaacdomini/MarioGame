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
    public class BackgroundItemSprite : AnimatedSprite
    {
        public enum Frames
        {
            //frames are all facing left. 
            Hill1 = 0,
            Hill2 = 1,
            Cloud1 = 2,
            Cloud2 = 3,
            Cloud3 = 4,
            Bush1 = 5,
            Bush2 = 6,
            Bush3 = 7
        }
        public BackgroundItemSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "backs";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, Collection<int>> {
                {Frames.Hill1.GetHashCode(), new Collection<int>{Frames.Hill1.GetHashCode()} },
                {Frames.Hill2.GetHashCode(), new Collection<int>{Frames.Hill2.GetHashCode()} },
                {Frames.Cloud1.GetHashCode(), new Collection<int>{Frames.Cloud1.GetHashCode()} },
                {Frames.Cloud2.GetHashCode(), new Collection<int>{Frames.Cloud2.GetHashCode()} },
                {Frames.Cloud3.GetHashCode(), new Collection<int>{Frames.Cloud3.GetHashCode()} },
                {Frames.Bush1.GetHashCode(), new Collection<int>{Frames.Bush1.GetHashCode()} },
                {Frames.Bush2.GetHashCode(), new Collection<int>{Frames.Bush2.GetHashCode()} },
                {Frames.Bush3.GetHashCode(), new Collection<int>{Frames.Bush3.GetHashCode()} }
            };
            RowSetPosition = 0;
            NumberOfFramesPerRow = 8;
        }
    }
}
