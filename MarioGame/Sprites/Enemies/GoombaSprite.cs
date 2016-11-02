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
    public enum Frames
    {
        //frames are all facing left. 
        Walk = 0,
        Walk1 = 1,
        Dead = 2,
    }

    public class GoombaSprite : HidableSprite
    {
        public GoombaSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "regulargoomba";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, Collection<int>> {
                {EnemyActionStateEnum.Walking.GetHashCode(), new Collection<int>{Frames.Walk.GetHashCode(), Frames.Walk1.GetHashCode()} },
                {EnemyActionStateEnum.Dead.GetHashCode(), new Collection<int> { Frames.Dead.GetHashCode() } }
            };
            FrameSet = FrameSets[Frames.Walk.GetHashCode()];
            FrameSetPosition = 0;
            RowSetPosition = 0;
            NumberOfFramesPerRow = 3;
        }
        
        public void ChangeActionState(GoombaActionState goombaActionState)
        {
            FrameSet = FrameSets[goombaActionState.EnemyState.GetHashCode()];
            FrameSetPosition = 0;
        }
    }
}
