using MarioGame.Entities;
using MarioGame.States.PlayerStates;
using MarioGame.Entities.EnemyEntities;


namespace MarioGame.States.EnemyStates
{
    public class KoopaActionState : ActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        public KoopaTroopa enemyEntity;
        public KoopaActionState(KoopaTroopa entity) : base(entity)
        {
            enemyEntity = entity;
        }

        public virtual void Begin(KoopaActionState prevState)
        {
            base.Begin(prevState);
            enemyEntity.eSprite.changeActionState(this);
        }
        public virtual void Halt()
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
