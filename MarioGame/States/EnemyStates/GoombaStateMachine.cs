using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.EnemyStates
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
            dead = new DeadGoombaState(_goomba, this);
            walking = new WalkingGoombaState(_goomba, this);

        }
    }
}
