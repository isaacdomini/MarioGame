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
        public IState PrevState { get; protected set; }
        private IEntity _entity;
        protected IEntity Entity => _entity;

        internal State(IEntity entity)
        {
            _entity = entity;
        }

        public virtual void Begin(IState prevState)
        {
            prevState.EndState();
            PrevState = prevState;
        }
        public virtual void EndState() {}

        public virtual void UpdateEntity(int elapsedMilliseconds)
        {
        }
    }
}
