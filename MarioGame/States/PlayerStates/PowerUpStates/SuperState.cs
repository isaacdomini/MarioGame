using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Super;
            _mario.isCollidable = true;
        }
        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public override void ChangeToStar()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperStarState);
            Mario.invinsibleTimer = 625;

        }
        public override void ChangeToStandard()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
        }
        public override void ChangeToDead()
        {
            _mario.ChangePowerUpState(_stateMachine.DeadState);
        }
        public override void EnemyHit()
        {
            ChangeToStandard();
            Mario.invinsibleTimer = 70;
        }
    }
}
