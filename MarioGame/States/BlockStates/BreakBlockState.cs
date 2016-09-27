using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.BlockEntities;
using MarioGame.States.BlockStates;

namespace MarioGame.States.BlockStates
{
    class BreakBlockState : BlockState
    {
        public BreakBlockState(BlockEntity entity) : base(entity)
        {
            bState = BlockStates.BreakingBlock;
        }

        public override void Bump() { }
        public override void Standard() { }
        public override void Used() { }
        public override void Break() { }
    }
}
