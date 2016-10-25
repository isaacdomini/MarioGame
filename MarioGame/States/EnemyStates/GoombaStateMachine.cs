using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class GoombaStateMachine
    {
        Goomba _goomba;
        GoombaActionState dead;
        GoombaActionState walking;
        internal GoombaActionState DeadGoomba
        {
            get { return dead; }           
        }
        internal GoombaActionState WalkingGoomba
        {
            get { return walking; }
        }

        public GoombaStateMachine(Goomba goomba)
        {
            _goomba = goomba;
            dead = new GoombaDeadState(_goomba, this);
            walking = new GoombaWalkingState(_goomba, this);

        }
    }
}
