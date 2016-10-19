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
        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public override void ChangeToStar()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardStarState);
            Mario.invincibleTiber = 625;
        }
        public override void ChangeToDead()
        {
            _mario.ChangePowerUpState(_stateMachine.DeadState);
        }
        public override void ChangeToSuper()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperState);
        }
        public override void EnemyHit()
        {
            ChangeToDead();
        }
    }
}
