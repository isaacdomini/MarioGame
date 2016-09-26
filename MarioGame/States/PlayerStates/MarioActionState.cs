using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;

namespace MarioGame.States.PlayerStates
{
    class MarioActionState : ActionState
    {
        protected MarioActionStates actionState; //TODO: make this read from some shared enum with Sprites

        public MarioActionState(IEntity entity) : base(entity)
        {
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((AnimatedSprite)((Entity)_entity)._sprite).changeFrameSet(actionState); //TODO: make it so we don't have to do this casts
        }
    }
}
