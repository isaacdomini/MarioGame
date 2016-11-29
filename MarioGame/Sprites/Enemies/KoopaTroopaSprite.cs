using MarioGame.Core;
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
            if (koopaActionState.GetHashCode() == EnemyActionStateEnum.Dead.GetHashCode())
            {
                if (Game1.playAsMario == false)
                    FrameSet = FrameSets[koopaActionState.EnemyState.GetHashCode()];
                else
                    FrameSet = FrameSets[MarioActionStateEnum.Dead.GetHashCode()];
            }
            FrameSetPosition = 0;
        }
        public override void Load(int framesPerSecond)
        {
            base.Load(framesPerSecond);
            if (Game1.playAsMario == false)
            {
                FrameHeight = 15;
                AssetName = "mariorunningright21";
                NumberOfFramesPerRow = 3;
                FrameSets = new Dictionary<int, Collection<int>> {
                { MarioActionStateEnum.Walking.GetHashCode(), new Collection<int> {MarioSprite.Frames.MovingMario1.GetHashCode(), MarioSprite.Frames.MovingMario2.GetHashCode(), MarioSprite.Frames.MovingMario3.GetHashCode(), MarioSprite.Frames.MovingMario2.GetHashCode() } },//TODO: instead of {1, 2, 3} may have to do {1, 2, 3, 2} or something like that
                { MarioActionStateEnum.Dead.GetHashCode(), new Collection<int> {MarioSprite.Frames.DeadMario.GetHashCode() } }
                };
            }
            else
                FrameHeight = 25;
        }
    }
}
