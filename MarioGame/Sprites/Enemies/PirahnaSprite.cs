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
        public enum Frames
        {
            //frames are all facing left. 
            Open = 0,
            Closed = 1
        }
        public PirahnaSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "Pirahna";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, Collection<int>> {
                {EnemyActionStateEnum.Walking.GetHashCode(), new Collection<int>{Frames.Open.GetHashCode(), Frames.Closed.GetHashCode()} }};
            FrameSet = FrameSets[Frames.Open.GetHashCode()];
            FrameSetPosition = 0;
            RowSetPosition = 0;
            NumberOfFramesPerRow = 2;
        }

        public void ChangeActionState(PirahnaActionState pirahnaActionState)
        {
           FrameSet = FrameSets[pirahnaActionState.EnemyState.GetHashCode()];
            FrameSetPosition = 0;
        }
    }
}
