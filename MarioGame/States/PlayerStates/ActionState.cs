using MarioGame.Entities;

namespace MarioGame.States
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
