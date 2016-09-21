
using System;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    public class MarioState : State
    {
        public MarioState(IEntity entity) : base(entity)
        {
 
        }

        public virtual void End() {}

        public virtual void Jump() {}

        public virtual void MoveRight() {}

        public virtual void MoveLeft() {}

        public virtual void Crouch() {}
    }
}
