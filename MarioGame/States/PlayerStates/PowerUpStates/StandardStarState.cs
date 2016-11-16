using MarioGame.Entities;
using MarioGame.States.PlayerStates.PowerUpStates;

namespace MarioGame.States
{
    class StandardStarState : BaseStarState
    {
        public StandardStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.StandardStar;
        }
        public override void Begin(IState prevState)
        {
            Mario.ChangePowerUpState(StateMachine.StandardStarState);
        }
        public override void OnInvincibilityEnded()
        {
            StateMachine.StandardState.Begin(this);
        }
    }
}
