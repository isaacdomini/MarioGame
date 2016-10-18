using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Dead;
        }
        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public override void ChangeToStandard()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
        }
        public override void ChangeToSuper()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperState);
        }
    }
}
