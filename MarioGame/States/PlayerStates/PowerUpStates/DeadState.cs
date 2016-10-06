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
    class DeadState : MarioPowerUpState
    {
        public DeadState(MarioEntity entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Dead;
            entity.boundingBox.Width = 20;
            entity.boundingBox.Height = 20;

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
        public override void ChangeToSuper()
        {
            MarioPowerUpState super = new SuperState(marioEntity);
            marioEntity.ChangePowerUpState(super);
            super.Begin(this);
        }
    }
}
