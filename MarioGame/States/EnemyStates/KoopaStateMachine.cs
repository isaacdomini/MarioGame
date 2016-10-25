﻿using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class KoopaStateMachine
    {
        KoopaTroopa _koopa;
        KoopaActionState dead;
        KoopaBouncingState bouncing;
        KoopaActionState walking;
        internal KoopaActionState DeadState
        {
            get { return dead; }
        }
        internal KoopaActionState WalkState
        {
            get { return walking; }
        }
        internal KoopaBouncingState BouncingState
        {
            get { return bouncing; }
        }
        public KoopaStateMachine(KoopaTroopa koopa)
        {
            _koopa = koopa;
            dead = new KoopaDeadState(_koopa, this);
            walking = new KoopaWalkingState(_koopa, this);
            bouncing = new KoopaBouncingState(_koopa, this);
        }

    }
}
