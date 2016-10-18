using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class BrickBlockState : BlockState
    {
        public BrickBlockState(BrickBlock block, BlockStateMachine stateMachine) : base(block, stateMachine)
        {

        }
        public override void ChangeToUsed()
        {
            _stateMachine.UsedState.Begin(this);
        }
    }
}
