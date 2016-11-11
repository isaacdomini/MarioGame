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
    public class KoopaTroopaSprite : HidableSprite
    {
        [Flags]
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

            FrameSets = new Dictionary<int, Collection<int>> {
                {EnemyActionStateEnum.Walking.GetHashCode(), new Collection<int>{Frames.MidWings.GetHashCode(), Frames.Wings.GetHashCode(), Frames.Walk.GetHashCode(), Frames.Walk2.GetHashCode()} },
                {EnemyActionStateEnum.Dead.GetHashCode(), new Collection<int> { Frames.Dead.GetHashCode() } }
            };
            FrameSet = FrameSets[EnemyActionStateEnum.Walking.GetHashCode()];
            FrameSetPosition = 0;
            RowSetPosition = 0;
            NumberOfFramesPerRow = 10;
        }

        public void ChangeActionState(KoopaActionState koopaActionState)
        {
            FrameSet = FrameSets[koopaActionState.EnemyState.GetHashCode()];
            FrameSetPosition = 0;
        }

    }
}
