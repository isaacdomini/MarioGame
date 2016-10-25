using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.BlockStates.PowerUpStates
{
    public class HiddenState : BlockPowerUpState
    {
        public HiddenState(Block block, BlockPowerUpStateMachine stateMachine) : base(block, stateMachine)
        {
            PowerUpStateEnum = BlockPowerUpStateEnum.Hidden;
        }
        public override void Begin(IState prevState)
        {
            Block.ChangeBlockPowerUpState(StateMachine.HiddenState);
        }
        public override void Reveal()
        {
            StateMachine.VisibleState.Begin(this);
        }
    }
}
