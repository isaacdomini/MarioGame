using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class IdleMarioState : MarioState
    {
        public IdleMarioState(IEntity entity) : base(entity)
        {
            
        }
    }
}
