using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class QuestionBlockState : BlockActionState
    {
        public QuestionBlockState(Block block, BlockActionStateMachine stateMachine) : base(block, stateMachine)
        {
            bState = BlockActionStateEnum.QuestionBlock;
        }
        public override void Begin(BlockActionState prevState)
        {
            block.ChangeBlockActionState(stateMachine.QuestionState);
        }
        public override void ChangeToUsed()
        {
            stateMachine.UsedState.Begin(this);
        }
    }
}

