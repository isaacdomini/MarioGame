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
    

    public class PirahnaSprite : HidableSprite
    {
        private enum Frames
        {
            //frames are all facing left. 
            Open = 0,
            Closed = 1
        }
        protected override void DefineFrameSets()
        {
            base.DefineFrameSets();
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;
            FrameSets = new Dictionary<int, Collection<int>> {
                {0, new Collection<int>{Frames.Open.GetHashCode(), Frames.Closed.GetHashCode() } },
            };
        }
        public PirahnaSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "Pirahna";
        }

        public void ChangeActionState(PirahnaActionState pirahnaActionState)
        {
           FrameSet = FrameSets[pirahnaActionState.EnemyState.GetHashCode()];
            FrameSetPosition = 0;
        }
    }
}
