using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class FireState : MarioPowerUpState
    {
        public FireState(MarioEntity entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Fire;
            entity.boundingBox.Width = 30;
            entity.boundingBox.Height = 40;
        }
        public override void ChangeToDead()
        {
            ChangeToStandard();

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
