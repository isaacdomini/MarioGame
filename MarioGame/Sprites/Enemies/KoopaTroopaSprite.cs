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
    public class KoopaTroopaSprite : AnimatedSprite
    {
        public enum Frames
        {
            //frames are all facing left. 
            MidWings = 0,
            Wings = 1,
            Walk = 2,
            Walk2 = 3,
            DeadLegs = 8,
            Dead = 9
        }
        public KoopaTroopaSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "regularkoopa";
            NumberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            FrameSets = new Dictionary<int, List<int>> {
                {EnemyActionStateEnum.Walking.GetHashCode(), new List<int>{Frames.MidWings.GetHashCode(), Frames.Wings.GetHashCode(), Frames.Walk.GetHashCode(), Frames.Walk2.GetHashCode()} },
                {EnemyActionStateEnum.Dead.GetHashCode(), new List<int> { Frames.Dead.GetHashCode() } }
            };
            FrameSet = FrameSets[EnemyActionStateEnum.Walking.GetHashCode()];
            FrameSetPosition = 0;
            RowSetPosition = 0;
            NumberOfFramesPerRow = 10;
        }

        public void changeActionState(KoopaActionState koopaActionState)
        {
            FrameSet = FrameSets[koopaActionState.EnemyState.GetHashCode()];
            FrameSetPosition = 0;
        }

    }
}
