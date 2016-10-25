using MarioGame.Entities;

namespace MarioGame.States
{
    internal class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Dead;
            Mario.IsCollidable = false;
        }

        public override void Begin(MarioPowerUpState prevState)
        {
            Mario.ChangePowerUpState(StateMachine.DeadState);
            Mario.SetVelocityToIdle();
        }
    }
}
