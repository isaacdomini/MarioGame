using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Sprites;
using MarioGame.Entities.BlockEntities;
using MarioGame.Sprites.BlockSprites;

namespace MarioGame.States.BlockStates
{
    class UsedBlockState : BlockState
    {
        public UsedBlockState(BlockEntity entity) : base(entity)
        {
            bState = BlockStates.UsedBlock;
        }

        public override void Bump(){}
        public override void Standard(){}
        public override void Used(){}
        public override void Break(){}
    }
}
