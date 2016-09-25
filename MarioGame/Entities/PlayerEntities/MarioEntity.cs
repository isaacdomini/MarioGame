
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
        protected enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            DeadMario = 1,
            FlyingMarioEnd = 2,
            FlyingMarioBeforeEnd = 3,
            FlyingMarioMiddle = 4,
            FlyingMarioAfterStart = 5,
            FlyingMarioStart = 6,
            SittingMario2 = 7,
            SittingMario1 = 8,
            JumpingMario = 9,
            UnkownAction3 = 10,
            WalkingMario3 = 11,
            WalkingMario2 = 12,
            WalkingMario1 = 13,
            StandingMario = 14
        }
        protected enum Directions
        {
            Left = 1,
            Right = 2
        }
        public MarioEntity()
        {
            _state = new IdleMarioState(this);
        }
        public override void Update()
        {
            
        }
        public override void ChangeState(MarioState marioState)
        {
            _state = marioState;
        }
        public void Jump()
        {
            ((MarioState)_state).Jump();
        }
    }
}
