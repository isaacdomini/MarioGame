using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static MarioGame.Entities.Mario;
using MarioGame.Entities;
using System;
using System.Collections.ObjectModel;
using static MarioGame.Entities.Entity;
using MarioGame.States;
using MarioGame.Core;

namespace MarioGame.Sprites
{
    public class MarioSprite : AnimatedSprite
    {
        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            None = 0,
            SwimmingMarioEnd = 1,
            SwimmingMarioBeforeEnd = 2,
            SwimmingMarioMiddle = 3,
            SwimmingMarioAfterStart = 4,
            SwimmingMarioStart = 5,
            SittingMario2 = 6, //I know he's not sitting . . .I'm just not sure exactly what that section of the sprite sheet is
            SittingMario1 = 7,
            JumpingMario = 8,
            FallingMario = 8,
            DashingMario = 9,
            MovingMario3 = 10, //moving is the same sprites for Running and Walking action states
            MovingMario2 = 11,
            MovingMario1 = 12,
            CrouchingMario = 13,
            StandingMario = 14,
            DeadMario = 14
        }

        public enum Rows
        {
            Super = 0,
            Standard = 1,
            SuperLuigi = 2,
            Luigi = 3,
            Fire = 4,
            Dead = 5
        }
        public enum GoombaRows
        {
            Super = 1,
            Standard = 0,
            SuperLuigi = 1,
            Luigi = 1,
            Fire = 1,
            Dead = 1
        }
        //power up states - standard(small), super(big), fire ,star (invincible), Dead

