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
            BState = BlockActionStateEnum.BrickBlock;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Block.ChangeBlockActionState(StateMachine.BrickState);
        }
        public override void ChangeToUsed()
        {
            StateMachine.UsedState.Begin(this);
        }
    }
}
