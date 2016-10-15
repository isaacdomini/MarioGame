using MarioGame.Entities.EnemyEntities;
using MarioGame.States.PlayerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.EnemyStates
{
    public class GoombaActionState : ActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        protected GoombaEntity enemyEntity;
        public GoombaActionState(GoombaEntity entity) : base(entity)
        {
            enemyEntity = entity;
        }

        public virtual void Begin(GoombaActionState prevState)
        {
            base.Begin(prevState);
            //enemyEntity.eSprite.changeActionState(this);
        }
        public void Halt()
        {
            GoombaActionState newState = new DeadGoombaState(enemyEntity);
            newState.setDirection(this.direction);
            //enemyEntity.ChangeActionState(newState);
            //enemyEntity.SetVelocityToIdle();
            newState.Begin(this);
        }

        public virtual void ChangeToDead(){ }
    }
}
