using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Super;
        }
        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public override void ChangeToStandard()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
        }
        public override void ChangeToDead()
        {
            _mario.ChangePowerUpState(_stateMachine.DeadState);
        }
        public override void EnemyHit()
        {
            ChangeToStandard();
        }
    }
}
