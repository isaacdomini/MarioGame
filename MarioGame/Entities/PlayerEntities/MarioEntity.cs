
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
        public Directions direction { get; protected set; }
        public enum Directions
        {
            Left = 1,
            Right = 2
        }
        protected void setDirection(Directions newDir)
        {
            direction = newDir;
        }


        private ActionState aState;
        private PowerUpState pState;

        public MarioEntity(Vector2 position) : base(position)
        {
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
            aState.Jump();
        }
        public void Crouch()
        {
            aState.Crouch();
        }
        public void WalkLeft()
        {
            aState.MoveLeft();
        }
        public void WalkRight()
        {
            aState.MoveRight();
        }
        public void ChangeToFireState()
        {
            pState.ChangeToFire();
        }
        public void ChangeToStandardState()
        {
            pState.ChangeToStandard();
        }
        public void ChangeToSuperState()
        {
            pState.ChangeToSuper();
        }
        public void ChangeToDeadState()
        {
            pState.ChangeToDead();
        }
    }
}
