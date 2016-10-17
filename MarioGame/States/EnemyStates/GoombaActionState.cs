using MarioGame.Entities;
using MarioGame.States.PlayerStates;

namespace MarioGame.States.EnemyStates
{
    public class GoombaActionState : ActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        protected Goomba enemyEntity;
        public GoombaActionState(Goomba entity) : base(entity)
        {
            enemyEntity = entity;
        }

        public virtual void Begin(GoombaActionState prevState)
        {
            base.Begin(prevState);
            enemyEntity.eSprite.changeActionState(this);
        }
        public virtual void Halt()
        {
            GoombaActionState newState = new DeadGoombaState(enemyEntity);
            newState.setDirection(this.direction);
            enemyEntity.ChangeActionState(newState);
            enemyEntity.SetVelocityToIdle();
            newState.Begin(this);
        }

        public virtual void ChangeToDead(){ }
    }
}
