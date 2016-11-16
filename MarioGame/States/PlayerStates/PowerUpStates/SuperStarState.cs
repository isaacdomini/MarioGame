using MarioGame.Entities;
using MarioGame.States.PlayerStates.PowerUpStates;

namespace MarioGame.States
{
    class SuperStarState : BaseStarState
    {
        public SuperStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.SuperStar;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Mario.ChangePowerUpState(StateMachine.SuperStarState);
        }
        public override void OnInvincibilityEnded()
        {
            StateMachine.StandardState.Begin(this);
        }
    }
}
