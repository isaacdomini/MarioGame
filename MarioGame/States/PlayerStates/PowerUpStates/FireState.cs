using MarioGame.Entities;

namespace MarioGame.States
{
    class FireState : MarioPowerUpState
    {
        public FireState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Fire;
            _mario.IsCollidable = true;
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            _mario.ChangePowerUpState(_stateMachine.FireStarState);
        }
        public override void onHitByEnemy()
        {
            ChangeToStandard();
            _mario.SetInvincible(1);
        }
    }
}
