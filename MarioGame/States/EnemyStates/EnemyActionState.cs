using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;

namespace MarioGame.States.EnemyStates
{
    public class EnemyActionState : ActionState
    {
        public EnemyActionState(IEntity entity) : base(entity)
        {
        }
    }
}
