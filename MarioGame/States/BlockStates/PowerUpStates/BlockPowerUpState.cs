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
        public BlockPowerUpStateEnum powerUpStateEnum
        {
            get; private set;
        }
        public BlockPowerUpState(IEntity entity) : base(entity)
        {
            powerUpStateEnum = BlockPowerUpStateEnum.Hidden;
        }
        public BlockPowerUpState(IEntity entity, BlockPowerUpStateEnum visibility) : base(entity)
        {
            powerUpStateEnum = visibility;
        }
        public void Bump()
        {
            powerUpStateEnum = BlockPowerUpStateEnum.Visible;
        }
    }
}
