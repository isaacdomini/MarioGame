using MarioGame.Entities;
using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.BlockStates.ActionStates
{
    public class BumpingState : BlockActionState
    {
        public BumpingState(Block entity, BlockActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            BState = BlockActionStateEnum.Bumping;

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            ((Block)Entity).ChangeActionState(StateMachine.BumpingState);
            //Entities.Entity.Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.bump.GetHashCode()]);
        }
        public override void EndState()
        {
            base.EndState();
            PrevState = this;
        }
        public override void ChangeToUsed()
        {
            this.EndState();
            StateMachine.UsedState.Begin(this);
        }
        public override void ChangeToStandard()
        {
            this.EndState();
            StateMachine.StandardState.Begin(this);
        }
    }
}
