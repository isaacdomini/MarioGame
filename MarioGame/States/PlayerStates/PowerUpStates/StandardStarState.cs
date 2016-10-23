using MarioGame.Entities;

namespace MarioGame.States
{
    class StandardStarState : MarioPowerUpState
    {
        public StandardStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.StandardStar;
        }
        public override void onInvincibilityEnded()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
        }
    }
}
