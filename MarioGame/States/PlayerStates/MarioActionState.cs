using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates
{
    public class MarioActionState : ActionState
    {
        public MarioActionStateEnum actionState
        {
            get; protected set; //TODO: make this read from some shared enum with Sprites
        }
        protected MarioEntity marioEntity;

        public MarioActionState(MarioEntity entity) : base(entity)
        {
            marioEntity = entity;
        }

        public virtual void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
            marioEntity.mSprite.changeActionState(this);
        }
        public virtual void Jump() { }

        public virtual void MoveRight() { }

        public virtual void MoveLeft() { }

        public virtual void Crouch() { }
        public void Halt()
        {
            MarioActionState newState = new IdleMarioState(marioEntity);
            newState.setDirection(this.direction);
            marioEntity.ChangeActionState(newState);
            marioEntity.SetVelocityToIdle();
            newState.Begin(this);
        }
    }
}
