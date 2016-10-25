using MarioGame.Entities;
using MarioGame.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class MarioPowerUpStateMachine
    {
        internal MarioPowerUpState StandardState { get; }

        internal MarioPowerUpState SuperState { get; }

        internal MarioPowerUpState FireState { get; }

        internal MarioPowerUpState DeadState { get; }

        internal MarioPowerUpState SuperStarState { get; }

        internal MarioPowerUpState StandardStarState { get; }

        internal MarioPowerUpState FireStarState { get; }
        // TODO: Add this when needed
        //        MarioActionState star;
        public MarioPowerUpStateMachine(Mario mario)
        {
            StandardState = new StandardState(mario, this);
            SuperState = new SuperState(mario, this);
            FireState = new FireState(mario, this);
            DeadState = new DeadState(mario, this);
            StandardStarState = new StandardStarState(mario,this);
            FireStarState = new FireStarState(mario, this);
            SuperStarState = new SuperStarState(mario, this);
        }
    }
}
