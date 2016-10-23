using MarioGame.Entities;

namespace MarioGame.States
{
    class StandardState : MarioPowerUpState
    {
        public StandardState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Standard;
            _mario.isCollidable = true;
        }
        public override void ChangeToStar()
        {
            base.ChangeToStar();
            _mario.ChangePowerUpState(_stateMachine.StandardStarState);
        }
        public override void onHitByEnemy()
        {
            ChangeToDead();
        }
    }
}
