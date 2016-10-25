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
            BState = BlockActionStateEnum.QuestionBlock;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Block.ChangeBlockActionState(StateMachine.QuestionState);
        }
        public override void ChangeToUsed()
        {
            StateMachine.UsedState.Begin(this);
        }
    }
}

