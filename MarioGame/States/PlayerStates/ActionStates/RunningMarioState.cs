using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates
{
    class RunningMarioState  : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public RunningMarioState(Mario entity) : base(entity)
        {
            actionState = MarioActionStateEnum.Running;
        }
    }
}
