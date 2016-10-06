using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;
using Microsoft.Xna.Framework;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class StandardState : MarioPowerUpState
    {
        public StandardState(MarioEntity entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Standard;
            MarioEntity.boundingBox.Width = 20;
            MarioEntity.boundingBox.Height = 20;
        }
        public override void ChangeToFire()
        {
            MarioPowerUpState fire = new FireState(marioEntity);
            marioEntity.ChangePowerUpState(fire);
            fire.Begin(this);

        }
        public override void ChangeToDead()
        {
            MarioPowerUpState dead = new DeadState(marioEntity);
            marioEntity.ChangePowerUpState(dead);
            dead.Begin(this);
        }
        public override void ChangeToSuper()
        {
            MarioPowerUpState super = new SuperState(marioEntity);
            marioEntity.ChangePowerUpState(super);
            super.Begin(this);
        }
    }
}
