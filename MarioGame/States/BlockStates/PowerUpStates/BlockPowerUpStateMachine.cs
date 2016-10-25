using MarioGame.Entities;
using MarioGame.States.BlockStates.PowerUpStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class BlockPowerUpStateMachine
    {
        internal HiddenState HiddenState { get; }

        internal VisibleState VisibleState { get; }

        public BlockPowerUpStateMachine(Block block)
        {
            var block1 = block;
            HiddenState = new HiddenState(block1, this);
            VisibleState = new VisibleState(block1, this);
        }
    }
}
