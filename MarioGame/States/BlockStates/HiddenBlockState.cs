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
    class HiddenBlockState : BlockState
    {
        public HiddenBlockState(BlockEntity entity) : base(entity)
        {
            bState = BlockStates.HiddenBlock;
        }

        public override void Bump() {
            Standard();
        }
        public override void Standard() {
            BlockState standardState = new StandardBlockState(_BlockEntity);
            _BlockEntity.ChangeBrickState(standardState);
            standardState.Begin(this);
        }
        public override void Used() { }
        public override void Break() { }
    }
}
