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
            _mario.ChangePowerUpState(_stateMachine.StandardStarState);
            Mario.invincibleTimer = 625;
        }
        public override void EnemyHit()
        {
            ChangeToDead();
        }
    }
}
