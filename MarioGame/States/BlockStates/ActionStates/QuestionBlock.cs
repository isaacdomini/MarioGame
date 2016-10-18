using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class QuestionBlockState : BlockState
    {
        public QuestionBlockState(Block block, BlockActionStateMachine stateMachine) : base(block, stateMachine)
        {

        }
        public override void ChangeToUsed()
        {
            _stateMachine.UsedState.Begin(this);
        }
    }
}

