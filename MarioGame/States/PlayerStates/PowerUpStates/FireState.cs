using MarioGame.Entities;

namespace MarioGame.States
{
    internal class FireState : MarioPowerUpState
    {
        public FireState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Fire;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Mario.ChangePowerUpState(StateMachine.FireState);
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            StateMachine.FireStarState.Begin(this);
        }
        public override void OnHitByEnemy()
        {
            ChangeToStandard();
            Mario.SetInvincible(1);
        }
        public override void DashOrThrowFireball()
        {
            Mario.ThrowFireball();
        }
    }
}
