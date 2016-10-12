using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.Blocks;

namespace MarioGame.States.BlockStates
{
    class BlockState : StandardState
    {
        protected BlockStateEnum bState;

        protected Block _BlockEntity;

        public BlockState(Block entity) : base(entity)
        {
            _BlockEntity = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
    }
}
