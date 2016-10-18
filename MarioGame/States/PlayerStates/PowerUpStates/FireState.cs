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
        public override void ChangeToStandard()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
        }
        public override void ChangeToDead()
        {
            _mario.ChangePowerUpState(_stateMachine.DeadState);
        }
        public override void ChangeToStar()
        {
            _mario.ChangePowerUpState(_stateMachine.FireStarState);
            Mario.invinsibleTimer = 625;

        }
        public override void ChangeToSuper()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperState);
        }
        public override void EnemyHit()
        {
            ChangeToStandard();
            Mario.invinsibleTimer = 70;
        }
    }
}
