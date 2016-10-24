﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework;
using MarioGame.Core;

namespace MarioGame.States
{
    public class KoopaBouncingState : KoopaActionState

    {
        public KoopaBouncingState(KoopaTroopa entity, KoopaStateMachine stateMachine) : base(entity, stateMachine)
        {
            enemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            koopa.ChangeActionState(_stateMachine.BouncingState);
            koopa.SetShellVelocityToMoving();
        }
        public override void JumpedOn(Sides side)
        {
            base.JumpedOn(side);
            ChangeToDead();
        }
    }
}
