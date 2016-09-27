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
    class MarioActionState : ActionState
    {
        protected MarioActionStates actionState; //TODO: make this read from some shared enum with Sprites

        protected MarioEntity marioEntity;

        public MarioActionState(MarioEntity entity) : base(entity)
        {
            marioEntity = entity;
        }

        public void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
            marioEntity.mSprite.changeFrameSet(actionState); //TODO: make it so we don't have to do this casts
        }
    }
}
