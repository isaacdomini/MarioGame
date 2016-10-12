using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.Blocks;
using MarioGame.Sprites.BlockSprites;

namespace MarioGame.States.BlockStates
{
    class StandardBlockState : BlockState
    {
        public StandardBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.StandardBlock;
        }

        public override void Bump()
        {
            BlockState bumpState = new BumpBlockState(_BlockEntity);
            _BlockEntity.ChangeBrickState(bumpState);
            bumpState.Begin(this);

        }
        public override void Standard(){}
        public override void Used(){}
        public override void Break()
        {
            BlockState breakState = new BreakBlockState(_BlockEntity);
            _BlockEntity.ChangeBrickState(breakState);
            breakState.Begin(this);
        }
    }
}
