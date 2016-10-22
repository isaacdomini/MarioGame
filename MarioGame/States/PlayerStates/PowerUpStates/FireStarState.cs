using MarioGame.Entities;

namespace MarioGame.States
{
    class FireStarState : MarioPowerUpState
    {
        public FireStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.SuperStar;

        }

        public override void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }

    }
}
