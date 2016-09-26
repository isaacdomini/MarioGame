
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using MarioGame.States.PlayerStates.PowerUpStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
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
