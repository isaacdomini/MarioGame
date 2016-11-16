using MarioGame.Entities;
using MarioGame.States.PlayerStates.PowerUpStates;

namespace MarioGame.States
{
    internal class FireStarState : BaseStarState
    {
        public FireStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.FireStar;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Mario.ChangePowerUpState(StateMachine.FireStarState);
        }
        public override void OnInvincibilityEnded()
        {
            StateMachine.FireState.Begin(this);
        }
        public override void DashOrThrowFireball()
        {
            Mario.ThrowFireball();
        }
    }
}
