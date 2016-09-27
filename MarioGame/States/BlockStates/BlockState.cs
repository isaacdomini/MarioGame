using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.BlockEntities;

namespace MarioGame.States.BlockStates
{
    class BlockState : StandardState
    {
        protected BlockStates bState;

        protected BlockEntity _BlockEntity;

        public BlockState(BlockEntity entity) : base(entity)
        {
            _BlockEntity = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
    }
}
