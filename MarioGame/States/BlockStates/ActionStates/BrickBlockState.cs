using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class BrickBlockState : BlockActionState
    {
        public BrickBlockState(Block block, BlockActionStateMachine stateMachine) : base(block, stateMachine)
        {
            bState = BlockActionStateEnum.BrickBlock;
        }
        public override void ChangeToUsed()
        {
            stateMachine.UsedState.Begin(this);
        }
    }
}
