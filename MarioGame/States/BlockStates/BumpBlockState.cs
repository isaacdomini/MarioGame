using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.BlockEntities;
using MarioGame.Sprites.BlockSprite;

namespace MarioGame.States.BlockStates
{
    class BumpBlockState : BlockState
    {
        public BumpBlockState(BlockEntity entity) : base(entity)
        {
            bState = BlockStates.BumpBlock;
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
