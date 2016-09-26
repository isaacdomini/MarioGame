using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class DeadState : PowerUpState
    {
        public DeadState(MarioEntity entity) : base(entity)
        {
        }
        public override void ChangeToFire()
        {
            PowerUpState fire = new FireState(_entity);
            marioEntity.ChangePowerUpState(fire);
                        
        }
        public override void ChangeToStandard()
        {
            base.ChangeToStandard();
        }
        public override void ChangeToSuper()
        {
            base.ChangeToSuper();
        }
    }
}
