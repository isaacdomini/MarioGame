using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    public class ActionState : State
    {
        public ActionState(IEntity entity) : base(entity)
        {

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }


    }
}
