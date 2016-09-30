using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.States.PlayerStates
{
    public class MarioPowerUpState : State
    {
        public MarioPowerUpStateEnum powerUpState
        {
            get; protected set;
        }
        protected MarioEntity marioEntity;
        public MarioPowerUpState(MarioEntity entity) : base(entity)
        {
            marioEntity = entity;
        }
        public void Begin(MarioPowerUpState prevState)
        {
            marioEntity.mSprite.changePowerUp(this);
            base.Begin(prevState);

        }
        public virtual void ChangeToSuper() {}
        public virtual void ChangeToStandard() {}
        public virtual void ChangeToFire() {}
        public virtual void ChangeToDead() {}
    }
}
