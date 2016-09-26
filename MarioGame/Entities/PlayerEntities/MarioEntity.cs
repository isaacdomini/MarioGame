
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using MarioGame.States.PlayerStates.PowerUpStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
        protected enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            DeadMario = 1,
            SwimmingMarioEnd = 2,
            SwimmingMarioBeforeEnd = 3,
            SwimmingMarioMiddle = 4,
            SwimmingMarioAfterStart = 5,
            SwimmingMarioStart = 6,
            SittingMario2 = 7,
            SittingMario1 = 8,
            JumpingMario = 9,
            DashingMario = 10,
            RunningMario3 = 11,
            RunningMario2 = 12,
            RunningMario1 = 13,
            StandingMario = 14,
            HalfBigMario = 15
        }
        protected enum Directions
        {
            Left = 1,
            Right = 2
        }

        private ActionState aState;
        private PowerUpState pState;

        public MarioEntity() : base()
        {
            _state = aState;
            aState = new IdleMarioState(this);
            pState = new StandardState(this);
        }
        public override void Update()
        {
            
        }
        public void ChangeActionState(ActionState state)
        {
            aState = state;
        }
        public void ChangePowerUpState(PowerUpState state)
        {
            pState = state;
        }
        public void Jump()
        {
            ((ActionState)_state).Jump();
        }
        public void Crouch()
        {

        }
        public void WalkLeft()
        {

        }
        public void WalkRight()
        {

        }
        public void ChangeToFireState()
        {

        }
        public void ChangeToStandardState()
        {

        }
        public void ChangeToSuperState()
        {

        }
        public void ChangeToDeadState()
        {

        }
    }
}
