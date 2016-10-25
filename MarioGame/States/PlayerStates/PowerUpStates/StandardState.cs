using MarioGame.Entities;

namespace MarioGame.States
{
    class StandardState : MarioPowerUpState
    {
        public StandardState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Standard;
            Mario.IsCollidable = true;
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            Mario.ChangePowerUpState(StateMachine.StandardStarState);
        }
        public override void OnHitByEnemy()
        {
            ChangeToDead();
        }
    }
}
