using MarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public class EnemyPlayerStateMachine
    {
        internal EnemyPlayerActionState DeadState { get; }
        internal EnemyPlayerActionState WalkingState { get; }

        public EnemyPlayerStateMachine(EnemyPlayer enemy)
        {
            DeadState = new EnemyPlayerDeadState(enemy, this);
            WalkingState = new EnemyPlayerWalkingState(enemy, this);

        }
    }
}
