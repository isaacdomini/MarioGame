using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Super;
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            Mario.ChangePowerUpState(StateMachine.SuperStarState);
        }
        public override void OnHitByEnemy()
        {
            ChangeToStandard();
            Mario.SetInvincible(1);
        }
    }
}