        public MarioSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            if (Game1.playAsMario == true)
            {
                AssetName = "characters_transparent";
                NumberOfFramesPerRow = 15;
                //Each state has a frameSet

                FrameSets = new Dictionary<int, Collection<int>> {
                { MarioActionStateEnum.Idle.GetHashCode(), new Collection<int> { Frames.StandingMario.GetHashCode() } },
                { MarioActionStateEnum.Walking.GetHashCode(), new Collection<int> {Frames.MovingMario1.GetHashCode(), Frames.MovingMario2.GetHashCode(), Frames.MovingMario3.GetHashCode(), Frames.MovingMario2.GetHashCode() } },//TODO: instead of {1, 2, 3} may have to do {1, 2, 3, 2} or something like that
                { MarioActionStateEnum.Running.GetHashCode(), new Collection<int> {Frames.MovingMario1.GetHashCode(), Frames.MovingMario2.GetHashCode(), Frames.MovingMario3.GetHashCode(), Frames.MovingMario2.GetHashCode() } },//TODO: instead of {1, 2, 3} may have to do {1, 2, 3, 2} or something like that
                { MarioActionStateEnum.Crouching.GetHashCode(), new Collection<int> {Frames.CrouchingMario.GetHashCode() } },
                { MarioActionStateEnum.Jumping.GetHashCode(), new Collection<int> {Frames.JumpingMario.GetHashCode() } },
                { MarioActionStateEnum.Falling.GetHashCode(), new Collection<int> {Frames.FallingMario.GetHashCode() } },
                { MarioActionStateEnum.Sitting.GetHashCode(), new Collection<int> {Frames.SittingMario1.GetHashCode(), Frames.SittingMario2.GetHashCode() } },
                { MarioActionStateEnum.Swimming.GetHashCode(), new Collection<int> {Frames.SwimmingMarioStart.GetHashCode(), Frames.SwimmingMarioAfterStart.GetHashCode(), Frames.SwimmingMarioMiddle.GetHashCode(), Frames.SwimmingMarioBeforeEnd.GetHashCode(), Frames.SwimmingMarioEnd.GetHashCode() }},
                { MarioActionStateEnum.Dead.GetHashCode(), new Collection<int> {Frames.DeadMario.GetHashCode() } }
            };

                RowSets = new Dictionary<int, Collection<int>>
            {
                {MarioPowerUpStateEnum.Standard.GetHashCode(), new Collection<int> {Rows.Standard.GetHashCode() } },
                {MarioPowerUpStateEnum.Super.GetHashCode(), new Collection<int> {Rows.Super.GetHashCode() } },
                {MarioPowerUpStateEnum.Fire.GetHashCode(), new Collection<int> {Rows.Fire.GetHashCode() } },
                {MarioPowerUpStateEnum.SuperStar.GetHashCode(), new Collection<int> {Rows.Fire.GetHashCode(), Rows.SuperLuigi.GetHashCode(), Rows.Super.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStateEnum.StandardStar.GetHashCode(), new Collection<int> {Rows.Luigi.GetHashCode(), Rows.Standard.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStateEnum.FireStar.GetHashCode(), new Collection<int> {Rows.Fire.GetHashCode(), Rows.SuperLuigi.GetHashCode(), Rows.Super.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStateEnum.Dead.GetHashCode(), new Collection<int> {Rows.Dead.GetHashCode() } }
            };

                FrameSet = FrameSets[MarioActionStateEnum.Idle.GetHashCode()];

                RowSet = RowSets[MarioPowerUpStateEnum.Standard.GetHashCode()];
            }
            else
            {
                AssetName = "goombaPlayer";
                NumberOfFramesPerRow = 3;
                //Each state has a frameSet

                FrameSets = new Dictionary<int, Collection<int>> {
                { EnemyActionStateEnum.Walking.GetHashCode(), new Collection<int> { GoombaSprite.Frames.Walk.GetHashCode(), GoombaSprite.Frames.Walk1.GetHashCode() } },
                { EnemyActionStateEnum.Dead.GetHashCode(), new Collection<int> {GoombaSprite.Frames.Dead.GetHashCode() } }
            };

                RowSets = new Dictionary<int, Collection<int>>
            {
                {MarioPowerUpStateEnum.Standard.GetHashCode(), new Collection<int> {GoombaRows.Standard.GetHashCode() } },
                {MarioPowerUpStateEnum.Super.GetHashCode(), new Collection<int> {GoombaRows.Super.GetHashCode() } },
                {MarioPowerUpStateEnum.Fire.GetHashCode(), new Collection<int> {GoombaRows.Fire.GetHashCode() } },
                {MarioPowerUpStateEnum.SuperStar.GetHashCode(), new Collection<int> {GoombaRows.Fire.GetHashCode(), GoombaRows.SuperLuigi.GetHashCode(), GoombaRows.Super.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStateEnum.StandardStar.GetHashCode(), new Collection<int> {GoombaRows.Luigi.GetHashCode(), GoombaRows.Standard.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStateEnum.FireStar.GetHashCode(), new Collection<int> {GoombaRows.Fire.GetHashCode(), GoombaRows.SuperLuigi.GetHashCode(), GoombaRows.Super.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStateEnum.Dead.GetHashCode(), new Collection<int> {GoombaRows.Dead.GetHashCode() } }
                };

                FrameSet = FrameSets[EnemyActionStateEnum.Walking.GetHashCode()];
                RowSet = RowSets[MarioPowerUpStateEnum.Standard.GetHashCode()];
            }
        }

        public override void Load(int framesPerSecond )
        {
            base.Load(framesPerSecond);
            if (Game1.playAsMario == true)
                FrameHeight = 40;
            else
                FrameHeight = 16;
        }
        public void ChangeActionState(MarioActionState marioActionState)
        {
            base.ChangeActionState();
            if(Game1.playAsMario==true)
                FrameSet = FrameSets[marioActionState.actionState.GetHashCode()];
            else
            {
                FrameSet = FrameSets[EnemyActionStateEnum.Walking.GetHashCode()];
            }
        }
        public void ChangePowerUp(MarioPowerUpState marioPowerUpState)
        {
            base.ChangePowerUp();
            // Because on the sprite sheet, dead state is a frame set, not a row set
                FrameSetPosition = 0;
            RowSet = RowSets[marioPowerUpState.PowerUpState.GetHashCode()];
            if (Game1.playAsMario == true)
            {
                FrameSet = FrameSets[marioPowerUpState.PowerUpState.GetHashCode()];
            }
            else
            {
                if (marioPowerUpState.PowerUpState.Equals(MarioPowerUpStateEnum.Standard))
                {
                    FrameSet = FrameSets[0];
                    RowSet = RowSets[GoombaRows.Standard.GetHashCode()];
                }
                else
                {
                    FrameSet = FrameSets[1];
                    RowSet = RowSets[GoombaRows.Super.GetHashCode()];
                }
            }
        }
    }
}
