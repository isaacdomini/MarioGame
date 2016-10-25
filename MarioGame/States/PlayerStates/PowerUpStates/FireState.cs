using MarioGame.Entities;

namespace MarioGame.States
{
    internal class FireState : MarioPowerUpState
    {
        public FireState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Fire;
            Mario.IsCollidable = true;
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            Mario.ChangePowerUpState(StateMachine.FireStarState);
        }
        public override void OnHitByEnemy()
        {
            ChangeToStandard();
            Mario.SetInvincible(1);
        }
    }
}
