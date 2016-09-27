using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class SuperState : PowerUpState
    {
        public SuperState(MarioEntity entity) : base(entity)
        {
            powerUpState = MarioPowerUpStates.Super;
        }
        public override void ChangeToFire()
        {
            PowerUpState fire = new FireState(marioEntity);
            marioEntity.ChangePowerUpState(fire);
            fire.Begin(this);

        }
        public override void ChangeToStandard()
        {
            PowerUpState standard = new StandardState(marioEntity);
            marioEntity.ChangePowerUpState(standard);
            standard.Begin(this);
        }
        public override void ChangeToDead()
        {
            PowerUpState dead = new DeadState(marioEntity);
            marioEntity.ChangePowerUpState(dead);
            dead.Begin(this);
        }
    }
}
