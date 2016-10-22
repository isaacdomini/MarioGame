using MarioGame.Entities;

namespace MarioGame.States
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Super;
            _mario.isCollidable = true;
        }
        public override void ChangeToStar()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperStarState);
            Mario.invincibleTimer = 625;

        }
        public override void EnemyHit()
        {
            ChangeToStandard();
            Mario.invincibleTimer = 70;
        }
    }
}
