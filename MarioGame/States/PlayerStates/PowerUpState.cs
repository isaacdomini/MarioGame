﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates
{
    public class PowerUpState : State
    {
        protected MarioEntity marioEntity;
        public PowerUpState(MarioEntity entity) : base(entity)
        {
            marioEntity = entity;
        }
        public virtual void ChangeToSuper() {}
        public virtual void ChangeToStandard() {}
        public virtual void ChangeToFire() {}
        public virtual void ChangeToDead() {}
    }
}