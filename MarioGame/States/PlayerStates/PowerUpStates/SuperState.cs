using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Super;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Mario.ChangePowerUpState(StateMachine.SuperState);
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            StateMachine.SuperStarState.Begin(this);
        }
        public override void OnHitByEnemy()
        {
            ChangeToStandard();
            Mario.SetInvincible(1);
        }

        public override void DashOrThrowFireball()
        {
            Mario.Dash();
        }
    }
}
