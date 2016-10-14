using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates
{
    public class MarioPowerUpState : State
    {
        public MarioPowerUpStateEnum powerUpState
        {
            get; protected set;
        }
        protected Mario mario;
        public MarioPowerUpState(Mario entity) : base(entity)
        {
            mario = entity;
        }
        public void Begin(MarioPowerUpState prevState)
        {
            mario.mSprite.changePowerUp(this);
            base.Begin(prevState);

        }
        public virtual void ChangeToSuper() {}
        public virtual void ChangeToStandard() {}
        public virtual void ChangeToFire() {}
        public virtual void ChangeToDead() {}
    }
}
