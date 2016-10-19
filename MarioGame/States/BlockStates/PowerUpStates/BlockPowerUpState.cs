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
            get; protected set;
        }
        protected BlockPowerUpStateMachine stateMachine;
        protected Block block;
        public BlockPowerUpState(Block entity, BlockPowerUpStateMachine stateMachine) : base(entity)
        {
            block = entity;
            this.stateMachine = stateMachine;
        }

        public BlockPowerUpState(IEntity entity, BlockPowerUpStateEnum visibility) : base(entity)
        {
            powerUpStateEnum = visibility;
        }
        public virtual void Reveal()
        {
            stateMachine.VisibleState.Begin(this);
        }
    }
}
