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
        MarioPowerUpState firestar;
        MarioPowerUpState superstar;
        MarioPowerUpState standardstar;
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
        internal MarioPowerUpState SuperStarState
        {
            get { return superstar; }
        }
        internal MarioPowerUpState StandardStarState
        {
            get { return standardstar; }
        }
        internal MarioPowerUpState FireStarState
        {
            get { return firestar; }
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
            standardstar = new StandardStarState(_mario,this);
            firestar = new FireStarState(_mario, this);
            superstar = new SuperStarState(_mario, this);
        }
    }
}
