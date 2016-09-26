
using System;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;
using MarioGame.Sprites;

namespace MarioGame.States.PlayerStates
{
    public class ActionState : State
    {
        public Directions direction { get; protected set; }
        public enum Directions
        {
            Left = 1,
            Right = 2
        }
        protected void setDirection(Directions newDir)
        {
            direction = newDir;
        }
        protected IEntity marioEntity;
        public ActionState(IEntity entity) : base(entity)
        {

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }

        public virtual void Jump() {}

        public virtual void MoveRight() {}

        public virtual void MoveLeft() {}

        public virtual void Crouch() {}
    }
}
