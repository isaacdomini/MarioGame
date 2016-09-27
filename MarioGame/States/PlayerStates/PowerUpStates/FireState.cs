using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class FireState : PowerUpState
    {
        public FireState(MarioEntity entity) : base(entity)
        {
        }
        public override void ChangeToDead()
        {
            PowerUpState dead = new DeadState(marioEntity);
            marioEntity.ChangePowerUpState(dead);
            dead.Begin(this);

        }
        public override void ChangeToStandard()
        {
            PowerUpState standard = new StandardState(marioEntity);
            marioEntity.ChangePowerUpState(standard);
            standard.Begin(this);
        }
        public override void ChangeToSuper()
        {
            PowerUpState super = new SuperState(marioEntity);
            marioEntity.ChangePowerUpState(super);
            super.Begin(this);
        }
    }
}
