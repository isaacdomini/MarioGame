using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class FireState : MarioPowerUpState
    {
        public FireState(Mario entity, PowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Fire;
            _mario.isCollidable = true;
        }
        public override void ChangeToStar()
        {
            _mario.ChangePowerUpState(_stateMachine.FireStarState);
            Mario.invinsibleTimer = 625;

        }
        public override void EnemyHit()
        {
            ChangeToStandard();
            Mario.invinsibleTimer = 70;
        }
    }
}
