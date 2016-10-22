using MarioGame.Entities;

namespace MarioGame.States
{
    class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Dead;
            _mario.isCollidable = false;
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
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
