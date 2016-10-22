using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperStarState : MarioPowerUpState
    {
        public SuperStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.SuperStar;

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
        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
    }
}
