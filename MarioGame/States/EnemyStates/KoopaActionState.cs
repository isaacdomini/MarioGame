using MarioGame.Entities.EnemyEntities;
using MarioGame.States.PlayerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.EnemyStates
{
    public class KoopaActionState : ActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        protected KoopaTroopaEntity enemyEntity;
        public KoopaActionState(KoopaTroopaEntity entity) : base(entity)
        {
            enemyEntity = entity;
        }

        public virtual void Begin(KoopaActionState prevState)
        {
            base.Begin(prevState);
            enemyEntity.eSprite.changeActionState(this);
        }
        public void Halt()
        {
            KoopaActionState newState = new DeadKoopaState(enemyEntity);
            newState.setDirection(this.direction);
            enemyEntity.ChangeActionState(newState);
            enemyEntity.SetVelocityToIdle();
            newState.Begin(this);
        }

        public virtual void ChangeToDead(){ }
    }
}
