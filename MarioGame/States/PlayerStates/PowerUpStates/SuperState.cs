using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(MarioEntity entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Super;
            entity.boundingBox.Width = 30;
            entity.boundingBox.Height = 40;
        }
        public override void ChangeToFire()
        {
            MarioPowerUpState fire = new FireState(marioEntity);
            marioEntity.ChangePowerUpState(fire);
            fire.Begin(this);

        }
        public override void ChangeToStandard()
        {
            MarioPowerUpState standard = new StandardState(marioEntity);
            marioEntity.ChangePowerUpState(standard);
            standard.Begin(this);
        }
        public override void ChangeToDead()
        {
            MarioPowerUpState dead = new DeadState(marioEntity);
            marioEntity.ChangePowerUpState(dead);
            dead.Begin(this);
        }
    }
}
