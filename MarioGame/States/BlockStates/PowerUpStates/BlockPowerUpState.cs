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
        public BlockPowerUpStateEnum PowerUpStateEnum
        {
            get; protected set;
        }
        protected BlockPowerUpStateMachine StateMachine;
        protected Block Block;
        public BlockPowerUpState(Block entity, BlockPowerUpStateMachine stateMachine) : base(entity)
        {
            Block = entity;
            this.StateMachine = stateMachine;
        }

        public BlockPowerUpState(IEntity entity, BlockPowerUpStateEnum visibility) : base(entity)
        {
            PowerUpStateEnum = visibility;
        }
        public virtual void Reveal()
        {
            StateMachine.VisibleState.Begin(this);
        }
    }
}
