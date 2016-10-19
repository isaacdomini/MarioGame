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
            powerUpStateEnum = BlockPowerUpStateEnum.Hidden;
        }
        public override void Reveal()
        {
            stateMachine.VisibleState.Begin(this);
        }
    }
}
