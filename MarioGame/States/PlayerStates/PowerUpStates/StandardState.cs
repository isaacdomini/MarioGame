using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class StandardState : MarioPowerUpState
    {
        public StandardState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Standard;
        }
        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public override void ChangeToDead()
        {
            _mario.ChangePowerUpState(_stateMachine.DeadState);
        }
        public override void ChangeToSuper()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperState);
        }
        public override void EnemyHit()
        {
            ChangeToDead();
        }
    }
}
