using MarioGame.Entities;

namespace MarioGame.States
{
    class FireState : MarioPowerUpState
    {
        public FireState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Fire;
            _mario.isCollidable = true;
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            _mario.ChangePowerUpState(_stateMachine.FireStarState);
        }
        public override void onHitByEnemy()
        {
            ChangeToStandard();
            _mario.setInvincible(1);
        }
    }
}
