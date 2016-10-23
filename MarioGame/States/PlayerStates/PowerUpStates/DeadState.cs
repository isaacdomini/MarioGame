using MarioGame.Entities;

namespace MarioGame.States
{
    class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            powerUpState = MarioPowerUpStateEnum.Dead;
            _mario.isCollidable = false;
        }
    }
}
