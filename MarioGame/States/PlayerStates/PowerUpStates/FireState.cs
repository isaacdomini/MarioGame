using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class FireState : MarioPowerUpState
    {
        public FireState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Fire;
        }
        public override void ChangeToStandard()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
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
            ChangeToStandard();
        }
    }
}
