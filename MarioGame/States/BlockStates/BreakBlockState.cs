using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.Blocks;
using MarioGame.States.BlockStates;

namespace MarioGame.States.BlockStates
{
    class BreakBlockState : BlockState
    {
        public BreakBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.BreakingBlock;
        }

        public override void Bump() { }
        public override void Standard() { }
        public override void Used() { }
        public override void Break() { }
    }
}
