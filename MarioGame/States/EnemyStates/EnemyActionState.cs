﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Core;

namespace MarioGame.States
{
    public class EnemyActionState : ActionState
    {
        public EnemyActionState(IEntity entity) : base(entity)
        {
        }
       
        public virtual void HitBlock()
        {
            ((Entity)Entity).FlipHorizontalVelocity();
        }
        public virtual void Halt()
        {
            ChangeToDead();
        }
        public virtual void JumpedOn(Sides side)
        {
            ChangeToDead();
        }
        public virtual void ChangeToDead() { }
    }
}
