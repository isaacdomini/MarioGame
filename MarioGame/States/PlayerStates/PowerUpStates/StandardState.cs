using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class StandardState : PowerUpState
    {
        public StandardState(MarioEntity entity) : base(entity)
        {
            powerUpState = MarioPowerUpStates.Standard;
        }
        public override void ChangeToFire()
        {
            PowerUpState fire = new FireState(marioEntity);
            marioEntity.ChangePowerUpState(fire);
            fire.Begin(this);

        }
        public override void ChangeToDead()
        {
            PowerUpState dead = new DeadState(marioEntity);
            marioEntity.ChangePowerUpState(dead);
            dead.Begin(this);
        }
        public override void ChangeToSuper()
        {
            PowerUpState super = new SuperState(marioEntity);
            marioEntity.ChangePowerUpState(super);
            super.Begin(this);
        }
    }
}
