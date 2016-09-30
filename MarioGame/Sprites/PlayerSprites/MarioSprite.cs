using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;
using System.Collections.Generic;
using System.Collections;
using MarioGame.States.PlayerStates;

namespace MarioGame.Sprites.PlayerSprites
{
    public class MarioSprite : AnimatedSprite
    {

        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            DeadMario = 0,
            SwimmingMarioEnd = 1,
            SwimmingMarioBeforeEnd = 2,
            SwimmingMarioMiddle = 3,
            SwimmingMarioAfterStart = 4,
            SwimmingMarioStart = 5,
            SittingMario2 = 6, //I know he's not sitting . . .I'm just not sure exactly what that section of the sprite sheet is
            SittingMario1 = 7,
            JumpingMario = 8,
            DashingMario = 9,
            MovingMario3 = 10, //moving is the same sprites for Running and Walking action states
            MovingMario2 = 11,
            MovingMario1 = 12,
            StandingMario = 13,
            HalfBigMario = 14
        }

        public enum Rows
        {
            Super = 0,
            Dead = 1, //When Mario is dead the sprite sheet will reference row 1 frame 0 where the dead mario sprite is
            Standard = 1,
            SuperLuigi = 2,
            Luigi = 3,
            Fire = 4
        }

        //power up states - standard(small), super(big), fire ,start (invincible), Dead

        public MarioSprite(ContentManager content) : base(content)
        {
            _assetName = "characters_transparent";
            _numberOfFramesPerRow = 15;
            //Each state has a frameSet
            
            _frameSets = new Dictionary<int, List<int>> {
                { MarioActionStates.Idle.GetHashCode(), new List<int> { Frames.StandingMario.GetHashCode() } },
                { MarioActionStates.Walking.GetHashCode(), new List<int> {Frames.MovingMario1.GetHashCode(), Frames.MovingMario2.GetHashCode(), Frames.MovingMario3.GetHashCode(), Frames.MovingMario2.GetHashCode() } },//TODO: instead of {1, 2, 3} may have to do {1, 2, 3, 2} or something like that
                { MarioActionStates.Running.GetHashCode(), new List<int> {Frames.MovingMario1.GetHashCode(), Frames.MovingMario2.GetHashCode(), Frames.MovingMario3.GetHashCode(), Frames.MovingMario2.GetHashCode() } },//TODO: instead of {1, 2, 3} may have to do {1, 2, 3, 2} or something like that
                {MarioActionStates.Crouching.GetHashCode(), new List<int> {Frames.StandingMario.GetHashCode() } },
                {MarioActionStates.Jumping.GetHashCode(), new List<int> {Frames.JumpingMario.GetHashCode() } },
                {MarioActionStates.Sitting.GetHashCode(), new List<int> {Frames.SittingMario1.GetHashCode(), Frames.SittingMario2.GetHashCode() } },
                { MarioActionStates.Swimming.GetHashCode(), new List<int> {Frames.SwimmingMarioStart.GetHashCode(), Frames.SwimmingMarioAfterStart.GetHashCode(), Frames.SwimmingMarioMiddle.GetHashCode(), Frames.SwimmingMarioBeforeEnd.GetHashCode(), Frames.SwimmingMarioEnd.GetHashCode() } },
                {MarioActionStates.Dead.GetHashCode(), new List<int> {Frames.DeadMario.GetHashCode() } } //TODO: Is Dead an action state or power up state?
            };

            _rowSets = new Dictionary<int, List<int>>
            {
                {MarioPowerUpStates.Standard.GetHashCode(), new List<int> {Rows.Standard.GetHashCode() } },
                {MarioPowerUpStates.Super.GetHashCode(), new List<int> {Rows.Super.GetHashCode() } },
                {MarioPowerUpStates.Fire.GetHashCode(), new List<int> {Rows.Fire.GetHashCode() } },
                {MarioPowerUpStates.Invincible.GetHashCode(), new List<int> {Rows.Standard.GetHashCode(), Rows.Fire.GetHashCode(), Rows.Luigi.GetHashCode() } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStates.Dead.GetHashCode(), new List<int> {Rows.Standard.GetHashCode() } }
            };
        }

        public override void Load(int framesPerSecond = 5)
        {
            base.Load(framesPerSecond);
            _frameHeight = 40;
        }
        public void changeActionState(MarioActionStates marioActionState)
        {
            _frameSet = _frameSets[marioActionState.GetHashCode()];
        }

        public void changePowerUp(MarioPowerUpStates marioPowerUpState)
        {
            _rowSet = _rowSets[marioPowerUpState.GetHashCode()];
        }

    }
}