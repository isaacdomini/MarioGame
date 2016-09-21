
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates
{
    public class MarioState : IState
    {
        protected MarioState _prevState;
        protected MarioEntity _entity;

        public MarioState() {}

        public MarioState(MarioEntity entity)
        {
            _entity = entity;
        }

        public virtual void Begin(MarioState prevState)
        {
            _prevState = prevState;
            _prevState.End();
        }

        public virtual void End() {}

        public virtual void Jump() {}

        public virtual void MoveRight() {}

        public virtual void MoveLeft() {}

        public virtual void Crouch() {}
    }
}
