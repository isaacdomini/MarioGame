using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;

namespace MarioGame.States
{
    public class BlockPowerUpState : PowerUpState
    {
        public BlockPowerUpState(IEntity entity) : base(entity)
        {
        }
    }
}
