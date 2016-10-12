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
    class BumpBlockState : BlockState
    {
        public BumpBlockState(Block entity) : base(entity)
        {
            bState = BlockStateEnum.BumpBlock;
        }

        public override void Bump(){}
        public override void Standard()
        {
            BlockState standardState = new StandardBlockState(_BlockEntity);
            _BlockEntity.ChangeBrickState(standardState);
            standardState.Begin(this);
        }
        public override void Used()
        {
            BlockState usedState = new UsedBlockState(_BlockEntity);
            _BlockEntity.ChangeBrickState(usedState);
            usedState.Begin(this);
        }
        public override void Break(){}
    }
}
