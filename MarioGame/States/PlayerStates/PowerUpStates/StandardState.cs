using MarioGame.Entities;

namespace MarioGame.States
{
    class StandardState : MarioPowerUpState
    {
        public StandardState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Standard;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Mario.ChangePowerUpState(StateMachine.StandardState);
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            StateMachine.StandardStarState.Begin(this);
        }
        public override void OnHitByEnemy()
        {
            ChangeToDead();
        }
    }
}
