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
            DeadMario = 1,
            SwimmingMarioEnd = 2,
            SwimmingMarioBeforeEnd = 3,
            SwimmingMarioMiddle = 4,
            SwimmingMarioAfterStart = 5,
            SwimmingMarioStart = 6,
            SittingMario2 = 7, //I know he's not sitting . . .I'm just not sure exactly what that section of the sprite sheet is
            SittingMario1 = 8,
            JumpingMario = 9,
            DashingMario = 10,
            MovingMario3 = 11, //moving is the same sprites for Running and Walking action states
            MovingMario2 = 12,
            MovingMario1 = 13,
            StandingMario = 14,
            HalfBigMario = 15
        }

        public enum Rows
        {
            Super = 1,
            Dead = 2, //When Mario is dead the sprite sheet will reference row 2 frame 1 where the dead mario sprite is
            Standard = 2,
            SuperLuigi = 3,
            Luigi = 4,
            Fire = 5
        }

        //power up states - standard(small), super(big), fire ,start (invincible), Dead

        public MarioSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
            _assetName = "characters_transparent.gif";
            _numberOfFramesPerRow = 15;
            _frameHeight = 40;
            //Each state has a frameSet
            _frameSets = new Dictionary<MarioActionStates, List<Frames>> {
                { MarioActionStates.Idle, new List<Frames> { Frames.StandingMario } },
                { MarioActionStates.Moving, new List<Frames> {Frames.MovingMario1, Frames.MovingMario2, Frames.MovingMario3 } },//TODO: instead of {1, 2, 3} may have to do {1, 2, 3, 2} or something like that
                {MarioActionStates.Jumping, new List<Frames> {Frames.JumpingMario } },
                {MarioActionStates.Sitting, new List<Frames> {Frames.SittingMario1, Frames.SittingMario2} },
                { MarioActionStates.Swimming, new List<Frames> {Frames.SwimmingMarioStart, Frames.SwimmingMarioAfterStart, Frames.SwimmingMarioMiddle, Frames.SwimmingMarioBeforeEnd, Frames.SwimmingMarioEnd  } },
                {MarioActionStates.Dead, new List<Frames> {Frames.DeadMario } } //TODO: Is Dead an action state or power up state?
            };

            _powerUpRowSets = new Dictionary<MarioPowerUpStates, List<Rows>>
            {
                {MarioPowerUpStates.Standard, new List<Rows> {Rows.Standard } },
                {MarioPowerUpStates.Super, new List<Rows> {Rows.Super } },
                {MarioPowerUpStates.Fire, new List<Rows> {Rows.Fire } },
                {MarioPowerUpStates.Invincible, new List<Rows> {Rows.Standard, Rows.Fire, Rows.Luigi } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                {MarioPowerUpStates.Dead, new List<Rows> {Rows.Standard} }
            };
        }

    }
}