
using System;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    public class ActionState : State
    {
        
        protected MarioEntity marioEntity;
        public ActionState(MarioEntity entity) : base(entity)
        {
            marioEntity = (MarioEntity)_entity;
        }

        public virtual void Jump() {}

        public virtual void MoveRight() {}

        public virtual void MoveLeft() {}

        public virtual void Crouch() {}
    }
}
