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
        Block _block;
        BlockPowerUpState visible;
        BlockPowerUpState hidden;
        
        internal BlockPowerUpState HiddenState
        {
            get { return hidden; }
        }
        internal BlockPowerUpState VisibleState
        {
            get { return visible; }
        }

        public BlockPowerUpStateMachine(Block block)
        {
            _block = block;
            hidden = new HiddenState(_block, this);
            visible = new VisibleState(_block, this);
        }
    }
}
