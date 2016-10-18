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
        Mario _mario;

        MarioPowerUpState standard;
        MarioPowerUpState super;
        MarioPowerUpState fire;
        MarioPowerUpState dead;
        internal MarioPowerUpState StandardState
        {
            get { return standard; }
        }
        internal MarioPowerUpState SuperState
        {
            get { return super; }
        }
        internal MarioPowerUpState FireState
        {
            get { return fire; }
        }
        internal MarioPowerUpState DeadState
        {
            get { return dead; }
        }
        // TODO: Add this when needed
        //        MarioActionState star;
        public MarioPowerUpStateMachine(Mario mario)
        {
            _mario = mario;
            standard = new StandardState(_mario, this);
            super = new SuperState(_mario, this);
            fire = new FireState(_mario, this);
            dead = new DeadState(_mario, this);

        }
    }
}
