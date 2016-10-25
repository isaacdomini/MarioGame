using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    public abstract class State: IState
    {
        public IState _prevState { get; set; }
        protected IEntity _entity;
        public State(IEntity entity)
        {
            _entity = entity;
        }

        public virtual void Begin(IState prevState)
        {
            _prevState?.End(); //TODO: << make it so that we don't need this null check. Rather make it so that we can know for sure that _prevState is not null.
            _prevState = prevState;
        }
        public virtual void End() {}

        public virtual void UpdateEntity(GameTime gameTime)
        {
        }
    }
}
