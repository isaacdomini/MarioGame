
using System;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;
using MarioGame.Sprites;

namespace MarioGame.States.BlockStates
{
    public class StandardState : State
    {
        public StandardState(IEntity entity) : base(entity)
        {

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }

        public virtual void Bump() { }

        public virtual void Standard() { }

        public virtual void Used() { }
        public virtual void Break() { }
    }
}
